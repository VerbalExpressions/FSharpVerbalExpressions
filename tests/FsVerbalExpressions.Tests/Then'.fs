namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module Then' =

    [<Fact>]
    let ``Does Match`` () =

        VerbEx()
        |> startOfLine
        |> something
        |> then' "github.com"
        |> isMatch "test@github.com"
        |> should equal true

    [<Fact>]
    let ``Does Not Match`` () =

        VerbEx()
        |> startOfLine
        |> then' "github.com"
        |> isMatch "test@"
        |> should equal false

    [<Fact>]
    let ``special characters`` () =

        VerbEx()
        |> then' "*+?"
        |> isMatch "Line1*+?Line2"
        |> should equal true

    [<Fact>]
    let ``Does Not Match GoogleCom Without Dot`` () =

        VerbEx()
        |> then' ".com"
        |> isMatch "http://www.googlecom/"
        |> should equal false

