namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open System
open System.Text.RegularExpressions
open Xunit

module RegexOptions =

    [<Fact>]
    let ``Multiline`` () =

        VerbEx(RegexOptions.Multiline)
        |> add "Line1"
        |> endOfLine
        |> isMatch "Line1\nLine2"
        |> should equal true

    [<Fact>]
    let ``Multiline None`` () =
        VerbEx()
        |> add "Line1"
        |> endOfLine
        |> isMatch @"Line1\nLine2"
        |> should equal false

    [<Fact>]
    let ``IgnoreCase`` () =

        VerbEx(RegexOptions.IgnoreCase)
        |> add "teststring"
        |> endOfLine
        |> isMatch "TESTSTRING"
        |> should equal true

    [<Fact>]
    let ``IgnoreCase None`` () =
        VerbEx()
        |> add "teststring"
        |> endOfLine
        |> isMatch "TESTSTRING"
        |> should equal false

    [<Fact>]
    let ``Singleline`` () =

        VerbEx(RegexOptions.Singleline)
        |> add "First string"
        |> anything
        |> add "Second string"
        |> isMatch ("First string" + Environment.NewLine + "Second string")
        |> should equal true

    [<Fact>]
    let ``Singleline None`` () =
        VerbEx()
        |> add "First string"
        |> anything
        |> add "Second string"
        |> isMatch ("First string" + Environment.NewLine + "Second string")
        |> should equal false

    let testSingleLineUpperCase v =
        v
        |> add "First string"
        |> anything
        |> add "Second string"
        |> isMatch ("FIRST STRING" + Environment.NewLine + "SECOND STRING")

    [<Fact>]
    let ``Singleline IgnoreCase`` () =

        VerbEx(RegexOptions.Singleline ||| RegexOptions.IgnoreCase)
        |> testSingleLineUpperCase
        |> should equal true

    [<Fact>]
    let ``Singleline IgnoreCase None`` () =

        VerbEx(RegexOptions.Singleline)
        |> testSingleLineUpperCase
        |> should equal false

    [<Fact>]
    let ``resetRegexOptions`` () =

        let v = VerbEx(RegexOptions.Singleline)
        
        v
        |> testSingleLineUpperCase
        |> should equal false

        (Some (RegexOptions.Singleline ||| RegexOptions.IgnoreCase), v)
        ||> resetRegexOptions 
        |> testSingleLineUpperCase
        |> should equal true

    let ``identify options`` () =

        let v = new VerbEx(RegexOptions.Singleline ||| RegexOptions.IgnoreCase)
        
        v.RegexOptions.HasFlag(RegexOptions.IgnoreCase) 
        |> should equal true

        v.RegexOptions.HasFlag(RegexOptions.ExplicitCapture) 
        |> should equal false

        
