namespace FsVerbalExpressions.Tests

open FsVerbalExpressions
open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open System
open Xunit

module Misc =

    [<Fact>]
    let ``valid url`` () =

        VerbEx()
        |> startOfLine
        |> then' "http"
        |> maybe "s"
        |> then' "://"
        |> maybe "www."
        |> anythingBut " "
        |> endOfLine
        |> isMatch "https://www.google.com"
        |> should equal true

    [<Fact>]
    let ``does match anything`` () =

        VerbEx()
        |> startOfLine
        |> anything
        |> isMatch "'!@#$%¨&*()__+{}'"
        |> should equal true


    [<Fact>]
    let ``lineBreak`` () =

        VerbEx()
        |> lineBreak
        |> isMatch (sprintf "testing with %s line break" Environment.NewLine)
        |> should equal true

    [<Fact>]
    let ``br`` () =

        VerbEx()
        |> br
        |> isMatch (sprintf "testing with %s line break" Environment.NewLine)
        |> should equal true

    [<Fact>]
    let ``tab`` () =

        VerbEx()
        |> tab
        |> isMatch (sprintf "testing with %s tab" "\t")
        |> should equal true
