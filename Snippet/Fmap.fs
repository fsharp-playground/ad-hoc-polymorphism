
type Fmap = Fmap with
    static member ($) (Fmap, x:option<_>) = fun f -> Option.map f x
    static member ($) (Fmap, x:list<_>) = fun f -> List.map f x

let inline fmap f x = Fmap $ x <| f

[<EntryPoint>]
let main argv =
    let add = (+) 3
    printfn "%A" <| fmap add [1;2;3]
    printfn "%A" <| fmap add (Some 3)
    0