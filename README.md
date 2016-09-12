[![Issue Stats](http://issuestats.com/github/verbalexpressions/FsVerbalExpressions/badge/issue)](http://issuestats.com/github/verbalexpressions/FsVerbalExpressions)
[![Issue Stats](http://issuestats.com/github/verbalexpressions/FsVerbalExpressions/badge/pr)](http://issuestats.com/github/verbalexpressions/FsVerbalExpressions)

# FsVerbalExpressions

The `FsVerbalExpressions` library provides composable F# functionality for nearly all the capabilites of the .NET `Regex` class, supporting uniform pipe forward `|>` composability and all `Regex` features except timeouts. Optionally you can compose F# verbal expressions in natural language. Lazy evaluation ensures natural language composition imposes no performance penalty.

The `FsRegEx` module contains composable functions representing all available `Regex` functionality (except timeouts) with the target input string uniformly the last parameter to better support pipe forward `|>` composition and partial application. 

- Documentation: [FsVerbalExpressions](http://verbalexpressions.github.io/FSharpVerbalExpressions/)
- Nuget: [FsVerbalExpressions](https://www.nuget.org/packages/FsVerbalExpressions "FsVerbalExpressions")

For enhanced debugging and API documentation experience, FsVerbalExpressions proudly implements [SourceLink](http://ctaggart.github.io/SourceLink/ "SourceLink")

## Pull requests welcome so long as 

- they include excellent unit test coverage 
- they include correct intellisense documentation
- they adhere to the concepts of composability and Verbal Expressions

FsVerbalExpressions adheres to [Semantic Versioning](http://semver.org/ "Semantic Versioning"). So long as the project is pre-1.0.0 minor versions may be breaking. Once the project reaches 1.0.0 minor enhancements will be backwards-compatible.

## About Verbal Expressions

You can see an up to date list of all ports of Verbal Expressions on [VerbalExpressions](http://verbalexpressions.github.io).

Giving credit where credit is due, the [CSharpVerbalExpressions](https://github.com/VerbalExpressions/CSharpVerbalExpressions "CSharpVerbalExpressions") was a great help in providing pre-made unit tests and inspiration for .NET specific functionality.

## Maintainer(s)

- [@jackfoxy](https://github.com/jackfoxy)

