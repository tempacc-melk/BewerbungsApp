using System.Diagnostics;
using BewerbungsApp.Database;

namespace BewerbungsApp
{

    internal class Program
    {

        private static bool gui;
        private static int pos = 0;
        private static readonly string[] langItems = new string[24];
        private static void SetLanguage(int input) 
        {
            if (input == 0)
            {
                // Grundlegende Sachen
                langItems[0] = "Eingabe: ";
                langItems[1] = "Err: Keine Eingabe";
                langItems[2] = "Err: Ungültige Eingabe";
                langItems[3] = "Anwendung wird beendet";
                langItems[4] = "Sie haben Deutsch als Sprache ausgewählt.";

                // Alle Funktionen
                langItems[5] = "Folgende Optionen stehen zur Verfügung:";
                langItems[6] = "0 | Datenbank | SQL / XML";
                langItems[7] = "1 | GUI | C# / Java";
                langItems[8] = "2 | Kommunikation | PHP";
                langItems[9] = "3 | ... | JavaScript";

                // Datenbank Optionen
                langItems[10] = "Folgende Datenbank Optionen stehen zur Verfügung:";
                langItems[11] = "0 | Erstelle eine Datenbank";
                langItems[12] = "1 | Lade 'Hard-Coded' Datenbank";
                langItems[13] = "2 | Datenbank bearbeiten";
                langItems[14] = "3 | Importiere eine Datenbank";
                langItems[15] = "4 | Exportiere the Datenbank";

                // GUI
                langItems[16] = "Folgende GUI Optionen stehen zur Verfügung:";
                langItems[17] = "0 | Öffne GUI geschrieben in C#";
                langItems[18] = "1 | Öffne GUI geschrieben in Java";

                // Liste mit allen Befehlen
                langItems[19] = " * Liste aller Befehle:";
                langItems[20] = " * Sprache -WERT | Um die Sprache zu ändern";
                langItems[21] = " * Menu          | Öffnet das Hauptfenster mit allen Funktionen";
                langItems[22] = " * Zuruck        | Springt eine Seite zurück";
                langItems[23] = " * Exit          | Beendet die Anwendung";
            }
            else
            {
                // Basic stuff
                langItems[0] = "Input: ";
                langItems[1] = "Err: No input";
                langItems[2] = "Err: Invalid input";
                langItems[3] = "Closing the application";
                langItems[4] = "You've selected english as your language.";

                // All functions
                langItems[5] = "Following options are available:";
                langItems[6] = "0 | Database | SQL / XML";
                langItems[7] = "1 | GUI | C# / Java";
                langItems[8] = "2 | Communication | PHP";
                langItems[9] = "3 | ... | JavaScript";

                // Database options
                langItems[10] = "Following database options are available:";
                langItems[11] = "0 | Create a database";
                langItems[12] = "1 | Load 'Hard coded' database";
                langItems[13] = "2 | Edit database";
                langItems[14] = "3 | Import a database";
                langItems[15] = "4 | Export the database";

                // GUI
                langItems[16] = "Following GUI options are available:";
                langItems[17] = "0 | Open GUI written in C#";
                langItems[18] = "1 | Open GUI written in Java";

                // List of all commands
                langItems[19] = " * List of all commands:";
                langItems[20] = " * Lang -VALUE   | To change the language";
                langItems[21] = " * Menu          | Opens the menu with all functions";
                langItems[22] = " * Return        | Goes back one page";
                langItems[23] = " * Exit          | Closes the application";
            }
        }

