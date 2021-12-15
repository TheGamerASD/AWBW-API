using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWBW
{
    public class GameSettings
    {
        /// <summary>
        /// The weather in the game.
        /// </summary>
        public Weather weather = Weather.Clear;
        /// <summary>
        /// If fog of war is enabled or not.
        /// </summary>
        public bool fog = false;
        /// <summary>
        /// If CO powers are enabled or not.
        /// </summary>
        public bool coPowers = true;
        /// <summary>
        /// The funds gained per property per turn.
        /// </summary>
        public int fundsPerTurn = 1000;
        /// <summary>
        /// The funds each player gets at the start of the game.
        /// </summary>
        public int startingFunds = 0;
        /// <summary>
        /// The amount of properties a player needs to own to win.
        /// </summary>
        public int captureLimit = 1000;
        /// <summary>
        /// After the days limit is reached, the player who owns the most buildings wins.
        /// </summary>
        public int daysLimit = 0;
        /// <summary>
        /// The maximum amount of units a player can have at once.
        /// </summary>
        public int unitLimit = 50;
        /// <summary>
        /// The timer settings of the game.
        /// </summary>
        public TimerSettings timerSettings = new TimerSettings();
    }

    public class TimerSettings
    {
        /// <summary>
        /// The initial time all players start with.
        /// </summary>
        public int initialTime = 7;
        /// <summary>
        /// The amount of time given at the start of a player's turn.
        /// </summary>
        public int increment = 1;
        /// <summary>
        /// The maximum time a turn can last for.
        /// </summary>
        public int maxTurnTime = 7;
        /// <summary>
        /// The unit of time to use for the initial time.
        /// </summary>
        public TimeUnit initialTimeUnit = TimeUnit.Days;
        /// <summary>
        /// The unit of time to use for the increment.
        /// </summary>
        public TimeUnit incrementUnit = TimeUnit.Days;
        /// <summary>
        /// The unit of time to use for the max turn time.
        /// </summary>
        public TimeUnit maxTurnTimeUnit = TimeUnit.Days;

        /// <summary>
        /// Live play timer settings:
        /// 10 min. initial, 1 min. increment, 5 min. max.
        /// </summary>
        public static TimerSettings LivePlay
        {
            get => new()
            {
                initialTime = 10,
                initialTimeUnit = TimeUnit.Minutes,
                increment = 1,
                incrementUnit = TimeUnit.Minutes,
                maxTurnTime = 5,
                maxTurnTimeUnit = TimeUnit.Minutes
            };
        }

        /// <summary>
        /// Global league timer settings:
        /// 10 days initial, 2 days increment, 7 days max.
        /// </summary>
        public static TimerSettings GlobalLeague
        {
            get => new()
            {
                initialTime = 10,
                initialTimeUnit = TimeUnit.Days,
                increment = 2,
                incrementUnit = TimeUnit.Days,
                maxTurnTime = 7,
                maxTurnTimeUnit = TimeUnit.Days
            };
        }
    }

    public class GameBans
    {
        /// <summary>
        /// The COs which are banned.
        /// </summary>
        public CO[] bannedCOs = Array.Empty<CO>();
        /// <summary>
        /// The units which are banned.
        /// </summary>
        public Unit[] bannedUnits = Array.Empty<Unit>();
        /// <summary>
        /// The units which can only be built by players who own a lab.
        /// </summary>
        public Unit[] labUnits = Array.Empty<Unit>();
    }

    public class MapSearchFilters
    {
        public string name = "";
        public string creator = "";
        public int minPlayers = 2;
        public int maxPlayers = 16;
        public DateTime minFirstPublishedDate;
        public DateTime maxFirstPublishedDate;
        public DateTime minLastPublishedDate;
        public DateTime maxLastPublishedDate;
        public int minWidth;
        public int maxWidth;
        public int minHeight;
        public int maxHeight;

        public bool and = false;
        public MapCategory[] categories = Array.Empty<MapCategory>();
    }
}
