
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "Type 'menu' anytime";
    string[] level1Passwords = {"books", "aisle", "shelf", "font", "borrow"};
    string[] level2Passwords = {"prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "astronaut", "spaceship", "telescope", "spaceforce", "outterspace" };

    //Game State

    #region variables

    string greetings = "Welcome, ";
    string userWife = "Jennifer Lynn Einman";
    string userBriar = "Briar Willam Einman";
    string userLilly = "Lillian Marie Einman";
    string userHannah = "Hannah Lynn Stenerson";
    string userAlison = "Alison Daniel Stenerson";
    int level;
    string password;
    int index;
    
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen;

    #endregion

    void Start()
    {
        ShowMainMenu();
    }



    // Funcitons
    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        print("Main Menu Displayed");
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine(greetings + userLilly );
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the Local Library");
        Terminal.WriteLine("Press 2 for the Police Station");
        Terminal.WriteLine("Press 3 for the NASA");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        

        #region Easter Eggs

        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level, Mr.Bond.");
        }
        else if (input == "082713")
        {
            Terminal.WriteLine("Happy Birthday, Lilly!");
        }
        else if (input == "3605891654")
        {
            Terminal.WriteLine("Calling... Dad");
        }

        #endregion
        else
        {
            Terminal.WriteLine("Please enter a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

     void AskForPassword()
    {
        print(level1Passwords.Length);
        print(level2Passwords.Length);
        print(level3Passwords.Length);
        currentScreen = Screen.Password;
        Terminal.ClearScreen(); 
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

     void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

     void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    __________
   /        //
  /        //
 /_______ //
(________(/
");
                Terminal.WriteLine(menuHint);
                break;
            case 2:
                Terminal.WriteLine("Bear Hug!");
                Terminal.WriteLine(@"
     ()=()   ()=()
     (':')   ('Y') 
     q . p   d . b  
     ()_()   ()_() 
");
                Terminal.WriteLine(menuHint);
                break;

            case 3:
                Terminal.WriteLine("Bear Hug!");
                Terminal.WriteLine(@"
     |     | |
    / \    | |
   |--o|===|-|
   |---|   | |
  /     \  |N|
 | U     | |A|
 | S     |=|S|
 | A     | |A|
 |_______| |_|
  |@| |@|  | |
___________|_|_
");
                Terminal.WriteLine(menuHint);
                break;
            default:
                Debug.LogError("oops");
                break;
        }
    }

    // Update is called once per frame

}

/*11111111111111111111111111111111111111111111111111111111111111111111111111111111122222222222222222222222222222222222222222222222222222222222222222222222
 * 33333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333444444444444444444444444444444444444
 * 5555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555
 * 66666666666666666666666666666666666666666666666666666666666666666677777777777777777777777777777777777777777777888888888888888888888888888888888888888888999999999999999999999999
 * 110101010101010101010101010101010101010101010101010101010100101010101010101010101101010101011111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
 * 12121212121212121212121212121212121221212212121211212121213313131313131313131313131331313131313131141414141414114141414141414141515151515515515151515151515116161616161616161616161616161616161617
 * 171717171717171717117\171717171717171717177171171717711717177117711771177117171771177117181818811818811818181818188181818181811881188118181818181818188111991191991199119919191919191919191919191911910220020
 * 121212112211221121122112121221211221212121211212122112121121212122112121212121221111212122112121221121212211212121122121122112212212211211212121121221121212121221122132233223232323232332233232323233223233232223233223232442422444244444424242
 * 525555525225522525225225252522552525252225225525252525252525252252522252552522525255225225525262622226262622662626226622626262626266262622626626262262662622662622622777727272727277227272772727277227272727727227277277227722777272777727272777772828
 * 92292992929292229929229929292299929292929292920303300030003033030300030330300033030330030303300311311113313131313131313131311331311313232322332322332322323322323223233223232332333333333333333333333333333333333333333333333333333333333333333333333333333333
*/
