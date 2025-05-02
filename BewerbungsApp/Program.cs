namespace BewerbungsApp
{

    internal class Program
    {
        private static int pos = 0;
        private static List<string> langItems = [];
        private static void SetLanguage(int input) {
            langItems.Clear();
            langItems = [];
            switch (input)
            {
                case 0:
                    // Grundlegende Sachen
                    langItems.Add("Eingabe: ");                                                         // 0
                    langItems.Add("Err: Keine Eingabe");                                                // 1
                    langItems.Add("Err: Ungültige Eingabe");                                            // 2
                    langItems.Add("Anwendung wird beendet");                                            // 3
                    langItems.Add("Sie haben Deutsch als Sprache ausgewählt.");                         // 4

                    // Alle Funktionen
                    langItems.Add("Folgende Optionen stehen zur Verfügung:");                           // 5
                    langItems.Add("0 | Datenbank | SQL / XML");                                         // 6
                    langItems.Add("1 | GUI | C# / Java");                                               // 7
                    langItems.Add("2 | Kommunikation | PHP");                                           // 8
                    langItems.Add("3 | ... | JavaScript");                                              // 9

                    // Datenbank Optionen
                    langItems.Add("Folgende Datenbank Optionen stehen zur Verfügung:");                 // 10
                    langItems.Add("0 | Erstelle eine Datenbank");                                       // 11
                    langItems.Add("1 | Lade 'Hard-Coded' Datenbank");                                   // 12
                    langItems.Add("2 | Datenbank bearbeiten");                                          // 13
                    langItems.Add("3 | Importiere eine Datenbank");                                     // 14
                    langItems.Add("4 | Exportiere the Datenbank");                                      // 15

                    // GUI
                    langItems.Add("Folgende GUI Optionen stehen zur Verfügung:");                       // 16
                    langItems.Add("0 | Öffne GUI geschrieben in C#");                                   // 17
                    langItems.Add("1 | Öffne GUI geschrieben in Java");                                 // 18

                    // Liste mit allen Befehlen
                    langItems.Add(" * Liste aller Befehle:");                                           // 
                    langItems.Add(" * Sprache -WERT | Um die Sprache zu ändern");                       // 
                    langItems.Add(" * Menu          | Öffnet das Hauptfenster mit allen Funktionen");   // 
                    langItems.Add(" * Zuruck        | Springt eine Seite zurück");                      //
                    langItems.Add(" * Exit          | Beendet die Anwendung");                          // 
                    break;

                case 1:
                    // Basic stuff
                    langItems.Add("Input: ");                                                   // 0
                    langItems.Add("Err: No input");                                             // 1
                    langItems.Add("Err: Invalid input");                                        // 2
                    langItems.Add("Closing the application");                                   // 3
                    langItems.Add("You've selected english as your language.");                 // 4

                    // All functions
                    langItems.Add("Following options are available:");                          // 5
                    langItems.Add("0 | Database | SQL / XML");                                  // 6
                    langItems.Add("1 | GUI | C# / Java");                                       // 7
                    langItems.Add("2 | Communication | PHP");                                   // 8
                    langItems.Add("3 | ... | JavaScript");                                      // 9

                    // Database options
                    langItems.Add("Following database options are available:");                 // 10
                    langItems.Add("0 | Create a database");                                     // 11
                    langItems.Add("1 | Load 'Hard coded' database");                            // 12
                    langItems.Add("2 | Edit database");                                         // 13
                    langItems.Add("3 | Import a database");                                     // 14
                    langItems.Add("4 | Export the database");                                   // 15

                    // GUI
                    langItems.Add("Following GUI options are available:");                      // 16
                    langItems.Add("0 | Open GUI written in C#");                                // 17
                    langItems.Add("1 | Open GUI written in Java");                              // 18

                    // List of all commands
                    langItems.Add(" * List of all commands:");                                  // 
                    langItems.Add(" * Lang -VALUE   | To change the language");                 // 
                    langItems.Add(" * Menu          | Opens the menu with all functions");      // 
                    langItems.Add(" * Return        | Goes back one page");                     //
                    langItems.Add(" * Exit          | Closes the application");                 // 
                    break;
            }
        }

        static void Main()
        {
            PostMessage(-1);
            PostMessage(0);
            
            InitializeApp();
        }
        private static void InitializeApp ()
        {
            pos = 0;
            Console.Write("Eingabe / Input: ");
            string input = CheckInput();

            if (input == "0" || input.Equals("deutsch", StringComparison.CurrentCultureIgnoreCase))
            {
                SetLanguage(0);
                pos = 1;

                Console.WriteLine(langItems[4] + "\n");

                PostMessage(1);
                ShowAllFunctions();
            }
            else if (input == "1" || input.Equals("english", StringComparison.CurrentCultureIgnoreCase))
            {
                SetLanguage(1);
                pos = 1;

                Console.WriteLine(langItems[4] + "\n");

                PostMessage(1);
                ShowAllFunctions();
            }
            else if (input != "0" || input != "1" || !input.Equals("deutsch", StringComparison.CurrentCultureIgnoreCase) || !input.Equals("english", StringComparison.CurrentCultureIgnoreCase))
            {
                InitializeApp();
            }
        }
        private static void ShowAllFunctions()
        {
            Console.Write(langItems[0]);
            string input = CheckInput();

            if (input == "0")
            {
                PostMessage(2);
                Database();
            }
            else if (input == "1")
            {
                PostMessage(3);
                GUI();
            }
            else if (input == "2")
            {
                PostMessage(4);
                Communication();
            }
            else if (input == "3")
            {
                PostMessage(5);
                Bots();
            }
            else
            {
                ShowAllFunctions();
            }
        }

        private static void Database ()
        {
            string[] sqlCmd = ["CREATE", "DROP", "SELECT", "UPDATE", "INSERT INTO", "DELETE"];
            string sqlquerey = $"";
            Console.Write(langItems[0]);
            string input = CheckInput();

            if (input == "0")
            {
                // Create

            }
            else if (input == "1")
            {
                // Load

            }
            else if (input == "2")
            {
                // Edit (UPDATE | INSERT | DELETE | DROP)

            }
            else if (input == "3")
            {
                // Import from SQL or XML format

            }
            else if (input == "4")
            {
                // Export as SQL or XML format
                Console.WriteLine();
            }
            else
            {
                Database();
            }
        }

        private static void GUI ()
        {
            Console.Write(langItems[0]);
            string input = CheckInput();

            if (input == "0")
            {

            }
            else if (input == "1")
            {

            }
            else
            {
                GUI();
            }
        }

        private static void Communication ()
        {
            Console.Write(langItems[0]);
            string input = CheckInput();
        }

        private static void Bots ()
        {
            Console.Write(langItems[0]);
            string input = CheckInput();
        }

        private static string CheckInput ()
        {
            string? checkInput = Console.ReadLine();

            if (pos == 0)
            {
                switch (checkInput?.ToUpper())
                {
                    case "":
                        Console.WriteLine("Err: Keine Eingabe / No input\n");
                        break;

                    case "HELP" or "HILFE":
                        Help();
                        break;

                    case "EXIT":
                        Console.WriteLine("Anwendung wird beendet / Closing the application");
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                switch (checkInput?.ToUpper())
                {
                    case "":
                        Console.WriteLine(langItems[1] + "\n");
                        break;

                    case string when 
                    (checkInput.ToUpper().Contains("SPRACHE ") || checkInput.ToUpper().Contains("LANG ")) && 
                    (checkInput.Contains("-0") || checkInput.ToUpper().Contains("-DEUTSCH") || checkInput.Contains("-1") || checkInput.ToUpper().Contains("-ENGLISH")):
                        string[] getLang = checkInput.Split('-');
                        if (getLang.Length > 2)
                        {
                            Console.WriteLine(langItems[2] + "\n");
                            break;
                        }

                        if (getLang[1].Length <= 1)
                        {
                            SetLanguage(int.Parse(getLang[1]));
                            Console.WriteLine(langItems[4] + "\n");
                        } 
                        else
                        {
                            getLang[1] = getLang[1].Remove(1);
                            if (getLang[1] == "d")
                            {
                                SetLanguage(0);
                            }
                            if (getLang[1] == "e")
                            {
                                SetLanguage(1);
                            }
                            Console.WriteLine(langItems[4] + "\n");
                        }
                        break;

                    case "HELP" or "HILFE":
                        Help();
                        break;

                    case "MENU":
                        pos = 1;
                        PostMessage(1);
                        ShowAllFunctions();
                        break;

                    case "Z" or "B" or "ZURUCK" or "BACK":
                        Console.WriteLine("placeholder");
                        break;

                    case "EXIT":
                        Console.WriteLine(langItems[3]);
                        Environment.Exit(0);
                        break;
                }
            }

            return checkInput!;
        }

        private static void Help()
        {
            string helpMsg = "\n/******************** Hilfe / Help ********************\n";
            if (pos == 0)
            {
                helpMsg +=
                " * \n" +
                " * Liste aller Befehle:\n" +
                " * Sprache -WERT | Sprache ändern\n" +
                " * Menu          | Öffnet das Hauptfenster mit allen Funktionen\n" +
                " * Zuruck        | Springt eine Seite zurück\n" +
                " * Exit          | Beendet die Anwendung\n" +
                " * \n" +
                " * List of all commands:\n" +
                " * Lang -VALUE   | Change the language\n" +
                " * Menu          | Opens the menu with all functions\n" +
                " * Back          | Jumps back one page\n" +
                " * Exit          | Closes the application\n" +
                " * ";
            }
            else
            {
                helpMsg += " * \n";
                    for (int i = 0; i < 5; i++)
                {
                    helpMsg += langItems[langItems.Count - 5 + i] + "\n";
                }
                helpMsg += " * ";
            }
            helpMsg += "\n ********************* Ende / End *********************/\n";

            Console.WriteLine(helpMsg);
        }

        private static void PostMessage (int value)
        {
            switch (value)
            {
                case -2:
                    Console.WriteLine("\n/******************************************************/\n");
                    break;

                case -1:
                    Console.WriteLine(
                    "/******************************************************\n" +
                    " *                                                    *\n" +
                    " *       Diese APP wurde von Melina Kotschetkow       *\n" +
                    " *          für Bewerbungszwecke geschrieben          *\n" +
                    " *                                                    *\n" +
                    " ******************************************************/\n" +
                    "");
                    break;

                case 0:
                    Console.WriteLine(
                    "   Wähle deine Sprache      |   Select your language\n" +
                    "   Deutsch: 0               |   English: 1\n"
                    ); 
                    break;

                case 1:
                    Console.Clear();
                    Console.WriteLine("\n/************************ MENU ************************/\n");
                    for (int i = 0; i <= 4; i++)
                    {
                        Console.WriteLine(langItems[5 + i]);
                    }
                    Console.Write(Environment.NewLine);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine(langItems[6]);
                    Console.WriteLine("/************************ DB **************************/\n");
                    for (int i = 0; i <= 5; i++)
                    {
                        Console.WriteLine(langItems[10 + i]);
                    }
                    Console.Write(Environment.NewLine);
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine(langItems[7]);
                    Console.WriteLine("/************************ GUI *************************/\n");
                    for (int i = 0; i <= 2; i++)
                    {
                        Console.WriteLine(langItems[16 + i]);
                    }
                    Console.Write(Environment.NewLine);
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine(langItems[8]);
                    Console.WriteLine("/************************ COM *************************/\n");
                    break;

                case 5:
                    Console.Clear();
                    Console.WriteLine(langItems[9]);
                    Console.WriteLine("/************************ BOT *************************/\n");
                    break;
            }
        }

    }
}
