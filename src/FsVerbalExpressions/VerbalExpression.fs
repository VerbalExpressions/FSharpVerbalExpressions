namespace FsVerbalExpressions

open System
open System.Text.RegularExpressions

module VerbalExpression = 

    type UniCodeGeneralCategory =
        | LetterUppercase
        | LetterLowercase
        | LetterTitlecase
        | LetterModifier
        | LetterOther
        | Letter
        | MarkNonspacing
        | MarkSpacingCombining
        | MarkEnclosing
        | Mark
        | NumberDecimalDigit
        | NumberLetter
        | NumberOther
        | NumberALL
        | PunctuationConnector
        | PunctuationDash
        | PunctuationOpen
        | PunctuationClose
        | PunctuationInitial
        | PunctuationFinal
        | PunctuationOther
        | Punctuation
        | SymbolMath
        | SymbolCurrency
        | SymbolModifier
        | SymbolOther
        | Symbol
        | SeparatorSpace
        | SeparatorLine
        | SeparatorParagraph
        | Separator
        | OtherControl
        | OtherFormat
        | OtherSurrogate
        | OtherPrivateUse
        | OtherNotAssigned
        | ControlAll
        override __.ToString() =
            match __ with
            | LetterUppercase -> "Lu"
            | LetterLowercase -> "Ll"
            | LetterTitlecase -> "Lt"
            | LetterModifier -> "Lm"
            | LetterOther -> "Lo"
            | Letter -> "L"
            | MarkNonspacing -> "Mn"
            | MarkSpacingCombining -> "Mc"
            | MarkEnclosing -> "Me"
            | Mark -> "M"
            | NumberDecimalDigit -> "Nd"
            | NumberLetter -> "Nl"
            | NumberOther -> "No"
            | NumberALL -> "N"
            | PunctuationConnector -> "Pc"
            | PunctuationDash -> "Pd"
            | PunctuationOpen -> "Ps"
            | PunctuationClose -> "Pe"
            | PunctuationInitial -> "Pi"
            | PunctuationFinal -> "Pf"
            | PunctuationOther -> "Po"
            | Punctuation -> "P"
            | SymbolMath -> "Sm"
            | SymbolCurrency -> "Sc"
            | SymbolModifier -> "Sk"
            | SymbolOther -> "So"
            | Symbol -> "S"
            | SeparatorSpace -> "Zs"
            | SeparatorLine -> "Zl"
            | SeparatorParagraph -> "Zp"
            | Separator -> "Z"
            | OtherControl -> "Cc"
            | OtherFormat -> "Cf"
            | OtherSurrogate -> "Cs"
            | OtherPrivateUse -> "Co"
            | OtherNotAssigned -> "Cn"
            | ControlAll -> "C"

    type SupportedNamedBlock =
        | IsBasicLatin
        | IsLatin_1Supplement
        | IsLatinExtended_A
        | IsLatinExtended_B
        | IsIPAExtensions
        | IsSpacingModifierLetters
        | IsCombiningDiacriticalMarks
        | IsGreek
        | IsGreekandCoptic
        | IsCyrillic
        | IsCyrillicSupplement
        | IsArmenian
        | IsHebrew
        | IsArabic
        | IsSyriac
        | IsThaana
        | IsDevanagari
        | IsBengali
        | IsGurmukhi
        | IsGujarati
        | IsOriya
        | IsTamil
        | IsTelugu
        | IsKannada
        | IsMalayalam
        | IsSinhala
        | IsThai
        | IsLao
        | IsTibetan
        | IsMyanmar
        | IsGeorgian
        | IsHangulJamo
        | IsEthiopic
        | IsCherokee
        | IsUnifiedCanadianAboriginalSyllabics
        | IsOgham
        | IsRunic
        | IsTagalog
        | IsHanunoo
        | IsBuhid
        | IsTagbanwa
        | IsKhmer
        | IsMongolian
        | IsLimbu
        | IsTaiLe
        | IsKhmerSymbols
        | IsPhoneticExtensions
        | IsLatinExtendedAdditional
        | IsGreekExtended
        | IsGeneralPunctuation
        | IsSuperscriptsandSubscripts
        | IsCurrencySymbols
        | IsCombiningDiacriticalMarksforSymbols
        | IsCombiningMarksforSymbols
        | IsLetterlikeSymbols
        | IsNumberForms
        | IsArrows
        | IsMathematicalOperators
        | IsMiscellaneousTechnical
        | IsControlPictures
        | IsOpticalCharacterRecognition
        | IsEnclosedAlphanumerics
        | IsBoxDrawing
        | IsBlockElements
        | IsGeometricShapes
        | IsMiscellaneousSymbols
        | IsDingbats
        | IsMiscellaneousMathematicalSymbols_A
        | IsSupplementalArrows_A
        | IsBraillePatterns
        | IsSupplementalArrows_B
        | IsMiscellaneousMathematicalSymbols_B
        | IsSupplementalMathematicalOperators
        | IsMiscellaneousSymbolsandArrows
        | IsCJKRadicalsSupplement
        | IsKangxiRadicals
        | IsIdeographicDescriptionCharacters
        | IsCJKSymbolsandPunctuation
        | IsHiragana
        | IsKatakana
        | IsBopomofo
        | IsHangulCompatibilityJamo
        | IsKanbun
        | IsBopomofoExtended
        | IsKatakanaPhoneticExtensions
        | IsEnclosedCJKLettersandMonths
        | IsCJKCompatibility
        | IsCJKUnifiedIdeographsExtensionA
        | IsYijingHexagramSymbols
        | IsCJKUnifiedIdeographs
        | IsYiSyllables
        | IsYiRadicals
        | IsHangulSyllables
        | IsHighSurrogates
        | IsHighPrivateUseSurrogates
        | IsLowSurrogates
        | IsPrivateUse
        | IsCJKCompatibilityIdeographs 
        | IsAlphabeticPresentationForms 
        | IsArabicPresentationForms_A 
        | IsVariationSelectors 
        | IsCombiningHalfMarks 
        | IsCJKCompatibilityForms 
        | IsSmallFormVariants 
        | IsArabicPresentationForms_B 
        | IsHalfwidthandFullwidthForms 
        | IsSpecials
        override __.ToString() =
            match __ with
            | IsBasicLatin -> "IsBasicLatin"
            | IsLatin_1Supplement -> "IsLatin-1Supplement"
            | IsLatinExtended_A -> "IsLatinExtended-A"
            | IsLatinExtended_B -> "IsLatinExtended-B"
            | IsIPAExtensions -> "IsIPAExtensions"
            | IsSpacingModifierLetters -> "IsSpacingModifierLetters"
            | IsCombiningDiacriticalMarks -> "IsCombiningDiacriticalMarks"
            | IsGreek -> "IsGreek"
            | IsGreekandCoptic -> "IsGreekandCoptic"
            | IsCyrillic -> "IsCyrillic"
            | IsCyrillicSupplement -> "IsCyrillicSupplement"
            | IsArmenian -> "IsArmenian"
            | IsHebrew -> "IsHebrew"
            | IsArabic -> "IsArabic"
            | IsSyriac -> "IsSyriac"
            | IsThaana -> "IsThaana"
            | IsDevanagari -> "IsDevanagari"
            | IsBengali -> "IsBengali"
            | IsGurmukhi -> "IsGurmukhi"
            | IsGujarati -> "IsGujarati"
            | IsOriya -> "IsOriya"
            | IsTamil -> "IsTamil"
            | IsTelugu -> "IsTelugu"
            | IsKannada -> "IsKannada"
            | IsMalayalam -> "IsMalayalam"
            | IsSinhala -> "IsSinhala"
            | IsThai -> "IsThai"
            | IsLao -> "IsLao"
            | IsTibetan -> "IsTibetan"
            | IsMyanmar -> "IsMyanmar"
            | IsGeorgian -> "IsGeorgian"
            | IsHangulJamo -> "IsHangulJamo"
            | IsEthiopic -> "IsEthiopic"
            | IsCherokee -> "IsCherokee"
            | IsUnifiedCanadianAboriginalSyllabics -> "IsUnifiedCanadianAboriginalSyllabics"
            | IsOgham -> "IsOgham"
            | IsRunic -> "IsRunic"
            | IsTagalog -> "IsTagalog"
            | IsHanunoo -> "IsHanunoo"
            | IsBuhid -> "IsBuhid"
            | IsTagbanwa -> "IsTagbanwa"
            | IsKhmer -> "IsKhmer"
            | IsMongolian -> "IsMongolian"
            | IsLimbu -> "IsLimbu"
            | IsTaiLe -> "IsTaiLe"
            | IsKhmerSymbols -> "IsKhmerSymbols"
            | IsPhoneticExtensions -> "IsPhoneticExtensions"
            | IsLatinExtendedAdditional -> "IsLatinExtendedAdditional"
            | IsGreekExtended -> "IsGreekExtended"
            | IsGeneralPunctuation -> "IsGeneralPunctuation"
            | IsSuperscriptsandSubscripts -> "IsSuperscriptsandSubscripts"
            | IsCurrencySymbols -> "IsCurrencySymbols"
            | IsCombiningDiacriticalMarksforSymbols -> "IsCombiningDiacriticalMarksforSymbols"
            | IsCombiningMarksforSymbols -> "IsCombiningMarksforSymbols"
            | IsLetterlikeSymbols -> "IsLetterlikeSymbols"
            | IsNumberForms -> "IsNumberForms"
            | IsArrows -> "IsArrows"
            | IsMathematicalOperators -> "IsMathematicalOperators"
            | IsMiscellaneousTechnical -> "IsMiscellaneousTechnical"
            | IsControlPictures -> "IsControlPictures"
            | IsOpticalCharacterRecognition -> "IsOpticalCharacterRecognition"
            | IsEnclosedAlphanumerics -> "IsEnclosedAlphanumerics"
            | IsBoxDrawing -> "IsBoxDrawing"
            | IsBlockElements -> "IsBlockElements"
            | IsGeometricShapes -> "IsGeometricShapes"
            | IsMiscellaneousSymbols -> "IsMiscellaneousSymbols"
            | IsDingbats -> "IsDingbats"
            | IsMiscellaneousMathematicalSymbols_A -> "IsMiscellaneousMathematicalSymbols-A"
            | IsSupplementalArrows_A -> "IsSupplementalArrows-A"
            | IsBraillePatterns -> "IsBraillePatterns"
            | IsSupplementalArrows_B -> "IsSupplementalArrows-B"
            | IsMiscellaneousMathematicalSymbols_B -> "IsMiscellaneousMathematicalSymbols-B"
            | IsSupplementalMathematicalOperators -> "IsSupplementalMathematicalOperators"
            | IsMiscellaneousSymbolsandArrows -> "IsMiscellaneousSymbolsandArrows"
            | IsCJKRadicalsSupplement -> "IsCJKRadicalsSupplement"
            | IsKangxiRadicals -> "IsKangxiRadicals"
            | IsIdeographicDescriptionCharacters -> "IsIdeographicDescriptionCharacters"
            | IsCJKSymbolsandPunctuation -> "IsCJKSymbolsandPunctuation"
            | IsHiragana -> "IsHiragana"
            | IsKatakana -> "IsKatakana"
            | IsBopomofo -> "IsBopomofo"
            | IsHangulCompatibilityJamo -> "IsHangulCompatibilityJamo"
            | IsKanbun -> "IsKanbun"
            | IsBopomofoExtended -> "IsBopomofoExtended"
            | IsKatakanaPhoneticExtensions -> "IsKatakanaPhoneticExtensions"
            | IsEnclosedCJKLettersandMonths -> "IsEnclosedCJKLettersandMonths"
            | IsCJKCompatibility -> "IsCJKCompatibility"
            | IsCJKUnifiedIdeographsExtensionA -> "IsCJKUnifiedIdeographsExtensionA"
            | IsYijingHexagramSymbols -> "IsYijingHexagramSymbols"
            | IsCJKUnifiedIdeographs -> "IsCJKUnifiedIdeographs"
            | IsYiSyllables -> "IsYiSyllables"
            | IsYiRadicals -> "IsYiRadicals"
            | IsHangulSyllables -> "IsHangulSyllables"
            | IsHighSurrogates -> "IsHighSurrogates"
            | IsHighPrivateUseSurrogates -> "IsHighPrivateUseSurrogates"
            | IsLowSurrogates -> "IsLowSurrogates"
            | IsPrivateUse -> "IsPrivateUse"
            | IsCJKCompatibilityIdeographs  -> "IsCJKCompatibilityIdeographs "
            | IsAlphabeticPresentationForms  -> "IsAlphabeticPresentationForms "
            | IsArabicPresentationForms_A  -> "IsArabicPresentationForms-A "
            | IsVariationSelectors  -> "IsVariationSelectors "
            | IsCombiningHalfMarks  -> "IsCombiningHalfMarks "
            | IsCJKCompatibilityForms  -> "IsCJKCompatibilityForms "
            | IsSmallFormVariants  -> "IsSmallFormVariants "
            | IsArabicPresentationForms_B  -> "IsArabicPresentationForms-B "
            | IsHalfwidthandFullwidthForms  -> "IsHalfwidthandFullwidthForms "
            | IsSpecials -> "IsSpecials"

    [<Class>]
    type VerbEx(regularExpression : string, regexOptions : RegexOptions) =

        let mutable _regexOptions : RegexOptions = regexOptions
        let mutable _prefixes = ""
        let mutable _source = regularExpression
        let mutable _suffixes = ""
        let mutable _regex : Regex option = None

        override __.ToString() = _prefixes + _source + _suffixes

        override __.GetHashCode() = 

           _regexOptions.GetHashCode().ToString() + __.ToString()
           |> hash

        override x.Equals(yobj) = 

            match yobj with

            | :? VerbEx as y -> (x.GetHashCode() = y.GetHashCode())

            | _ -> false

        new () =
            VerbEx("", RegexOptions.None)

        new (regularExpression : string) =
            VerbEx(regularExpression, RegexOptions.None)

        new (regexOptions : RegexOptions) =
            VerbEx("", regexOptions)

        member __.Regex =
            match _regex with
            | Some x -> x
            | None ->
                let regex = new Regex(__.ToString(), _regexOptions)

                _regex <- Some regex
                regex

        member __.Capture input (groupName : string) =

            let match' = __.Regex.Match input
            match'.Groups.[groupName].Value

        member __.Clone (newRegexOptions : RegexOptions option) =

            let v =
                match newRegexOptions with
                | Some x -> new VerbEx(x)
                | None -> new VerbEx(_regexOptions)
             
            v.Prefixes <- _prefixes
            v.Source <- _source
            v.Suffixes <- _suffixes
            v

        member __.GroupNameFromNumber n =
            __.Regex.GroupNameFromNumber n

        member __.GroupNames() =
            
            __.Regex.GetGroupNames()

        member __.GroupNumberFromName groupName =
            __.Regex.GroupNumberFromName groupName

        member __.GroupNumbers() =
            
            __.Regex.GetGroupNumbers()

        member __.IsMatch input =

            __.Regex.IsMatch input

        member __.IsMatch (input, startAt) =

            __.Regex.IsMatch(input, startAt)

        member __.Match input =
            __.Regex.Match input

        member __.Match (input, startAt) =
            __.Regex.Match(input, startAt)

        member __.Match (input, startAt, length) =
            __.Regex.Match(input, startAt, length)

        member __.Matches input =
            __.Regex.Matches input

        member __.Matches (input, startAt) =
            __.Regex.Matches(input, startAt)

        member __.MatchTimeout =
            __.Regex.MatchTimeout

        member __.Prefixes

            with get() = _prefixes
            and set(value) = _prefixes <- value

        member __.RegexOptions = _regexOptions

        member __.Replace (input, (replacement : string)) =
            __.Regex.Replace(input, replacement)

        member __.Replace (input, (evalutor : MatchEvaluator)) =
            __.Regex.Replace(input, evalutor)

        member __.Replace (input, (replacement : string), count) =
            __.Regex.Replace(input, replacement, count)

        member __.Replace (input, (evalutor : MatchEvaluator), count) =
            __.Regex.Replace(input, evalutor, count)

        member __.Replace (input, (replacement : string), count, startAt) =
            __.Regex.Replace(input, replacement, count, startAt)

        member __.Replace (input, (evalutor : MatchEvaluator), count, startAt) =
            __.Regex.Replace(input, evalutor, count, startAt)

        member __.RightToLeft =
            __.Regex.RightToLeft
            
        member __.Source

            with get() = _source
            and set(value) = _source <- value

        member __.Suffixes

            with get() = _suffixes
            and set(value) = _suffixes <- value

        member  __.Split input =
            __.Regex.Split input

        member  __.Split (input, count) =
            __.Regex.Split(input, count)

        member  __.Split (input, count, startAt) =
            __.Regex.Split(input, count, startAt)

    let match' input (verbEx : VerbEx) = 
        verbEx.Match input

    let matchAt input startAt (verbEx : VerbEx) = 
        verbEx.Match (input, startAt)

    let matches input (verbEx : VerbEx) = 
        verbEx.Matches input

    let matchesAt input startAt (verbEx : VerbEx) = 
        verbEx.Matches (input, startAt)

    let matchAtFor input startAt length (verbEx : VerbEx) = 
        verbEx.Match (input, startAt, length)

    let Replace input (replacement : string) (verbEx : VerbEx) =
        verbEx.Replace(input, replacement)

    let ReplaceByMatch input (evalutor : MatchEvaluator) (verbEx : VerbEx) =
        verbEx.Replace(input, evalutor)

    let ReplaceMaxTimes input (replacement : string) count (verbEx : VerbEx) =
        verbEx.Replace(input, replacement, count )

    let ReplaceByMatchMaxTimes input (evalutor : MatchEvaluator) count (verbEx : VerbEx) =
        verbEx.Replace(input, evalutor, count)

    let ReplaceMaxTimesStartAt input (replacement : string) count startAt (verbEx : VerbEx) =
        verbEx.Replace(input, replacement, count, startAt)

    let ReplaceByMatchMaxTimesStartAt input (evalutor : MatchEvaluator) count startAt (verbEx : VerbEx) =
        verbEx.Replace(input, evalutor, count, startAt)

    let Split input (verbEx : VerbEx) =
        verbEx.Split input

    let SplitMaxTimes input count (verbEx : VerbEx) =
        verbEx.Split (input, count)

    let SplitMaxTimesStartAt input count startAt (verbEx : VerbEx) =
        verbEx.Split (input, count, startAt)

    let resetRegexOptions regexOptions (verbEx : VerbEx) =
        verbEx.Clone regexOptions

    let capture input groupName (verbEx : VerbEx) =
        verbEx.Capture input groupName

    let groupNames (verbEx : VerbEx) =
        verbEx.GroupNames()

    let groupNumbers (verbEx : VerbEx) =
        verbEx.GroupNumbers()

    let isMatch value (verbEx : VerbEx) =
        verbEx.IsMatch value

    let isMatchAt value startAt (verbEx : VerbEx) =
        verbEx.IsMatch (value, startAt)
     
    let toString (verbEx : VerbEx) =
        verbEx.ToString()

    let startOfLine (verbEx : VerbEx) =
        let v = verbEx.Clone None
        if v.Prefixes.StartsWith("^") then v
        else 
            v.Prefixes <- "^" + v.Prefixes
            v

    let endOfLine (verbEx : VerbEx) =
        let v = verbEx.Clone None
        if v.Suffixes.EndsWith("$") then v
        else 
            v.Suffixes <- v.Suffixes + "$"
            v

    let add value (verbEx : VerbEx) =
        let v = verbEx.Clone None
        v.Source <- v.Source + value
        v

    let internalAdd (verbEx : VerbEx) value =
        let v = verbEx.Clone None
        v.Source <- v.Source + value
        v

    let then' value (verbEx : VerbEx) =
        Regex.Escape value
        |> sprintf "(%s)"
        |> internalAdd verbEx

    let find value (verbEx : VerbEx) = then' value verbEx

    let maybe value (verbEx : VerbEx) =
        Regex.Escape value
        |> sprintf "(%s)?"
        |> internalAdd verbEx

    let anything (verbEx : VerbEx) =
        internalAdd verbEx "(.*)"

    let anythingBut value (verbEx : VerbEx) =
        Regex.Escape value
        |> sprintf "([^%s]*)"
        |> internalAdd verbEx

    let something (verbEx : VerbEx) =
        internalAdd verbEx "(.+)"

    let somethingBut value (verbEx : VerbEx) =
        Regex.Escape value
        |> sprintf "([^%s]+)"
        |> internalAdd verbEx

    let lineBreak (verbEx : VerbEx) =
        internalAdd verbEx @"(\n|(\r\n))"

    let br (verbEx : VerbEx) = lineBreak verbEx

    let tab (verbEx : VerbEx) =
        internalAdd verbEx @"\t"

    let whiteSpace (verbEx : VerbEx) =
        internalAdd verbEx @"\s"

    let nonWhiteSpace (verbEx : VerbEx) =
        internalAdd verbEx @"\S"

    let word (verbEx : VerbEx) =
        internalAdd verbEx @"\w+"

    let wordCharacter (verbEx : VerbEx) =
        internalAdd verbEx @"\w"

    let nonWordCharacter (verbEx : VerbEx) =
        internalAdd verbEx @"\W"

    let digit (verbEx : VerbEx) =
        internalAdd verbEx @"\d"

    let nonDigit (verbEx : VerbEx) =
        internalAdd verbEx @"\D"

    let backReference ordinal (verbEx : VerbEx) =
        if ordinal < 1 then invalidArg "ordinal" "must be greater than 0" 

        sprintf @"\%i" ordinal
        |> internalAdd verbEx 

    let namedBackReference name (verbEx : VerbEx) =
        sprintf @"\k<%s>" name
        |> internalAdd verbEx

    let anyOf value (verbEx : VerbEx) =
        Regex.Escape value
        |> sprintf "[%s]"
        |> internalAdd verbEx

    let any value (verbEx : VerbEx) = anyOf value verbEx

    let range (collection : seq<obj>) (verbEx : VerbEx) =

        let elem =
            collection
            |> Seq.fold (fun s t -> 
                let x = t.ToString()
                if x.Length = 0 then s
                else Regex.Escape(x)::s) []
            |> List.rev

        let divisor =
            if elem.Length % 2 = 0 then
                elem.Length / 2
            else
                elem.Length / 2 + 1
                
        List.splitInto divisor elem
        |> List.fold (fun (s : string) t -> 
            if t.Length = 1 then
                if s.Length = 0 then
                    invalidArg "range" "one-element range"
                else
                    s + "|" + t.Head 
            else
                s + ("[" + t.Head + "-" + t.Tail.Head + "]") ) ""
        |> internalAdd verbEx

    let multiple value (verbEx : VerbEx) =
        Regex.Escape value
        |> sprintf @"(%s)+"
        |> internalAdd verbEx

    let or' value (verbEx : VerbEx) =
        let v = verbEx.Clone None
        v.Prefixes <- v.Prefixes + "("
        v.Source <- v.Source + ")|(" + value
        v.Suffixes <- ")" + v.Suffixes
        v

    let verbExOrVerbEx regexOptions (verbEx : VerbEx) (verbEx2 : VerbEx) =
        let v = verbEx.Clone (Some regexOptions)
        v.Prefixes <- v.Prefixes + "("
        v.Source <- v.Source + ")|(" + verbEx2.ToString()
        v.Suffixes <- ")" + v.Suffixes
        v

    let beginCapture (verbEx : VerbEx) =
        internalAdd verbEx "("

    let beginCaptureNamed groupName (verbEx : VerbEx) =
        Regex.Escape groupName
        |> sprintf "(?<%s>"
        |> internalAdd verbEx

    let endCapture (verbEx : VerbEx) =
        internalAdd verbEx ")"

    let repeatPrevious n (verbEx : VerbEx) =

        if n < 1 then
            invalidArg "repeatPrevious" "must be greater than 0"

        sprintf "{%i}" n
        |> internalAdd verbEx

    let repeatBetweenPrevious n m (verbEx : VerbEx) =

        if n < 1 then
            invalidArg "repeatBetweenPrevious" "must be greater than 0"

        if n >= m then
            invalidArg "repeatBetweenPrevious" "m must be greater than n"

        sprintf "{%i,%i}" n m
        |> internalAdd verbEx

    let unicode  nnnn (verbEx : VerbEx) =

        sprintf "\u%s" nnnn
        |> internalAdd verbEx

    let unicodeCategory (category : UniCodeGeneralCategory) (verbEx : VerbEx) =
        
        category.ToString()
        |> sprintf "\p{%s}" 
        |> internalAdd verbEx

    let notUnicodeCategory (category : UniCodeGeneralCategory) (verbEx : VerbEx) =

        category.ToString()
        |> sprintf "\P{%s}" 
        |> internalAdd verbEx

    let namedBlock (name : SupportedNamedBlock) (verbEx : VerbEx) =

        name.ToString()
        |> sprintf "\p{%s}" 
        |> internalAdd verbEx

    let notNamedBlock (name : SupportedNamedBlock) (verbEx : VerbEx) =

        name.ToString()
        |> sprintf "\P{%s}" 
        |> internalAdd verbEx