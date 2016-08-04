module SingleModule.Midify

open System
open System.Runtime.InteropServices

[<AutoOpen>]
module Map =
    type Map() =
        static member inline Map(x: 'x option, f: 'x -> 'y) = Option.map f x
        static member inline Map(x: 'x list, f: 'x -> 'y) = List.map f x

    (*
    let inline private invoke(typeClass: 'TypeClass) (f: 'x -> 'y)(fx: '``F<'x>``) =
        ((^TypeClass or ^``F<'x>``) : (static member Map: _*_*_ -> _) fx, f, typeClass)
    *)

    let inline private invoke(f: 'x -> 'y)(fx: '``F<'x>``) =
        // ((^TypeClass or ^``F<'x>``) : (static member Map: _*_*_ -> _) Fx, f, typeClass)
        ((^``F<'x>``) : (static member Map: _*_ -> _) fx, f)

    let inline map(f: 'x -> 'y) (fx: '``F<'x>``) : '``F<'y>`` =
        // invoke (Unchecked.defaultof<Map>) f fx
        invoke f fx

[<EntryPoint>]
let main argv =
    let addNine = (+) 9
    let value = 0

    let someValue = Some value
    let addNineMap = map addNine
    let result = addNineMap someValue
    printfn "%A" result

    let alist = [value; value; value]
    let addNineMap = map addNine
    let result = addNineMap alist

    printfn "%A" result
    0