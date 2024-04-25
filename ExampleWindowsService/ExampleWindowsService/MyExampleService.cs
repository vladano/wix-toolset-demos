using System;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Reflection.Emit;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using static ExampleWindowsService.Calculator;

namespace ExampleWindowsService
{
    /// <summary>
    /// Class that defines a service. In this case, calls the calculation of a Factorial asynchronously.
    /// </summary>
    public partial class MyExampleService : ServiceBase
    {
        private int argumentFactorialOperation = 100;
        //private string resultFilePath = "C:\\result.txt";
        private string resultFilePath = "C:\\temp\\result.txt";

        /// <summary>
        /// Constructor. Initializes the needed components for the service to run.
        /// </summary>
        public MyExampleService()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            File.AppendAllText(resultFilePath, $"\nCalculating the factorial of: {argumentFactorialOperation}\n");
        }

        /// <summary>
        /// Initializes the event handlers of the backgroundWorkers in this class.
        /// </summary>
        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);

        }

        /// <summary>
        /// Triggered when the service starts. It can use <paramref name="args"/> if provided.
        /// </summary>
        /// <param name="args"></param>
        protected override async void OnStart(string[] args)
        {
             backgroundWorker1.RunWorkerAsync(argumentFactorialOperation);
        }

        /// <summary>
        /// Triggered when the service stops.
        /// </summary>
        protected override void OnStop()
        {
            backgroundWorker1.CancelAsync();
        }

        /// <summary>
        /// When the backgroundworker is requested to run, the corresponding event handler defined in (<see cref="InitializeBackgroundWorker"/>) triggers this method. <br/>
        /// The method calculates the factorial of a number passed as the <paramref name="e"/> argument.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender,
            DoWorkEventArgs e)
        {
            try
            {
                // Get the BackgroundWorker that raised this event.
                BackgroundWorker worker = sender as BackgroundWorker;

                int argument = (int)(e.Argument);

                // Assign the result of the computation
                // to the Result property of the DoWorkEventArgs
                // object. This is will be available to the 
                // RunWorkerCompleted eventhandler.
                e.Result = CalculateFactorial(argument, worker, e);
            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(Path.GetTempPath(), "CalculatorErrorLogs.txt"), $"There was an error in execution. Details:\n{ex.Message}\n{ex.StackTrace}");
                e.Cancel = true;
            }
            
        }   

        /// <summary>
        /// When the backgroundworker finishes its execution, the corresponding event handler defined in (<see cref="InitializeBackgroundWorker"/>) triggers this method. <br/>
        /// The method reports the result of the background worker operation passed as the <paramref name="e"/> argument.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string resultMessage = $"The operation result is: {e.Result}";
            WriteLineToFileSafely(resultFilePath, resultMessage);
        }

        /// <summary>
        /// When the backgroundworker raises an event of progress changed, the corresponding event handler defined in (<see cref="InitializeBackgroundWorker"/>) triggers this method. <br/>
        /// The method reports the progress of the background worker operation passed as the <paramref name="e"/> argument.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            string progressMessage = $"Operation progress is: {e.ProgressPercentage}%";
            WriteLineToFileSafely(resultFilePath, progressMessage);
        }

        /// <summary>
        /// Method that writes <paramref name="textToWrite"/> to <paramref name="filePath"/> safely, and can handle writing even when the file is locked by another process.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="textToWrite"></param>
        private void WriteLineToFileSafely(string filePath, string textToWrite)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(textToWrite);
            }
        }
    }
}
