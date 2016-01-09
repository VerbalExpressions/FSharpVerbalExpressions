namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module StartOfLine =

    [<Fact>]
    let ``line start`` () =

        VerbEx()
        |> startOfLine
        |> toString 
        |> should equal "^"

    let ``Prefix At Beginning Of The Expression`` () =
        
        VerbEx()
        |> add "test"
        |> add "ing"
        |> startOfLine
        |> isMatch "testing1234"
        |> should equal true

    let ``match correct at start`` () =
        
        VerbEx()
        |> startOfLine
        |> then' "http"
        |> maybe "www"
        |> startOfLine
        |> isMatch "http://xxx.test.xxx"
        |> should equal true

    let ``no match not at start`` () =
        
        VerbEx()
        |> startOfLine
        |> then' "http"
        |> maybe "www"
        |> startOfLine
        |> isMatch "www.test.com"
        |> should equal true