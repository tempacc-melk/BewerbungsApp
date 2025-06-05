
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

        private string vorname;
        internal string Vorname
        {
            get => vorname;
            set => vorname = value;
        }
        private string nachname;
        internal string Nachname
        {
            get => nachname;
            set => nachname = value;
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
            vorname = dir["Vorname"];
            nachname = dir["Nachname"];
            email = dir["Email"];
            handy = ulong.Parse(dir["Handy"]);
            townplz = ushort.Parse(dir["TownPLZ"]);
            strasse = dir["Strasse"];
        }
        internal DBItem(string newvorname, string newnachname, string newemail, ulong newhandy, ushort newtownplz, string newstrasse)
        {
            Id = (byte)(DB.Count);
            Vorname = string.IsNullOrEmpty(newvorname) ? "" : newvorname;
            Nachname = string.IsNullOrEmpty(newnachname) ? "" : newnachname;
            Email = string.IsNullOrEmpty(newemail) ? "" : newemail;
            Handy = newhandy;
            Townplz = newtownplz;
            Strasse = string.IsNullOrEmpty(newstrasse) ? "" : newstrasse;
        }

        internal string Clear ()
        {
            Id = 0;
            Vorname = string.Empty;
            Nachname = string.Empty;
            Email = string.Empty;
            Handy = 0;
            Townplz = 0;
            Strasse = string.Empty;

            return "Cleared";
        }
    }
}
