namespace FsVerbalExpressions.Tests

open FsVerbalExpressions
open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open System.Text.RegularExpressions
open Xunit

module Or' =

    [<Fact>]
    let ``Matches Com And Org`` () =

        let v =
            VerbEx()
            |> add "com"
            |> or' "org"

        v
        |> toString
        |> should equal "com|org"

        v
        |> isMatch "org"
        |> should equal true

        v
        |> isMatch "com"
        |> should equal true

    [<Fact>]
    let ``Matches Com And Org all or`` () =

        let v =
            VerbEx()
            |> or' "com"
            |> or' "org"

        v
        |> toString
        |> should equal "com|org"

        v
        |> isMatch "org"
        |> should equal true

        v
        |> isMatch "com"
        |> should equal true

    [<Fact>]
    let ``VerbEx email or url`` () =

        let v =
            CommonVerbEx.Email
            |> verbExOrVerbEx RegexOptions.None CommonVerbEx.Url

        v.IsMatch "test@github.com" |> should equal true
        v.IsMatch "http://www.google.com" |> should equal true

    [<Fact>]
    let ``VerbEx or regular expression`` () =

        let v =
            CommonVerbEx.Email
            |> or' "org"

        v.IsMatch "test@github.com" |> should equal true
        v.IsMatch "org" |> should equal true
