using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWBW
{
    public class GameSettings
    {
        public Weather weather = Weather.Clear;
        public bool fog = false;
        public bool coPowers = true;
        public int fundsPerTurn = 1000;
        public int startingFunds = 0;
        public int captureLimit = 1000;
        public int daysLimit = 0;
        public int unitLimit = 50;
        public TimerSettings timerSettings = new TimerSettings();
    }

    public class TimerSettings
    {
        public int initialTime = 7, increment = 1, maxTurnTime = 7;
        public TimeUnit initialTimeUnit = TimeUnit.Days, incrementUnit = TimeUnit.Days, maxTurnTimeUnit = TimeUnit.Days;

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
        public CO[] bannedCOs = Array.Empty<CO>();
        public Unit[] bannedUnits = Array.Empty<Unit>();
        public Unit[] labUnits = Array.Empty<Unit>();

        public static CO[] GetBannedCOsFromTier(Tier tier)
        {
            return tier switch
            {
                Tier.StdTier1 => new[] { CO.Colin, CO.Grit, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei, CO.Sturm },
                Tier.StdTier2 => new[] { CO.Colin, CO.Grit, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei, CO.Sturm, CO.Hawke, CO.Javier, CO.Sasha, CO.VonBolt },
                Tier.StdTier3 => new[] { CO.Colin, CO.Grit, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei, CO.Sturm, CO.Hawke, CO.Javier, CO.Sasha, CO.VonBolt, CO.Eagle, CO.Max, CO.Olaf, CO.Sami },
                Tier.StdTier4 => new[] { CO.Colin, CO.Grit, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei, CO.Sturm, CO.Hawke, CO.Javier, CO.Sasha, CO.VonBolt, CO.Eagle, CO.Max, CO.Olaf, CO.Sami, CO.Andy, CO.Drake, CO.Kindle, CO.Lash, CO.Rachel },
                Tier.FogTier1 => new[] { CO.Colin, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei },
                Tier.FogTier2 => new[] { CO.Colin, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei, CO.Grit, CO.Hawke, CO.Javier, CO.Sasha, CO.Sturm, CO.VonBolt },
                Tier.FogTier3 => new[] { CO.Colin, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei, CO.Grit, CO.Hawke, CO.Javier, CO.Sasha, CO.Sturm, CO.VonBolt, CO.Eagle, CO.Max, CO.Olaf },
                Tier.FogTier4 => new[] { CO.Colin, CO.Hachi, CO.Kanbei, CO.Nell, CO.Sensei, CO.Grit, CO.Hawke, CO.Javier, CO.Sasha, CO.Sturm, CO.VonBolt, CO.Eagle, CO.Max, CO.Olaf, CO.Sonja, CO.Andy, CO.Drake, CO.Kindle, CO.Lash, CO.Rachel },
                Tier.HFTier1 => new[] { CO.Colin, CO.Hachi, CO.Nell },
                Tier.HFTier2 => new[] { CO.Colin, CO.Hachi, CO.Nell, CO.Eagle, CO.Hawke, CO.Kanbei, CO.Olaf, CO.Sensei },
                Tier.HFTier3 => new[] { CO.Colin, CO.Hachi, CO.Nell, CO.Eagle, CO.Hawke, CO.Kanbei, CO.Olaf, CO.Sensei, CO.Andy, CO.Drake, CO.Flak, CO.Javier, CO.Jugger, CO.Max, CO.Rachel, CO.Sasha, CO.Sturm, CO.VonBolt },
                _ => throw new ArgumentException("Invalid tier.")
            };
        }
    }
}
