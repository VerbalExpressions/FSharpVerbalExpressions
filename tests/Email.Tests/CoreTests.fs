namespace Email.Tests

open FsVerbalExpressions
open FsVerbalExpressions.VerbalExpression
open FsUnit.Xunit


//to do: @ is present, not start or end
        //      no illegal characters
        // https://tools.ietf.org/html/rfc2822
        // https://tools.ietf.org/html/rfc2822#section-3.2.4
        // https://tools.ietf.org/html/rfc2822#section-3.4.1
        // http://www.ex-parrot.com/pdw/Mail-RFC822-Address.html
        //
        // http://emailregex.com/
        // ( see also RFC 5322 )
        //  [a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?

        // http://stackoverflow.com/questions/297420/list-of-email-addresses-that-can-be-used-to-test-a-javascript-validation-script

//        let emailValid = new VerbEx("""[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?""")
//        match emailValid.IsMatch email with
//        | true -> Success ()
//        | false -> 
//            (caller, sprintf "%s is not a valid email address" email)
//            |> Failure

/// RFC822 tests from http://code.iamcal.com/php/rfc822/tests/
module RFC822 =

    [<Literal>]
    let Valid = true

    [<Literal>]
    let Invalid = false

    let test1 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@iana.org"
        |> should equal Valid

    let test2 (verbEx :VerbEx) =
        verbEx.IsMatch @"1234567890123456789012345678901234567890123456789012345678901234@iana.org"
        |> should equal Valid

    let test3 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@sub.do,com"
        |> should equal Invalid

//    let test4 (verbEx :VerbEx) =
//    "first\"last"@iana.org
//        |> should equal Valid

    let test5 (verbEx :VerbEx) =
        verbEx.IsMatch @"first\@last@iana.org"
        |> should equal Invalid

//    let test6 (verbEx :VerbEx) =
//    "first@last"@iana.org
//        |> should equal Valid

//    let test7 (verbEx :VerbEx) =
//    "first\\last"@iana.org
//        |> should equal Valid

    let test8 (verbEx :VerbEx) =
        verbEx.IsMatch @"x@x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x2"
        |> should equal Valid

    let test9 (verbEx :VerbEx) =
        verbEx.IsMatch @"1234567890123456789012345678901234567890123456789012345678@12345678901234567890123456789012345678901234567890123456789.12345678901234567890123456789012345678901234567890123456789.123456789012345678901234567890123456789012345678901234567890123.iana.org"
        |> should equal Valid

    let test10 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[12.34.56.78]"
        |> should equal Valid

    let test11 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:::12.34.56.78]"
        |> should equal Valid

    let test12 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333::4444:12.34.56.78]"
        |> should equal Valid

    let test13 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:12.34.56.78]"
        |> should equal Valid

    let test14 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:::1111:2222:3333:4444:5555:6666]"
        |> should equal Valid

    let test15 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333::4444:5555:6666]"
        |> should equal Valid

    let test16 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333:4444:5555:6666::]"
        |> should equal Valid

    let test17 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:7777:8888]"
        |> should equal Valid

    let test18 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@x23456789012345678901234567890123456789012345678901234567890123.iana.org"
        |> should equal Valid

    let test19 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@3com.com"
        |> should equal Valid

    let test20 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@123.iana.org"
        |> should equal Valid

    let test21 (verbEx :VerbEx) =
        verbEx.IsMatch @"123456789012345678901234567890123456789012345678901234567890@12345678901234567890123456789012345678901234567890123456789.12345678901234567890123456789012345678901234567890123456789.12345678901234567890123456789012345678901234567890123456789.12345.iana.org"
        |> should equal Invalid

    let test22 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last"
        |> should equal Invalid

    let test23 (verbEx :VerbEx) =
        verbEx.IsMatch @"12345678901234567890123456789012345678901234567890123456789012345@iana.org"
        |> should equal Invalid

    let test24 (verbEx :VerbEx) =
        verbEx.IsMatch @".first.last@iana.org"
        |> should equal Invalid

    let test25 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last.@iana.org"
        |> should equal Invalid

    let test26 (verbEx :VerbEx) =
        verbEx.IsMatch @"first..last@iana.org"
        |> should equal Invalid

