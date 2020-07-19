// Learn more about F# at http://fsharp.org

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations
open System.Reflection.Metadata.Ecma335
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
 
type FruitSalad = {
     Apple: AppleVariety
     Banana: BanaVariety
     Cherries: CherryVariety
 }
 
type FruitSnack =
    | Apple of AppleVariety
    | Banana of BanaVariety
    | Cherries of CherryVariety

// Same as type ProductCode = ProductCode of string
type ProductCode =
    | ProductCode of string

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    
    let add1res = add1 10
    let add2res = add2 10 10
    
    printfn "%d %d" add1res add2res
    
    let res = squarePlusOne 10
    printfn "%d" res
    0 // return an integer exit code
