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

        n.Count
        |> should equal 3
