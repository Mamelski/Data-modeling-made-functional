module Playground.Chapter10


let bind switchFn =
    fun twoTrackInput ->
        match twoTrackInput with
        | Ok success -> switchFn success
        | Error failure -> Error failure
        
// Ładniej    
let bind2 switchFn twoTrackInput =
    match twoTrackInput with
        | Ok success -> switchFn success
        | Error failure -> Error failure
        
let map f aResult =
    match aResult with
    | Ok success -> Ok (f success)
    | Error failure -> Error failure

[<EntryPoint>]
let main argv =
    
    0 // return an integer exit code
