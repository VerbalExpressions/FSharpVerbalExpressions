namespace FsVerbalExpressions

open System.Text.RegularExpressions

module FsRegEx =

    let firstMatch regularExpression input = 
        let regex = new Regex(regularExpression)
        FsMatch (regex, Regex.Match(input, regularExpression))

    let firstMatchOpt regularExpression regexOptions input = 
        let regex = new Regex(regularExpression)
        FsMatch (regex, Regex.Match(input, regularExpression, regexOptions))

    let matchAt regularExpression startAt input = 
        let regex = new Regex(regularExpression)
        FsMatch (regex, regex.Match (input, startAt))

    let matchAtOpt regularExpression regexOptions startAt input = 
        let regex = new Regex(regularExpression, regexOptions)
        FsMatch (regex, regex.Match (input, startAt))

    let matchAtFor regularExpression startAt length input = 
        let regex = new Regex(regularExpression)
        FsMatch (regex, regex.Match (input, startAt, length))

    let matchAtForOpt regularExpression regexOptions startAt length input = 
        let regex = new Regex(regularExpression, regexOptions)
        FsMatch (regex, regex.Match (input, startAt, length))

    let matches regularExpression input = 
        let regex = new Regex(regularExpression)
        (regex, regex.Matches(input))
        ||> Common.arrayFromMatches

    let matchesOpt regularExpression regexOptions input = 
        let regex = new Regex(regularExpression, regexOptions)
        (regex, regex.Matches(input))
        ||> Common.arrayFromMatches

    let matchesAt regularExpression startAt input = 
        let regex = new Regex(regularExpression)
        (regex, regex.Matches(input, startAt))
        ||>Common.arrayFromMatches

    let matchesAtOpt regularExpression regexOptions startAt input = 
        let regex = new Regex(regularExpression, regexOptions)
        (regex, regex.Matches(input, startAt))
        ||> Common.arrayFromMatches

    let replace regularExpression (replacement : string) input =
        Regex.Replace(input, regularExpression, replacement)

    let replaceOpt regularExpression regexOptions (replacement : string) input =
        Regex.Replace(input, regularExpression, replacement, regexOptions)

    let replaceByMatch regularExpression (evalutor : MatchEvaluator) input =
        Regex.Replace(input, regularExpression, evalutor)

    let replaceByMatchOpt regularExpression regexOptions (evalutor : MatchEvaluator) input =
        Regex.Replace(input, regularExpression, evalutor, regexOptions)

    let replaceMaxTimes regularExpression (replacement : string) count input =
        (new Regex(regularExpression)).Replace(input, replacement, count )

    let replaceMaxTimesOpt regularExpression regexOptions (replacement : string) count input =
        (new Regex(regularExpression, regexOptions)).Replace(input, replacement, count )

    let replaceByMatchMaxTimes regularExpression (evalutor : MatchEvaluator) count input =
        (new Regex(regularExpression)).Replace(input, evalutor, count)

    let replaceByMatchMaxTimesOpt regularExpression regexOptions (evalutor : MatchEvaluator) count input =
        (new Regex(regularExpression, regexOptions)).Replace(input, evalutor, count)

    let replaceMaxTimesStartAt regularExpression (replacement : string) count startAt input =
        (new Regex(regularExpression)).Replace(input, replacement, count, startAt)

    let replaceMaxTimesStartAtOpt regularExpression regexOptions (replacement : string) count startAt input =
        (new Regex(regularExpression, regexOptions)).Replace(input, replacement, count, startAt)

    let replaceByMatchMaxTimesStartAt regularExpression (evalutor : MatchEvaluator) count startAt input =
        (new Regex(regularExpression)).Replace(input, evalutor, count, startAt)

    let replaceByMatchMaxTimesStartAtOpt regularExpression regexOptions (evalutor : MatchEvaluator) count startAt input =
        (new Regex(regularExpression, regexOptions)).Replace(input, evalutor, count, startAt)

    let split regularExpression input =
        Regex.Split(input, regularExpression)

    let splitOpt regularExpression regexOptions input =
        Regex.Split(input, regularExpression, regexOptions)

    let splitMaxTimes regularExpression count input =
        (new Regex(regularExpression)).Split (input, count)

    let splitMaxTimesOpt regularExpression regexOptions count input =
        (new Regex(regularExpression, regexOptions)).Split (input, count)

    let splitMaxTimesStartAt regularExpression count startAt input =
        (new Regex(regularExpression)).Split (input, count, startAt)

    let splitMaxTimesStartAtOpt regularExpression regexOptions count startAt input =
        (new Regex(regularExpression, regexOptions)).Split (input, count, startAt)

    let capture regularExpression (groupName : string) input =
        let match' = (new Regex(regularExpression)).Match input 
        match'.Groups.[groupName].Value

    let captureOpt regularExpression regexOptions (groupName : string) input =
        let match' = (new Regex(regularExpression, regexOptions)).Match input 
        match'.Groups.[groupName].Value

    let captureGroup regularExpression (groupName : string) input =
        let regex = new Regex(regularExpression)

        let match' = regex.Match input 
        (groupName, match'.Groups.[groupName])
        |> FsGroup

    let captureGroupOpt regularExpression regexOptions (groupName : string) input =
        let regex = new Regex(regularExpression, regexOptions)

        let match' = regex.Match input 
        (groupName, match'.Groups.[groupName])
        |> FsGroup

    let groupNames regularExpression =
        (new Regex(regularExpression)).GetGroupNames()

    let groupNumbers regularExpression =
        (new Regex(regularExpression)).GetGroupNumbers()

    let isMatch regularExpression input =
        Regex.IsMatch(input, regularExpression)

    let isMatchOpt regularExpression regexOptions input =
        Regex.IsMatch(input, regularExpression, regexOptions)

    let isMatchAt regularExpression startAt input =
        (new Regex(regularExpression)).IsMatch (input, startAt)

    let isMatchAtOpt regularExpression regexOptions startAt input =
        (new Regex(regularExpression, regexOptions)).IsMatch (input, startAt)