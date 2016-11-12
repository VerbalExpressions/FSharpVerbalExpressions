namespace FsVerbalExpressions

open System.Text.RegularExpressions

[<Class>]
///Composable wrapping type for System.Text.RegularExpressions.Group.
type FsGroup(name : string, group : Group) =

    let mutable _captures : Capture [] option = None

    override __.Equals(yobj) = 

        match yobj with
        | :? FsGroup as y -> (group = y.Group)
        | _ -> false

    override __.GetHashCode() = group.GetHashCode()

    override __.ToString() = group.ToString()

    ///Returns array of captures matched by the capturing group, in innermost-leftmost-first order (or innermost-rightmost-first order if the regular expression is modified with the RegexOptions.RightToLeft option). 
    member __.Captures() =

        match _captures with
        | Some x -> x
        | None ->
            let a : Capture[] = Array.zeroCreate group.Captures.Count 
            group.Captures.CopyTo(a, 0)
            _captures <- Some a
            a

    ///The underlying System.Text.RegularExpressions.Group.
    member __.Group = group

    ///The position in the original string where the first character of the captured substring is found.
    member __.Index =
        group.Index

    ///Returns the length of the captured substring.
    member __.Length =
        group.Length

    ///Returns name of capture group.
    member ___.Name = name

    ///Returns a value indicating whether the match is successful.
    member __.Success =
        group.Success

    ///Returns the captured substring from the input string.
    member __.Value =
        group.Value

[<Class>]
///Composable wrapping type for System.Text.RegularExpressions.Match.
type FsMatch(regex : Regex, fsMatch : Match) =

    override __.Equals(yobj) = 

        match yobj with
        | :? FsMatch as y -> (fsMatch = y.Match)
        | _ -> false

    override __.GetHashCode() = fsMatch.GetHashCode()

    override __.ToString() = fsMatch.ToString()

    ///Returns array of captures matched by the capturing group, in innermost-leftmost-first order (or innermost-rightmost-first order if the regular expression is modified with the RegexOptions.RightToLeft option). 
    member __.Captures() =

        let a : Capture[] = Array.zeroCreate fsMatch.Captures.Count 
        fsMatch.Captures.CopyTo(a, 0)
        a

    ///Returns array of groups matched by the regular expression.
    member __.Groups() =

        let a : Group[] = Array.zeroCreate fsMatch.Groups.Count 
        fsMatch.Groups.CopyTo(a, 0)
        a
        |> Array.mapi (fun i t -> FsGroup(regex.GroupNameFromNumber(i), t)) 

    ///The position in the original string where the first character of the captured substring is found.
    member __.Index =
        fsMatch.Index

    ///Returns the length of the captured substring.
    member __.Length =
        fsMatch.Length

    ///The underlying System.Text.RegularExpressions.Match.
    member __.Match = fsMatch

    ///Returns the expansion of the specified replacement pattern.
    member __.Result replacement =
        fsMatch.Result replacement

    ///Returns a value indicating whether the match is successful.
    member __.Success =
        fsMatch.Success

    ///Returns the captured substring from the input string.
    member __.Value =
        fsMatch.Value

module internal Common =

    let arrayFromMatches regex (c : MatchCollection) =
        let a : Match[] = Array.zeroCreate c.Count
        c.CopyTo(a, 0)
        a
        |> Array.map (fun t -> new FsMatch(regex, t))

