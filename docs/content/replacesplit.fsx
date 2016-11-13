(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin/FsVerbalExpressions"

(**
Replacing and Splitting
=======================

Replace
-------

The `System.Text.RegularExpressions.Regex` Class provides several overloads of `replace`. The same overloads are available in the `VerbEx` class and as individually 
named functions in the `FsRegEx` module, including overloads and functions using `RegexOptions`. `Timeout` is not supported at this time.
*)

(*** hide ***) 
#r "FsVerbalExpressions.dll"

(**
### simple replacement of all occurence ###
*)
open FsVerbalExpressions
open System
open System.Text.RegularExpressions

"This is   text with   far  too   much   " + 
                "whitespace."
|> FsRegEx.replace "\\s+" " "
|>printfn "Replacement String: %s" 

// Replacement String: This is text with far too much whitespace.
(**
### replace max time starting at ###

Replaces a specified maximum number of strings starting at location that match a regular expression pattern with a specified replacement string.
*)
"Instantiating a New Type\n" +
    "Generally, there are two ways that an\n" + 
    "instance of a class or structure can\n" +
    "be instantiated. "
|> FsRegEx.replaceMaxTimesStartAtOpt "^.*$" RegexOptions.Multiline "\n$&"  -1 1
|> printfn "%s"

// Instantiating a New Type
//       
// Generally, there are two ways that an
//       
// instance of a class or structure can
//       
// be instntiated.
(**
### replace with MatchEvaluator ###
*)
let capText (m : Match) =
    // Get the matched string.
    let x = m.Value
    // If the first char is lower case...
    if (Char.IsLower(x.[0])) then
        // Capitalize it.
        (Char.ToUpper(x.[0]).ToString()) + (x.Substring(1, x.Length - 1))
    else
        x

"four score and seven years ago"
|> FsRegEx.replaceByMatch @"\w+" (new MatchEvaluator(capText))
|> printfn "result=[%s]"

// result=[Four Score And Seven Years Ago]
(**
Splitting
---------

The `System.Text.RegularExpressions.Regex` Class provides several overloads of `split` to split strings into arrays. The same overloads are available in the `VerbEx` class and as individually 
named functions in the `FsRegEx` module, including overloads and functions using `RegexOptions`. `Timeout` is not supported at this time.

### split with Regex option ###
*)
"Abc1234Def5678Ghi9012Jklm"
|> FsRegEx.splitOpt "[a-z]+" RegexOptions.IgnoreCase
|> Array.iter (fun x -> printfn "'%s'" x)

// ''
// '1234'
// '5678'
// '9012'
// ''