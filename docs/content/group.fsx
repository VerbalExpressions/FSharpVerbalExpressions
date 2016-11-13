(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin/FsVerbalExpressions"

(**
Capture Groups
==============

FsGroup
-------

`FsGroup` provides the functionality in the `System.Text.RegularExpressions.Group` Class, but returning arrays of objects instead of special collections and makes the group name a property.
*)

(*** hide ***) 
#r "FsVerbalExpressions.dll"

(**
### anonymous groups ###
*)
open FsVerbalExpressions

let pattern = @"(\b(\w+?)[,:;]?\s?)+[?.!]"
let input = "This is one sentence. This is a second sentence."

let m = FsRegEx.firstMatch pattern input
printfn "Match: %s" m.Value

m.Groups()
|> Array.iteri (fun i g -> 
    printfn "   Group %i: '%s'" i g.Value
    g.Captures()
    |> Array.iteri (fun i c ->  
        printfn "      Capture %i: '%s'" i c.Value 
        )
    )

// Match: This is one sentence.
//    Group 0: 'This is one sentence.'
//        Capture 0: 'This is one sentence.'
//    Group 1: 'sentence'
//        Capture 0: 'This '
//        Capture 1: 'is '
//        Capture 2: 'one '
//        Capture 3: 'sentence'
//    Group 2: 'sentence'
//        Capture 0: 'This'
//        Capture 1: 'is'
//        Capture 2: 'one'
//        Capture 3: 'sentence'
(**
### named groups ###
*)
let pattern' = @"\b(?<FirstWord>\w+)\s?((\w+)\s)*(?<LastWord>\w+)?(?<Punctuation>\p{Po})"
let input' = "The cow jumped over the moon."

let m' = FsRegEx.firstMatch pattern' input'

printfn "Named Groups:"

m'.Groups()
|> Array.iter (fun g -> printfn "   %s: '%s'" g.Name g.Value)

// Named Groups:
//    0: 'The cow jumped over the moon.'
//    1: 'the '
//    2: 'the'
//    FirstWord: 'The'
//    LastWord: 'moon'
//    Punctuation: '.'
(**
### capturing groups ###
*)
let regExpr = @"\b(\w+?)([\u00AE\u2122])"

let matches = 
    "Microsoft® Office Professional Edition combines several office " +
        "productivity products, including Word, Excel®, Access®, Outlook®, " +
        "PowerPoint®, and several others. Some guidelines for creating " +
        "corporate documents using these productivity tools are available " +
        "from the documents created using Silverlight™ on the corporate " +
        "intranet site."
    |> FsRegEx.matches regExpr

matches
|> Array.iter (fun m ->
    let groups = m.Groups()
    printfn "%s: %s" groups.[2].Value groups.[1].Value)
                           
printfn ""
printfn "Found %i trademarks or registered trademarks." matches.Length

// ®: Microsoft
// ®: Excel
// ®: Access
// ®: Outlook
// ®: PowerPoint
// ™: Silverlight
//
// Found 6 trademarks or registered trademarks.
(**
### group numbers and names ###
*)
open System

let pattern'' = @"\b((?<word>\w+)\s*)+(?<end>[.?!])"
let input'' = "This is a sentence. This is a second sentence."

let groupNumbers' = FsRegEx.groupNumbers pattern''
let groupNames = FsRegEx.groupNames pattern''

let m'' = FsRegEx.firstMatch pattern'' input''

printfn "Match: %s" m''.Value

Array.zip groupNumbers' groupNames
|> Array.iter (fun (n, name) ->
    let isNumber, _ = Int32.TryParse(name)
    printfn "   Group %i%s: '%s'" 
        n 
        (if (not isNumber) then
            " (" + name + ")"
         else String.Empty)
        (m'.Groups()).[n].Value
    )

// Match: This is a sentence.
//    Group 0: 'This is a sentence.'
//    Group 1: 'sentence'
//    Group 2 (word): 'sentence'
//    Group 3 (end): '.'