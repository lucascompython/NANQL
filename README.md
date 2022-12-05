# NANQL (Not a Normal Query Language)

## What is NANQL?

NANQL is yet another simple (and quite normal) query language for json, that I made to learn better about parsers and F#.  
It's syntax is very declarative and easy to understand.  
Check the change log [here](CHANGELOG.md).

## Code Preview

```SQL
filterby Category = 'Fantasy'
orderby Rating asc
take 1
```

## How to get it

<!--You can get it from just cloning this repository and then running it (`dotnet run`).  
Or you can clone this repository and then install it globally as a dotnet package (`./install_globally.ps1`) and then just use `nanql`  
Or download the executable [here](https://github.com/lucascompython/NANQL/releases) and then you can just use that file.-->
Download the binary [here](https://github.com/lucascompython/NANQL/releases).  
OR  
Build it  

```pwsh
git clone https://github.com/lucascompython/NANQL.git
cd NANQL/NANQL
./build.ps1 -help
```

## How to use it
<!--
```powershell
# this example is using the files found in the NANQL directory
nanql quary.nanql data.json # use --help to see more details

# or with no arguments to input the query inside the program

# OUTPUT
{ Title = "The Fellowship of the Ring"
  Author = "J.R.R. Tolkien"
  Category = "Fantasy"
  PublishYear = 1954
  Rating = 4.36 }
```
-->
Check the [examples](https://github.com/lucascompython/NANQL/tree/master/Examples).

## TODOs

- [X] Add "interactive" mode
- [X] Add a binary release
- [X] Add support for building the project with powershell helper
- [ ] Add YAML support
- [ ] Documentation
- [ ] Add some more complex queries, for example let's say you have this piece of json: `[{"x": 2, "y": 0}, {"x": 3, "y": 1}, {"x": 4, "y": 1}]`, I wan't to add something like `SUM(X) WHERE Y > 0     (would equate to 7)` and `LIST(X) WHERE Y > 0    (would equate to [3,4])`

# LICENSE
This project is licensed under the GPL3 license.