//    let test27 (verbEx :VerbEx) =
//    "first"last"@iana.org
//        |> should equal Invalid

//    let test28 (verbEx :VerbEx) =
//    "first\last"@iana.org
//        |> should equal Valid
//
//    let test29 (verbEx :VerbEx) =
//    """@iana.org
//        |> should equal Invalid
//
//    let test30 (verbEx :VerbEx) =
//    "\"@iana.org
//        |> should equal Invalid
//
//    let test31 (verbEx :VerbEx) =
//    ""@iana.org
//        |> should equal Invalid

    let test32 (verbEx :VerbEx) =
        verbEx.IsMatch @"first\\@last@iana.org"
        |> should equal Invalid

    let test33 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@"
        |> should equal Invalid

    let test34 (verbEx :VerbEx) =
        verbEx.IsMatch @"x@x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456"
        |> should equal Invalid

    let test35 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[.12.34.56.78]"
        |> should equal Invalid

    let test36 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[12.34.56.789]"
        |> should equal Invalid

    let test37 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[::12.34.56.78]"
        |> should equal Invalid

    let test38 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv5:::12.34.56.78]"
        |> should equal Invalid

    let test39 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333::4444:5555:12.34.56.78]"
        |> should equal Valid

    let test40 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333:4444:5555:12.34.56.78]"
        |> should equal Invalid

    let test41 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:7777:12.34.56.78]"
        |> should equal Invalid

    let test42 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:7777]"
        |> should equal Invalid

    let test43 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:7777:8888:9999]"
        |> should equal Invalid

    let test44 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222::3333::4444:5555:6666]"
        |> should equal Invalid

    let test45 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333::4444:5555:6666:7777]"
        |> should equal Valid

    let test46 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:333x::4444:5555]"
        |> should equal Invalid

    let test47 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:33333::4444:5555]"
        |> should equal Invalid

    let test48 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@example.123"
        |> should equal Valid

    let test49 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@com"
        |> should equal Valid

    let test50 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@-xample.com"
        |> should equal Invalid

    let test51 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@exampl-.com"
        |> should equal Invalid

    let test52 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@x234567890123456789012345678901234567890123456789012345678901234.iana.org"
        |> should equal Invalid

//    let test53 (verbEx :VerbEx) =
//    "Abc\@def"@iana.org
//        |> should equal Valid
//
//    let test54 (verbEx :VerbEx) =
//    "Fred\ Bloggs"@iana.org
//        |> should equal Valid
//
//    let test55 (verbEx :VerbEx) =
//    "Joe.\\Blow"@iana.org
//        |> should equal Valid
//
//    let test56 (verbEx :VerbEx) =
//    "Abc@def"@iana.org
//        |> should equal Valid
//
//    let test57 (verbEx :VerbEx) =
//    "Fred Bloggs"@iana.org
//        |> should equal Valid

    let test58 (verbEx :VerbEx) =
        verbEx.IsMatch @"user+mailbox@iana.org"
        |> should equal Valid

    let test59 (verbEx :VerbEx) =
        verbEx.IsMatch @"customer/department=shipping@iana.org"
        |> should equal Valid

    let test60 (verbEx :VerbEx) =
        verbEx.IsMatch @"$A12345@iana.org"
        |> should equal Valid

    let test61 (verbEx :VerbEx) =
        verbEx.IsMatch @"!def!xyz%abc@iana.org"
        |> should equal Valid

    let test62 (verbEx :VerbEx) =
        verbEx.IsMatch @"_somename@iana.org"
        |> should equal Valid

    let test63 (verbEx :VerbEx) =
        verbEx.IsMatch @"dclo@us.ibm.com"
        |> should equal Valid

    let test64 (verbEx :VerbEx) =
        verbEx.IsMatch @"abc\@def@iana.org"
        |> should equal Invalid

    let test65 (verbEx :VerbEx) =
        verbEx.IsMatch @"abc\\@iana.org"
        |> should equal Invalid

    let test66 (verbEx :VerbEx) =
        verbEx.IsMatch @"peter.piper@iana.org"
        |> should equal Valid

