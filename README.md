<img src="http://i.imgur.com/nDzId69.png" alt="Steam Basic Tools" title="SBT" align="right" height="60" />


Steam Basic Tools
======================

This program helps you to use Steam with awesome features!


## Index
- [Preview](#preview)
- [Download](#download)
- [Installation](#installation)
- [SBT setup](#setup)
    - [Configuration](#configuration)
    - [Dependencies](#dependencies)
- [Licenses](#Licenses)
- [Credits](#Credits)



## Preview
Screenshots of program:
<p align="center">
    <img src="https://image.prntscr.com/image/nIAwVg3kR-a1s_8erApQZQ.png" alt="Splash screen Steam Basic Tools" title="SBT" height="100" />
</p>


Steam Basic Tools          |  Steam Basic Tools
:-------------------------:|:-------------------------:
![](http://i.imgur.com/C5cuwwZ.png)  |  ![](http://i.imgur.com/XMIsmdD.png)
![](http://i.imgur.com/XMIsmdD.png)  |  ![](http://i.imgur.com/yXabDUD.png)

## Download
Just clone this repository:

```bash
$ git clone https://github.com/13dev/steam-basic-tools.git
```

## Installation

Just Run the solution(.sln) on IDE like Visual Studio 2015

## Configuration

For this program to work it needs to be configured.

### 1º Configure the **Configuration.cs**

```csharp
public const string WEB_API_KEY = "WEB_KEY_API_STEAM";
public const string CHECK_UPDATES_URL = "YOUR_UPDATE_XML_LINK";
public const string DB_CONNECTION =
    "Server=localhost;Database=database_name;Uid=username;Pwd=password_username";
public const string DB_TABLE = "TABLE_NAME";
//Remember put wildcard '%' to remote mysql
```
* **WEB_API_KEY**<br>
Get your api on: http://steamcommunity.com/dev/apikey.


* **CHECK_UPDATES_URL**<br>
This program have **AutoUpdader.NET**, so upload xml to your server/web-hosting, example:
    ```xml
    <?xml version="1.0" encoding="UTF-8"?>
    <item>
        <version>1.0.0.8</version>
        <url>http://site.com/versions/Release.zip</url>
        <changelog>http://site.com/changelog.html</changelog>
    </item>
    ```
    And you just need to enter the url of the xml to **CHECK_UPDATES_URL**, ex:

    ```csharp
    public const string CHECK_UPDATES_URL = "http://site.com/update.xml";
    ```
    For more information access: https://github.com/ravibpatel/AutoUpdater.NET
    
* **DB_CONNECTION**<br>

    Configure according to your needs
    Example of table:
    ```
    +----+-----------------+--------------------+---------------------+----------------+
    | id |      name       |      steamid       |        date         |       ip       |
    +----+-----------------+--------------------+---------------------+----------------+
    |  1 | 13 Developer ~~ | STEAM_0:1:98891213 | 2017-08-04 14:29:05 | 188.222.111.33 |
    |  2 | PlayerName      | STEAM_0:1:12345678 | 2017-08-04 14:49:15 | 292.212.114.33 |
    +----+-----------------+--------------------+---------------------+----------------+
    ```
    More info here: https://stackoverflow.com/questions/21618015/how-to-connect-to-mysql-database
    
* **DB_TABLE**<br>
    Just the name of your table.

## Dependencies

This repository needs 2 dependencies.
* **Steam4NET**
    Download, and build, copy dll and add it as a reference: https://github.com/SteamRE/Steam4NET
    
* **AutoUpdate.NET**
    This project is already included because I edited it, to know how it works access: https://github.com/ravibpatel/AutoUpdater.NET

* **Newtonsoft.Json**
    Download, and build, copy dll and add it as a reference: https://github.com/JamesNK/Newtonsoft.Json

## Licenses

* **Steam4NET**

    Steam4NET  is [Unlicensed](http://unlicense.org/) (?).
    
* **AutoUpdate.NET**
    
    AutoUpdate.NET is licensed under MIT: https://opensource.org/licenses/MIT

* **Newtonsoft.Json**
    
     Newtonsoft.Json is licensed under MIT: https://github.com/JamesNK/Newtonsoft.Json
     
## Credits

* Thanks to [Simple Line Icons](http://simplelineicons.com) for the status image.
* Thanks to [@SteamRE](https://github.com/SteamRE) for the steam4NET.

