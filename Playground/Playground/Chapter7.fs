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
    
    
type Price = Undefined
type PricedOrder = Undefined
type GetProductPrice = 
        ProductCode -> Price


type PriceOrder = 
    GetProductPrice      // dependency
      -> ValidatedOrder  // input
      -> PricedOrder     // output

type EmailAddress = EmailAddress of string

type HtmlString = 
    HtmlString of string

type OrderAcknowledgment = {
    EmailAddress : EmailAddress
    Letter : HtmlString 
    }

type CreateOrderAcknowledgmentLetter =
    PricedOrder -> HtmlString

module SendOrderAcknowledgmentUnit =

    type SendOrderAcknowledgment =
        OrderAcknowledgment -> unit

module SendOrderAcknowledgmentBool =
    // bool jest zazwyczaj słaby i mało mówi
    type SendOrderAcknowledgment =
        OrderAcknowledgment -> bool
            
module SendOrderAcknowledgmentEnum =
    type SendResult = Sent | NotSent

    type SendOrderAcknowledgment =
        OrderAcknowledgment -> SendResult 

    module SendOrderAcknowledgmentOption =
        type OrderAcknowledgmentSent = Undefined

        type SendOrderAcknowledgment =
            OrderAcknowledgment -> OrderAcknowledgmentSent option


   
type OrderId = Undefined
type SendOrderAcknowledgment = SendOrderAcknowledgmentEnum.SendOrderAcknowledgment          

// nasz event
type OrderAcknowledgmentSent = {
    OrderId : OrderId
    EmailAddress : EmailAddress 
    }

type AcknowledgeOrder = 
    CreateOrderAcknowledgmentLetter     // dependency
      -> SendOrderAcknowledgment        // dependency
      -> PricedOrder                    // input
      -> OrderAcknowledgmentSent option // output

    
//[<EntryPoint>]
let main argv =
    0 // return an integer exit code
