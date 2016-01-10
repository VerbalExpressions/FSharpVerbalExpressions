(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin/FsVerbalExpressions"

(**
Introducing F# Verbal Expressions
=================================

FsVerbalExpressions is an F# library that allows you to compose regular expressions in natural language using an immutable F# Type called VerbEx. 

In turn you can compose values of the VerbEx type with the |> operator, including creating a new regular expression by logical or on 2 existing VerbExs. 

*)
#r "FsVerbalExpressions.dll"
open FsVerbalExpressions
open System.Text.RegularExpressions

let v =
    CommonVerbEx.Email
    |> VerbalExpression.verbExOrVerbEx RegexOptions.None CommonVerbEx.Url

let foundEmail =
    v
    |> VerbalExpression.isMatch "test@github.com"

let foundUrl =
    v
    |> VerbalExpression.isMatch "http://www.google.com"

printfn "%b" foundEmail
printfn "%b" foundUrl

// true
// true

(**
Natural language composition consists of building up a new VerbEx from an old by functions which append special characters, groups, modifiers, and other attributes of the regular expression language.

function : 'T -> VerbEx -> VerbEx

See the API documentation for all the regular expression functions available.
*)

open VerbalExpression

let foundFromGithub =
    VerbEx()
    |> startOfLine
    |> something
    |> then' "github.com"
    |> endOfLine
    |> isMatch "test@github.com"

printfn "%b" foundFromGithub

// true

(**
You do not have to worry about escaping special characters in your regular expression.
*)

let foundSomethingSpecial =
    VerbEx()
    |> startOfLine
    |> something
    |> then' "*+?"
    |> anything
    |> isMatch "blah blah blah*+?yackety yack"

printfn "%b" foundSomethingSpecial

// true

(**
Sometimes you may need more power than the natural language provides, or you just need to include a snippet of native regular expression. The add function lets you do that.
*)

let foundSpecialInMultiline =
    VerbEx()
    |> add @"phrase1\*\+\?"
    |> anything
    |> isMatch @"phrase1*+?RestOfLine\n"
    
printfn "%b" foundSpecialInMultiline

// true

(**
Or you can include a regular expression in the costructor.
*)

let verbEx = new VerbEx(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")

(**
VerbExs posses all the power of the .Net RegEx class in a composable form.
*)

let n =
    VerbEx()
    |> word
    |> matches "three words here"

printfn "%i" n.Count

// 3

let betterFormat =
    VerbEx()
    |> add "\s+"
    |> or' "whitespace"
    |> replace "This     is   text with   far  too   much   whitespace" " "

printfn "%s" betterFormat

// This is text with far too much  

let groupName =  "GroupNumber"
 
VerbEx()
|> add "COD"
|> beginCaptureNamed groupName
|> any "0-9"
|> repeatPrevious 3
|> endCapture
|> then' "END"
|> capture "COD123END" groupName
|> printfn "%s"

// 123

(**
VerbEx comes with first class support for unicode, including unicode general categories and .Net extension blocks.
*)

VerbEx()
|> beginCaptureNamed "upper"
|> unicodeCategory UniCodeGeneralCategory.LetterUppercase
|> add "+"
|> endCapture
|> capture "some mixed case WORDS" "upper"
|> printfn "%s"

// WORDS