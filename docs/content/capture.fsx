(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin/FsVerbalExpressions"

(**
Capturing
=========

Capturing is a shortcut through matching to a named group or the group's captured value.
*)

(*** hide ***) 
#r "FsVerbalExpressions.dll"

(**
### capture ###
*)
open FsVerbalExpressions.FsRegEx

let groupNumberRegExp = @"COD(?<GroupNumber>[0-9]{3})END"
let groupNumberName = "GroupNumber"

capture groupNumberRegExp groupNumberName "COD123END"
|> printfn "%s"

// 123
(**
### capture group ###
*)
let group = captureGroup groupNumberRegExp groupNumberName "COD123END"

printfn "%s" group.Value

// 123