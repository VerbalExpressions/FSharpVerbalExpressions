namespace FsVerbalExpressions

open System.Text.RegularExpressions

///Composable regular expressions functions.
module FsRegEx =

    ///Searches the specified input string for the first occurrence of the regular expression.
    val firstMatch : regularExpression : string -> input : string -> FsMatch

    ///Searches the specified input string for the first occurrence of the regular expression with Regex options.
    val firstMatchOpt : regularExpression : string -> regexOptions : RegexOptions -> input : string -> FsMatch

    ///Searches the specified input string for the first occurrence of the regular expression beginning at the specified starting position.
    val matchAt : regularExpression : string -> startAt : int -> input : string -> FsMatch

    ///Searches the specified input string for the first occurrence of the regular expression beginning at the specified starting position with Regex options.
    val matchAtOpt : regularExpression : string -> regexOptions : RegexOptions -> startAt : int -> input : string -> FsMatch

    ///Searches the specified input string for the first occurrence of the VerbExbeginning at the starting position for the length.
    val matchAtFor : regularExpression : string -> startAt : int ->  length : int -> input : string -> FsMatch

    ///Searches the specified input string for the first occurrence of the VerbExbeginning at the starting position for the length with Regex options.
    val matchAtForOpt : regularExpression : string -> regexOptions : RegexOptions -> startAt : int ->  length : int -> input : string -> FsMatch

    ///Searches the specified input string for all occurrences of a regular expression with Regex options.
    val matches : regularExpression : string -> input : string -> FsMatch[]

    ///Searches the specified input string for all occurrences of a regular expression.
    val matchesOpt : regularExpression : string -> regexOptions : RegexOptions -> input : string -> FsMatch[]

    ///Searches the input string for all occurrence of a regular expression, beginning at the specified starting position.
    val matchesAt : regularExpression : string -> startAt : int -> input : string -> FsMatch[]

    ///Searches the input string for all occurrence of a regular expression, beginning at the specified starting position with Regex options.
    val matchesAtOpt : regularExpression : string -> regexOptions : RegexOptions -> startAt : int -> input : string -> FsMatch[]

    ///In input string replaces all strings that match regular expression pattern with replacement string.
    val replace : regularExpression : string -> replacement : string -> input : string -> string

    ///In input string replaces all strings that match regular expression with string returned by MatchEvaluator delegate.
    val replaceByMatch : regularExpression : string -> evalutor : MatchEvaluator -> input : string -> string

    ///In input string replaces all strings that match regular expression with string returned by MatchEvaluator delegate with Regex options.
    val replaceByMatchOpt : regularExpression : string -> regexOptions : RegexOptions -> evalutor : MatchEvaluator -> input : string -> string

    ///In input string replaces a specified maximum number of strings that match regular expression with replacement string.
    val replaceMaxTimes : regularExpression : string -> replacement : string -> count : int -> input : string -> string

    ///In input string replaces a specified maximum number of strings that match regular expression with replacement string with Regex options.
    val replaceMaxTimesOpt : regularExpression : string -> regexOptions : RegexOptions -> replacement : string -> count : int -> input : string -> string

    ///In input string replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate.
    val replaceByMatchMaxTimes : regularExpression : string -> evalutor : MatchEvaluator -> count : int -> input : string -> string

    ///In input string replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate with Regex options.
    val replaceByMatchMaxTimesOpt : regularExpression : string -> regexOptions : RegexOptions -> evalutor : MatchEvaluator -> count : int -> input : string -> string

    ///In input string beginning at start at position replaces a specified maximum number of strings that match regular expression with replacement string.
    val replaceMaxTimesStartAt : regularExpression : string -> replacement : string -> count : int -> startAt : int -> input : string -> string

    ///In input string beginning at start at position replaces a specified maximum number of strings that match regular expression with replacement string with Regex options.
    val replaceMaxTimesStartAtOpt : regularExpression : string -> regexOptions : RegexOptions -> replacement : string -> count : int -> startAt : int -> input : string -> string

    ///In input string beginning at start at position replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate.
    val replaceByMatchMaxTimesStartAt : regularExpression : string -> evalutor : MatchEvaluator -> count : int -> startAt : int -> input : string -> string

    ///In input string beginning at start at position replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate with Regex options.
    val replaceByMatchMaxTimesStartAtOpt : regularExpression : string -> regexOptions : RegexOptions -> evalutor : MatchEvaluator -> count : int -> startAt : int -> input : string -> string

    ///Splits input string into an array of substrings at the positions defined by regular expression.
    val split : regularExpression : string -> input : string -> array<string>

    ///Splits input string into an array of substrings at the positions defined by regular expression with Regex options.
    val splitOpt : regularExpression : string -> regexOptions : RegexOptions -> input : string -> array<string>

    ///Splits input string a specified maximum number of times into an array of substrings at the positions defined by regular expression.
    val splitMaxTimes : regularExpression : string -> count : int -> input : string -> array<string>

    ///Splits input string a specified maximum number of times into an array of substrings at the positions defined by regular expression with Regex options.
    val splitMaxTimesOpt : regularExpression : string -> regexOptions : RegexOptions -> count : int -> input : string -> array<string>

    ///Splits input string, begining at start position, a specified maximum number of times into an array of substrings at the positions defined by regular expression.
    val splitMaxTimesStartAt : regularExpression : string -> count : int -> startAt : int -> input : string -> array<string>

    ///Splits input string, begining at start position, a specified maximum number of times into an array of substrings at the positions defined by regular expression with Regex options.
    val splitMaxTimesStartAtOpt : regularExpression : string -> regexOptions : RegexOptions -> count : int -> startAt : int -> input : string -> array<string>

    ///Match and select groupname value.
    val capture : regularExpression : string  -> groupName : string -> input : string -> string

    ///Match and select groupname value with Regex options.
    val captureOpt : regularExpression : string  -> regexOptions : RegexOptions -> groupName : string -> input : string -> string

    ///Match and select group.
    val captureGroup : regularExpression : string -> groupName : string -> input : string -> FsGroup

    ///Match and select group with Regex options.
    val captureGroupOpt : regularExpression : string -> regexOptions : RegexOptions -> groupName : string -> input : string -> FsGroup

    ///Returns an array of capturing group names for the regular expression.
    val groupNames : regularExpression : string -> array<string>

    ///Returns an array of capturing group numbers that correspond to group names in an array.
    val groupNumbers : regularExpression : string -> array<int>

    ///Indicates whether the regular expression finds a match in the input string.
    val isMatch : regularExpression : string  -> input : string -> bool

    ///Indicates whether the regular expression finds a match in the input string with Regex options.
    val isMatchOpt : regularExpression : string  -> regexOptions : RegexOptions -> input : string -> bool

    ///Indicates whether the regular expression finds a match in the input string beginning at the specified starting position.
    val isMatchAt : regularExpression : string -> startAt : int -> input : string -> bool

    ///Indicates whether the regular expression finds a match in the input string beginning at the specified starting position with Regex options.
    val isMatchAtOpt : regularExpression : string -> regexOptions : RegexOptions -> startAt : int -> input : string -> bool
