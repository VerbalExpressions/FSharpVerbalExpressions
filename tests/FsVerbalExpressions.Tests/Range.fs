namespace FsVerbalExpressions.Tests

open FsVerbalExpressions
open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module Range =

    [<Fact>]
    let ``Odd Number Of Items Append LastElement With Or Clause`` () =

        let v =
            VerbEx()
            |> range [1; 6; 7]

        v
        |> toString
        |> should equal "[1-6]|7"

        v
        |> isMatch "abcd7sdadqascdaswde"
        |> should equal true

    [<Fact>]
    let ``Even Number Of Items`` () =

        let v =
            VerbEx()
            |> range [|"1"; "6"; "a"; "c"|]

        let x = v.ToString()

        v
        |> toString
        |> should equal "[1-6][a-c]"

        v
        |> isMatch "2b"
        |> should equal true

    [<Fact>]
    let ``Has Only One Value  Throw Exception`` () =

        let x =
            try
                VerbEx() |> range [1] |> ignore
                ""
            with e ->
                e.Message 
                
        x |> should equal "one-element range\r\nParameter name: range"