//    let test67 (verbEx :VerbEx) =
//    Doug\ \"Ace\"\ Lovell@iana.org
//        |> should equal Invalid
//
//    let test68 (verbEx :VerbEx) =
//    "Doug \"Ace\" L."@iana.org
//        |> should equal Valid

    let test69 (verbEx :VerbEx) =
        verbEx.IsMatch @"abc@def@iana.org"
        |> should equal Invalid

    let test70 (verbEx :VerbEx) =
        verbEx.IsMatch @"abc\\@def@iana.org"
        |> should equal Invalid

    let test71 (verbEx :VerbEx) =
        verbEx.IsMatch @"abc\@iana.org"
        |> should equal Invalid

    let test72 (verbEx :VerbEx) =
        verbEx.IsMatch @"@iana.org"
        |> should equal Invalid

    let test73 (verbEx :VerbEx) =
        verbEx.IsMatch @"doug@"
        |> should equal Invalid

//    let test74 (verbEx :VerbEx) =
//    "qu@iana.org
//        |> should equal Invalid
//
//    let test75 (verbEx :VerbEx) =
//    ote"@iana.org
//        |> should equal Invalid

    let test76 (verbEx :VerbEx) =
        verbEx.IsMatch @".dot@iana.org"
        |> should equal Invalid

    let test77 (verbEx :VerbEx) =
        verbEx.IsMatch @"dot.@iana.org"
        |> should equal Invalid

    let test78 (verbEx :VerbEx) =
        verbEx.IsMatch @"two..dot@iana.org"
        |> should equal Invalid

//    let test79 (verbEx :VerbEx) =
//    "Doug "Ace" L."@iana.org
//        |> should equal Invalid
//
//    let test80 (verbEx :VerbEx) =
//    Doug\ \"Ace\"\ L\.@iana.org
//        |> should equal Invalid

    let test81 (verbEx :VerbEx) =
        verbEx.IsMatch @"hello world@iana.org"
        |> should equal Invalid

    let test82 (verbEx :VerbEx) =
        verbEx.IsMatch @"gatsby@f.sc.ot.t.f.i.tzg.era.l.d."
        |> should equal Invalid

    let test83 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@iana.org"
        |> should equal Valid

    let test84 (verbEx :VerbEx) =
        verbEx.IsMatch @"TEST@iana.org"
        |> should equal Valid

    let test85 (verbEx :VerbEx) =
        verbEx.IsMatch @"1234567890@iana.org"
        |> should equal Valid

    let test86 (verbEx :VerbEx) =
        verbEx.IsMatch @"test+test@iana.org"
        |> should equal Valid

    let test87 (verbEx :VerbEx) =
        verbEx.IsMatch @"test-test@iana.org"
        |> should equal Valid

    let test88 (verbEx :VerbEx) =
        verbEx.IsMatch @"t*est@iana.org"
        |> should equal Valid

    let test89 (verbEx :VerbEx) =
        verbEx.IsMatch @"+1~1+@iana.org"
        |> should equal Valid

    let test90 (verbEx :VerbEx) =
        verbEx.IsMatch @"{_test_}@iana.org"
        |> should equal Valid

//    let test91 (verbEx :VerbEx) =
//    "[[ test ]]"@iana.org
//        |> should equal Valid

    let test92 (verbEx :VerbEx) =
        verbEx.IsMatch @"test.test@iana.org"
        |> should equal Valid

//    let test93 (verbEx :VerbEx) =
//    "test.test"@iana.org
//        |> should equal Valid

//    let test94 (verbEx :VerbEx) =
//    test."test"@iana.org
//        |> should equal Valid
//
//    let test95 (verbEx :VerbEx) =
//    "test@test"@iana.org
//        |> should equal Valid

    let test96 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@123.123.123.x123"
        |> should equal Valid

    let test97 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@123.123.123.123"
        |> should equal Valid

    let test98(verbEx :VerbEx) =
        verbEx.IsMatch @"test@[123.123.123.123]"
        |> should equal Valid

    let test99(verbEx :VerbEx) =
        verbEx.IsMatch @"test@example.iana.org"
        |> should equal Valid

    let test100 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@example.example.iana.org"
        |> should equal Valid

    let test101 (verbEx :VerbEx) =
        verbEx.IsMatch @"test.iana.org"
        |> should equal Invalid

    let test102 (verbEx :VerbEx) =
        verbEx.IsMatch @"test.@iana.org"
        |> should equal Invalid

    let test103 (verbEx :VerbEx) =
        verbEx.IsMatch @"test..test@iana.org"
        |> should equal Invalid

    let test104 (verbEx :VerbEx) =
        verbEx.IsMatch @".test@iana.org"
        |> should equal Invalid

    let test105 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@test@iana.org"
        |> should equal Invalid

    let test106 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@@iana.org"
        |> should equal Invalid

    let test107 (verbEx :VerbEx) =
        verbEx.IsMatch @"-- test --@iana.org"
        |> should equal Invalid

    let test108 (verbEx :VerbEx) =
        verbEx.IsMatch @"[test]@iana.org"
        |> should equal Invalid

