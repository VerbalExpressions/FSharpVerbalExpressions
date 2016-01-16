namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module Match =

    [<Fact>]
    let ``Returns Expected Number Of Matches`` () =

        let n =
            VerbEx()
            |> word
            |> matches "three words here"

        n.Length
        |> should equal 3

    [<Fact>]
    let ``No Matches returned`` () =

        let n =
            VerbEx()
            |> word
            |> matches "$#% )(*! {}"

        n.Length
        |> should equal 0
