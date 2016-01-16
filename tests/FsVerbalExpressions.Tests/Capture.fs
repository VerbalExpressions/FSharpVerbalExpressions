namespace FsVerbalExpressions.Tests

open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open Xunit

module Capture =
    
    [<Fact>]
    let ``begin and end`` () =

        VerbEx()
        |> beginCapture
        |> add "com" 
        |> or' "org"
        |> endCapture
        |> isMatch "((com)|(org))"
        |> should equal true

    let duplicateIdentifier = 

        VerbEx()
        |> beginCapture
        |> word 
        |> endCapture
        |> whiteSpace
        |> beginCapture
        |> backReference 1
        |> endCapture
        
    [<Fact>]
    let ``Duplicates Identifier Does Match`` () =

        duplicateIdentifier
        |> toString 
        |> should equal @"(\w+)\s(\1)"

        duplicateIdentifier.IsMatch "He said that that was the the correct answer." 
        |> should equal true

    [<Fact>]
    let ``Duplicates Identifier Does Not Match`` () =

        duplicateIdentifier.IsMatch "He said that was the correct answer." 
        |> should equal false

    [<Fact>]
    let ``Group Names and Group Numbers`` () =

        duplicateIdentifier
        |> groupNames
        |> should equal [|"0"; "1"; "2"|]

        duplicateIdentifier
        |> groupNumbers
        |> should equal [|0; 1; 2|]

    [<Fact>]
    let ``Group Name`` () =

        let groupName =  "GroupNumber"

        let v =
            VerbEx()
            |> add "COD"
            |> beginCaptureNamed groupName
            |> any "0-9"
            |> repeatPrevious 3
            |> endCapture
            |> add "END"

        v
        |> toString
        |> should equal @"COD(?<GroupNumber>[0-9]{3})END"

        v
        |> capture "COD123END" groupName
        |> should equal "123"

        v
        |> groupNames
        |> should equal [|"0"; "GroupNumber"|]

    [<Fact>]
    let ``Nmaed Backreference`` () =

        let groupName = "char"

        let v =
            VerbEx()
            |> add @"(?<char>\w)"
            |> namedBackReference "char"

        let x = v |> capture "trellis llama webbing dresser swagger" groupName

        x |> should equal "l"

    [<Fact>]
    let ``Match' has 1 capture`` () =

        let n =
            VerbEx()
            |> word
            |> matches "three words here"

        n.[0].Captures().Length
        |> should equal 1

    [<Fact>]
    let ``Match' has 1 group`` () =

        let n =
            VerbEx()
            |> word
            |> matches "three words here"

        n.[0].Groups().Length
        |> should equal 1

    [<Fact>]
    let ``Group' captures`` () =

        let testString = "This is a sentence. This is another sentence."

        let v =
            VerbEx()
            |> add @"\b"
            |> beginCapture
            |> word
            |> whiteSpace
            |> add "*"
            |> endCapture
            |> add @"+\."

        let m =
            v
            |> matches testString

        let g =
            m.[0].Groups().[1]

        let testStringBegins = 
            ("", g.Captures())
            ||> Array.fold (fun s t ->
                if s.Length = 0 then t.Value
                else (s + t.Value)) 

        testString.StartsWith(testStringBegins) |> should equal true