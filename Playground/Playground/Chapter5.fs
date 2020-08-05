module Playground.Chapter5

open System
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

// Entities with Id
type InvoiceId = InvoiceId of int
type UnpaidInvoice = {
    InvoiceId: InvoiceId
    // some fields
}
type PaidInvoice = {
    InvoiceId: InvoiceId
    // some fields
}

type Invoice = 
    | Unpaid of UnpaidInvoice
    | Paid of PaidInvoice

let invoice = Paid {InvoiceId = InvoiceId(10) }

match invoice with
    | Unpaid unpaidInvoice ->
        printfn "The unpaid invoiceId is %A" unpaidInvoice.InvoiceId
    | Paid paidInvoice ->
        printfn "The paid invoiceId is %A" paidInvoice.InvoiceId
        
let invoice2 = {InvoiceId=InvoiceId(10)}
printfn "%A" invoice2.InvoiceId

// No equality testing with this type
[<NoEquality; NoComparison>]
type Contact = {
    ContactId: Guid
    PhoneNuber: string
}
type PersonId = PersonId of int

type Person = {
    PersonId : PersonId
    Name : string
}

let initialPerson = {PersonId = PersonId 12; Name = "Mamelski"}

let updatedPerson = {initialPerson with Name="Mamelski 2"}
 
// [<EntryPoint>]
let main argv =

    processCustomerId customerId

    0 // return an integer exit code
