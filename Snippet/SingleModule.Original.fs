open System
open System.Runtime.InteropServices

[<AutoOpen>]
module Map =
    type Map() =
        static member inline Map(x: 'x option, f: 'x -> 'y, [<Optional>] impl: Map) = Option.map f x
        static member inline Map(x: 'x list, f: 'x -> 'y, [<Optional>]impl: Map) = List.map f x

    let inline private invoke(typeClass: 'TypeClass) (f: 'x -> 'y)(Fx: '``F<'x>``) =
        ((^TypeClass or ^``F<'x>``) : (static member Map: _*_*_ -> _) Fx, f, typeClass)

    let inline map(f: 'x -> 'y) (Fx: '``F<'x>``) : '``F<'y>`` =
        invoke (Unchecked.defaultof<Map>) f Fx

[<EntryPoint>]
let main argv =
    let f = (+) 9
    let x = 0

    let Fx = Some x
    let Ff = map f
    let Fy = Ff Fx
    printfn "%A" Fy

    let F = [x]
    let Ff = map f
    let Fy = Ff F

    printfn "%A" Fy
    0