//    let test109 (verbEx :VerbEx) =
//    "test\test"@iana.org
//        |> should equal Valid
//
//    let test110 (verbEx :VerbEx) =
//    "test"test"@iana.org
//        |> should equal Invalid

    let test111 (verbEx :VerbEx) =
        verbEx.IsMatch @"()[]\;:,><@iana.org"
        |> should equal Invalid

    let test112 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@."
        |> should equal Invalid

    let test113 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@example."
        |> should equal Invalid

    let test114 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@.org"
        |> should equal Invalid

    let test115 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012.com"
        |> should equal Invalid

    let test116 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@example"
        |> should equal Valid

    let test117 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@[123.123.123.123"
        |> should equal Invalid

    let test118(verbEx :VerbEx) =
        verbEx.IsMatch @"test@123.123.123.123]"
        |> should equal Invalid

    let test119 (verbEx :VerbEx) =
        verbEx.IsMatch @"NotAnEmail"
        |> should equal Invalid

    let test120 (verbEx :VerbEx) =
        verbEx.IsMatch @"@NotAnEmail"
        |> should equal Invalid

//    let test121 (verbEx :VerbEx) =
//    "test\\blah"@iana.org
//        |> should equal Valid
//
//    let test122 (verbEx :VerbEx) =
//    "test\blah"@iana.org
//        |> should equal Valid
//
//    let test123 (verbEx :VerbEx) =
//    "test\&#13;blah"@iana.org
//        |> should equal Valid
//
//    let test124 (verbEx :VerbEx) =
//    "test&#13;blah"@iana.org
//        |> should equal Invalid
//
//    let test125 (verbEx :VerbEx) =
//    "test\"blah"@iana.org
//        |> should equal Valid
//
//    let test126 (verbEx :VerbEx) =
//    "test"blah"@iana.org
//        |> should equal Invalid

    let test127 (verbEx :VerbEx) =
        verbEx.IsMatch @"customer/department@iana.org"
        |> should equal Valid

    let test128 (verbEx :VerbEx) =
        verbEx.IsMatch @"_Yosemite.Sam@iana.org"
        |> should equal Valid

    let test129 (verbEx :VerbEx) =
        verbEx.IsMatch @"~@iana.org"
        |> should equal Valid

    let test130 (verbEx :VerbEx) =
        verbEx.IsMatch @".wooly@iana.org"
        |> should equal Invalid

    let test131 (verbEx :VerbEx) =
        verbEx.IsMatch @"wo..oly@iana.org"
        |> should equal Invalid

    let test132 (verbEx :VerbEx) =
        verbEx.IsMatch @"pootietang.@iana.org"
        |> should equal Invalid

    let test133 (verbEx :VerbEx) =
        verbEx.IsMatch @".@iana.org"
        |> should equal Invalid

//    let test134 (verbEx :VerbEx) =
//    "Austin@Powers"@iana.org
//        |> should equal Valid

    let test135 (verbEx :VerbEx) =
        verbEx.IsMatch @"Ima.Fool@iana.org"
        |> should equal Valid

//    let test136 (verbEx :VerbEx) =
//    "Ima.Fool"@iana.org
//        |> should equal Valid
//
//    let test137 (verbEx :VerbEx) =
//    "Ima Fool"@iana.org
//        |> should equal Valid

    let test138 (verbEx :VerbEx) =
        verbEx.IsMatch @"Ima Fool@iana.org"
        |> should equal Invalid

    let test139 (verbEx :VerbEx) =
        verbEx.IsMatch @"phil.h\@\@ck@haacked.com"
        |> should equal Invalid

//    let test140 (verbEx :VerbEx) =
//    "first"."last"@iana.org
//        |> should equal Valid
//
//    let test141 (verbEx :VerbEx) =
//    "first".middle."last"@iana.org
//        |> should equal Valid
//
//    let test142 (verbEx :VerbEx) =
//    "first\\"last"@iana.org
//        |> should equal Invalid
//
//    let test143 (verbEx :VerbEx) =
//    "first".last@iana.org
//        |> should equal Valid
//
//    let test144 (verbEx :VerbEx) =
//    first."last"@iana.org
//        |> should equal Valid
//
//    let test145 (verbEx :VerbEx) =
//    "first"."middle"."last"@iana.org
//        |> should equal Valid
//
//    let test146 (verbEx :VerbEx) =
//    "first.middle"."last"@iana.org
//        |> should equal Valid

//    let test147 (verbEx :VerbEx) =
//    "first.middle.last"@iana.org
//        |> should equal Valid
//
//    let test148 (verbEx :VerbEx) =
//    "first..last"@iana.org
//        |> should equal Valid

    let test149 (verbEx :VerbEx) =
        verbEx.IsMatch @"foo@[\1.2.3.4]"
        |> should equal Invalid

//    let test150 (verbEx :VerbEx) =
//    "first\\\"last"@iana.org
//        |> should equal Valid
//
//    let test151 (verbEx :VerbEx) =
//    first."mid\dle"."last"@iana.org
//        |> should equal Valid

    let test152 (verbEx :VerbEx) =
        verbEx.IsMatch @"Test.&#13;&#10; Folding.&#13;&#10; Whitespace@iana.org"
        |> should equal Valid

//    let test153 (verbEx :VerbEx) =
//    first."".last@iana.org
//        |> should equal Invalid

    let test154 (verbEx :VerbEx) =
        verbEx.IsMatch @"first\last@iana.org"
        |> should equal Invalid

    let test155 (verbEx :VerbEx) =
        verbEx.IsMatch @"Abc\@def@iana.org"
        |> should equal Invalid

    let test156 (verbEx :VerbEx) =
        verbEx.IsMatch @"Fred\ Bloggs@iana.org"
        |> should equal Invalid

    let test157 (verbEx :VerbEx) =
        verbEx.IsMatch @"Joe.\\Blow@iana.org"
        |> should equal Invalid

    let test158 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:12.34.567.89]"
        |> should equal Invalid

