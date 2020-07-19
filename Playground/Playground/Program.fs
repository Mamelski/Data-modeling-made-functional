// Learn more about F# at http://fsharp.org

open System

let add1 x = + 1
let add2 x y = x + y

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    
    let add1res = add1 10
    let add2res = add2 10 10
    
    printf "%d %d" add1res add2res
    0 // return an integer exit code
