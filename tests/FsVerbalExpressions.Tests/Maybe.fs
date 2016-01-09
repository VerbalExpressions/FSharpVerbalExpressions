namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module Maybe =

    let maybeSSL =
        VerbEx()
        |> find "http"
        |> maybe "s"
        |> anythingBut " "
        |> then' "://"

    [<Fact>]
    let ``present`` () =

        maybeSSL
        |> isMatch "https://www.google.com"
        |> should equal true

    [<Fact>]
    let ``not present`` () =

        maybeSSL
        |> isMatch "http://www.google.com"
        |> should equal true
