namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module Something =

    [<Fact>]
    let ``something there`` () =

        VerbEx()
        |> something
        |> isMatch "Test string should not be empty"
        |> should equal true

    [<Fact>]
    let ``nothing there`` () =

        VerbEx()
        |> something
        |> isMatch ""
        |> should equal false

