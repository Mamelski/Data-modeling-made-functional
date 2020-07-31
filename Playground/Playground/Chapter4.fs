module Playground.Chapter4

// Learn more about F# at http://fsharp.org

open System
open System.Collections.Specialized
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations
open System.Reflection.Metadata.Ecma335
open System.Runtime.CompilerServices
open Microsoft.VisualBasic

// Functions
let add1 x = + 1
let add2 x y = x + y

let squarePlusOne x =
    let square = x * x
    square + 1    
let equal x y=
    x = y
    
// Compositions
type AppleVariety =
 | GoldenDelicious
 | GrannySmith
 | Fuji
 
type BanaVariety =
 | Cavendish
 | GrosMichel
 | Manzano
 
type CherryVariety =
 | Montmorency
 | Bing
 
 // Record type (product)
type FruitSalad = {
     Apple: AppleVariety
     Banana: BanaVariety
     Cherries: CherryVariety
 }
 
 // Discriminated union (sum)
type FruitSnack =
    | Apple of AppleVariety
    | Banana of BanaVariety
    | Cherries of CherryVariety

// Same as type ProductCode = ProductCode of string
type ProductCode =
    | ProductCode of string
    
type Person = {First:string; Last:string}
let aPerson = {First = "Jakub"; Last= "Mamelski"}

// dekonstrukcja rekordu
let {First=first; Last=last} = aPerson
let first2 = aPerson.First
let last2 = aPerson.Last

// Dekonstrukcja unii (choice type)
type OrderQuantity =
    | UnitQuantity of int
    | KilogramQuantity of decimal

let anOrderQtyInUnits = UnitQuantity 10
let anOrderQtyInKg = KilogramQuantity 2.5m

let printQuantity aOrderQty =
    match aOrderQty with
    | UnitQuantity uQty ->
        printfn "%i units" uQty
    | KilogramQuantity kgQty ->
        printfn "%g kg" kgQty
  
// Kompozycja
type CheckNumber = CheckNumber of int
type CardNumber = CardNumber of string 
type CardType =
     Visa | Mastercard
     
type CreaditCardInfo = {
     CardType: CardType
     CardNumber: CardNumber
}
 
type PaymentMethod =
     | Cash
     | Check of CheckNumber
     | Card of CreaditCardInfo
     
type PaymentAmount = PaymentAmount of decimal
type Currency = USD | EUR

type Payment = {
    Amount: PaymentAmount
    Currency: Currency
    Method: PaymentMethod
}

//Funkcja konwertująca waluty
type ConvertPaymentCurrency =
    Payment -> Currency -> Payment

// Optional values
// Takie generyczne nullable w sumie
type Option<'a> =
    | Some of 'a
    | None

// Drugie imię jest albo i nie 
type PersonalName = {
    FirstName: string
    SecondName: Option<string>
    LastName: string
}

// Void and function without params
type SaveText = string -> unit

type NextRandom = unit -> int

type Order = {
    OrderId: string
    Lines: string list
}

let aList = [1;2;3]

let aNewList = 0 :: aList

let printList1 aList =
    match aList with
    | [] ->
        printfn "Lista jest pusta"
    | [x] ->
        printfn "Lista ma jeden element %A" x
    | [x;y] ->
        printfn "Lista ma dwa elementy %A %A" x y
    | lonerList ->
        printfn "Lista ma więcej niż dwa elementy"
        
let printList2 =
    match aList with
    | []->
        printfn "Lista jest pusta"
    | first::rest ->
        printfn "Lista jest niepusta, pierwszy element to %A" first

        
//[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    
    let add1res = add1 10
    let add2res = add2 10 10
    
    printfn "%d %d" add1res add2res
    
    let res = squarePlusOne 10
    printfn "%d" res
    printfn "%s %s" first last
    
    printQuantity anOrderQtyInKg
    printQuantity anOrderQtyInUnits
    
    printfn "%A" aList
    printfn "%A" aNewList
    
    0 // return an integer exit code
