namespace FsVerbalExpressions

open System
open System.Text.RegularExpressions

///Composable immutable wrapping type for .Net Regex.
module VerbalExpression = 

    type UniCodeGeneralCategory =
        ///Letter, Uppercase; Lu
        | LetterUppercase
        ///Letter, Lowercase; Ll
        | LetterLowercase
        ///Letter, Titlecase; Lt
        | LetterTitlecase
        ///Letter, Modifier; Lm
        | LetterModifier
        ///Letter, Other; Lo
        | LetterOther
        ///All letter characters. This includes the LetterUppercase, LetterLowercase, LetterTitlecase, LetterModifier, and LetterOther characters; L
        | Letter
        ///Mark, Nonspacing; Mn
        | MarkNonspacing
        ///Mark, Spacing Combining; Mc
        | MarkSpacingCombining
        ///Mark, Enclosing; Me
        | MarkEnclosing
        ///All diacritic marks. This includes the MarkNonspacing, MarkSpacingCombining, and MarkEnclosing categories; M
        | Mark
        ///Number, Decimal Digit; Nd
        | NumberDecimalDigit
        ///Number, Letter; Nl
        | NumberLetter
        ///Number, Other; No
        | NumberOther
        ///All numbers. This includes the Nd, Nl, and No categories; N
        | NumberALL
        ///Punctuation, Connector; Pc
        | PunctuationConnector
        ///Punctuation, Dash; Pd
        | PunctuationDash
        ///Punctuation, Open; Ps
        | PunctuationOpen
        ///Punctuation, Close; Pe
        | PunctuationClose
        ///Punctuation, Initial quote (may behave like Ps or Pe depending on usage); Pi
        | PunctuationInitial
        ///Punctuation, Final quote (may behave like Ps or Pe depending on usage); Pf
        | PunctuationFinal
        ///Punctuation, Other; Po
        | PunctuationOther
        ///All punctuation characters. This includes the PunctuationConnector, PunctuationDash, PunctuationOpen, PunctuationClose, PunctuationInitial, PunctuationFinal, and PunctuationOther categories; P
        | Punctuation
        ///Symbol, Math; Sm
        | SymbolMath
        ///Symbol, Currency; Sc
        | SymbolCurrency
        ///Symbol, Modifier; Sk
        | SymbolModifier
        ///Symbol, Other; So
        | SymbolOther
        ///All symbols. This includes the SymbolMath, SymbolCurrency, SymbolModifier, and SymbolOther categories; S
        | Symbol
        ///Separator, Space; Zs
        | SeparatorSpace
        ///Separator, Line; Zl
        | SeparatorLine
        ///Separator, Paragraph; Zp
        | SeparatorParagraph
        ///All separator characters. This includes the SeparatorSpace, SeparatorLine, and SeparatorLine categories; Z
        | Separator
        ///Other, Control; Cc
        | OtherControl
        ///Other, Format; Cf
        | OtherFormat
        ///Other, Surrogate; Cs
        | OtherSurrogate
        ///Other, Private Use; Co
        | OtherPrivateUse
        ///Other, Not Assigned (no characters have this property); Cn
        | OtherNotAssigned
        ///All control characters. This includes the OtherControl, OtherFormat, OtherSurrogate, OtherPrivateUse, and OtherNotAssigned categories; C
        | ControlAll

    type SupportedNamedBlock =
        ///0000 - 007F
        | IsBasicLatin
        ///0080 - 00FF
        | IsLatin_1Supplement
        ///0100 - 017F
        | IsLatinExtended_A
        ///0180 - 024F
        | IsLatinExtended_B
        ///0250 - 02AF
        | IsIPAExtensions
        ///02B0 - 02FF
        | IsSpacingModifierLetters
        ///0300 - 036F
        | IsCombiningDiacriticalMarks
        ///0370 - 03FF
        | IsGreek
        ///0370 - 03FF
        | IsGreekandCoptic
        ///0400 - 04FF
        | IsCyrillic
        ///0500 - 052F
        | IsCyrillicSupplement
        ///0530 - 058F
        | IsArmenian
        ///0590 - 05FF
        | IsHebrew
        ///0600 - 06FF
        | IsArabic
        ///0700 - 074F
        | IsSyriac
        ///0780 - 07BF
        | IsThaana
        ///0900 - 097F
        | IsDevanagari
        ///0980 - 09FF
        | IsBengali
        ///0A00 - 0A7F
        | IsGurmukhi
        ///0A80 - 0AFF
        | IsGujarati
        ///0B00 - 0B7F
        | IsOriya
        ///0B80 - 0BFF
        | IsTamil
        ///0C00 - 0C7F
        | IsTelugu
        ///0C80 - 0CFF
        | IsKannada
        ///0D00 - 0D7F
        | IsMalayalam
        ///0D80 - 0DFF
        | IsSinhala
        ///0E00 - 0E7F
        | IsThai
        ///0E80 - 0EFF
        | IsLao
        ///0F00 - 0FFF
        | IsTibetan
        ///1000 - 109F
        | IsMyanmar
        ///10A0 - 10FF
        | IsGeorgian
        ///1100 - 11FF
        | IsHangulJamo
        ///1200 - 137F
        | IsEthiopic
        ///13A0 - 13FF
        | IsCherokee
        ///1400 - 167F
        | IsUnifiedCanadianAboriginalSyllabics
        ///1680 - 169F
        | IsOgham
        ///16A0 - 16FF
        | IsRunic
        ///1700 - 171F
        | IsTagalog
        ///1720 - 173F
        | IsHanunoo
        ///1740 - 175F
        | IsBuhid
        ///1760 - 177F
        | IsTagbanwa
        ///1780 - 17FF
        | IsKhmer
        ///1800 - 18AF
        | IsMongolian
        ///1900 - 194F
        | IsLimbu
        ///1950 - 197F
        | IsTaiLe
        ///19E0 - 19FF
        | IsKhmerSymbols
        ///1D00 - 1D7F
        | IsPhoneticExtensions
        ///1E00 - 1EFF
        | IsLatinExtendedAdditional
        ///1F00 - 1FFF
        | IsGreekExtended
        ///2000 - 206F
        | IsGeneralPunctuation
        ///2070 - 209F
        | IsSuperscriptsandSubscripts
        ///20A0 - 20CF
        | IsCurrencySymbols
        ///20D0 - 20FF
        | IsCombiningDiacriticalMarksforSymbols
        ///20D0 - 20FF
        | IsCombiningMarksforSymbols
        ///2100 - 214F
        | IsLetterlikeSymbols
        ///2150 - 218F
        | IsNumberForms
        ///2190 - 21FF
        | IsArrows
        ///2200 - 22FF
        | IsMathematicalOperators
        ///2300 - 23FF
        | IsMiscellaneousTechnical
        ///2400 - 243F
        | IsControlPictures
        ///2440 - 245F
        | IsOpticalCharacterRecognition
        ///2460 - 24FF
        | IsEnclosedAlphanumerics
        ///2500 - 257F
        | IsBoxDrawing
        ///2580 - 259F
        | IsBlockElements
        ///25A0 - 25FF
        | IsGeometricShapes
        ///2600 - 26FF
        | IsMiscellaneousSymbols
        ///2700 - 27BF
        | IsDingbats
        ///27C0 - 27EF
        | IsMiscellaneousMathematicalSymbols_A
        ///27F0 - 27FF
        | IsSupplementalArrows_A
        ///2800 - 28FF
        | IsBraillePatterns
        ///2900 - 297F
        | IsSupplementalArrows_B
        ///2980 - 29FF
        | IsMiscellaneousMathematicalSymbols_B
        ///2A00 - 2AFF
        | IsSupplementalMathematicalOperators
        ///2B00 - 2BFF
        | IsMiscellaneousSymbolsandArrows
        ///2E80 - 2EFF
        | IsCJKRadicalsSupplement
        ///2F00 - 2FDF
        | IsKangxiRadicals
        ///2FF0 - 2FFF
        | IsIdeographicDescriptionCharacters
        ///3000 - 303F
        | IsCJKSymbolsandPunctuation
        ///3040 - 309F
        | IsHiragana
        ///30A0 - 30FF
        | IsKatakana
        ///3100 - 312F
        | IsBopomofo
        ///3130 - 318F
        | IsHangulCompatibilityJamo
        ///3190 - 319F
        | IsKanbun
        ///31A0 - 31BF
        | IsBopomofoExtended
        ///31F0 - 31FF
        | IsKatakanaPhoneticExtensions
        ///3200 - 32FF
        | IsEnclosedCJKLettersandMonths
        ///3300 - 33FF
        | IsCJKCompatibility
        ///3400 - 4DBF
        | IsCJKUnifiedIdeographsExtensionA
        ///4DC0 - 4DFF
        | IsYijingHexagramSymbols
        ///4E00 - 9FFF
        | IsCJKUnifiedIdeographs
        ///A000 - A48F
        | IsYiSyllables
        ///A490 - A4CF
        | IsYiRadicals
        ///AC00 - D7AF
        | IsHangulSyllables
        ///D800 - DB7F
        | IsHighSurrogates
        ///DB80 - DBFF
        | IsHighPrivateUseSurrogates
        ///DC00 - DFFF
        | IsLowSurrogates
        ///E000 - F8FF
        | IsPrivateUse
        ///F900 - FAFF
        | IsCJKCompatibilityIdeographs 
        ///FB00 - FB4F
        | IsAlphabeticPresentationForms 
        ///FB50 - FDFF
        | IsArabicPresentationForms_A 
        ///FE00 - FE0F
        | IsVariationSelectors 
        ///FE20 - FE2F
        | IsCombiningHalfMarks 
        ///FE30 - FE4F
        | IsCJKCompatibilityForms 
        ///FE50 - FE6F
        | IsSmallFormVariants 
        ///FE70 - FEFF
        | IsArabicPresentationForms_B 
        ///FF00 - FFEF
        | IsHalfwidthandFullwidthForms 
        ///FFF0 - FFFF
        | IsSpecials

    [<Class>]
    ///Composable immutable wrapping type for .Net Regex.
    type VerbEx =
        new : regularExpression : string * regexOptions : RegexOptions -> VerbEx
        new : regularExpression : string -> VerbEx
        new : regexOptions : RegexOptions -> VerbEx
        new : unit -> VerbEx

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
        member Matches : input : string -> MatchCollection

        ///Searches the input string for the first occurrence of a regular expression, beginning at the specified starting position.
        member Matches : input : string * startAt : int -> MatchCollection

        ///Gets the time-out interval of the current instance.
        member MatchTimeout : TimeSpan

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
    val matches : input : string -> verbEx : VerbEx -> MatchCollection

    ///Searches the input string for the first occurrence of a regular expression, beginning at the specified starting position.
    val matchesAt : input : string -> startAt : int -> verbEx : VerbEx -> MatchCollection

    ///In input string replaces all strings that match regular expression pattern with replacement string.
    val Replace : input : string -> replacement : string -> verbEx : VerbEx -> string

    ///In input string replaces all strings that match regular expression with string returned by MatchEvaluator delegate.
    val ReplaceByMatch : input : string -> evalutor : MatchEvaluator -> verbEx : VerbEx -> string

    ///In input string replaces a specified maximum number of strings that match regular expression with replacement string.
    val ReplaceMaxTimes : input : string -> replacement : string -> count : int -> verbEx : VerbEx -> string

    ///In input string replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate.
    val ReplaceByMatchMaxTimes : input : string -> evalutor : MatchEvaluator -> count : int -> verbEx : VerbEx -> string

    ///In input string beginning at start at position replaces a specified maximum number of strings that match regular expression with replacement string.
    val ReplaceMaxTimesStartAt : input : string -> replacement : string -> count : int -> startAt : int -> verbEx : VerbEx -> string

    ///In input string beginning at start at position replaces a specified maximum number of strings that match a regular expression with string returned by MatchEvaluator delegate.
    val ReplaceByMatchMaxTimesStartAt : input : string -> evalutor : MatchEvaluator -> count : int -> startAt : int -> verbEx : VerbEx -> string

    ///Splits input string into an array of substrings at the positions defined by regular expression.
    val Split : input : string -> verbEx : VerbEx -> array<string>

    ///Splits input string a specified maximum number of times into an array of substrings at the positions defined by regular expression.
    val SplitMaxTimes : input : string -> count : int -> verbEx : VerbEx -> array<string>

    ///Splits input string, begining at start position, a specified maximum number of times into an array of substrings at the positions defined by regular expression.
    val SplitMaxTimesStartAt : input : string -> count : int -> startAt : int -> verbEx : VerbEx -> array<string>

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
