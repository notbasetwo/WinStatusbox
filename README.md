# Statusbox Windows Agent 
The Statusbox Windows agent is a Windows Service created in C# and targeting .NET Framework 4.8.1.
This service aims to provide information to a backend compatible with the Statusbox API Framework. The information collected about the system is done with WMI.

The agent currently uses no more than 30MB of RAM and a negligble amount of processor power. 

The agent should be considered beta software and not used in production.

## Configuration
You can set the API key, endpoint URL, endpoint ID and update interval (in seconds) in the WinStatusbox.exe.config file.

## Installation
Whilst a proper installer is currently under way, you can use the .NET Framework InstallUtil.exe - available in `%windir%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe`.

Uninstallation is possible with the same tool, just with the `/u` command line switch.

## Requirements
- .NET Framework 4.8.1
- Supported version of Microsoft Windows

## License
This software and the code in this repository are licensed under the [GNU General Public License v3](LICENSE.md).
