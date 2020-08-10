module Playground.Chapter11

open Newtonsoft.Json

let serialize obj =
    JsonConvert.SerializeObject obj
    
let deserialize<'a> str =
    try
        JsonConvert.DeserializeObject<'a> str
        |> Result.Ok
    with
    | ex -> Result.Error ex
    
[<EntryPoint>]
let main argv =
    
    0 // return an integer exit code
