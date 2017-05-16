#### 0.6.1 - May 16, 2017
* deprecated in favor of FsRegEx, https://jackfoxy.github.io/FsRegEx/index.html

#### 0.6.0 - November 13, 2016
* breaking change
* GroupNameFromNumber and GroupNumberFromName are option types
* add name to FsGroup
* hide FsGroup and FsMatch constructors

#### 0.5.0 - September 11, 2016
* breaking change
* new module, FsRegEx, of composable regular expressions functions
* added tests of RegularExpressions email validation
* renamed Match' type to FsMatch, moved to root namespace
* renamed Group' type to FsGroup, moved to root namespace
* renamed match' function in VerbalExpression module firstMatch
* fixed bugs in reuse of VerbEx Groups() and Captures()
* return FsMatch where previously Regex Match returned

#### 0.4.0 - May 17, 2016
* or' can be first VE is series of or's

#### 0.3.1 - January 17, 2016
* internals

#### 0.3.0 - January 16, 2016
* breaking change
* VerbEx now fully composable
* Match' composable System.Text.RegularExpressions.Match type
* Group' composable System.Text.RegularExpressions.Group type
* System.Text.RegularExpressions special collections returned as arrays
* VerbEx timeout constructor added
* added exists, fold, foldBack, iter, and map for VerbalExpression module
* eliminated underscores in unicode names

#### 0.2.0 - January 10, 2016
* breaking change
* put UniCodeGeneralCategory and SupportedNamedBlock under the namespace

#### 0.1.0 - January 9, 2016
* Initial release
