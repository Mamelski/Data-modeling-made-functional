// Learn more about F# at http://fsharp.org

let add1 x = x+1

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let addRes = add1(4)
    printfn "%d" addRes
    0 // return an integer exit code


