# NANQL (Not a Normal Query Language)


## What is NANQL?

NANQL is yet another simple (and quit normal) query language for json, that I made to learn better about parsers and F#. <br />
It's syntax is very declarative and easy to understand (just like SQL).

## Code Preview

```NANQL
filterby Category = 'Fantasy'
orderby Rating asc
take 1
```

## How to use it

```powershell
git clone https://github.com/lucascompython/NANQL.git
cd "NANQL/Query Language"
dotnet run -- query.nanql data.json #use --help to see more details

#or with no arguments to input the query inside the program
#dotnet run --

# OUTPUT
{ Title = "The Fellowship of the Ring"
  Author = "J.R.R. Tolkien"
  Category = "Fantasy"
  PublishYear = 1954
  Rating = 4.36 }
```



## CAUTION

In this example, I'm using a Book's record with it's own member (look [here](Query%20Language/Program.fs#L7)), if you want to use a different "object", for now you need to change the Record in the Program.fs file.


## TODOs

- [X] Add "interactive" mode
- [ ] Add a binary release
- [ ] Polish the output
- [ ] Add some more complex queries, for example let's say you have this piece of json: `[{"x": 2, "y": 0}, {"x": 3, "y": 1}, {"x": 4, "y": 1}]`, I wan't to add something like `SUM(X) WHERE Y > 0     (would equate to 7)` and `LIST(X) WHERE Y > 0    (would equate to [3,4])`
- [ ] Making the act of change the type of the object easier.


# LICENSE

This project is licensed under the GPL3 license.