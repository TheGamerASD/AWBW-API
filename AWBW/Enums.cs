using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWBW
{
    internal static class EnumExtensions
    {
        public static string AsString(this Unit unit)
        {
            return unit switch
            {
                Unit.Infantry => "Infantry",
                Unit.Mech => "Mech",
                Unit.Recon => "Recon",
                Unit.TCopter => "T-Copter",
                Unit.APC => "APC",
                Unit.Artillery => "Artillery",
                Unit.Tank => "Tank",
                Unit.BlackBoat => "Black Boat",
                Unit.AntiAir => "Anti-Air",
                Unit.BCopter => "B-Copter",
                Unit.Missile => "Missile",
                Unit.Lander => "Lander",
                Unit.Rocket => "Rocket",
                Unit.MdTank => "Md.Tank",
                Unit.Cruiser => "Cruiser",
                Unit.Fighter => "Fighter",
                Unit.Piperunner => "Piperunner",
                Unit.Sub => "Sub",
                Unit.Neotank => "Neotank",
                Unit.Bomber => "Bomber",
                Unit.Stealth => "Stealth",
                Unit.BlackBomb => "Black Bomb",
                Unit.Battleship => "Battleship",
                Unit.MegaTank => "Mega Tank",
                Unit.Carrier => "Carrier",
                _ => throw new ArgumentException("Invalid unit type.")
            };
        }

        public static string AsString(this MapCategory category)
        {
            return category switch
            {
                MapCategory.SRank => "S-Rank",
                MapCategory.ARank => "A-Rank",
                MapCategory.CasualPlay => "Casual Play",
                MapCategory.New => "New",
                MapCategory.GlobalLeague => "Global League",
                MapCategory.UnderReview => "Under Review",
                MapCategory.HallOfFame => "Hall of Fame",
                MapCategory.HistoricalGeographical => "Historical/Geographical",
                MapCategory.Joke => "Joke",
                MapCategory.Sprite => "Sprite",
                MapCategory.ToyBox => "Toy-Box",
                MapCategory.BaseLight => "Base Light",
                MapCategory.FogOfWar => "Fog of War",
                MapCategory.HeavyNaval => "Heavy Naval",
                MapCategory.HighFunds => "High Funds",
                MapCategory.Innovative => "Innovative",
                MapCategory.LivePlay => "Live Play",
                MapCategory.LimitedHighFunds => "Limited High Funds",
                MapCategory.MixedBase => "Mixed Base",
                MapCategory.TeleportTile => "Teleport Tile",
                MapCategory.FFAMultiplay => "FFA Multiplay",
                MapCategory.TeamPlay => "Team Play",
                _ => throw new ArgumentException("Invalid map category.")
            };
        }

        public static string GetID(this CO co)
        {
            return ((int)co).ToString();
        }

        public static string GetID(this Country country)
        {
            return ((int)country).ToString();
        }

        public static string GetID(this MapCategory category)
        {
            return ((int)category).ToString();
        }

        public static string GetID(this MapSortCriteria sortCriteria)
        {
            return sortCriteria switch
            {
                MapSortCriteria.MapName => "lower_name",
                MapSortCriteria.Creator => "users_username",
                MapSortCriteria.Players => "maps_players",
                MapSortCriteria.FirstPublished => "maps_first_published_date",
                MapSortCriteria.LastPublished => "maps_published_date",
                MapSortCriteria.MapWidth => "max_x",
                MapSortCriteria.MapHeight => "max_y",
                _ => throw new ArgumentException("Invalid sort criteria.")
            };
        }

        public static int AsInt(this Tier tier)
        {
            return tier switch
            {
                Tier.StdTier1 => 1,
                Tier.StdTier2 => 2,
                Tier.StdTier3 => 3,
                Tier.StdTier4 => 4,
                Tier.FogTier1 => 1,
                Tier.FogTier2 => 2,
                Tier.FogTier3 => 3,
                Tier.FogTier4 => 4,
                Tier.HFTier1 => 1,
                Tier.HFTier2 => 2,
                Tier.HFTier3 => 3,
                _ => throw new ArgumentException("Invalid tier.")
            };
        }
    }

    public enum GameState
    {
        NotStarted,
        InProgress,
        Ended
    }

    public enum Weather
    {
        Clear,
        Snow,
        Rain,
        Random
    }

    public enum TimeUnit
    {
        Minutes,
        Hours,
        Days
    }

    public enum Tier
    {
        StdTier1,
        StdTier2,
        StdTier3,
        StdTier4,
        FogTier1,
        FogTier2,
        FogTier3,
        FogTier4,
        HFTier1,
        HFTier2,
        HFTier3
    }

    public enum GameType
    {
        Standard,
        FogOfWar,
        HighFunds
    }

    public enum CO
    {
        Colin = 15,
        Grit = 2,
        Hachi = 17,
        Kanbei = 3,
        Nell = 24,
        Sensei = 13,
        Sturm = 29,
        Hawke = 12,
        Javier = 27,
        Sasha = 19,
        VonBolt = 30,
        Eagle = 10,
        Max = 7,
        Olaf = 9,
        Sami = 8,
        Andy = 1,
        Drake = 5,
        Kindle = 23,
        Lash = 16,
        Rachel = 28,
        Adder = 11,
        Flak = 25,
        Grimm = 20,
        Jake = 22,
        Jess = 14,
        Jugger = 26,
        Koal = 21,
        Sonja = 18
    }

    public enum Unit
    {
        Infantry,
        Mech,
        Recon,
        TCopter,
        APC,
        Artillery,
        Tank,
        BlackBoat,
        AntiAir,
        BCopter,
        Missile,
        Lander,
        Rocket,
        MdTank,
        Cruiser,
        Fighter,
        Piperunner,
        Sub,
        Neotank,
        Bomber,
        Stealth,
        BlackBomb,
        Battleship,
        MegaTank,
        Carrier
    }

    public enum Country
    {
        OrangeStar = 1,
        BlueMoon = 2,
        GreenEarth = 3,
        YellowComet = 4,
        BlackHole = 5,
        RedFire = 6,
        GreySky = 7,
        BrownDesert = 8,
        AmberBlaze = 9,
        JadeSun = 10,
        CobaltIce = 16,
        PinkCosmos = 17,
        TealGalaxy = 19,
        PurpleLightning = 20,
        AcidRain = 21,
        WhiteNova = 22
    }

    public enum MapCategory
    {
        SRank = 25,
        ARank = 22,
        CasualPlay = 38,
        New = 23,
        GlobalLeague = 26,
        UnderReview = 10,
        HallOfFame = 32,
        HistoricalGeographical = 19,
        Joke = 4,
        Sprite = 5,
        ToyBox = 14,
        BaseLight = 30,
        FogOfWar = 34,
        HeavyNaval = 28,
        HighFunds = 33,
        Innovative = 35,
        LivePlay = 40,
        LimitedHighFunds = 39,
        MixedBase = 31,
        TeleportTile = 27,
        FFAMultiplay = 13,
        TeamPlay = 12
    }

    public enum MapSortCriteria
    {
        MapName,
        Creator,
        Players,
        FirstPublished,
        LastPublished,
        MapWidth,
        MapHeight
    }
}
