
using System.Diagnostics;
using System.Text.Unicode;
using System.Xml;

namespace BewerbungsApp.Database
{
    internal class DB
    {
        private static XmlDocument newtempXml = new();
        private static List<DBItem> dbitems = new();
        internal static List<DBItem> Dbitems
        {
            get => dbitems;
            set => dbitems = value;
        }
        private static List<Dictionary<string, string>> dbitemDictionary = new();
        private static Dictionary<string, string> _dictionary;

        private static int count;
        internal static int Count
        {
            get => count;
            set => count = value;
        }

        internal static void InitializeDB()
        {
            Console.Write(Environment.NewLine);
            string xmlfile =
                @"<?xml version='1.0' encoding='UTF-8' standalone='yes'?>" +
                "<root xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>" +
                    "<user>" +
                        "<Name>Max Mustermann</Name>" +
                        "<Email>max.mustermann@muster.de</Email>" +
                        "<Handy>0123456789</Handy>" +
                        "<TownPLZ>12345</TownPLZ>" +
                        "<Strasse>Musterstrasse 12</Strasse>" +
                    "</user>" +
                    "<user>" +
                        "<Name>Markus Mustermann</Name>" +
                        "<Email>markus.mustermann@muster.de</Email>" +
                        "<Handy>9876543210</Handy>" +
                        "<TownPLZ>45123</TownPLZ>" +
                        "<Strasse>Musterstrasse 21</Strasse>" +
                    "</user>" +
                    "<user>" +
                        "<Name>Anna Mustermann</Name>" +
                        "<Email>anna.mustermann@muster.de</Email>" +
                        "<Handy>7896542130</Handy>" +
                        "<TownPLZ>13024</TownPLZ>" +
                        "<Strasse>Musterstrasse 22</Strasse>" +
                    "</user>" +
                    "<user>" +
                        "<Name>Tom Mustermann</Name>" +
                        "<Email>tom.mustermann@muster.de</Email>" +
                        "<Handy>5846279130</Handy>" +
                        "<TownPLZ>52431</TownPLZ>" +
                        "<Strasse>Musterstrasse 31</Strasse>" +
                    "</user>" +
                    "<user>" +
                        "<Name>Lena Mustermann</Name>" +
                        "<Email>lena.mustermann@muster.de</Email>" +
                        "<Handy>3698521470</Handy>" +
                        "<TownPLZ>25143</TownPLZ>" +
                        "<Strasse>Musterstrasse 8</Strasse>" +
                    "</user>" +
                "</root>";

            // NAME || EMAIL || PHONE || TOWN ZIP || STREET + NR
            newtempXml.LoadXml(xmlfile);
            LoadDatabase();
            for (int i = 0; i < dbitemDictionary.Count; i++)
            {
                dbitems.Add(new DBItem(dbitemDictionary[i]));
                Count++;
            }
        }

        private static void LoadDatabase()
        {
            XmlNodeList itemList = newtempXml.GetElementsByTagName("user");
            foreach (XmlNode itemInfo in itemList)
            {
                XmlNodeList itemContent = itemInfo.ChildNodes;
                _dictionary = new();
                foreach (XmlNode content in itemContent)
                {
                    switch (content.Name)
                    {
                        case "Name":
                            _dictionary.Add("Name", content.InnerText);
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

            for (int i = 0; i < dbitems.Count; i++)
            {
                Debug.WriteLine("Here");
                Console.WriteLine(dbitems[i].Name);
            }
        }
    }
}
