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
- Create a prompt loop (`do while`)
- Create a Laugh command
- Create an Unknown response command
- Create an Exit command

## Homework
- Create 3 new emote commands : `dance`, `sing`, and `whistle`



