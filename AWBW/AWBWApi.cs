﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Text.RegularExpressions;

namespace AWBW
{
    public class AWBWApi
    {
        private HttpClient client;

        public AWBWApi()
        {
            client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.All });
        }

        /// <summary>
        /// Create a public game.
        /// </summary>
        /// <param name="account">The account to use for creating the game.</param>
        /// <param name="name">The name of the game.</param>
        /// <param name="map">The map for the game.</param>
        /// <param name="comment">The description of the game.</param>
        /// <param name="gameSettings">The settings the game will use.</param>
        /// <param name="gameBans">The bans the game will use.</param>
        /// <returns>The game which has been created.</returns>
        public async Task<Game> CreateGame(Account account, string name, Map map, string comment, GameSettings gameSettings, GameBans gameBans) => await CreatePrivateGame(account, name, map, "", comment, gameSettings, gameBans);

        /// <summary>
        /// Create a private game.
        /// </summary>
        /// <param name="account">The account to use for creating the game.</param>
        /// <param name="name">The name of the game.</param>
        /// <param name="map">The map for the game.</param>
        /// <param name="password">The password of the game.</param>
        /// <param name="comment">The description of the game.</param>
        /// <param name="gameSettings">The settings the game will use.</param>
        /// <param name="gameBans">The bans the game will use.</param>
        /// <returns>The game which has been created.</returns>
        public async Task<Game> CreatePrivateGame(Account account, string name, Map map, string password, string comment, GameSettings gameSettings, GameBans gameBans)
        {
            if (name.Length > 40)
            {
                throw new ArgumentException($"Game name is {name.Length - 40} character{(name.Length - 40 == 1 ? "" : "s")} too long.");
            }

            List<(string key, string value)> pairs = new();

            pairs.AddRange(
                new[] {
                    ("game_name", name),
                    ("game_password", password),
                    ("comment", comment),
                    ("mapsID", map.id.ToString()),
                    ("weather", gameSettings.weather.ToString()),
                    ("fog", gameSettings.fog ? "Y" : "N"),
                    ("co_powers", gameSettings.coPowers ? "on" : "off"),
                    ("funds", gameSettings.fundsPerTurn.ToString()),
                    ("starting_funds", gameSettings.startingFunds.ToString()),
                    ("capture", gameSettings.captureLimit.ToString()),
                    ("days", gameSettings.daysLimit.ToString()),
                    ("unit_limit", gameSettings.unitLimit.ToString()),
                    ("initialclock", gameSettings.timerSettings.initialTime.ToString()),
                    ("unit_initial", gameSettings.timerSettings.initialTimeUnit.ToString().ToLower()),
                    ("increment", gameSettings.timerSettings.increment.ToString()),
                    ("unit_increment", gameSettings.timerSettings.incrementUnit.ToString().ToLower()),
                    ("maxturn", gameSettings.timerSettings.maxTurnTime.ToString()),
                    ("unit_maxturn", gameSettings.timerSettings.maxTurnTimeUnit.ToString().ToLower()),
                    ("create", "Create Game")
                }
            );

            foreach (CO co in gameBans.bannedCOs)
            {
                pairs.Add(new("main_co_ban[]", co.GetID()));
            }

            foreach (Unit unit in gameBans.bannedUnits)
            {
                pairs.Add(new("unit_ban[]", unit.AsString()));
            }

            foreach (Unit unit in gameBans.labUnits)
            {
                pairs.Add(new("lab_units[]", unit.AsString()));
            }

            HttpResponseMessage response = await client.HttpPost($"create.php?maps_id={map.id}", $"create.php?maps_id={map.id}", account.cookie, pairs.ToArray());
            string html = await response.Content.ReadAsStringAsync();
            string matchValue = Regex.Match(html, @"(?<='yourgames.php#game_)\d{5,7}(?=';)").Value;
            int gameID = int.Parse(matchValue);

            return new Game() { id = gameID, name = name, isPrivate = password != "", map = map, settings = gameSettings, bans = gameBans };
        }

        /// <summary>
        /// Create a public game with no players in it, similar to a Z-Game.
        /// Note that you cannot lab units and that the game will
        /// disappear if someone joins and the player count goes back down to 0.
        /// </summary>
        /// <param name="account">The account to use for creating the game.</param>
        /// <param name="name">The name of the game.</param>
        /// <param name="map">The map for the game.</param>
        /// <param name="comment">The description of the game.</param>
        /// <param name="gameSettings">The settings the game will use.</param>
        /// <param name="gameBans">The bans the game will use.</param>
        public async Task CreateEmptyGame(Account account, string name, Map map, string comment, GameSettings gameSettings, GameBans gameBans) => await CreatePrivateEmptyGame(account, name, map, "", comment, gameSettings, gameBans);

        /// <summary>
        /// Create a private game with no players in it, similar to a Z-Game.
        /// Note that you cannot lab units and that the game will
        /// disappear if someone joins and the player count goes back down to 0.
        /// </summary>
        /// <param name="account">The account to use for creating the game.</param>
        /// <param name="name">The name of the game.</param>
        /// <param name="map">The map for the game.</param>
        /// <param name="password">The password of the game.</param>
        /// <param name="comment">The description of the game.</param>
        /// <param name="gameSettings">The settings the game will use.</param>
        /// <param name="gameBans">The bans the game will use.</param>
        public async Task CreatePrivateEmptyGame(Account account, string name, Map map, string password, string comment, GameSettings gameSettings, GameBans gameBans)
        {
            if (name.Length > 40)
            {
                throw new ArgumentException($"Game name is {name.Length - 40} character{(name.Length - 40 == 1 ? "" : "s")} too long.");
            }

            List<(string key, string value)> pairs = new();

            pairs.AddRange(
                new[] {
                    ("game_name", name),
                    ("game_password", password),
                    ("comment", comment),
                    ("mapsID", map.id.ToString()),
                    ("weather", gameSettings.weather.ToString()),
                    ("fog", gameSettings.fog ? "Y" : "N"),
                    ("co_powers", gameSettings.coPowers ? "on" : "off"),
                    ("funds", gameSettings.fundsPerTurn.ToString()),
                    ("starting_funds", gameSettings.startingFunds.ToString()),
                    ("capture", gameSettings.captureLimit.ToString()),
                    ("days", gameSettings.daysLimit.ToString()),
                    ("unit_limit", gameSettings.unitLimit.ToString()),
                    ("initialclock", gameSettings.timerSettings.initialTime.ToString()),
                    ("unit_initial", gameSettings.timerSettings.initialTimeUnit.ToString().ToLower()),
                    ("increment", gameSettings.timerSettings.increment.ToString()),
                    ("unit_increment", gameSettings.timerSettings.incrementUnit.ToString().ToLower()),
                    ("maxturn", gameSettings.timerSettings.maxTurnTime.ToString()),
                    ("unit_maxturn", gameSettings.timerSettings.maxTurnTimeUnit.ToString().ToLower()),
                    ("create", "Create Game")
                }
            );

            foreach (CO co in gameBans.bannedCOs)
            {
                pairs.Add(new("main_co_ban[]", co.GetID()));
            }

            foreach (Unit unit in gameBans.bannedUnits)
            {
                pairs.Add(new("unit_ban[]", unit.AsString()));
            }

            pairs.Add(new("lab_units", "null"));

            await client.HttpPost($"create.php?maps_id={map.id}", $"create.php?maps_id={map.id}", account.cookie, pairs.ToArray());
        }

        /// <summary>
        /// Join a public game.
        /// </summary>
        /// <param name="account">The account to join the game with.</param>
        /// <param name="game">The game to join.</param>
        /// <param name="country">The country to join with.</param>
        /// <param name="co">The CO to join with./param>
        public async Task JoinGame(Account account, Game game, Country country, CO co)
        {
            List<(string key, string value)> pairs = new();

            pairs.AddRange(
                new[]
                {
                    ("games_id", $"{game.id}"),
                    ("countries_id", $"{country.GetID()}"),
                    ("co_id", $"{co.GetID()}"),
                    ("JOIN", $"Join"),
                }
            );

            await client.HttpPost("join.php", $"join.php?games_id={game.id}", account.cookie, pairs.ToArray());
        }

        /// <summary>
        /// Join a private game.
        /// </summary>
        /// <param name="account">The account to join the game with.</param>
        /// <param name="game">The game to join.</param>
        /// <param name="country">The country to join with.</param>
        /// <param name="co">The CO to join with./param>
        /// <param name="password">The password for the game.</param>
        public async Task JoinPrivateGame(Account account, Game game, Country country, CO co, string password)
        {
            List<(string key, string value)> pairs = new();

            pairs.AddRange(
                new[]
                {
                    ("games_id", game.id.ToString()),
                    ("countries_id", country.GetID().ToString()),
                    ("co_id", co.GetID().ToString()),
                    ("password", password),
                    ("JOIN", "Join"),
                }
            );

            await client.HttpPost("join.php", $"join.php?games_id={game.id}", account.cookie, pairs.ToArray());
        }

        /// <summary>
        /// Get a game from its ID.
        /// </summary>
        /// <param name="account">The account to use.</param>
        /// <param name="gameID">The ID of the game.</param>
        /// <returns>The game with the ID <paramref name="gameID"/>.</returns>
        public async Task<Game> GetGame(Account account, int gameID)
        {
            HttpResponseMessage response = await client.HttpGet($"join.php?games_id={gameID}", account.cookie);
            string html = await response.Content.ReadAsStringAsync();

            string gameName = Regex.Match(html, @"(?<=<span style=""display: block; float: left; padding-left: 2px;""><b><\/b><\/span>\n<span><b>).+?(?=<\/b><\/span>\n<\/div>)").Value;
            Map gameMap = await GetMap(int.Parse(Regex.Match(html, @"(?<=<img src=https:\/\/awbw\.amarriner\.com\/smallmaps\/)\d{5,7}(?=\.png border=1>)").Value));
            bool isPrivate = Regex.Match(html, @"(?<=<span class=small_text style=""display: inline-block; margin-top: 3px; vertical-align: top;""><b>Join )(Public|Private)(?= Game<\/b>)").Value == "Private";

            MatchCollection bannedCOMatches = Regex.Matches(html, @"(?<=<span class=small_text_strike>).+?(?=<\/span>)");
            MatchCollection bannedUnitMatches = Regex.Matches(html, @"(?<=<b>Banned:<\/b><\/span><\/td><td><img src=https:\/\/awbw\.amarriner\.com\/terrain\/.+?\/ge)(?<!Lab:.+?)\w+");
            MatchCollection labUnitMatches = Regex.Matches(html, @"(?<=<b>Lab:<\/b><\/span><\/td><td><img src=https:\/\/awbw\.amarriner\.com\/terrain\/.+?\/ge)\w+");

            List<CO> bannedCOs = new();
            List<Unit> bannedUnits = new();
            List<Unit> labUnits = new();

            foreach (string match in bannedCOMatches.ToList().ConvertAll(m => m.Value))
            {
                CO co = Enum.Parse<CO>(match.Replace(" ", ""), true);
                bannedCOs.Add(co);
            }

            foreach (string match in bannedUnitMatches.ToList().ConvertAll(m => m.Value))
            {
                Unit unit = default;

                foreach (Unit value in Enum.GetValues<Unit>())
                {
                    if (match == value.AsString().ToLower())
                    {
                        unit = value;
                        break;
                    }
                }

                bannedUnits.Add(unit);
            }

            foreach (string match in labUnitMatches.ToList().ConvertAll(m => m.Value))
            {
                Unit unit = default;

                foreach (Unit value in Enum.GetValues<Unit>())
                {
                    if (match == value.AsString().ToLower())
                    {
                        unit = value;
                        break;
                    }
                }

                labUnits.Add(unit);
            }

            GameBans gameBans = new GameBans() { bannedCOs = bannedCOs.ToArray(), bannedUnits = bannedUnits.ToArray(), labUnits = labUnits.ToArray() };

            string itunit = Regex.Match(html, @"(?<=<tr><td align=center style=""""><b>Initial<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="""">\d+ )\w+?(?=<\/span>\n<\/td>)").Value;
            itunit = itunit == "hr" ? "hour" : itunit;
            itunit = itunit.EndsWith("s") ? itunit : $"{itunit}s";
            string inunit = Regex.Match(html, @"(?<=<tr><td align=center style=""""><b>Increment<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="""">\d+ )\w+?(?=<\/span>\n<\/td>)").Value;
            inunit = inunit == "hr" ? "hour" : inunit;
            inunit = inunit.EndsWith("s") ? inunit : $"{inunit}s";
            string mttunit = Regex.Match(html, @"(?<=<tr><td align=center style=""""><b>Max Turn<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="""">\d+ )\w+?(?=<\/span>\n<\/td>)").Value;
            mttunit = mttunit == "hr" ? "hour" : mttunit;
            mttunit = mttunit.EndsWith("s") ? mttunit : $"{mttunit}s";

            TimerSettings timerSettings = new TimerSettings()
            {
                initialTime = int.Parse(Regex.Match(html, @"(?<=<tr><td align=center style=""""><b>Initial<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="""">)\d+(?= days<\/span>\n<\/td>)").Value),
                initialTimeUnit = Enum.Parse<TimeUnit>(itunit, true),
                increment = int.Parse(Regex.Match(html, @"(?<=<tr><td align=center style=""""><b>Increment<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="""">)\d+(?= \w+?<\/span>\n<\/td>)").Value),
                incrementUnit = Enum.Parse<TimeUnit>(inunit, true),
                maxTurnTime = int.Parse(Regex.Match(html, @"(?<=<tr><td align=center style=""""><b>Max Turn<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="""">)\d+(?= \w+?<\/span>\n<\/td>)").Value),
                maxTurnTimeUnit = Enum.Parse<TimeUnit>(mttunit, true),
            };

            bool fog = Regex.Match(html, @"(?<=<tr><td align=center style="".*?""><b>Fog<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="".*?"">)(On|Off)(?=<\/span>\n<\/td>)").Value == "On";
            Weather weather = Enum.Parse<Weather>(Regex.Match(html, @"(?<=<tr><td align=center style="".*?""><b>Weather<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="".*?"">)\w+?(?=<\/span>\n<\/td>)").Value, true);
            int funds = int.Parse(Regex.Match(html, @"(?<=<tr><td align=center style="".*?""><b>Funds<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="".*?"">)\d+?(?=<\/span>\n<\/td>)").Value);
            bool powers = Regex.Match(html, @"(?<=<tr><td align=center style="".*?""><b>Powers<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="".*?"">)(On|Off)(?=<\/span>\n<\/td>)").Value == "On";
            int startingFunds = int.Parse(Regex.Match(html, @"(?<=<tr><td align=center style="".*?""><b>Starting<\/b><\/td><\/tr>\n<tr>\n<td align=center><span class=small_text style="".*?"">)\d+?(?=G<\/span>\n<\/td>)").Value);
            string captureLimit = Regex.Match(html, @"title=""Capture Limit: (\d+|Off)""").Value;
            string daysLimit = Regex.Match(html, @"title=""Days Limit: (\d+|Off)""").Value;
            string unitLimit = Regex.Match(html, @"title=""Unit Limit: (\d+|Off)""").Value;
            int cLimit = captureLimit == "Off" ? 1000 : int.Parse(captureLimit);
            int dLimit = daysLimit == "Off" ? 0 : int.Parse(daysLimit);
            int uLimit = unitLimit == "Off" ? 5000 : int.Parse(unitLimit);

            GameSettings gameSettings = new GameSettings() { captureLimit = cLimit, coPowers = powers, daysLimit = dLimit, fog = fog, fundsPerTurn = funds, startingFunds = startingFunds, timerSettings = timerSettings, unitLimit = uLimit, weather = weather };

            return new Game() { id = gameID, name = gameName, map = gameMap, bans = gameBans, settings = gameSettings, isPrivate = isPrivate };
        }

        /// <summary>
        /// Delete a game.
        /// </summary>
        /// <param name="account">The account to delete the game with. You must be the creator of the game to delete it.</param>
        /// <param name="game">The game to delete.</param>
        public async Task DeleteGame(Account account, Game game)
        {
            await client.HttpGet($"yourgames.php?games_id={game.id}&action=reallydelete", account.cookie);
        }

        /// <summary>
        /// Get a user from their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The user with the username <paramref name="username"/>.</returns>
        public async Task<User> GetUser(string username)
        {
            HttpResponseMessage response = await client.HttpGet($"profile.php?username={username}");
            string html = await response.Content.ReadAsStringAsync();

            if (html.Contains("Invalid User!"))
            {
                throw new ArgumentException("User does not exist.");
            }
            else
            {
                return new User() { username = username };
            }
        }

        /// <summary>
        /// Get a map from its ID.
        /// </summary>
        /// <param name="mapID">The ID of the map.</param>
        /// <returns>The map with the ID <paramref name="mapID"/>.</returns>
        public async Task<Map> GetMap(int mapID)
        {
            HttpResponseMessage response = await client.HttpGet($"prevmaps.php?maps_id={mapID}");
            string html = await response.Content.ReadAsStringAsync();
            Console.WriteLine(html);

            string mapName = Regex.Match(html, @"(?<=<a class=bordertitle href=""prevmaps.php\?maps_id=\d{1,7}"">).+?(?=<\/a>)").Value;

            int mapPlayers = int.Parse(Regex.Match(html, @"(?<=First Published: \d{1,2}\/\d{1,2}\/\d{4} \|\| Players: )\d{1,2}(?= \|\| Size: \d{1,}x\d{1,})").Value);

            MatchCollection categoryMatches = Regex.Matches(html, @"(?<=<a href=""categories\.php\?categories_id=)\d{1,2}(?="">[\w-/ ]+?<\/a>)");

            List<MapCategory> categories = new();

            foreach (Match match in categoryMatches.ToArray())
            {
                categories.Add(Enum.Parse<MapCategory>(match.Value));
            }

            return new Map() { id = mapID, name = mapName, players = mapPlayers, categories = categories.ToArray() };
        }

        /// <summary>
        /// Get the 15 most recently published maps.
        /// </summary>
        /// <returns>An array of the most recently published maps.</returns>
        public async Task<Map[]> GetRecentMaps()
        {
            HttpResponseMessage response = await client.HttpGet($"recentmaps.php");
            string html = await response.Content.ReadAsStringAsync();

            List<Map> maps = new();

            MatchCollection idMatches = Regex.Matches(html, @"(?<=<a href=prevmaps.php\?maps_id=)\d{1,7}(?=>.+?<\/a>)");

            MatchCollection nameMatches = Regex.Matches(html, @"(?<=<a href=prevmaps.php\?maps_id=\d{1,7}>).+?(?=<\/a>)");

            MatchCollection playerMatches = Regex.Matches(html, @"(?<=<td  valign=top align=left>\n<span class=small_text>\nPlayers: )\d{1,2}(?=<br>)");

            for (int i = 0; i < idMatches.Count; i++)
            {
                MatchCollection categoryMatches = Regex.Matches(html.Split($"<b>{i + 1}.</b>")[1].Split($"<b>{i + 2}.</b>")[0], @"(?<=<a href=""categories\.php\?categories_id=)\d{1,2}(?="">[\w-/ ]+?<\/a>)");

                List<MapCategory> categories = new();

                foreach (Match match in categoryMatches.ToArray())
                {
                    categories.Add(Enum.Parse<MapCategory>(match.Value));
                }

                maps.Add(new Map() { id = int.Parse(idMatches[i].Value), name = nameMatches[i].Value, players = int.Parse(playerMatches[i].Value), categories = categories.ToArray() });
            }

            return maps.ToArray();
        }

        /// <summary>
        /// Get the maps created by a user.
        /// </summary>
        /// <param name="user">The user to get maps from.</param>
        /// <returns>An array of maps created by the user <paramref name="user"/>.</returns>
        public async Task<Map[]> GetUserMaps(User user)
        {
            HttpResponseMessage response = await client.HttpGet($"design_map.php?username={user.username}");
            string html = await response.Content.ReadAsStringAsync();

            List<Map> maps = new();

            MatchCollection idMatches = Regex.Matches(html, @"(?<=<a href=prevmaps.php\?maps_id=)\d{1,7}(?=>.+?<\/a>)");

            MatchCollection nameMatches = Regex.Matches(html, @"(?<=<a href=prevmaps.php\?maps_id=\d{1,7}>).+?(?=<\/a>)");

            MatchCollection playerMatches = Regex.Matches(html, @"(?<=<td  valign=top align=left>\n<span class=small_text>\nPlayers: )\d{1,2}(?=<br>)");

            for (int i = 0; i < idMatches.Count; i++)
            {
                MatchCollection categoryMatches = Regex.Matches(html.Split($"<b>{i + 1}.</b>")[1].Split($"<b>{i + 2}.</b>")[0], @"(?<=<a href=""categories\.php\?categories_id=)\d{1,2}(?="">[\w-/ ]+?<\/a>)");

                List<MapCategory> categories = new();

                foreach (Match match in categoryMatches.ToArray())
                {
                    categories.Add(Enum.Parse<MapCategory>(match.Value));
                }

                maps.Add(new Map() { id = int.Parse(idMatches[i].Value), name = nameMatches[i].Value, players = int.Parse(playerMatches[i].Value), categories = categories.ToArray() });
            }

            return maps.ToArray();
        }
    }
}