//    let test159 (verbEx :VerbEx) =
//    "test\&#13;&#10; blah"@iana.org
//        |> should equal Invalid
//
//    let test160 (verbEx :VerbEx) =
//    "test&#13;&#10; blah"@iana.org
//        |> should equal Valid

    let test161 (verbEx :VerbEx) =
        verbEx.IsMatch @"{^c\@**Dog^}@cartoon.com"
        |> should equal Invalid

    let test162 (verbEx :VerbEx) =
        verbEx.IsMatch @"(foo)cal(bar)@(baz)iamcal.com(quux)"
        |> should equal Valid

    let test163 (verbEx :VerbEx) =
        verbEx.IsMatch @"cal@iamcal(woo).(yay)com"
        |> should equal Valid

//    let test164 (verbEx :VerbEx) =
//    "foo"(yay)@(hoopla)[1.2.3.4]
//        |> should equal Invalid

    let test165 (verbEx :VerbEx) =
        verbEx.IsMatch @"cal(woo(yay)hoopla)@iamcal.com"
        |> should equal Valid

    let test166 (verbEx :VerbEx) =
        verbEx.IsMatch @"cal(foo\@bar)@iamcal.com"
        |> should equal Valid

    let test167 (verbEx :VerbEx) =
        verbEx.IsMatch @"cal(foo\)bar)@iamcal.com"
        |> should equal Valid

    let test168 (verbEx :VerbEx) =
        verbEx.IsMatch @"cal(foo(bar)@iamcal.com"
        |> should equal Invalid

    let test169 (verbEx :VerbEx) =
        verbEx.IsMatch @"cal(foo)bar)@iamcal.com"
        |> should equal Invalid

    let test170(verbEx :VerbEx) =
        verbEx.IsMatch @"cal(foo\)@iamcal.com"
        |> should equal Invalid

    let test171 (verbEx :VerbEx) =
        verbEx.IsMatch @"first().last@iana.org"
        |> should equal Valid

    let test172 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.(&#13;&#10; middle&#13;&#10; )last@iana.org"
        |> should equal Valid

    let test173 (verbEx :VerbEx) =
        verbEx.IsMatch @"first(12345678901234567890123456789012345678901234567890)last@(1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890)iana.org"
        |> should equal Invalid

//    let test174 (verbEx :VerbEx) =
//        verbEx.IsMatch @"first(Welcome to&#13;&#10; the ("wonderful" (!)) world&#13;&#10; of email)@iana.org"
//        |> should equal Valid

    let test175 (verbEx :VerbEx) =
        verbEx.IsMatch @"pete(his account)@silly.test(his host)"
        |> should equal Valid

    let test176 (verbEx :VerbEx) =
        verbEx.IsMatch @"c@(Chris's host.)public.example"
        |> should equal Valid

    let test177(verbEx :VerbEx) =
        verbEx.IsMatch @"jdoe@machine(comment).  example"
        |> should equal Valid

    let test178 (verbEx :VerbEx) =
        verbEx.IsMatch @"1234   @   local(blah)  .machine .example"
        |> should equal Valid

    let test179 (verbEx :VerbEx) =
        verbEx.IsMatch @"first(middle)last@iana.org"
        |> should equal Invalid

    let test180 (verbEx :VerbEx) =
        verbEx.IsMatch @"first(abc.def).last@iana.org"
        |> should equal Valid

//    let test181 (verbEx :VerbEx) =
//    first(a"bc.def).last@iana.org
//        |> should equal Valid
//
//    let test182 (verbEx :VerbEx) =
//    first.(")middle.last(")@iana.org
//        |> should equal Valid
//
//    let test183 (verbEx :VerbEx) =
//    first(abc("def".ghi).mno)middle(abc("def".ghi).mno).last@(abc("def".ghi).mno)example(abc("def".ghi).mno).(abc("def".ghi).mno)com(abc("def".ghi).mno)
//        |> should equal Invalid

    let test184 (verbEx :VerbEx) =
        verbEx.IsMatch @"first(abc\(def)@iana.org"
        |> should equal Valid

    let test185 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@x(1234567890123456789012345678901234567890123456789012345678901234567890).com"
        |> should equal Valid

    let test186 (verbEx :VerbEx) =
        verbEx.IsMatch @"a(a(b(c)d(e(f))g)h(i)j)@iana.org"
        |> should equal Valid

    let test187 (verbEx :VerbEx) =
        verbEx.IsMatch @"a(a(b(c)d(e(f))g)(h(i)j)@iana.org"
        |> should equal Invalid

    let test188 (verbEx :VerbEx) =
        verbEx.IsMatch @"name.lastname@domain.com"
        |> should equal Valid

    let test189 (verbEx :VerbEx) =
        verbEx.IsMatch @".@"
        |> should equal Invalid

    let test190 (verbEx :VerbEx) =
        verbEx.IsMatch @"a@b"
        |> should equal Valid

    let test191 (verbEx :VerbEx) =
        verbEx.IsMatch @"@bar.com"
        |> should equal Invalid

    let test192 (verbEx :VerbEx) =
        verbEx.IsMatch @"@@bar.com"
        |> should equal Invalid

    let test193 (verbEx :VerbEx) =
        verbEx.IsMatch @"a@bar.com"
        |> should equal Valid

    let test194 (verbEx :VerbEx) =
        verbEx.IsMatch @"aaa.com"
        |> should equal Invalid

    let test195 (verbEx :VerbEx) =
        verbEx.IsMatch @"aaa@.com"
        |> should equal Invalid

    let test196 (verbEx :VerbEx) =
        verbEx.IsMatch @"aaa@.123"
        |> should equal Invalid

    let test197 (verbEx :VerbEx) =
        verbEx.IsMatch @"aaa@[123.123.123.123]"
        |> should equal Valid

    let test198 (verbEx :VerbEx) =
        verbEx.IsMatch @"aaa@[123.123.123.123]a"
        |> should equal Invalid

    let test199 (verbEx :VerbEx) =
        verbEx.IsMatch @"aaa@[123.123.123.333]"
        |> should equal Invalid

    let test200 (verbEx :VerbEx) =
        verbEx.IsMatch @"a@bar.com."
        |> should equal Invalid

    let test201 (verbEx :VerbEx) =
        verbEx.IsMatch @"a@bar"
        |> should equal Valid

    let test202 (verbEx :VerbEx) =
        verbEx.IsMatch @"a-b@bar.com"
        |> should equal Valid

    let test203 (verbEx :VerbEx) =
        verbEx.IsMatch @"+@b.c"
        |> should equal Valid

    let test204 (verbEx :VerbEx) =
        verbEx.IsMatch @"+@b.com"
        |> should equal Valid

    let test205 (verbEx :VerbEx) =
        verbEx.IsMatch @"a@-b.com"
        |> should equal Invalid

    let test206 (verbEx :VerbEx) =
        verbEx.IsMatch @"a@b-.com"
        |> should equal Invalid

    let test207 (verbEx :VerbEx) =
        verbEx.IsMatch @"-@..com"
        |> should equal Invalid

    let test208 (verbEx :VerbEx) =
        verbEx.IsMatch @"-@a..com"
        |> should equal Invalid

    let test209 (verbEx :VerbEx) =
        verbEx.IsMatch @"a@b.co-foo.uk"
        |> should equal Valid

//    let test210 (verbEx :VerbEx) =
//    "hello my name is"@stutter.com
//        |> should equal Valid
//
//    let test211 (verbEx :VerbEx) =
//    "Test \"Fail\" Ing"@iana.org
//        |> should equal Valid

    let test212 (verbEx :VerbEx) =
        verbEx.IsMatch @"valid@about.museum"
        |> should equal Valid

    let test213 (verbEx :VerbEx) =
        verbEx.IsMatch @"invalid@about.museum-"
        |> should equal Invalid

    let test214 (verbEx :VerbEx) =
        verbEx.IsMatch @"shaitan@my-domain.thisisminekthx"
        |> should equal Valid

    let test215 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@...........com"
        |> should equal Invalid

    let test216 (verbEx :VerbEx) =
        verbEx.IsMatch @"foobar@192.168.0.1"
        |> should equal Valid

//    let test217 (verbEx :VerbEx) =
//    "Joe\\Blow"@iana.org
//        |> should equal Valid

    let test218 (verbEx :VerbEx) =
        verbEx.IsMatch @"Invalid \&#10; Folding \&#10; Whitespace@iana.org"
        |> should equal Invalid

    let test219 (verbEx :VerbEx) =
        verbEx.IsMatch @"HM2Kinsists@(that comments are allowed)this.is.ok"
        |> should equal Valid

    let test220 (verbEx :VerbEx) =
        verbEx.IsMatch @"user%uucp!path@berkeley.edu"
        |> should equal Valid

//    let test221 (verbEx :VerbEx) =
//    "first(last)"@iana.org
//        |> should equal Valid

    let test222 (verbEx :VerbEx) =
        verbEx.IsMatch @"&#13;&#10; (&#13;&#10; x &#13;&#10; ) &#13;&#10; first&#13;&#10; ( &#13;&#10; x&#13;&#10; ) &#13;&#10; .&#13;&#10; ( &#13;&#10; x) &#13;&#10; last &#13;&#10; (  x &#13;&#10; ) &#13;&#10; @iana.org"
        |> should equal Valid

    let test223 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last @iana.org"
        |> should equal Valid

    let test224 (verbEx :VerbEx) =
        verbEx.IsMatch @"test. &#13;&#10; &#13;&#10; obs@syntax.com"
        |> should equal Valid

    let test225 (verbEx :VerbEx) =
        verbEx.IsMatch @"test.&#13;&#10;&#13;&#10; obs@syntax.com"
        |> should equal Invalid

//    let test226 (verbEx :VerbEx) =
//    "Unicode NULL \␀"@char.com
//        |> should equal Valid
//
//    let test227 (verbEx :VerbEx) =
//    "Unicode NULL ␀"@char.com
//        |> should equal Invalid
//
//    let test228 (verbEx :VerbEx) =
//    Unicode NULL \␀@char.com
//        |> should equal Invalid

    let test229 (verbEx :VerbEx) =
        verbEx.IsMatch @"cdburgess+!#$%&'*-/=?+_{}|~test@gmail.com"
        |> should equal Valid

    let test230 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:::a2:a3:a4:b1:b2:b3:b4]"
        |> should equal Valid

    let test231 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2:a3:a4:b1:b2:b3::]"
        |> should equal Valid

    let test232 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::]"
        |> should equal Invalid

    let test233 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:::]"
        |> should equal Valid

    let test234 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::::]"
        |> should equal Invalid

    let test235 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::b4]"
        |> should equal Invalid

    let test236 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:::b4]"
        |> should equal Valid

    let test237 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::::b4]"
        |> should equal Invalid

    let test238 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::b3:b4]"
        |> should equal Invalid

    let test239 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:::b3:b4]"
        |> should equal Valid

    let test240(verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::::b3:b4]"
        |> should equal Invalid

    let test241 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::b4]"
        |> should equal Valid

    let test242 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:::b4]"
        |> should equal Invalid

    let test243 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:]"
        |> should equal Invalid

    let test244 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::]"
        |> should equal Valid

    let test245 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:::]"
        |> should equal Invalid

    let test246 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2:]"
        |> should equal Invalid

    let test247 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2::]"
        |> should equal Valid

    let test248 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2:::]"
        |> should equal Invalid

    let test249 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:0123:4567:89ab:cdef::]"
        |> should equal Valid

    let test250 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:0123:4567:89ab:CDEF::]"
        |> should equal Valid

    let test251 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:::a3:a4:b1:ffff:11.22.33.44]"
        |> should equal Valid

    let test252 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:::a2:a3:a4:b1:ffff:11.22.33.44]"
        |> should equal Valid

    let test253 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2:a3:a4::11.22.33.44]"
        |> should equal Valid

    let test254 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2:a3:a4:b1::11.22.33.44]"
        |> should equal Valid

    let test255 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::11.22.33.44]"
        |> should equal Invalid

    let test256 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::::11.22.33.44]"
        |> should equal Invalid

    let test257 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:11.22.33.44]"
        |> should equal Invalid

    let test258 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::11.22.33.44]"
        |> should equal Valid

    let test259 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:::11.22.33.44]"
        |> should equal Invalid

    let test260 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2::11.22.33.44]"
        |> should equal Valid

    let test261 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2:::11.22.33.44]"
        |> should equal Invalid

    let test262 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:0123:4567:89ab:cdef::11.22.33.44]"
        |> should equal Valid

    let test263 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:0123:4567:89ab:cdef::11.22.33.xx]"
        |> should equal Invalid

    let test264 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:0123:4567:89ab:CDEF::11.22.33.44]"
        |> should equal Valid

    let test265 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:0123:4567:89ab:CDEFF::11.22.33.44]"
        |> should equal Invalid

    let test266 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::a4:b1::b4:11.22.33.44]"
        |> should equal Invalid

    let test267 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::11.22.33]"
        |> should equal Invalid

    let test268 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::11.22.33.44.55]"
        |> should equal Invalid

    let test269 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::b211.22.33.44]"
        |> should equal Invalid

    let test270 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::b2:11.22.33.44]"
        |> should equal Valid

    let test271 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::b2::11.22.33.44]"
        |> should equal Invalid

    let test272 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1::b3:]"
        |> should equal Invalid

    let test273 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::a2::b4]"
        |> should equal Invalid

    let test274 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2:a3:a4:b1:b2:b3:]"
        |> should equal Invalid

    let test275 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6::a2:a3:a4:b1:b2:b3:b4]"
        |> should equal Invalid

    let test276 (verbEx :VerbEx) =
        verbEx.IsMatch @"first.last@[IPv6:a1:a2:a3:a4::b1:b2:b3:b4]"
        |> should equal Invalid

    let test277 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@test.com"
        |> should equal Valid

    let test278 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@test.com"
        |> should equal Valid

    let test279 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@example.com&#10;"
        |> should equal Invalid

    let test280 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@xn--example.com"
        |> should equal Valid

    let test281 (verbEx :VerbEx) =
        verbEx.IsMatch @"test@Bücher.ch"
        |> should equal Valid