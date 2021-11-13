using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWBW
{
    public class Game
    {
        public int id;
        public string name;
        public Map map;
        public GameSettings settings;
        public GameBans bans;

        public bool isPrivate;
    }

    public struct Map
    {
        public int id;
        public string name;
        public int players;
        public MapCategory[] categories;

        public override bool Equals(object obj)
        {
            return id == ((Map)obj).id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(Map a, Map b)
        {
            return a.id == b.id;
        }

        public static bool operator !=(Map a, Map b)
        {
            return a.id != b.id;
        }
    }

    public class Account
    {
        internal string cookie, username, password;

        public Account(string phpsessid, string awbwusername, string awbwpassword)
        {
            cookie = $"PHPSESSID={phpsessid}; awbw_username={awbwusername}; awbw_password={awbwpassword}";
            username = awbwusername;
            password = awbwpassword;
        }
    }

    public struct User
    {
        public string username;

        public override bool Equals(object obj)
        {
            return username == ((User)obj).username;
        }

        public override int GetHashCode()
        {
            return username.GetHashCode();
        }

        public static bool operator ==(User a, User b)
        {
            return a.username == b.username;
        }

        public static bool operator !=(User a, User b)
        {
            return a.username != b.username;
        }
    }
}
