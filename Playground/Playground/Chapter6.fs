
module Playground.Chapter6

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
    

[<EntryPoint>]
let main argv =
    let u = UnitQuantity 10
    printfn "%A" u
    0 // return an integer exit code
