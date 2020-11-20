# Freedirect

[![continuous](https://github.com/lukaspieper/Freedirect/workflows/continuous/badge.svg)](https://github.com/lukaspieper/Freedirect/actions)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://github.com/lukaspieper/Freedirect/blob/master/LICENSE)

Freedirect aims to give you a little bit more control about your Windows 10 device. It redirects links targeting MS Edge to your
default browser. For example a common use case is the search field in the tastbar. By default it will open MS Edge and use Bing
as search engine. Freedirect does not only redirect to your default browser, it will also change the search engine to your
prefered one.

## About this project/repository/code ...

I originally created this tool in 2018. Due to the idea to make the code open source, I have rewritten and refactored large parts. The following technologies and techniques are used in the current state:

- WPF (.NET 5 with [nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references) enabled)
- MVVM ([Prism](https://github.com/prismlibrary))
- Unit Tests ([xUnit](https://github.com/xunit))
- [My personal build system with static code analysis and test coverage](https://github.com/lukaspieper/dotnet-build-system)
