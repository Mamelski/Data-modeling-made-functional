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
    

[<EntryPoint>]
let main argv =
    
    for fn in listOfFunctions do
        let result = fn 5
        printfn "Result is %A" result
    0 // return an integer exit code
