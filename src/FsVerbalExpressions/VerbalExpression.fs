namespace FsVerbalExpressions

open System.Text.RegularExpressions

module VerbalExpression = 

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

    let replace input (replacement : string) (verbEx : VerbEx) =
        verbEx.Replace(input, replacement)

    let replaceByMatch input (evalutor : MatchEvaluator) (verbEx : VerbEx) =
        verbEx.Replace(input, evalutor)

    let replaceMaxTimes input (replacement : string) count (verbEx : VerbEx) =
        verbEx.Replace(input, replacement, count )

    let replaceByMatchMaxTimes input (evalutor : MatchEvaluator) count (verbEx : VerbEx) =
        verbEx.Replace(input, evalutor, count)

    let replaceMaxTimesStartAt input (replacement : string) count startAt (verbEx : VerbEx) =
        verbEx.Replace(input, replacement, count, startAt)

    let replaceByMatchMaxTimesStartAt input (evalutor : MatchEvaluator) count startAt (verbEx : VerbEx) =
        verbEx.Replace(input, evalutor, count, startAt)

    let split input (verbEx : VerbEx) =
        verbEx.Split input

    let splitMaxTimes input count (verbEx : VerbEx) =
        verbEx.Split (input, count)

    let splitMaxTimesStartAt input count startAt (verbEx : VerbEx) =
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

    let multipleVerbEx (sourceVerbEx : VerbEx) (verbEx : VerbEx) =
        sourceVerbEx.ToString()
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