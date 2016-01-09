namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module EndOfLine =

    [<Fact>]
    let ``Match Dot Com In End`` () =

        VerbEx()
        |> add ".com" 
        |> endOfLine
        |> isMatch "www.google.com"
        |> should equal true

    [<Fact>]
    let ``Does Not Match Forward Slash In End`` () =

        VerbEx()
        |> add ".com" 
        |> endOfLine
        |> isMatch "www.google.com/"
        |> should equal false
