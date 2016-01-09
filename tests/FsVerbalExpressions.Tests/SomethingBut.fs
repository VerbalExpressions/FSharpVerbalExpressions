namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module SomethingBut =

    [<Fact>]
    let ``all characters in test`` () =

        VerbEx()
        |> somethingBut "Test"
        |> isMatch "Test"
        |> should equal false

    [<Fact>]
    let ``a characters out of test`` () =

        VerbEx()
        |> somethingBut "Test"
        |> isMatch "TestA"
        |> should equal true

