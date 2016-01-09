namespace FsVerbalExpressions

open VerbalExpression

module CommonVerbEx = 
    
    let Email = new VerbEx(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")

    let Url = new VerbEx(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[^-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+(:[0-9]+)?|(?:www.|[^-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w_]*)?\??(?:[-\+=&;%@.\w-_]*)#?‌​(?:[\w]*))?)")

    

