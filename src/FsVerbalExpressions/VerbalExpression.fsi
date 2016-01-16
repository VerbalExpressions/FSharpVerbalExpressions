namespace FsVerbalExpressions

open System
open System.Text.RegularExpressions

///Composable immutable wrapping types and functions for .Net Regex.
module VerbalExpression = 

    [<Class>]
    ///Composable wrapping type for System.Text.RegularExpressions.Group.
    type Group' =
        new : Group -> Group'

        ///Returns array of captures matched by the capturing group, in innermost-leftmost-first order (or innermost-rightmost-first order if the regular expression is modified with the RegexOptions.RightToLeft option). 
        member Captures : unit -> Capture []

        ///The underlying System.Text.RegularExpressions.Group.
        member Group : Group

        ///The position in the original string where the first character of the captured substring is found.
        member Index : int

        ///Returns the length of the captured substring.
        member Length : int

        ///Returns a value indicating whether the match is successful.
        member Success : bool

        ///Returns the captured substring from the input string.
        member Value : string

    [<Class>]
    ///Composable wrapping type for System.Text.RegularExpressions.Match.
    type Match' =
        new : Match -> Match'

        ///Returns array of captures matched by the capturing group, in innermost-leftmost-first order (or innermost-rightmost-first order if the regular expression is modified with the RegexOptions.RightToLeft option). 
        member Captures : unit -> Capture []

        ///Returns array of groups matched by the regular expression.
        member Groups : unit -> Group' []

        ///The position in the original string where the first character of the captured substring is found.
        member Index : int

        ///Returns the length of the captured substring.
        member Length : int

        ///The underlying System.Text.RegularExpressions.Match.
        member Match : Match

        ///Returns the expansion of the specified replacement pattern.
        member Result : replacement : string ->  string

        ///Returns a value indicating whether the match is successful.
        member Success : bool

        ///Returns the captured substring from the input string.
        member Value : string

    [<Class>]
    ///Composable immutable wrapping type for System.Text.RegularExpressions.Regex.
    type VerbEx =
        new : unit -> VerbEx
        new : regexOptions : RegexOptions -> VerbEx
        new : regularExpression : string -> VerbEx
        new : regularExpression : string * regexOptions : RegexOptions -> VerbEx
        new : regularExpression : string * regexOptions : RegexOptions * matchTimeout : TimeSpan -> VerbEx

        ///Match and select groupname value.
        member Capture : input : string -> string -> string

        ///Gets the group name that corresponds to the specified group number.
        member GroupNameFromNumber : n : int -> string

        ///Returns an array of capturing group names for the regular expression.
        member GroupNames : unit -> array<string>

        ///Returns the group number that corresponds to the specified group name.
        member GroupNumberFromName : groupName : string -> int

        ///Returns an array of capturing group numbers that correspond to group names in an array.
        member GroupNumbers : unit -> array<int>

        ///Indicates whether the regular expression finds a match in the input string.
        member IsMatch : input : string -> bool

        ///Indicates whether the regular expression finds a match in the input string beginning at the specified starting position.
        member IsMatch : input : string * startAt : int -> bool

        ///Searches the specified input string for the first occurrence of the regular expression.
        member Match : input : string -> Match

        ///Searches the specified input string for the first occurrence of the regular expression beginning at the specified starting position.
        member Match : input : string * startAt : int -> Match

        ///Searches the specified input string for the first occurrence of the regular expression beginning at the starting position for the length.
        member Match : input : string * startAt : int * length : int -> Match

        ///Searches the specified input string for all occurrences of a regular expression.
        member Matches : input : string -> Match'[]

        ///Searches the input string for the first occurrence of a regular expression, beginning at the specified starting position.
        member Matches : input : string * startAt : int -> Match'[]

        ///Gets the time-out interval of the current instance.
        member MatchTimeout : TimeSpan

        ///The underlying System.Text.RegularExpressions.Regex
        member Regex : Regex

        ///Enumerated values to use to set regular expression options.
        member RegexOptions : RegexOptions

        ///In input string replaces all strings that match regular expression pattern with replacement string.
        member Replace : input : string * replacement : string -> string

        ///In input string replaces all strings that match regular expression with string returned by MatchEvaluator delegate.
        member Replace : input : string * evalutor : MatchEvaluator -> string

        ///In input string replaces a specified maximum number of strings that match regular expression with replacement string.
        member Replace : input : string * replacement : string * count : int -> string

        ///In input string replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate.
        member Replace : input : string * evalutor : MatchEvaluator * count : int -> string

        ///In input string beginning at start at position replaces a specified maximum number of strings that match regular expression with replacement string.
        member Replace : input : string * replacement : string * count : int * startAt : int -> string

        ///In input string beginning at start at position replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate.
        member Replace : input : string * evalutor : MatchEvaluator * count : int * startAt : int -> string

        ///Indicates whether the regular expression searches from right to left.
        member RightToLeft : bool

        ///Splits input string into an array of substrings at the positions defined by regular expression.
        member Split : input : string -> array<string>

        ///Splits input string a specified maximum number of times into an array of substrings at the positions defined by regular expression.
        member Split : input : string * count : int -> array<string>

        ///Splits input string, begining at start position, a specified maximum number of times into an array of substrings at the positions defined by regular expression.
        member Split : input : string * count : int * startAt : int -> array<string>

    ///Searches the specified input string for the first occurrence of the VerbEx.
    val match' : input : string -> verbEx : VerbEx -> Match

    ///Searches the specified input string for the first occurrence of the VerbEx beginning at the specified starting position.
    val matchAt : input : string -> startAt : int -> verbEx : VerbEx -> Match

    ///Searches the specified input string for the first occurrence of the VerbExbeginning at the starting position for the length.
    val matchAtFor : input : string -> startAt : int ->  length : int -> verbEx : VerbEx -> Match

    ///Searches the specified input string for all occurrences of a regular expression.
    val matches : input : string -> verbEx : VerbEx -> Match'[]

    ///Searches the input string for the first occurrence of a regular expression, beginning at the specified starting position.
    val matchesAt : input : string -> startAt : int -> verbEx : VerbEx -> Match'[]

    ///In input string replaces all strings that match regular expression pattern with replacement string.
    val replace : input : string -> replacement : string -> verbEx : VerbEx -> string

    ///In input string replaces all strings that match regular expression with string returned by MatchEvaluator delegate.
    val replaceByMatch : input : string -> evalutor : MatchEvaluator -> verbEx : VerbEx -> string

    ///In input string replaces a specified maximum number of strings that match regular expression with replacement string.
    val replaceMaxTimes : input : string -> replacement : string -> count : int -> verbEx : VerbEx -> string

    ///In input string replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate.
    val replaceByMatchMaxTimes : input : string -> evalutor : MatchEvaluator -> count : int -> verbEx : VerbEx -> string

    ///In input string beginning at start at position replaces a specified maximum number of strings that match regular expression with replacement string.
    val replaceMaxTimesStartAt : input : string -> replacement : string -> count : int -> startAt : int -> verbEx : VerbEx -> string

    ///In input string beginning at start at position replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate.
    val replaceByMatchMaxTimesStartAt : input : string -> evalutor : MatchEvaluator -> count : int -> startAt : int -> verbEx : VerbEx -> string

    ///Splits input string into an array of substrings at the positions defined by regular expression.
    val split : input : string -> verbEx : VerbEx -> array<string>

    ///Splits input string a specified maximum number of times into an array of substrings at the positions defined by regular expression.
    val splitMaxTimes : input : string -> count : int -> verbEx : VerbEx -> array<string>

    ///Splits input string, begining at start position, a specified maximum number of times into an array of substrings at the positions defined by regular expression.
    val splitMaxTimesStartAt : input : string -> count : int -> startAt : int -> verbEx : VerbEx -> array<string>

    ///Return new VerbEx with new RegExOptions.
    val resetRegexOptions : newRegexOptions : RegexOptions option -> verbEx : VerbEx -> VerbEx

    ///Match and select groupname value.
    val capture : input : string -> groupName : string -> verbEx : VerbEx -> string

    ///Indicates whether the regular expression finds a match in the input string.
    val isMatch : value : string -> verbEx : VerbEx -> bool

    ///Indicates whether the regular expression finds a match in the input string beginning at the specified starting position.
    val isMatchAt : value : string -> startAt : int -> verbEx : VerbEx -> bool

    ///Returns an array of capturing group names for the regular expression.
    val groupNames : verbEx : VerbEx -> array<string>

    ///Returns an array of capturing group numbers that correspond to group names in an array.
    val groupNumbers : verbEx : VerbEx -> array<int>

    ///Value of regular expression.
    val toString : verbEx : VerbEx -> string

    ///Mark the expression to start at the beginning of the line; ^
    val startOfLine : verbEx : VerbEx -> VerbEx

    ///Mark the expression to end at the last character of the line; $
    val endOfLine : verbEx : VerbEx -> VerbEx

    ///Append unescaped literal expression to the expression.
    val add : value : string -> verbEx : VerbEx -> VerbEx

    ///Append escaped literal expression to the expression. (Same as find.)
    val then' : value : string -> verbEx : VerbEx -> VerbEx

    ///Append escaped literal expression to the expression. (Same as then'.)
    val find : value : string -> verbEx : VerbEx -> VerbEx

    ///Add escaped string to the expression that might appear once (or not); (value)?
    val maybe : value : string -> verbEx : VerbEx -> VerbEx

    ///Zero or more of any character; (.*)
    val anything : verbEx : VerbEx -> VerbEx

    ///Zero or more of any character except escaped character(s); ([^value]*)
    val anythingBut : value : string -> verbEx : VerbEx -> VerbEx

    ///One or more of any character; (.+)
    val something : verbEx : VerbEx -> VerbEx
    
    ///One or more of any character except escaped character; ([^%s]+)
    val somethingBut : value : string -> verbEx : VerbEx -> VerbEx

    ///Refers to nth occurence of capturing groups; \ordinal
    val backReference : ordinal : int -> verbEx : VerbEx -> VerbEx

    ///Refers to named capturing group; \k<groupname>
    val namedBackReference : groupname : string -> verbEx : VerbEx -> VerbEx

    ///Add expression to match a range (or multiple ranges), unescaped values.
    val range : collection : seq<obj> -> verbEx : VerbEx -> VerbEx

    ///Matches universal line break expression; \n
    val lineBreak : verbEx : VerbEx -> VerbEx

    ///Same as lineBreak; \n
    val br : verbEx : VerbEx ->  VerbEx

    ///Matches a tab character; \t
    val tab : verbEx : VerbEx -> VerbEx

    ///Matches any white-space character; \s
    val whiteSpace : verbEx : VerbEx -> VerbEx

    ///Matches any non-white-space character; \S.
    val nonWhiteSpace : verbEx : VerbEx -> VerbEx

    ///Expression to match a word; \w+
    val word : verbEx : VerbEx -> VerbEx

    ///Matches any word character; \w
    val wordCharacter  : verbEx : VerbEx -> VerbEx

    ///Matches any nonword character; \W
    val nonWordCharacter  : verbEx : VerbEx -> VerbEx

    ///Matches any decimal digit; \d
    val digit  : verbEx : VerbEx -> VerbEx

    ///Matches any nondigit; \D
    val nonDigit  : verbEx : VerbEx -> VerbEx

    ///Matches any single character included in the specified set of escaped characters; [value]
    val anyOf : value : string -> verbEx : VerbEx -> VerbEx

    ///Same as anyOf.
    val any : value : string -> verbEx : VerbEx ->  VerbEx

    ///The escaped expression 1 or more times; (value)+
    val multiple : value : string -> verbEx : VerbEx -> VerbEx

    ///The VerbEx 1 or more times; (sourceVerbEx)+
    val multipleVerbEx : sourceVerbEx : VerbEx -> verbEx : VerbEx -> VerbEx

    ///Or's the regular expression to the regular expression in a VerbEx.
    val or' : regularExpression : string -> verbEx : VerbEx -> VerbEx

    ///Return new VerbEx of two VerbExs or'ed.
    val verbExOrVerbEx : regexOptions : RegexOptions -> verbEx : VerbEx -> verbEx : VerbEx -> VerbEx

    ///Begin capture group; (
    val beginCapture : verbEx : VerbEx -> VerbEx

    ///Begin named capture group ;(?<groupName>
    val beginCaptureNamed : groupName : string -> verbEx : VerbEx -> VerbEx

    ///End capture group; )
    val endCapture : verbEx : VerbEx -> VerbEx

    ///Repeat previous exact number of times; {n}
    val repeatPrevious : n : int -> VerbEx -> VerbEx

    ///Repeat previous number of times between n and m; {n,m}
    val repeatBetweenPrevious : n : int ->  m : int -> VerbEx -> VerbEx

    ///Matches a Unicode character by using hexadecimal representation  (exactly four digits, as represented by nnnn); \unnnn
    val unicode : nnnn : string -> VerbEx -> VerbEx

    ///Matches any single character in the Unicode general category; \p{name}
    val unicodeCategory : category : UniCodeGeneralCategory -> VerbEx -> VerbEx

    ///Matches any single character that is not in the Unicode general category; \P{name}
    val notUnicodeCategory : category : UniCodeGeneralCategory -> VerbEx -> VerbEx

    ///Matches any single character in the supported named block; \p{name}
    val namedBlock : name : SupportedNamedBlock -> VerbEx -> VerbEx

    ///Matches any single character that is not in the supported named block; \P{name}
    val notNamedBlock : name : SupportedNamedBlock -> VerbEx -> VerbEx

    ///Executes a function on a VerbEx.
    val iter : f : (VerbEx -> unit) -> verbEx : VerbEx -> unit

    ///Transforms a Verbex with a mapping function
    val map : f : (VerbEx -> VerbEx) -> verbEx : VerbEx -> VerbEx

    ///Applies a function to a VerbEx and a state returning a state
    val fold : f : ('State -> VerbEx -> 'State) -> state : 'State -> verbEx : VerbEx -> 'State

    ///Applies a function to a VerbEx and a state returning a state
    val foldBack : f : (VerbEx -> 'State -> 'State) -> verbEx : VerbEx -> state : 'State -> 'State

    ///Evaluates the boolean function on the VerbEx
    val exists : f : (VerbEx -> bool) -> verbEx : VerbEx -> bool
