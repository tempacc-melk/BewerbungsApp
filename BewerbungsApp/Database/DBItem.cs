using System.Xml;

namespace BewerbungsApp.Database
{
    internal class DBItem
    {
        internal static uint _ID;
        internal static string _Name;
        internal static string _Email;
        internal static ushort _Handy;
        internal static uint _TownPLZ;
        internal static string _Strasse;

        internal static List<string> CreateTempXml()
        {
            Console.Write(Environment.NewLine);
            XmlDocument newtempXml = new();
            // NAME || EMAIL || PHONE || TOWN ZIP || STREET + NR
            newtempXml.LoadXml(
                @"<root>" +
                    "<user>" +
                        "Name: Max Mustermann " +
                        "Email: max.mustermann@muster.de " +
                        "Handy: 0123456789 " +
                        "TownPLZ: 12345 " +
                        "Strasse: Musterstrasse 12" +
                    "</user>" +
                    "<user>" +
                        "Name: Markus Mustermann " +
                        "Email: markus.mustermann@muster.de " +
                        "Handy: 9876543210 " +
                        "TownPLZ: 45123 " +
                        "Strasse: Musterstrasse 21" +
                    "</user>" +
                    "<user>" +
                        "Name: Anna Mustermann " +
                        "Email: anna.mustermann@muster.de " +
                        "Handy: 7896542130 " +
                        "TownPLZ: 13024 " +
                        "Strasse: Musterstrasse 22" +
                    "</user>" +
                    "<user>" +
                        "Name: Tom Mustermann " +
                        "Email: tom.mustermann@muster.de " +
                        "Handy: 5846279130 " +
                        "TownPLZ: 52431 " +
                        "Strasse: Musterstrasse 31" +
                    "</user>" +
                    "<user>" +
                        "Name: Lena Mustermann " +
                        "Email: lena.mustermann@muster.de " +
                        "Handy: 3698521470 " +
                        "TownPLZ: 25143 " +
                        "Strasse: Musterstrasse 8" +
                    "</user>" +
                "</root>"
                );
            List<string> outputxml = new();
            XmlElement xmlroot = newtempXml.DocumentElement;
            XmlNodeList xmlnodelist = xmlroot.SelectNodes("user");
            foreach (XmlNode node in xmlnodelist)
            {
                string nodecontent = node.InnerText;
                outputxml.Add(nodecontent);
                Console.WriteLine($"{nodecontent}");
            }
            return outputxml;
        }


        private static void AddItemToDatabase (Dictionary<string, string> dir)
        {
            _Name = dir["Name"];
            _Email = dir["Email"];
            _Handy = ushort.Parse(dir["Handy"]);
            _TownPLZ = uint.Parse(dir["TownPLZ"]);
            _Strasse = dir["Strasse"];
        }
    }
}
