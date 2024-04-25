using System;
using System.IO;
using System.ComponentModel;
using System.Numerics;
using System.Diagnostics;

namespace ExampleWindowsService
{
    /// <summary>
    /// Static class that holds declarations of various math methods. 
    /// </summary>
    internal static class Calculator
    {

        public static int factorialCalculationHighestPercentageReached = 0;
        public enum ErrorCode : Int32
        {
            ErrorOperationCancelled = -1,
            ErrorWrongInputArgument = -2,
            ErrorExceptionOccurred = -3,
        }

        /// <summary>
        /// Performs calculation of the factorial of <paramref name="number"/>, when called from a backgroundworker <paramref name="worker"/>. <br/>
        /// Supports cancellation via DoWorkEventArgs <paramref name="e"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        /// <returns>The factorial of <paramref name="number"/>. If execution fails or factorial is not defined for <paramref name="number"/>, it returns a member of <see cref="ErrorCode"/> </returns>
        internal static BigInteger CalculateFactorial(BigInteger number, BackgroundWorker worker, DoWorkEventArgs e)
        {
            
            try
            {
                
                //Cancellation and input validation
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    File.AppendAllText(Path.Combine(Path.GetTempPath(), "CalculatorErrorLogs.txt"),
                                       $"There was an error in execution. The task was cancelled externally.");
                    return (int)ErrorCode.ErrorOperationCancelled;
                }

                if (number < 0)
                {
                    File.AppendAllText(Path.Combine(Path.GetTempPath(),
                                                    "CalculatorErrorLogs.txt"), $"There was an error in execution. Wrong input argument \"{number}\".");
                    return (int)ErrorCode.ErrorWrongInputArgument;
                }

                //calculation of the factorial of number
                else
                {
                    // Report progress as a percentage of the total task.
                    int percentComplete = (int)(100 / number);
                    if (percentComplete > factorialCalculationHighestPercentageReached)
                    {
                        factorialCalculationHighestPercentageReached = percentComplete;
                        worker.ReportProgress(percentComplete);
                    }
                    //Calculate the factorial of number
                    if (number <= 1)
                    {
                        return number;
                    }
                    else
                    {
                        return number * CalculateFactorial(number - 1, worker, e);
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(Path.GetTempPath(),"CalculatorErrorLogs.txt"),$"There was an error in execution. Details:\n{ex.Message}\n{ex.StackTrace}");
                return (int)ErrorCode.ErrorExceptionOccurred;
            }
        }      
    }
}
