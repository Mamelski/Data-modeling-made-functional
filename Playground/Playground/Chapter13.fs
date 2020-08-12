module Playground.Chapter13

type Address = {
    State : string
    Country : string
}
type ValidatedOrder = {
    ShippingAddress : Address
    }

let (|UsLocalState|UsRemoteState|International|) address = 
    if address.Country = "US" then
        match address.State with
        | "CA" | "OR" | "AZ" | "NV" -> 
            UsLocalState
        | _ -> 
            UsRemoteState
    else
        International
            
let calculateShippingCost validatedOrder = 
    match validatedOrder.ShippingAddress with
    | UsLocalState -> 5.0
    | UsRemoteState -> 10.0
    | International -> 20.0

[<EntryPoint>]
let main argv =
    
    0 // return an integer exit code
