// Learn more about F# at http://fsharp.org

open System
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

[<EntryPoint>]
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
    
    0 // return an integer exit code
