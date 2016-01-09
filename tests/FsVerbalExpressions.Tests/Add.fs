namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open System.Text.RegularExpressions
open Xunit

module Add =

    [<Fact>]
    let ``special characters unescaped`` () =

        VerbEx(RegexOptions.Multiline)
        |> add "Line1\*+?"
        |> isMatch "Line1\*+?Line2"
        |> should equal false

    [<Fact>]
    let ``special characters escaped`` () =

        VerbEx(RegexOptions.Multiline)
        |> add "Line1\*\+\?"
        |> isMatch "Line1*+?Line2"
        |> should equal true

    [<Fact>]
    let ``Does Not Match GoogleCom With Escaped Dot`` () =

        VerbEx(RegexOptions.Multiline)
        |> add "\.com"
        |> isMatch "http://www.googlecom/"
        |> should equal false

    [<Fact>]
    let ``Does Not Match GoogleCom With Dot`` () =

        VerbEx(RegexOptions.Multiline)
        |> add ".com"
        |> isMatch "http://www.googlecom/"
        |> should equal true

