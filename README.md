# AWBW-API
A C# API for Advance Wars By Web.

### User Guide:

First, add this to your project:
```C#
using AWBW;
```

To use many of the API functions, you will need to create an `Account`.
To get the tokens required, look below:

<details>
  <summary>Mozilla Firefox</summary>
  
  1. Open [Advance Wars By Web](https://awbw.amarriner.com/).
  2. Log in to your account.
  3. Press F12.
  4. Open the Storage tab.
</details>
<details>
  <summary>Google Chrome</summary>
  
  1. Open [Advance Wars By Web](https://awbw.amarriner.com/).
  2. Log in to your account.
  3. Press F12.
  4. Open the Application tab.
  5. Expand the Cookies button under the Storage header.
  6. Click on the 'https://awbw.amarriner.com' button.
</details>

Here's how you can create an `Account` object:
```C#
Account account = new Account("PHPSESSID HERE", "awbw_username HERE", "awbw_password HERE");
```
Make sure to keep these tokens private, as anyone with them can control your account.

### Here are some examples of how to use the API:
<details>
  <summary>Create API</summary>
  
```C#
AWBWApi api = new AWBWApi();
```  
</details>

<details>
  <summary>Get A Map</summary>
  
```C#
// Get map with ID '12345'
Map map = await api.GetMap(12345);
```  
</details>

<details>
  <summary>Create A TimerSettings Object</summary>
  
```C#
TimerSettings timer = new TimerSettings()
{
  initialTime = 2,
  initialTimeUnit = TimeUnit.Hours,
  increment = 30,
  incrementUnit = TimeUnit.Minutes,
  maxTurnTime = 1,
  maxTurnTimeUnit = TimeUnit.Days
};
```  
</details>

<details>
  <summary>Create A GameSettings Object</summary>
  
```C#
GameSettings settings = new GameSettings()
{
  timerSettings = timer,
  daysLimit = 20,
  weather = Weather.Clear,
  fog = true
};
```  
</details>

<details>
  <summary>Create A GameBans Object</summary>
  
```C#
GameBans bans = new GameBans()
{
  bannedCOs = GameBans.GetBannedCOsFromTier(Tier.FogTier4),
  bannedUnits = new Unit[] { Unit.BlackBomb, Unit.Stealth },
  labUnits = new Unit[] { Unit.Neotank }
};
```  
</details>

<details>
  <summary>Create A Game</summary>
  
```C#
// Create a public game with the name 'Game Name' and description 'This is the description of the game.'
Game game = await api.CreateGame(account, "Game Name", map, "This is the description of the game.", settings, bans);
```  
</details>

#
I'm still working on new features, so any feedback is appreciated.
