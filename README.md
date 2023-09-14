# Quiz Game App
Console app for a Quiz game with questions and answers. 
## Description
<p>
The Quiz console app can can help with answering questions of your choice one by one, just like in a quiz game.<br>
The app defines a winner by comparing the overall score of each player.<br>
Written in C# for Windows.<br>
</p>
<p>
The app consistf of 3 main parts: User Interface Class and ConsoleUIHelper class, Program class and QuizLibrary.<br>
All the data and data related logic contained in the QuizLibrary whereas all the User interface and user input related logic located in the UserInterface class. Program class contains the most high level logic of the execution of the program.  
</p>


### **User interface screenshots**

<details>
  <summary><i>show/hide</i></summary>

<img src="welcome.png" alt="welcome.png" height="400"> <img src="mainmenu.png" alt="mainmenu.png" height="400">

</details>

## Quiz Library
#### The Quiz Library provides the following functionality:
- constains Classes to store user's data and questions with corresponding answers for the Quiz game.
- provides a question
- answer check
- score calculation within a game round
- total score calculation
- saves/loads user's data and question/answer data to the corresponding CSV files

## Tests
All the Quiz library classes have full unit test coverage with MSTest.
