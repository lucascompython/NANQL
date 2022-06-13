open Query
open System.Text.Json
open System


// CHANGE ONLY THE MEMBERS OF THIS TYPE
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
        printfn "Interactive mode!"
        printf "Enter the json file to query: "
        let fileName = Console.ReadLine()
        let reader = System.IO.File.ReadAllText(fileName)
        let jsonInput = JsonSerializer.Deserialize<Things list>(reader) 
        let mutable inputs: string list = []
        let mutable Break = false
        while not Break do 
            printf "> "
            let input = Console.ReadLine()
            if input = "" then 
                Break <- true
            inputs <- input :: inputs
        let NANQLInput = String.Join (Environment.NewLine, inputs)
        

        NANQLInput |> parse |> interpret jsonInput
    
    elif args.Length > 2 then
        printfn "Too many arguments were given..."

    elif Array.contains args[0] [| "-h" ; "--help" |] then
        printfn "This program expects two arguments, the first one being the NANQL file and the other being the json file. OR you can pass zero arguments to use 'interactive' mode."
    else
        
        printfn "Interpreting %A with %A" args[0] args[1]
        
        let reader = System.IO.File.ReadAllText(args[1])
        let jsonInput = JsonSerializer.Deserialize<Things list>(reader)
        
        let NANQLInput = System.IO.File.ReadAllText(args[0])


        
        NANQLInput |> parse |> interpret jsonInput

    0