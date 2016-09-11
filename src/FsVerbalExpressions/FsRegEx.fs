namespace FsVerbalExpressions

open System.Text.RegularExpressions

module FsRegEx =

    let firstMatch regularExpression input = 
        Regex.Match(input, regularExpression)
        |> FsMatch

    let firstMatchOpt regularExpression regexOptions input = 
        Regex.Match(input, regularExpression, regexOptions)
        |> FsMatch

    let matchAt regularExpression startAt input = 
        (new Regex(regularExpression)).Match (input, startAt)
        |> FsMatch

    let matchAtOpt regularExpression regexOptions startAt input = 
        (new Regex(regularExpression, regexOptions)).Match (input, startAt)
        |> FsMatch

    let matchAtFor regularExpression startAt length input = 
        (new Regex(regularExpression)).Match (input, startAt, length)
        |> FsMatch

    let matchAtForOpt regularExpression regexOptions startAt length input = 
        (new Regex(regularExpression, regexOptions)).Match (input, startAt, length)
        |> FsMatch

    let matches regularExpression input = 
        Regex.Matches(input, regularExpression)
        |> Common.arrayFromMatches

    let matchesOpt regularExpression regexOptions input = 
        Regex.Matches(input, regularExpression, regexOptions)
        |> Common.arrayFromMatches

    let matchesAt regularExpression startAt input = 
        (new Regex(regularExpression)).Matches (input, startAt)
        |> Common.arrayFromMatches

    let matchesAtOpt regularExpression regexOptions startAt input = 
        (new Regex(regularExpression, regexOptions)).Matches (input, startAt)
        |> Common.arrayFromMatches

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
        let match' = (new Regex(regularExpression)).Match input 
        match'.Groups.[groupName]
        |> FsGroup

    let captureGroupOpt regularExpression regexOptions (groupName : string) input =
        let match' = (new Regex(regularExpression, regexOptions)).Match input 
        match'.Groups.[groupName]
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