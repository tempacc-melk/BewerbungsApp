
namespace BewerbungsApp.Database
{
    internal class DBItem
    {
        private byte id;
        internal byte Id
        {
            get => id; 
            set => id = value;
        }

        private string name;
        internal string Name
        {
            get => name;
            set => name = value;
        }
        private string email;
        internal string Email
        {
            get => email;
            set => email = value;
        }
        private ulong handy;
        internal ulong Handy
        {
            get => handy;
            set => handy = value;
        }
        private ushort townplz;
        internal ushort Townplz
        {
            get => townplz;
            set => townplz = value;
        }
        private string strasse;
        internal string Strasse
        {
            get => strasse;
            set => strasse = value;
        }

        internal DBItem(Dictionary<string, string> dir)
        {
            id = byte.Parse(dir["ID"]);
            name = dir["Name"];
            email = dir["Email"];
            handy = ulong.Parse(dir["Handy"]);
            townplz = ushort.Parse(dir["TownPLZ"]);
            strasse = dir["Strasse"];
        }
        internal DBItem() { }
        internal DBItem(byte newid, string newname, string newemail, ulong newhandy, ushort newtownplz, string newstrasse)
        {
            Id = newid;
            Name = newname;
            Email = newemail;
            Handy = newhandy;
            Townplz = newtownplz;
            Strasse = newstrasse;
        }
        
        internal string Clear ()
        {
            Id = 0;
            Name = string.Empty;
            Email = string.Empty;
            Handy = 0;
            Townplz = 0;
            Strasse = string.Empty;

            return "Cleared";
        }
    }
}
