module Playground.Chapter5

type CustomerId = CustomerId of int
type WidgetCode = WidgetCode of string
type UnitQuantity = UnitQuantity of int
type KilogramQuantity = KilogramQuantity of decimal

let customerId = CustomerId 42

let processCustomerId (CustomerId innerValue) =
    printf "%A" innerValue

[<EntryPoint>]
let main argv =

    processCustomerId customerId
    
    0 // return an integer exit code
