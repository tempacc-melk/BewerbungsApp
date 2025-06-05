using BewerbungsApp.Database;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace BewerbungsApp
{

    internal class Program
    {
        #region Variables
        private static bool gui;
        internal static bool Gui
        {
            get => gui;
            set => gui = value;
        }

        private static int pos = 0;
        internal static int Pos
        {
            get => pos;
            set => pos = value;
        }

        private static readonly string[] langItems = new string[28];
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

                // Datenbank Option 0 - Weitere Funktionen
                langItems[19] = "Folgende Datenbank Bearbeitungs Optionen stehen zur Verfügung";
                langItems[20] = "0 | Hinzufügen";
                langItems[21] = "1 | Bearbeiten";
                langItems[22] = "2 | Löschen";

                // Liste mit allen Befehlen
                langItems[^5] = " * Liste aller Befehle:";
                langItems[^4] = " * Sprache -WERT | Um die Sprache zu ändern";
                langItems[^3] = " * Menu          | Öffnet das Hauptfenster mit allen Funktionen";
                langItems[^2] = " * Zuruck        | Springt eine Seite zurück";
                langItems[^1] = " * Exit          | Beendet die Anwendung";

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

                // Datenbank Option 0 - Further functions
                langItems[19] = "Following database edit options are available";
                langItems[20] = "0 | Add";
                langItems[21] = "1 | Edit";
                langItems[22] = "2 | Delete";

                // List of all commands
                langItems[^5] = " * List of all commands:";
                langItems[^4] = " * Lang -VALUE   | To change the language";
                langItems[^3] = " * Menu          | Opens the menu with all functions";
                langItems[^2] = " * Return        | Goes back one page";
                langItems[^1] = " * Exit          | Closes the application";
            }
        }

        private static readonly string databaseName = "Local DB v0.1";

        private static TcpListener? tcpListenerv4;
        private static TcpListener TcpListenerv4
        {
            get => tcpListenerv4;
            set => tcpListenerv4 = value;
        }

        private static TcpListener? tcpListenerv6;
        private static TcpListener TcpListenerv6
        {
            get => tcpListenerv6;
            set => tcpListenerv6 = value;
        }
        #endregion
        #region Main Methods
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
        #endregion
        #region Basic Methods
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

                if (Gui)
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
                        Console.WriteLine("Going back to menu.");
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
                        Gui = true;

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
                            Console.WriteLine("Going back to menu.");
                            Thread.Sleep(2000);
                            Return(3);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Going back to menu.");
                        Thread.Sleep(2000);
                        Return(3);
                    }
                }


            }
            else if (input == "2")
            {
                // Edit (UPDATE | INSERT | DELETE | DROP)
                PostMessage(22);
                DatabaseEdit();
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
        private static void DatabaseEdit ()
        {
            pos = 30;
            Console.Write(langItems[0]);
            string input = CheckInput();
            if (input == string.Empty)
            {
                DatabaseEdit();
            }
            else
            {

                /*
                DBItem newitem = new("Test1", string.Empty, "No Email", 123, 55555, "Test 123");
                DB.AddItemToDatabase(newitem);
                PostMessage(21);
                */
                DatabaseEdit();
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
                    Gui = true;
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
                        Gui = false;
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
        #endregion
        #region Check for inputs
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
        private static bool CheckForYesOrNo(string input)
        {
            return input.ToUpper().Contains('Y');
        }
        #endregion
        #region Other Methods
        internal static void PostMessage (int value)
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
                    DatabaseContent();
                    break;

                case 22:
                    Console.Clear();
                    Console.WriteLine("/************************ DB **************************/\n");
                    DatabaseContent();
                    Console.Write(Environment.NewLine);

                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine(langItems[19 + i]);
                    }
                    Console.Write(Environment.NewLine);
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
        private static void DatabaseContent ()
        {
            Console.WriteLine($"Database: {databaseName}");
            Console.WriteLine("ID  |Vorname       |Nachname        |Email                           |Handy            |Plz       |Strasse             ");
            Console.WriteLine("====|==============|================|================================|=================|==========|====================");
            if (DB.Count <= 0)
            {
                Console.WriteLine("No items found");
                return;
            }

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
                if (tempemail.Length < 32) tempemail = tempemail.PadRight(32, ' ');
                else if (tempemail.Length > 32) tempemail = tempemail[..32];

                string temphandy = DB.Items[i].Handy.ToString();
                if (temphandy.Length < 17) temphandy = temphandy.PadRight(17, ' ');
                else if (temphandy.Length > 17) temphandy = temphandy[..17];

                string tempstadtplz = DB.Items[i].Townplz.ToString();
                if (tempstadtplz.Length < 10) tempstadtplz = tempstadtplz.PadRight(10, ' ');
                else if (tempstadtplz.Length > 10) tempstadtplz = tempstadtplz[..10];

                string tempstrasse = DB.Items[i].Strasse;
                if (tempstrasse.Length < 20) tempstrasse = tempstrasse.PadRight(20, ' ');
                else if (tempstrasse.Length > 20) tempstrasse = tempstrasse[..20];

                Console.WriteLine($"{tempid}|{tempvorname}|{tempnachname}|{tempemail}|{temphandy}|{tempstadtplz}|{tempstrasse}");
            }
        }
        private static void Return (int value)
        {
            if (value >= 3 && value <= 6)
            {
                PostMessage(1);
                ShowAllFunctions();
            }
            if (value >= 30)
            {
                PostMessage(2);
                Database();
            }
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

        #endregion
        #region Communication to GUI
        private void OpenListener()
        {
            TcpListenerv4 = new TcpListener(IPAddress.Loopback, 50001);
            TcpListenerv6 = new TcpListener(IPAddress.IPv6Loopback, 50001);
        }
        private void SendMessageToGUI(string message)
        {

        }
        private void CloseListener ()
        {
            TcpListenerv4?.Stop();
            TcpListenerv6?.Stop();
        }
        #endregion
    }
}
