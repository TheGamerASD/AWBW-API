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
        /// The creator of the map.
        /// </summary>
        public string creator;
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

    public struct MapData
    {
        public string data;
    }

    public class TierList
    {
        CO[][] coTiers;

        public static TierList Std
        {
            get => new(new[] { CO.Colin, CO.Grit, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei, CO.Sturm }, new[] { CO.Hawke, CO.Javier, CO.Sasha, CO.VonBolt }, new[] { CO.Eagle, CO.Max, CO.Olaf, CO.Sami }, new[] { CO.Andy, CO.Drake, CO.Kindle, CO.Lash, CO.Rachel }, Array.Empty<CO>());
        }

        public static TierList Fog
        {
            get => new(new[] { CO.Colin, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei }, new[] { CO.Grit, CO.Hawke, CO.Javier, CO.Sasha, CO.Sturm, CO.VonBolt }, new[] { CO.Eagle, CO.Max, CO.Olaf }, new[] { CO.Sonja, CO.Andy, CO.Drake, CO.Kindle, CO.Lash, CO.Rachel }, Array.Empty<CO>());
        }

        public static TierList HF
        {
            get => new(new[] { CO.Colin, CO.Hachi, CO.Nell }, new[] { CO.Eagle, CO.Hawke, CO.Kanbei, CO.Olaf, CO.Sensei }, new[] { CO.Andy, CO.Drake, CO.Flak, CO.Javier, CO.Jugger, CO.Max, CO.Rachel, CO.Sasha, CO.Sturm, CO.VonBolt }, Array.Empty<CO>());
        }

        public TierList(params CO[][] coTiers)
        {
            this.coTiers = coTiers;
        }

        public int GetTiers()
        {
            return coTiers.Length;
        }

        /// <summary>
        /// Gets the COs which should be banned for a tier in this tierlist.
        /// </summary>
        /// <param name="tier">The tier to get the banned COs from.</param>
        /// <returns>An array of COs.<returns>
        public CO[] this[int tier]
        {
            get
            {
                if (tier >= GetTiers())
                {
                    throw new IndexOutOfRangeException("Tier does not exist in tierlist.");
                }

                List<CO> bannedCOs = new();

                for (int i = tier - 1; i >= 0; i--)
                {
                    bannedCOs.AddRange(coTiers[i]);
                }

                return bannedCOs.ToArray();
            }
        }
    }
}
