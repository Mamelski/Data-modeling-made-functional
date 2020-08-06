
module Playground.Chapter6

open Microsoft.VisualBasic
open Playground.Chapter6.Module1

module Module1 =
    type UnitQuantity = private UnitQuantity of int

    module UnitQuantity =
        let create qty =
            if qty < 1 then
                Error "Unit quantity must be positive."
            else if qty > 1000 then
                Error "Unit quantity cant be more than 1000"
            else
                Ok (UnitQuantity qty)
        let value (UnitQuantity qty) = qty
    
module Module2 =
    //let value = UnitQuantity 1
    
    let unitQty = Module1.UnitQuantity.create 1
    
    match unitQty with
    | Error msg ->
        printfn "Failure. Error is %A" msg
    | Ok Qty ->
        printfn "Ok, value is %A" Qty
    
    

[<EntryPoint>]
let main argv =
    0 // return an integer exit code
