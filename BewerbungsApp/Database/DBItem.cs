using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BewerbungsApp.Database
{
    internal class DBItem
    {
        internal uint _ID;
        internal string _Name;
        internal string _Email;
        internal ushort _Handy;
        internal uint _TownPLZ;
        internal string _Strasse;

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


        private void AddItemToDatabase (Dictionary<string, string> dir)
        {
            this._Name = dir["Name"];
            this._Email = dir["Email"];
            this._Handy = ushort.Parse(dir["Handy"]);
            this._TownPLZ = uint.Parse(dir["TownPLZ"]);
            this._Strasse = dir["Strasse"];
        }
    }
}