        private static readonly string databaseName = "Local DB v0.1";

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
            input = input.ToUpper();
            if (input == "0" || input.Equals("DEUTSCH"))
            {
                SetLanguage(0);
                pos = 1;

                Console.WriteLine(langItems[4] + "\n");

                PostMessage(1);
                ShowAllFunctions();
            }
            else if (input == "1" || input.Equals("ENGLISH"))
            {
                SetLanguage(1);
                pos = 1;

                Console.WriteLine(langItems[4] + "\n");

                PostMessage(1);
                ShowAllFunctions();
            }
            else if (input != "0" || input != "1" || !input.Equals("DEUTSCH") || !input.Equals("ENGLISH"))
            {
                InitializeApp();
            }
        }
        private static void ShowAllFunctions()
        {
            pos = 2;
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
            pos = 3;
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
                DB.InitializeDB();
                PostMessage(21);

                for (int i = 0; i < DB.Count; i++)
                {
                    string tempid = DB.Items[i].Id.ToString();
                    if (tempid.Length < 4) tempid = tempid.PadRight(4, ' ');

                    string tempvorname = DB.Items[i].Vorname;
                    if (tempvorname.Length < 14) tempvorname = tempvorname.PadRight(14, ' ');
                    else if (tempvorname.Length > 14) tempvorname = tempvorname[..14];

                    string tempnachname = DB.Items[i].Nachname;
                    if (tempnachname.Length < 16) tempnachname = tempnachname.PadRight(16, ' ');
                    else if (tempnachname.Length > 16) tempnachname = tempnachname[..16];

                    string tempemail = DB.Items[i].Email;
                    if (tempemail.Length < 26) tempemail = tempemail.PadRight(26, ' ');
                    else if (tempemail.Length > 26) tempemail = tempemail[..26];

                    string temphandy = DB.Items[i].Handy.ToString();
                    if (temphandy.Length < 16) temphandy = temphandy.PadRight(16, ' ');
                    else if (temphandy.Length > 16) temphandy = temphandy[..16];

                    string tempstadtplz = DB.Items[i].Townplz.ToString();
                    if (tempstadtplz.Length < 10) tempstadtplz = tempstadtplz.PadRight(10, ' ');
                    else if (tempstadtplz.Length > 10) tempstadtplz = tempstadtplz[..10];

                    string tempstrasse = DB.Items[i].Strasse;
                    if (tempstrasse.Length < 20) tempstrasse = tempstrasse.PadRight(20, ' ');
                    else if (tempstrasse.Length > 20) tempstrasse = tempstrasse[..20];

                    Console.WriteLine($"{tempid}|{tempvorname}|{tempnachname}|{tempemail}|{temphandy}|{tempstadtplz}|{tempstrasse}");
                }

                if (gui)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("GUI detected. Do you want to enable auto-update to GUI? Y/N");
                    Console.Write("Input: ");
                    if (CheckForYesOrNo(Console.ReadLine()!))
                    {
                        // Placeholder
                    }
                    else
                    {
                        Console.WriteLine("No input detected or denied, going back to menu.");
                        Thread.Sleep(2000);
                        Return(3);
                    }
                    
                } 
                else
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("GUI not detected. Do you want to start the GUI? Y/N");
                    Console.Write("Input: ");
                    if (CheckForYesOrNo(Console.ReadLine()!))
                    {
                        Console.WriteLine("Starting GUI C# v0.1");
                        Process.Start("GUI/BewerbungsAppGUI.exe");
                        gui = true;

                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Do you want to enable auto-update to GUI? Y/N");
                        Console.Write("Input: ");
                        if (CheckForYesOrNo(Console.ReadLine()!))
                        {
                            Console.WriteLine("placeholder");
                            Thread.Sleep(2000);
                            Return(3);
                        }
                        else
                        {
                            Console.WriteLine("No input detected or denied, going back to menu.");
                            Thread.Sleep(2000);
                            Return(3);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No input detected or refused, going back to menu.");
                        Thread.Sleep(2000);
                        Return(3);
                    }
                }


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
                // Einfrage einbauen ob als SQL oder XML exportiert werden soll
                // SQL Format
                //
                
