# Lessons Plans

## Rules of the Road
- We're moving fast
- Any amount of behind is too far behind, if I'm moving on and you're still working then **TELL ME**
- There is no such thing as a stupid question, if you don't know then **ASK**
- There will be homework each session for you to practice on.


## Lesson 1
- Open the terminal:
  - `cd c:\`
  - `mkdir source`
  - `cd source`
- Create a new console application
  - `dotnet new console -n Sork`
  - `cd Sork`
- Initialize the GIT repository
  - `git init`
- Ensure you're on the `main` branch
  - `git checkout main`
- Open Cursor in the current directory
  - `cursor .`
- Add the .gitignore file
  - Create a new file named `.gitignore`
  - Open browser to `gitignore.io`
  - Search for `VisualStudioCode` and `Dotnetcore`
  - Copy the content and paste it into the `.gitignore` file
- Add ignore file to GIT
  - `git add .gitignore`
  - `git commit -m "Add .gitignore file"`
- Modify the Program.cs file to use `static void Main(string[] args)` and print "Hello, World!"
- Run the application
  - `dotnet run`
- Commit the changes to GIT
  - `git add .`
  - `git commit -m "Modify Program.cs file"`
- Create the GitHub repository
  - Open browser to `GitHub`
  - Create a new repository named `Sork`
  - Copy the remote repository URL
- Add the remote repository to the local repository
  - `git remote add origin https://github.com/your-username/Sork.git`
- Push the changes to the remote repository
  - `git push -u origin main`
- Create a prompt loop
  - `do { } while (true);`
  - `Console.Write(" > ");`
  - `string input = Console.ReadLine();`
- Create a Laugh command
  - `if (input == "laugh") { Console.WriteLine("Hahahaha"); }`
- Create an Unknown response command
  - `else { Console.WriteLine("Unknown command"); }`
- Create an Exit command
  - `else if (input == "exit") { break; }`

### Homework
- Create 3 new emote commands : `dance`, `sing`, and `whistle`



## Lesson 2

 - Introduce the concept of a command class
   - `public class LaughCommand`
 - Create an interface for Command classes
   - `public interface ICommand`
 - Implement the ICommand interface in the LaughCommand class
   - `public class LaughCommand : ICommand`
 - Ensure that the `Execute` method returns a `CommandResult`
   - CommandResult is a class with a `RequestExit` property and a `IsHandled` property
 - Repeat for `ExitCommand`, `DanceCommand`, `SingCommand`, and `WhistleCommand`
 - Modify `Main` to use a `List<ICommand>` to store the commands


### Homework
- Move all classes and interfaces to their own files.

## Lesson 3

 - Introduce a namespace for the project
   - `namespace Sork`
 - Organize our files so Commands are in a Commands folder
 - Abstract `Console` by creating a `UserInputOutput` class
     - `WriteNoun`
     - `WriteMessage`
     - `WriteMessageLine`
     - `WritePrompt`
     - `ReadInput`
     - `ReadInputLine`
- Update `LaughCommand` to use the `UserInputOutput` class
- Extract a BaseCommand class from the Command classes
  - Implment a Parse method that takes the user input and returns the first word.

### Homework
- Implement all existing commands as BaseCommand classes.

## Lesson 4

- Change `Execute` to take the `userInput` as a parameter.
- Modify `DanceCommand` to allow for a `noun` parameter
- Modify `DanceCommand` to not handle anything with more than 1 parameter or 0 parameters.
- Implement a `GameState` class that is aware of a `Player` and a `Room`
- Initialize the `GameState` class in `Main`
- Implement a `Room` class that has a `Name` and a `Description`
- Implement a `Player` class that has a `Name` and a `Location`
- Implement a `MoveCommand` that allows the player to move between rooms.

### Homework
- Implement a `LookCommand` that allows the player to look around the room.

## Lesson 5

- Implement Microsoft.Extensions.DependencyInjection to register the commands and game state.
- Update `Main` to use the dependency injection container to get the commands and game state.
- Implement a UnitTest project to test the commands and game state.

### Homework
None

## Lesson 6

- Implemented a `TakeCommand` that allows the player to take an item. (eventually)
- Added a `TestInputOutput` class to test the commands and game state.
- Refactored the `UserInputOutput` class to be an interface `IUserInputOutput`.

### Homework

For all other commands, except `MoveCommand` and `LookCommand`, write the following tests:
  - `Execute_ShouldOutputMessage`
  - `Handles_ShouldReturnTrue_WhenCapitalizedInputIsProvided`
  - `Handles_ShouldReturnTrue_WhenLowercaseInputIsProvided`


