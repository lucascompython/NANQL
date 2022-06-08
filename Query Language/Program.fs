open Query
open System.Text.Json
open System


// PUT INSIDE THIS RECORD THE MEMBERS
type Things = {
    Title : string
    Author : string
    Category : string
    PublishYear : int
    Rating : float
}

let interpret lst result = 
    match result with
    | Result.Ok res ->
        let queryResult = execute res lst
        List.iter (fun i -> printfn "%O" i) queryResult
    | Result.Error err -> printfn "%O" err

[<EntryPoint>]
let main (args) = 
    
    if args.Length < 1 then
        printfn "No file was specified..."
    
    elif args.Length > 2 then
        printfn "Too many arguments were given..."

    elif Array.contains args[0] [| "-h" ; "--help" |] then
        printfn "This program expects two arguments, the first one being the NANQL file and the other being the json file."
    else
        
        printfn "Interpreting %A with %A" args[0] args[1]
        
        let reader = System.IO.File.ReadAllText(args[1])
        let jsonInput = JsonSerializer.Deserialize<Things list>(reader)
        
        let NANQLInput = System.IO.File.ReadAllText(args[0])


        
        NANQLInput |> parse |> interpret jsonInput

    0