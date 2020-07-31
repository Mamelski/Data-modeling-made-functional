module Playground.Chapter5

open System.Net.NetworkInformation

type CustomerId = CustomerId of int
type WidgetCode = WidgetCode of string
type UnitQuantity = UnitQuantity of int
type KilogramQuantity = KilogramQuantity of decimal

let customerId = CustomerId 42

let processCustomerId (CustomerId innerValue) =
    printf "%A" innerValue

// nie referancyjny typ
[<Struct>]
type StructType = StructType of int

// Jeśli jeszcze nie znamy szczegółów typów
type Undefined = exn
type CustomerInfo = Undefined
type ShippingAddress = Undefined
type BillingAddress = Undefined
type OrderLine = Undefined
type BillingAmount = Undefined
type GizmoCode = Undefined
type UnvalidatedOrder = Undefined
type ValidatedOrder = Undefined
type ValidationError = {
    FieldName: string
    ErrorDescription: string
}


type Order = {
    CustomerInfo: CustomerInfo
    ShippingAddress: ShippingAddress
    BillingAddress: BillingAddress
    OrderLine: OrderLine list
    AmountToBill: BillingAmount
}

type ProductCode =
    | Widget of WidgetCode
    | Gizmo of GizmoCode
    
type OrderQuantity =
    | UnitQuantity of UnitQuantity
    | KilogramQuantity of KilogramQuantity
    
// funkcja z wieloma wyjściami
type EnvelopeContents = EnvelopeContents of string
type CategorizedEmail =
    | Quote of string
    | Order of string

type CategorizeInboudEmail = EnvelopeContents -> CategorizedEmail

// Funkcja z wieloma wejsciami (albo osobny typ na parametry)
type CalculatePrices = Order -> ProductCode -> int

// ValidationErrors are side effects
//type ValidateOrder =
//    UnvalidatedOrder -> Async<Result<ValidatedOrder, ValidationError list>>   
type ValidationResponse<'a> = Async<Result<'a, ValidationError>>
type ValidateOrder =
    UnvalidatedOrder -> ValidationResponse<ValidatedOrder>

type 
 
[<EntryPoint>]
let main argv =

    processCustomerId customerId
    
    0 // return an integer exit code
