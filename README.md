# Freedirect

Freedirect aims to give you a little bit more control about your Windows 10 device. It redirects links targeting MS Edge to your default browser. For example a common use case is the search field in the tastbar. By default it will open MS Edge and use Bing as search engine. Freedirect does not only redirect to your default browser, it will also change the search engine to your prefered one.

## About this project/repository/code ...

I created this tool back in 2018. While I definitifly could have done it better at that time, I decided to just get it working. Honestly even from today's point of view this tool is simple and small enough that it does not need a fancy clean architecture, MVVM, etc. Properly it is already overengineered in some places. Nevertheless, when I decided to make it open source, I thought about refactoring the project to best practise. And here we go.

I plan to implement the following things:
* .net Core 3.1 instead of .net Framework
* MVVM (with Prism or MVVM Light)
* Unit Tests (likely NUnit)
* Build system (likely Nuke.Build) with GitHub Actions
* Finishing started (additional) features
* Refactoring existing code
* ...
