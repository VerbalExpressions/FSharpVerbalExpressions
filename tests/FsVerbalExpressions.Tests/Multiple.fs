namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module Multiple =

    [<Fact>]
    let ``Match One Or Multiple Values Given`` () =

        let v =
            VerbEx()
            |> add "y"
            |> multiple "aho"
            |> add "u"

        v
        |> toString
        |> should equal  "y(aho)+u"

        v
        |> isMatch "testesting 123 yahoahoahou another test"
        |> should equal true