                // XML Format
                if (DB.Xmlstring.Length > 0)
                {
                    string fileName = $"Custom DB - {DateTime.Now:HH.mm.ss}.xml";
                    Console.WriteLine($"Creating {fileName}...");
                    File.WriteAllText($"./Database/Export/{fileName}", DB.Xmlstring);
                    Console.WriteLine($"File created. Going back to menu");
                    Thread.Sleep(2000);
                } 
                else
                {
                    Console.WriteLine("The Hardcoded DB hasn't been loaded, going back");
                    Thread.Sleep(2000);
                    Return(pos--);
                }
                Return(3);
            }
            else
            {
                Database();
            }
        }
        private static void GUI ()
        {
            pos = 4;
            Console.Write(langItems[0]);
            string input = CheckInput();

            if (input == "0")
            {
                Process[] pname = Process.GetProcessesByName("BewerbungsAppGUI");
                if (pname.Length == 0)
                {
                    PostMessage(31);
                    Process.Start("GUI/BewerbungsAppGUI.exe");
                    gui = true;
                    Thread.Sleep(1000);
                    Return(3);
                }
                else
                {
                    Console.WriteLine("Process already running\n");
                    Console.Write("Close the GUI? Y/N: ");
                    if (CheckForYesOrNo(Console.ReadLine()!))
                    {
                        pname[0].Kill();
                        gui = false;
                        Return(3);
                    }
                    else
                    {
                        Return(3);
                    }
                    
                }
            }
            else if (input == "1")
            {
                Console.WriteLine("placeholder");
                GUI();
            }
            else
            {
                GUI();
            }
        }
        private static bool CheckForYesOrNo (string input)
        {
            return input.ToUpper().Contains('Y') ? true : false;
        }

        private static void Communication ()
        {
            pos = 5;
            Console.Write(langItems[0]);
            string input = CheckInput();
        }
        private static void Bots ()
        {
            pos = 6;
            Console.Write(langItems[0]);
            string input = CheckInput();
        }


        private static string CheckInput ()
        {
            string? checkInput = Console.ReadLine();
            string inputUC = checkInput.ToUpper();

            if (pos == 0)
            {
                if (inputUC == "")
                {
                    Console.WriteLine("Err: Keine Eingabe / No input\n");
                }
                else if (inputUC == "HELP" || inputUC == "HILFE")
                {
                    Help();
                }
                else if (inputUC == "EXIT")
                {
                    Console.WriteLine("Anwendung wird beendet / Closing the application");
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Err: Unbekannte Eingabe / Unknown input\n");
                }
            }
            else
            {
                switch (inputUC)
                {
                    case "":
                        Console.WriteLine(langItems[1] + "\n");
                        break;
                    
                    case string when inputUC.Contains("SPRACHE -") || inputUC.Contains("LANG -"):
                        string[] getLang = inputUC.Split('-');
                        bool checkForNumber = int.TryParse(getLang[1], out _);
                        if (getLang[1].Length > 0)
                        {
                            getLang[1] = getLang[1][..1];
                            if (checkForNumber)
                            {
                                SetLanguage(int.Parse(getLang[1]));
                            }
                            else
                            {
                                if (getLang[1] == "D")
                                {
                                    SetLanguage(0);
                                }
                                else
                                {
                                    SetLanguage(1);
                                }
                            }
                            Console.WriteLine(langItems[4] + "\n");
                        }
                        else
                        {
                            Console.WriteLine(langItems[2] + "\n");
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

                    case "Z" or "R" or "ZURUCK" or "RETURN":
                        Return(pos--);
                        break;

                    case "EXIT":
                        Console.WriteLine(langItems[3]);
                        Thread.Sleep(1500);
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
                " * Return        | Jumps back one page\n" +
                " * Exit          | Closes the application\n" +
                " * ";
            }
            else
            {
                helpMsg += " * \n";
                    for (int i = 0; i < 5; i++)
                {
                    helpMsg += langItems[langItems.Length - 5 + i] + "\n";
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
                    Console.WriteLine("/************************ MENU ************************/\n");
                    for (int i = 0; i <= 4; i++)
                    {
                        Console.WriteLine(langItems[5 + i]);
                    }
                    Console.Write(Environment.NewLine);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("/************************ DB **************************/\n");
                    for (int i = 0; i <= 5; i++)
                    {
                        Console.WriteLine(langItems[10 + i]);
                    }
                    Console.Write(Environment.NewLine);
                    break;

                case 21:
                    Console.Clear();
                    Console.WriteLine("/************************ DB **************************/\n");
                    Console.WriteLine($"Hardcoded Database has been loaded: {databaseName}");
                    Console.WriteLine("ID  |Vorname       |Nachname        |Email                     |Handy           |Stadt-Plz |Strasse             ");
                    Console.WriteLine("====|==============|================|==========================|================|==========|====================");
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("/************************ GUI *************************/\n");
                    for (int i = 0; i <= 2; i++)
                    {
                        Console.WriteLine(langItems[16 + i]);
                    }
                    Console.Write(Environment.NewLine);
                    break;

                case 31:
                    Console.WriteLine("GUI loaded");
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("/************************ COM *************************/\n");
                    break;

                case 5:
                    Console.Clear();
                    Console.WriteLine("/************************ BOT *************************/\n");
                    break;
            }
        }

        private static void Return (int value)
        {
            if (value >= 3 && value <= 6)
            {
                PostMessage(1);
                ShowAllFunctions();
            }
        }       
    }
}
