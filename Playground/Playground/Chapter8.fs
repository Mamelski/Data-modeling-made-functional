module Playground.Chapter8

// Functionas are things
let plus3 x = x + 3
let times2 x = x * 2
let square = (fun x -> x * x)
let add3 = plus3

let listOfFunctions =
    [plus3;
     times2;
     square]
    
let evalWith6AndAdd1 fn =
    fn(6) + 1
    
//Partial application
let sayGreeting greeting name =
    printfn "%s %s" greeting name

let saySiema =
    sayGreeting "siema"
    
//Piping
let add3ThenSquare x =
    x |> add3 |> square

[<EntryPoint>]
let main argv =
    
    for fn in listOfFunctions do
        let result = fn 5
        printfn "Result is %A" result
        
    let res = evalWith6AndAdd1 square
    printfn "Result is %A" res
    
    saySiema "Jakub"
    
    let res2 = add3ThenSquare 2
    printfn "Result is %A" res2
    
    0 // return an integer exit code
