namespace FsRegEx.Tests

open FsVerbalExpressions
open FsVerbalExpressions.FsRegEx
open FsUnit.Xunit
open System.Text.RegularExpressions
open Xunit

module FsRegEx =

    let carText = "One car red car blue car"
    let carRegExp = @"(\w+)\s+(car)"
    let eval = new MatchEvaluator(fun _ -> "blah")

    let splitText = "123ABCDE456FGHIJKL789MNOPQ012"
    let splitRegExp = @"\d+"

    let groupNumberRegExp = @"COD(?<GroupNumber>[0-9]{3})END"
    let groupNumberName = "GroupNumber"

    let partNumberRegExp = @"^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$"

    [<Fact>]
    let ``firstMatch`` () =

        let fsMatch = firstMatch carRegExp carText
        fsMatch.Value |> should equal "One car"

    [<Fact>]
    let ``matchAt`` () =

        let fsMatch = matchAt carRegExp 3 carText
        fsMatch.Value |> should equal "red car"

    [<Fact>]
    let ``matchAtFor`` () =

        let fsMatch = matchAtFor carRegExp 3 15 carText
        fsMatch.Value |> should equal "red car"

    [<Fact>]
    let ``matches`` () =

        matches carRegExp carText
        |> Array.map (fun m -> m.Value)
        |> should equal [|"One car"; "red car"; "blue car"|]

    [<Fact>]
    let ``matchesAt`` () =

        matchesAt carRegExp 3 carText
        |> Array.map (fun m -> m.Value)
        |> should equal [|"red car"; "blue car"|]

    [<Fact>]
    let ``replace`` () =

        replace carRegExp "blah" carText
        |> should equal "blah blah blah"

    [<Fact>]
    let ``replaceByMatch`` () =

        replaceByMatch carRegExp eval carText
        |> should equal "blah blah blah"

    [<Fact>]
    let ``replaceMaxTimes`` () =

        replaceMaxTimes carRegExp "blah" 2 carText
        |> should equal "blah blah blue car"

    [<Fact>]
    let ``replaceByMatchMaxTimes`` () =
        
        replaceByMatchMaxTimes carRegExp eval 2 carText
        |> should equal "blah blah blue car"

    [<Fact>]
    let ``replaceMaxTimesStartAt`` () =

        replaceMaxTimesStartAt carRegExp "blah" 1 3 carText
        |> should equal "One car blah blue car"

    [<Fact>]
    let ``replaceByMatchMaxTimesStartAt`` () =
        
        replaceByMatchMaxTimesStartAt carRegExp eval 1 3 carText
        |> should equal "One car blah blue car"

    [<Fact>]
    let ``split`` () =

        split splitRegExp splitText
        |> should equal [|""; "ABCDE"; "FGHIJKL"; "MNOPQ"; ""|]

    [<Fact>]
    let ``splitMaxTimes`` () =

        splitMaxTimes splitRegExp 3 splitText
        |> should equal [|""; "ABCDE"; "FGHIJKL789MNOPQ012"|]

    [<Fact>]
    let ``splitMaxTimesStartAt`` () =
        
        splitMaxTimesStartAt splitRegExp 3 5 splitText
        |> should equal [|"123ABCDE"; "FGHIJKL"; "MNOPQ012"|]

    [<Fact>]
    let ``capture`` () =

        capture groupNumberRegExp groupNumberName "COD123END"
        |> should equal "123"

    [<Fact>]
    let ``captureGroup`` () =

        let group = captureGroup groupNumberRegExp groupNumberName "COD123END"
        group.Value |> should equal "123"

    [<Fact>]
    let ``groupNames`` () =

        groupNames groupNumberRegExp
        |> should equal [|"0"; groupNumberName|]

    [<Fact>]
    let ``groupNumbers`` () =
        
        groupNumbers groupNumberRegExp
        |> should equal [|0; 1|]

    [<Fact>]
    let ``isMatch`` () =

        isMatch partNumberRegExp "1298-673-4192"
        |> should equal true

    [<Fact>]
    let ``isMatchAt`` () =

        let partNumber = "Part Number: 1298-673-4192"
        let start = partNumber.IndexOf(":")

        isMatchAt @"[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$" start partNumber
        |> should equal true