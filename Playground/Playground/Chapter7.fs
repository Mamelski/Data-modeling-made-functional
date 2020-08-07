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

 type ProductCode = Undefined

// Coś jak interfejs w sumie albo abstrakcyjna metoda
type CheckProductCodeExists = 
    ProductCode -> bool

type Address = Undefined

type CheckedAddress = CheckedAddress of UnvalidatedAddress
type AddressValidationError = AddressValidationError of string

type CheckAddressExists = 
    UnvalidatedAddress -> Result<CheckedAddress,AddressValidationError>
    // ^input                    ^output

type ValidatedOrder = Undefined
type ValidationError = Undefined

type ValidateOrder = 
    CheckProductCodeExists    // dependency
      -> CheckAddressExists   // dependency
      -> UnvalidatedOrder     // input
      -> Result<ValidatedOrder,ValidationError>  // output
    
[<EntryPoint>]
let main argv =
    0 // return an integer exit code
