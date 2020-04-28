# Lingu:
## The **lingu**istic language.


### Syntax
Lingu features verbose syntax, static typing, and is strongly typed.

> Every line ends with a `.`

> Every line starts with a keyword.

> Any kind of string value must be wrapped with quotes (`""`).
> This includes variable names and values.

> Comments start with a hashtag (`#`).

> Lots and lots of syntactic sugar.

### Example
Here we will provide an example:
#### Source
```
# A comment in Lingu
Output "Defining variables..." to Console.
New string of name "sampleStringVar" with value "sample".
Output "enter your name:" to Console.
Get input and store in "sampleStringVar".
Output the value of variable "sampleStringVar" to Console.
```
#### Output
```
Defining variables...
enter your name:
(austin)
austin
```

### Dependencies

#### Development
[.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) <br>
[Visual Studio 2019 v16.6+](https://visualstudio.microsoft.com/vs/preview/) <br>
(as of May 1st, if you don't have the Preview, you don't have 16.6)

#### Runtime
(for Windows) [.NET 5 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/5.0) <br>
(for MacOS/Linux) Coming soon...

### Shenanigans
The `LinguLib.dll` file must be in the same directory as the executable.
