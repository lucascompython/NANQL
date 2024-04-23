open Query
open System
open FSharp.Data

[<Literal>]
let VERSION = "0.2.0"


let interpret lst result = 
    match result with
    | Result.Ok res ->
        let queryResult = execute res lst
        List.iter (fun i -> printfn "%O" i) queryResult
    | Result.Error err -> printfn "%O" err

[<EntryPoint>]
let main (args) = 
    if args.Length >= 1 && Array.contains args[0] [| "--version"; "-v" |] then
        printfn "NANQL version %s" VERSION
        exit 0
    if args.Length < 1 then
        printfn "Interactive mode!"
        printf "Enter the json file to query: "
        let fileName: string = Console.ReadLine()
        let jsonInput = JsonValue.Load(fileName).AsArray() |> Array.toList
        
        let mutable inputs: string list = []
        let mutable Break = false
        while not Break do 
            printf "> "
            let input = Console.ReadLine()
            match input with
            | "/quit" -> Break <- true
            | "/clear" -> inputs <- []
            | "/run" -> 
                let NANQLInput = String.Join (Environment.NewLine, inputs)
                NANQLInput |> parse |> interpret jsonInput
                inputs <- []
            | "/help" -> printfn "Commands: /quit, /clear, /run, /help"
            | _ -> inputs <- input :: inputs

    
    elif args.Length > 2 then
        printfn "Too many arguments were given..."
        exit 1 

    elif Array.contains args[0] [| "-h" ; "--help" |] then
        printfn "Usage: nanql [NANQLQUERYFILE] [JSONFILE]\n  -h, --help\tShow this help message\n  -v, --version\tShow the version"
    else
        
        let jsonInput = JsonValue.Load(args[1]).AsArray() |> Array.toList
        
        let NANQLInput = System.IO.File.ReadAllText(args[0])

        NANQLInput |> parse |> interpret jsonInput

    0