# NANQL (Not a Normal Query Language)


## What is NANQL?

NANQL is a simple query language for json, that I made to learn better about parsers and F#. <br />
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
dotnet run -- query.nanql data.json
```



## CAUTION

In this example, I'm using a Book's record with it's own member (look [here](Query%20Language/Program.fs#L9)), if you want to use a different "object", for now you need to change the Record in the Program.fs file.


## TODOs

- [ ] Polish the output
- [ ] Add some more complex queries, for example let's say you have this piece of json: `[{"x": 2, "y": 0}, {"x": 3, "y": 1}, {"x": 4, "y": 1}]`, I wan't to add something like `SUM(X) WHERE Y > 0     (would equate to 7)` and `LIST(X) WHERE Y > 0    (would equate to [3,4])`
- [ ] Making the act of change the type of the object easier.


# LICENSE

This project is licensed under the GPL3 license.