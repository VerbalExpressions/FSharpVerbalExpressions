namespace FsVerbalExpressions.Tests

open FsVerbalExpressions
open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit
open System.Text.RegularExpressions
open Xunit

module Tutorial =

    [<Fact>]
    let ``Tutorial 1`` () =

        let v =
            CommonVerbEx.Email
            |> VerbalExpression.verbExOrVerbEx RegexOptions.None CommonVerbEx.Url

        let foundEmail =
            v
            |> VerbalExpression.isMatch "test@github.com"

        let foundUrl =
            v
            |> VerbalExpression.isMatch "http://www.google.com"

        foundEmail
        |> should equal true

        foundUrl
        |> should equal true

    [<Fact>]
    let ``Tutorial 2`` () =
        let foundFromGithub =
            VerbEx()
            |> startOfLine
            |> something
            |> then' "github.com"
            |> endOfLine
            |> isMatch "test@github.com"

        foundFromGithub
        |> should equal true

    [<Fact>]
    let ``Tutorial 3`` () =

        let foundSomethingSpecial =
            VerbEx()
            |> startOfLine
            |> something
            |> then' "*+?"
            |> anything
            |> isMatch "blah blah blah*+?yackety yack"

        foundSomethingSpecial
        |> should equal true

    [<Fact>]
    let ``Tutorial 4`` () =

        let foundSpecialInMultiline =
            VerbEx()
            |> add @"phrase1\*\+\?"
            |> anything
            |> isMatch @"phrase1*+?RestOfLine\n"
    
        foundSpecialInMultiline
        |> should equal true

    [<Fact>]
    let ``Tutorial 5`` () =

        let n =
            VerbEx()
            |> word
            |> matches "three words here"

        n.Length
        |> should equal 3

    [<Fact>]
    let ``Tutorial 6`` () =

        let betterFormat =
            VerbEx()
            |> add "\s+"
            |> or' "whitespace"
            |> replace "This     is   text with   far  too   much   whitespace" " "

        betterFormat
        |> should equal "This is text with far too much  "

    [<Fact>]
    let ``Tutorial 7`` () =

        let groupName =  "GroupNumber"
 
        VerbEx()
        |> add "COD"
        |> beginCaptureNamed groupName
        |> any "0-9"
        |> repeatPrevious 3
        |> endCapture
        |> then' "END"
        |> capture "COD123END" groupName
        |> should equal "123"

    [<Fact>]
    let ``Tutorial 8`` () =

        VerbEx()
        |> beginCaptureNamed "upper"
        |> unicodeCategory UniCodeGeneralCategory.LetterUppercase
        |> add "+"
        |> endCapture
        |> capture "some mixed case WORDS" "upper"
        |> should equal "WORDS"

