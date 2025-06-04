using System.Xml;
using System.Xml.Linq;

namespace BewerbungsApp.Database
{
    internal class DB
    {
        private static XmlDocument newtempXml = [];
        private static List<DBItem> items = [];
        internal static List<DBItem> Items
        {
            get => items;
            set => items = value;
        }
        private static List<Dictionary<string, string>> dbitemDictionary = [];
        private static Dictionary<string, string> _dictionary = [];

        private static string xmlstring = "";
        internal static string Xmlstring
        {
            get => xmlstring;
            set => xmlstring = value;
        }

        private static int count;
        internal static int Count
        {
            get => count;
            set => count = value;
        }

        internal static void InitializeDB()
        {
            Console.Write(Environment.NewLine);
            Xmlstring = XElement.Parse(
                @"<root xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">" +
                    "<user>" +
                        "<ID>0</ID>" +
                        "<Vorname>Max</Vorname>" +
                        "<Nachname>Mustermann</Nachname>" +
                        "<Email>max.mustermann@muster.de</Email>" +
                        "<Handy>0123456789</Handy>" +
                        "<TownPLZ>12345</TownPLZ>" +
                        "<Strasse>Musterstrasse 12</Strasse>" +
                    "</user>" +
                    "<user>" +
                        "<ID>1</ID>" +
                        "<Vorname>Markus</Vorname>" +
                        "<Nachname>Mustermann</Nachname>" +
                        "<Email>markus.mustermann@muster.de</Email>" +
                        "<Handy>9876543210</Handy>" +
                        "<TownPLZ>45123</TownPLZ>" +
                        "<Strasse>Musterstrasse 21</Strasse>" +
                    "</user>" +
                    "<user>" +
                        "<ID>2</ID>" +
                        "<Vorname>Anna</Vorname>" +
                        "<Nachname>Mustermann</Nachname>" +
                        "<Email>anna.mustermann@muster.de</Email>" +
                        "<Handy>7896542130</Handy>" +
                        "<TownPLZ>13024</TownPLZ>" +
                        "<Strasse>Musterstrasse 22</Strasse>" +
                    "</user>" +
                    "<user>" +
                        "<ID>3</ID>" +
                        "<Vorname>Tom</Vorname>" +
                        "<Nachname>Mustermann</Nachname>" +
                        "<Email>tom.mustermann@muster.de</Email>" +
                        "<Handy>5846279130</Handy>" +
                        "<TownPLZ>52431</TownPLZ>" +
                        "<Strasse>Musterstrasse 31</Strasse>" +
                    "</user>" +
                    "<user>" +
                        "<ID>4</ID>" +
                        "<Vorname>Lena</Vorname>" +
                        "<Nachname>Mustermann</Nachname>" +
                        "<Email>lena.mustermann@muster.de</Email>" +
                        "<Handy>3698521470</Handy>" +
                        "<TownPLZ>25143</TownPLZ>" +
                        "<Strasse>Musterstrasse 8</Strasse>" +
                    "</user>" +
                "</root>"
                ).ToString();

            newtempXml.LoadXml(Xmlstring);
            LoadDatabase();
            for (int i = 0; i < dbitemDictionary.Count; i++)
            {
                Items.Add(new DBItem(dbitemDictionary[i]));
                Count++;
            }
        }

        private static void LoadDatabase()
        {
            XmlNodeList itemList = newtempXml.GetElementsByTagName("user");
            foreach (XmlNode itemInfo in itemList)
            {
                XmlNodeList itemContent = itemInfo.ChildNodes;
                _dictionary = [];
                foreach (XmlNode content in itemContent)
                {
                    switch (content.Name)
                    {
                        case "ID":
                            _dictionary.Add("ID", content.InnerText);
                            break;
                        case "Vorname":
                            _dictionary.Add("Vorname", content.InnerText);
                            break;
                        case "Nachname":
                            _dictionary.Add("Nachname", content.InnerText);
                            break;
                        case "Email":
                            _dictionary.Add("Email", content.InnerText);
                            break;
                        case "Handy":
                            _dictionary.Add("Handy", content.InnerText);
                            break;
                        case "TownPLZ":
                            _dictionary.Add("TownPLZ", content.InnerText);
                            break;
                        case "Strasse":
                            _dictionary.Add("Strasse", content.InnerText);
                            break;
                    }
                }
                dbitemDictionary.Add(_dictionary);
            }
        }
    }
}
