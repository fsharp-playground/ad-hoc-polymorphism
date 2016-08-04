module Fmap.Modify

type Map = Map with
    static member ($) (Map, x: option<_>) = fun f -> Option.map f x
    static member ($) (Map, x: list<_>) = fun f -> List.map f x

let inline map f x = Map $ x <| f

[<EntryPoint>]
let main argv =
    let add = (+) 9
    printfn "%A" <| map add (Some 0)
    printfn "%A" <| map add [0]
    0
