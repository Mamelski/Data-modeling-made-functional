module Playground.Chapter7

open System

type UnvalidatedCustomerInfo = Udefined
type UnvalidatedAddress = Udefined

type UnvalidatedOrder = {
    OrderId: string
    CustomerInfo: UnvalidatedCustomerInfo
    ShippingAddress: UnvalidatedAddress
}

type Command<'a> = {
    Data: 'a
    TimeStamp: DateTime
    UserId: Guid
}

type PlacedOrder = Command<UnvalidatedOrder>
    
    
[<EntryPoint>]
let main argv =
    0 // return an integer exit code
