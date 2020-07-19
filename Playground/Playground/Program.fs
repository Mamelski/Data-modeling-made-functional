// Learn more about F# at http://fsharp.org

open System

let add1 x = + 1
let add2 x y = x + y

let squarePlusOne x =
    let square = x * x
    square + 1
    
let equal x y=
    x = y

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    
    let add1res = add1 10
    let add2res = add2 10 10
    
    printfn "%d %d" add1res add2res
    
    let res = squarePlusOne 10
    printfn "%d" res
    0 // return an integer exit code
