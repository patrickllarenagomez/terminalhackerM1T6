using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    public System.Random ran = new System.Random();

    // Use this for initialization
    private string level = "";
    private int n = 0;
    private int incorrect = 0;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;
    string[,] array2D = new string[,] { { "airplane", "helicopter","aircraft" }, { "instrument", "orchestra","drumstick" }, { "universe", "moonstone","Apollo" }};
    private string password = "";

    void Start () {
        string greeting = "";
        ShowMainMenu(greeting);

    }

    void ShowMainMenu(string name)
    {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine(name);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the National Airport");
        Terminal.WriteLine("Press 2 for the National Music Centre");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }
	
    void OnUserInput(string input)
    {
        if("menu" == input)
        {
            Terminal.ClearScreen();
            ShowMainMenu("Hello");
        }
        else if("007" == input)
        {
            Terminal.ClearScreen();
            ShowMainMenu("Hello, Mr. Bond." + "\n" + "Please choose a level, Mr. Bond");
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if(currentScreen == Screen.Win)
        {
            // do nothing
        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Please choose a valid level.");
        }
    }

    
    void StartGame(string level)
    {
        if (n == 0)
            n = 1;
        else if (n == 1)
            n = 2;
        else
            n = 0;

        int arrayLevel = int.Parse(level);
        Terminal.ClearScreen();

        if (incorrect == 1)
            Terminal.WriteLine("Incorrect Password!");

        Terminal.WriteLine("Level " + level);
        string word = array2D[arrayLevel - 1, n];
        password = word;
        string scram = ScrambleWord(word);

        Terminal.WriteLine("Clue: " + scram);
        Terminal.WriteLine("Enter Password");
    }
    
    void RunMainMenu(string input)
    {
        if ("1" == input)
        {
            level = "1";
            StartGame(level);
            currentScreen = Screen.Password;
        }
        else if ("2" == input)
        {
            level = "2";
            StartGame(level);
            currentScreen = Screen.Password;
        }
        else if ("3" == input)
        {
            level = "3";
            StartGame(level);
            currentScreen = Screen.Password;
        }
    }
       
    void CheckPassword(string answer)
    {
        if (password == answer)
            WinCredit();
        else
        {
            incorrect = 1;
            StartGame(level);
        }
    }

    void WinCredit()
    {
        incorrect = 0;
        currentScreen = Screen.Win;
        if (level == "1")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congratulations!");
            Terminal.WriteLine("You won an old model airplane!");
            Terminal.WriteLine("");
            Terminal.WriteLine(@" ----|------------|-----------|----");
            Terminal.WriteLine(@"     |        --/ - \--       |    ");
            Terminal.WriteLine(@"    -|---------|  o  |--------|-   ");
            Terminal.WriteLine(@"               /\ _ /\             ");
            Terminal.WriteLine(@"            []/       \[]          ");
            Terminal.WriteLine("");
            Terminal.WriteLine("Type 'menu' to restart.");
            
        }
        else if (level == "2")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congratulations!");
            Terminal.WriteLine("You won a keyboard!");
            Terminal.WriteLine(@"     ________________________________");
            Terminal.WriteLine(@"    /    o   oooo ooo oooo   o o o  /\");
            Terminal.WriteLine(@"   /    oo  ooo  oo  oooo   o o o  / /");
            Terminal.WriteLine(@"  /    _________________________  / /");
            Terminal.WriteLine(@" / // / // /// // /// // /// / / / /");
            Terminal.WriteLine(@"/___ //////////////////////////_/ /");
            Terminal.WriteLine(@"\____\________________________\_\/");
            Terminal.WriteLine("");
            Terminal.WriteLine("Type 'menu' to restart.");

        }
        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congratulations!");
            Terminal.WriteLine("You discovered alien life form.");
            Terminal.WriteLine(@"         .-""""-.           .-""""-.");
            Terminal.WriteLine(@"        /_        _\    /_        _\");
            Terminal.WriteLine(@"       // \      / \\  // \      / \\");
            Terminal.WriteLine(@"       |\__\    /__/|  |\__\    /__/|");
            Terminal.WriteLine(@"        \    ||    /    \    ||    /");
            Terminal.WriteLine(@"          \  __  /        \  __  /");
            Terminal.WriteLine(@"           '.__.'          '.__.'");
            Terminal.WriteLine(@"            |  |            |  |");
            Terminal.WriteLine("Type 'menu' to restart.");

        }

    }

    public string ScrambleWord(string word)
    {
        char[] chars = new char[word.Length];
        
        int index = 0;
        while (word.Length > 0)
        { // Get a random number between 0 and the length of the word. 
            int next = ran.Next(0, word.Length - 1); // Take the character from the random position 
                                                      //and add to our char array. 
            chars[index] = word[next];                // Remove the character from the word. 
            word = word.Substring(0, next) + word.Substring(next + 1);
            ++index;
        }
        return new string(chars);
    }
}
