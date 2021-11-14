using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWBW
{
    public class Game
    {
        /// <summary>
        /// The ID of the game.
        /// </summary>
        public int id;
        /// <summary>
        /// The name of the game.
        /// </summary>
        public string name;
        /// <summary>
        /// The map the game is on.
        /// </summary>
        public Map map;
        /// <summary>
        /// The settings the game uses.
        /// </summary>
        public GameSettings settings;
        /// <summary>
        /// The bans the game uses.
        /// </summary>
        public GameBans bans;

        /// <summary>
        /// If the game has a password or not.
        /// </summary>
        public bool isPrivate;
    }

    public struct Map
    {
        /// <summary>
        /// The ID of the map.
        /// </summary>
        public int id;
        /// <summary>
        /// The name of the map.
        /// </summary>
        public string name;
        /// <summary>
        /// The amount of players on the map.
        /// </summary>
        public int players;
        /// <summary>
        /// An array of the categories the map has.
        /// </summary>
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

        /// <summary>
        /// See https://github.com/TheGamerASD/AWBW-API/blob/main/README.md for how to create an account.
        /// </summary>
        /// <param name="phpsessid">Your PHPSESSID cookie.</param>
        /// <param name="awbwusername">Your username cookie.</param>
        /// <param name="awbwpassword">Your password cookie. It should start with a % sign.</param>
        public Account(string phpsessid, string awbwusername, string awbwpassword)
        {
            cookie = $"PHPSESSID={phpsessid}; awbw_username={awbwusername}; awbw_password={awbwpassword}";
            username = awbwusername;
            password = awbwpassword;
        }
    }

    public struct User
    {
        /// <summary>
        /// The username of the user.
        /// </summary>
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
