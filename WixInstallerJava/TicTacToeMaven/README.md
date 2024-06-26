# TicTacToeMaven

This is a Java/Mavenized version of the popular classic game Tic-Tac-Toe. It features a new, adjustable AI for the computer that let's you choose whether your (computer) opponent will be easy, smart or genius. At genius level you won't be able to beat the computer unless you start by selecting the center cell, which gives you a statistical advantage, but it can still beat you if you're not careful.

Any human player ("X") can challenge the computer ("0") to a game. Currently there is no way to change player ID or to use the game to challenge another human player.

The modular object design follows the MVC design pattern and the Single Responsibility Principle. Notice that the GameEngine (Controller), Rail and Tile classes (Model) are not dependent on the GameWindow (View / GUI) or startup classes. That means that the game can use different pluggable UI classes without modifying the Controller or Model classes.

## Prerequisite:

Apache Maven
JRE

## How to build

To compile use:
mvn compile

To build:
mvn package

Output will be gaenerate to folder "target" => file "TicTacToe-1.1.0.jar"
