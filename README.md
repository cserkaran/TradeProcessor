# TradeProcessor
A simple app to process trade objects in text stream and create them in the database.
# Summary
The idea is to split into mutliple layers to distribute the logic. The layers are : 
- Infrastrucure Layer
- Business Logic Layer
- Repository/Data Layer.
- User interface

The app is designed to be as extensible as possible e.g. try to avoid hard-code instatiation of the object. Using MEF as dependency injection framework
to supply/inject the dependencies.
For example, the Logger is injectable and rest of the app works with ILogger. The concrete implmentation, TextLogger in case is injected.It allows us to 
replace TextLogger with say, Console Logger or some other type of logger in the future. We only need to write this new implementation(say ConsoleLogger).
The rest of the app needs unchanged and does not care about the concrete implementation.

The infrastructure layer(TradeProcessor.Infrastructure) defines the common extensibility constructs used to make full use of MEF.
