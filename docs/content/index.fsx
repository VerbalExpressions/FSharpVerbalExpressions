(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin/FsVerbalExpressions"

(**
FsVerbalExpressions
======================

This library wraps the .NET RegEx object in a composable F# type and allows you to write regular expressions in natural language. Lazy evaluation ensures composition imposes no performance penalty.

<div class="row">
  <div class="span1"></div>
  <div class="span6">
    <div class="well well-small" id="nuget">
      The FsVerbalExpressions library can be <a href="https://nuget.org/packages/FsVerbalExpressions">installed from NuGet</a>:
      <pre>PM> Install-Package FsVerbalExpressions</pre>
    </div>
  </div>
  <div class="span1"></div>
</div>

Introduction
------------

The FsVerbalExpressions library brings a composable regular expression experience to F#.

 * `VerbEx` - A composable F# wrapper type over `System.Text.RegularExpressions.Regex`.

 * Basic functional operations on VerbEx (exists, fold, foldBack, iter, and map), among other composable functions.

 * `Match'` - A composable F# wrapper type over `System.Text.RegularExpressions.Match`.

 * `Group'` - A composable F# wrapper type over `System.Text.RegularExpressions.Group`.

The RegEx speciall collections are returned as arrays. This does lose the advantange of lazy match evaluation the special collections provide. 
A future release may include matches returned as a lazy list. The underlying object can always be returned from the wrapper

*)
#r "FsVerbalExpressions.dll"
open FsVerbalExpressions
open System.Text.RegularExpressions
open VerbalExpression

let allXs = new VerbEx("x+")

let verbEx =
    CommonVerbEx.Email
    |> verbExOrVerbEx RegexOptions.None CommonVerbEx.Url
    |> verbExOrVerbEx RegexOptions.None allXs

let foundEmail =
    verbEx
    |> isMatch "test@github.com"

let foundUrl =
    verbEx
    |> isMatch "http://www.google.com"

let foundAllXs =
    verbEx
    |> isMatch "xxxxx"

printfn "%b" foundEmail
printfn "%b" foundUrl
printfn "%b" foundAllXs

// true
// true
// true

(**
The library also provides the composable Verbal Expressions language for constructing simple regular expressions in a readable fashion.
*)
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
A comparison of using Regex natively, and Verbex to retrieve the database parameter from a connection string:
*)

let TestConnString = 
    """<add name="MyConnString" connectionString="Server=MyServer;Database=MyDatabase;User ID=me;Password=secret;Encrypt=True;TrustServerCertificate=True;Enlist=False;" />"""

let databaseFromRegex connectionString =
        
    Regex.Match(connectionString, "[dD]atabase=(?<database>.*?);").Groups.["database"].Value

let databaseFromVerbEx connectionString =

    VerbEx()
    |> add "[dD]atabase=(?<database>.*?);"
    |> capture connectionString "database"

(databaseFromRegex TestConnString) = (databaseFromVerbEx TestConnString) 
|> printfn "%b"

// true

(**
This example shows the more verbose and desctriptive Verbal Expressions:
*)

let databaseFromVerboseVerbEx connectionString =

    VerbEx()
    |> anyOf "dD"
    |> then' "atabase="
    |> beginCaptureNamed "database"
    |> add ".*?"
    |> endCapture
    |> then' ";"
    |> capture connectionString "database"

(databaseFromRegex TestConnString) = (databaseFromVerboseVerbEx TestConnString) 
|> printfn "%b"

// true

(**
Documentation
-------------

FsVerbalExpressions comes with comprehensive API documentation and a tutorial. 

 * [Tutorial](tutorial.html) contains further explanation of FsVerbalExpressions and many more usage examples.

 * [API Reference](reference/index.html) contains documentation for all types, modules, and functions in the library. 

 * For enhanced debugging and API documentation experience, FsVerbalExpressions implements [SourceLink](http://ctaggart.github.io/SourceLink/ "SourceLink")

Versioning
-----------------------

 FsVerbalExpressions adheres to [Semantic Versioning](http://semver.org/ "Semantic Versioning"). So long as the project is pre-1.0.0 minor versions may be breaking. Once the project reaches 1.0.0 minor enhancements will be backwards-compatible.
 
Contributing and copyright
--------------------------

FsVerbalExpressions is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project, and submit pull requests, so long as pull requests:

 * include excellent unit test coverage 
 * include correct intellisense documentation
 * adhere to the concepts of composability and Verbal Expressions

FsVerbalExpressions  is available under Public Domain license, which allows modification and 
redistribution for both commercial and non-commercial purposes. For more information see the 
[License file][license] in the GitHub repository. 

  [content]: http://github.com/VerbalExpressions/FSharpVerbalExpressions/tree/master/docs/content
  [gh]: http://github.com/VerbalExpressions/FSharpVerbalExpressions
  [issues]: http://github.com/VerbalExpressions/FSharpVerbalExpressions/issues
  [readme]: http://github.com/VerbalExpressions/FSharpVerbalExpressions/blob/master/README.md
  [license]: http://github.com/VerbalExpressions/FSharpVerbalExpressions/blob/master/LICENSE.txt
*)
