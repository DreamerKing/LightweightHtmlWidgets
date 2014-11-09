# LightweightHtmlWidgets

## Introduction

LightweightHtmlWidgets is the successor of [gPyWk-environment](https://github.com/GameplayJDK/gPyWk-environment) on the Windows side. It is a HTML5 desktop framework for Windows. It depends on Awesomium.NET 1.7.4.2 and IronPython 1.7. Since they're available for Mono (which is available for OS X and Linux) as well, LightweightHtmlWidgets will possibly be ported to these platforms.

The main part of it is an Awesomium.NET webview, which is a port of the WebKit browser for .NET (and C++). The webview, api interface and winform can be customized through the universal `Settings.ini` file (please visit the [wiki page](https://github.com/GameplayJDK/LightweightHtmlWidgets/wiki/Settings.ini) for more information). The api interface is normally stored in `Ipy_Interface.py` and supports all standard modules from Python 1.7 (please visit the [wiki page](https://github.com/GameplayJDK/LightweightHtmlWidgets/wiki/Ipy_Interface.py) for more information). For publishing [InnoSetup](http://www.jrsoftware.org/isinfo.php) is recommended (please visit the [wiki page](https://github.com/GameplayJDK/LightweightHtmlWidgets/wiki/LightweightHtmlWidgets-v1.x-setup-x86t.iss) for more information).

## Features

* Detailed configuartion
* Fullfeatured WebKit (Awesomium) browser which can be customized to suite your applications requirements
* Asynchronous javascript-to-python bridge without needing a seperate `.js`

Planned features are:

* OS X and Linux support (depends on Mono compatibility; will take time, since the whole app has to be recreated)
* Custom ISS preset for easy packaging
* Icon customization

*You can submit feature requests using the github repository's [issue tracker](https://github.com/GameplayJDK/LightweightHtmlWidgets/issues).*

## Requirements

* [Dot Net Framework 4](http://www.microsoft.com/en-us/download/details.aspx?id=17718)
* Windows Vista SP2 / Windows 7 SP1 / Windows 8 / Windows 8.1

## Downloads

* v1.0 | 09.11.2014 | (recommended)
  * For testers: [Download exe installer](https://github.com/GameplayJDK/LightweightHtmlWidgets/raw/master/publish-rc/v1.0/LightweightHtmlWidgets-v1.0-setup-x86t.exe)
  * For devlopers: [Download 7z archive](https://github.com/GameplayJDK/LightweightHtmlWidgets/raw/master/publish-rc/v1.0/LightweightHtmlWidgets-v1.0-files-x86t.7z)

:heart: *[![Buy me a coffe](https://raw.githubusercontent.com/GameplayJDK/LightweightHtmlWidgets/master/buy-me-a-coffe.png "Buy me a coffe")](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=WMYAN6G9LE2LG)* :heart:

## Installation

* For testers:
  1. Start the installer
  2. Go through the installation
  3. Open the installation directory
  4. Start testing
* For developers:
  1. Extract the `.7z` file to a location of your choice
  2. Edit `Default.html` (for graphical enhancements), `Settings.ini` (for winform and browser customization) and `Ipy_Interface.py` (for api methods and functions)
  3. Test your application
  4. (Optional) Create an ISS installer using the `.iss` script preset

## Documentation

The wiki is temporarily used as documentation: [`https://github.com/GameplayJDK/LightweightHtmlWidgets/wiki`](https://github.com/GameplayJDK/LightweightHtmlWidgets/wiki)

## License

```
Copyright (C) 2014 GameplayJDK

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program. If not, see <http://www.gnu.org/licenses/>.
```
View full license [here](http://www.gnu.org/licenses/gpl.txt).