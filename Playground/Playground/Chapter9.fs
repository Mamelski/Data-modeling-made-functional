module Playground.Chapter9
open System

module Domain = 
    type OrderId = private OrderId of string

    module OrderId =
        /// Define a "Smart constructor" for OrderId 
        /// string -> OrderId 
        let create str = 
            if String.IsNullOrEmpty(str) then
                // use exceptions rather than Result for now
                failwith "OrderId must not be null or empty" 
            elif str.Length > 50 then
                failwith "OrderId must not be more than 50 chars" 
            else
                OrderId str

        /// Extract the inner value from an OrderId
        /// OrderId -> string
        let value (OrderId str) = // unwrap in the parameter!
          str                     // return the inner value
     
// Adapter - f zwraca nam bool, ale jeśli true to chcemy zwrócić wartość    
let predicateToPassthru errorMsg f x =
    if f x then  
        x
    else  
        failwith errorMsg 
              
[<EntryPoint>]
let main argv =
    
    0 // return an integer exit code
