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
        /// <summary>
        /// The usernames of the players in the game.
        /// </summary>
        public Player[] players;
    }

    public struct Player
    {
        public string username;
        public bool hasLost;
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

    public class BrowserAccount
    {
        internal string cookie;

        /// <summary>
        /// See https://github.com/TheGamerASD/AWBW-API/blob/main/README.md for how to create an account.
        /// </summary>
        /// <param name="phpsessid">Your PHPSESSID cookie.</param>
        /// <param name="awbwpassword">Your password cookie. It should start with a % sign.</param>
        public BrowserAccount(string phpsessid, string awbwpassword)
        {
            cookie = $"PHPSESSID={phpsessid}; awbw_password={awbwpassword}";
        }
    }

    public struct User
    {
        /// <summary>
        /// The username of the user.
        /// </summary>
        public string username;

        /// <summary>
        /// The global league rating of the user.
        /// </summary>
        public decimal elo;

        /// <summary>
        /// The number of global league games the user has won.
        /// </summary>
        public int leagueWins;

        /// <summary>
        /// The number of global league games the user has lost.
        /// </summary>
        public int leagueLosses;

        /// <summary>
        /// The number of global league games the user has drawed.
        /// </summary>
        public int leagueDraws;

        /// <summary>
        /// The number of global league games the user has completed.
        /// </summary>
        public int leagueMatches
        {
            get => leagueWins + leagueLosses + leagueDraws;
        }

        /// <summary>
        /// The number of games this user has played.
        /// </summary>
        public int totalGames;

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

        public TierList(IEnumerable<IEnumerable<CO>> coTiers)
        {
            this.coTiers = coTiers.ToList().ConvertAll(tier => tier.ToArray()).ToArray();
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
