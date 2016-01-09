namespace FsVerbalExpressions.Tests

open FsVerbalExpressions
open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module RepeatPrevious =

    [<Fact>]
    let ``3 A`` () =

        VerbEx()
        |> add "A"
        |> repeatPrevious 3
        |> toString
        |> should equal "A{3}"

    [<Fact>]
    let ``between 2 and 4`` () =

        VerbEx()
        |> add "A"
        |> repeatBetweenPrevious 3 4
        |> toString
        |> should equal "A{3,4}"
