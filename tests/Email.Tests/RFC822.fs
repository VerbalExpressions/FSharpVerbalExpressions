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

    let test1 (f : string -> bool) =
        f @"first.last@iana.org"
        |> should equal Valid

    let test2 (f : string -> bool) =
        f @"1234567890123456789012345678901234567890123456789012345678901234@iana.org"
        |> should equal Valid

    let test3 (f : string -> bool) =
        f @"first.last@sub.do,com"
        |> should equal Invalid

    let test4 (f : string -> bool) =
    //"first\"last"@iana.org
        f "\"first\\\"last\"@iana.org"
        |> should equal Valid

    let test5 (f : string -> bool) =
        f @"first\@last@iana.org"
        |> should equal Invalid

    let test6 (f : string -> bool) =
    //"first@last"@iana.org
        f "\"first@last\"@iana.org"
        |> should equal Valid

    let test7 (f : string -> bool) =
    //"first\\last"@iana.org
        f "\"first\\\\last\"@iana.org"
        |> should equal Valid

    let test8 (f : string -> bool) =
        f @"x@x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x2"
        |> should equal Valid

    let test9 (f : string -> bool) =
        f @"1234567890123456789012345678901234567890123456789012345678@12345678901234567890123456789012345678901234567890123456789.12345678901234567890123456789012345678901234567890123456789.123456789012345678901234567890123456789012345678901234567890123.iana.org"
        |> should equal Valid

    let test10 (f : string -> bool) =
        f @"first.last@[12.34.56.78]"
        |> should equal Valid

    let test11 (f : string -> bool) =
        f @"first.last@[IPv6:::12.34.56.78]"
        |> should equal Valid

    let test12 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333::4444:12.34.56.78]"
        |> should equal Valid

    let test13 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:12.34.56.78]"
        |> should equal Valid

    let test14 (f : string -> bool) =
        f @"first.last@[IPv6:::1111:2222:3333:4444:5555:6666]"
        |> should equal Valid

    let test15 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333::4444:5555:6666]"
        |> should equal Valid

    let test16 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333:4444:5555:6666::]"
        |> should equal Valid

    let test17 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:7777:8888]"
        |> should equal Valid

    let test18 (f : string -> bool) =
        f @"first.last@x23456789012345678901234567890123456789012345678901234567890123.iana.org"
        |> should equal Valid

    let test19 (f : string -> bool) =
        f @"first.last@3com.com"
        |> should equal Valid

    let test20 (f : string -> bool) =
        f @"first.last@123.iana.org"
        |> should equal Valid

    let test21 (f : string -> bool) =
        f @"123456789012345678901234567890123456789012345678901234567890@12345678901234567890123456789012345678901234567890123456789.12345678901234567890123456789012345678901234567890123456789.12345678901234567890123456789012345678901234567890123456789.12345.iana.org"
        |> should equal Invalid

    let test22 (f : string -> bool) =
        f @"first.last"
        |> should equal Invalid

    let test23 (f : string -> bool) =
        f @"12345678901234567890123456789012345678901234567890123456789012345@iana.org"
        |> should equal Invalid

    let test24 (f : string -> bool) =
        f @".first.last@iana.org"
        |> should equal Invalid

    let test25 (f : string -> bool) =
        f @"first.last.@iana.org"
        |> should equal Invalid

    let test26 (f : string -> bool) =
        f @"first..last@iana.org"
        |> should equal Invalid

    let test27 (f : string -> bool) =
    //"first"last"@iana.org
        f "\"first\"last\"@iana.org"
        |> should equal Invalid

    let test28 (f : string -> bool) =
    //"first\last"@iana.org
        f "\"first\\last\"@iana.org"
        |> should equal Valid

    let test29 (f : string -> bool) =
    //"""@iana.org
        f "\"\"\"@iana.org"
        |> should equal Invalid

    let test30 (f : string -> bool) =
    //"\"@iana.org
        f "\"\\\"@iana.org"
        |> should equal Invalid

    let test31 (f : string -> bool) =
    //""@iana.org
        f "\"\"@iana.org"
        |> should equal Invalid

    let test32 (f : string -> bool) =
        f @"first\\@last@iana.org"
        |> should equal Invalid

    let test33 (f : string -> bool) =
        f @"first.last@"
        |> should equal Invalid

    let test34 (f : string -> bool) =
        f @"x@x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456789.x23456"
        |> should equal Invalid

    let test35 (f : string -> bool) =
        f @"first.last@[.12.34.56.78]"
        |> should equal Invalid

    let test36 (f : string -> bool) =
        f @"first.last@[12.34.56.789]"
        |> should equal Invalid

    let test37 (f : string -> bool) =
        f @"first.last@[::12.34.56.78]"
        |> should equal Invalid

    let test38 (f : string -> bool) =
        f @"first.last@[IPv5:::12.34.56.78]"
        |> should equal Invalid

    let test39 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333::4444:5555:12.34.56.78]"
        |> should equal Valid

    let test40 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333:4444:5555:12.34.56.78]"
        |> should equal Invalid

    let test41 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:7777:12.34.56.78]"
        |> should equal Invalid

    let test42 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:7777]"
        |> should equal Invalid

    let test43 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:7777:8888:9999]"
        |> should equal Invalid

    let test44 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222::3333::4444:5555:6666]"
        |> should equal Invalid

    let test45 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333::4444:5555:6666:7777]"
        |> should equal Valid

    let test46 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:333x::4444:5555]"
        |> should equal Invalid

    let test47 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:33333::4444:5555]"
        |> should equal Invalid

    let test48 (f : string -> bool) =
        f @"first.last@example.123"
        |> should equal Valid

    let test49 (f : string -> bool) =
        f @"first.last@com"
        |> should equal Valid

    let test50 (f : string -> bool) =
        f @"first.last@-xample.com"
        |> should equal Invalid

    let test51 (f : string -> bool) =
        f @"first.last@exampl-.com"
        |> should equal Invalid

    let test52 (f : string -> bool) =
        f @"first.last@x234567890123456789012345678901234567890123456789012345678901234.iana.org"
        |> should equal Invalid

    let test53 (f : string -> bool) =
    //"Abc\@def"@iana.org
        f "\"Abc\\@def\"@iana.org"
        |> should equal Valid

    let test54 (f : string -> bool) =
    //"Fred\ Bloggs"@iana.org
        f "\"Fred\\ Bloggs\"@iana.org"
        |> should equal Valid

    let test55 (f : string -> bool) =
    //"Joe.\\Blow"@iana.org
        f "\"Joe.\\\\Blow\"@iana.org"
        |> should equal Valid

    let test56 (f : string -> bool) =
    //"Abc@def"@iana.org
        f "\"Abc@def\"@iana.org"
        |> should equal Valid

    let test57 (f : string -> bool) =
    //"Fred Bloggs"@iana.org
        f "\"Fred Bloggs\"@iana.org"
        |> should equal Valid

    let test58 (f : string -> bool) =
        f @"user+mailbox@iana.org"
        |> should equal Valid

    let test59 (f : string -> bool) =
        f @"customer/department=shipping@iana.org"
        |> should equal Valid

    let test60 (f : string -> bool) =
        f @"$A12345@iana.org"
        |> should equal Valid

    let test61 (f : string -> bool) =
        f @"!def!xyz%abc@iana.org"
        |> should equal Valid

    let test62 (f : string -> bool) =
        f @"_somename@iana.org"
        |> should equal Valid

    let test63 (f : string -> bool) =
        f @"dclo@us.ibm.com"
        |> should equal Valid

    let test64 (f : string -> bool) =
        f @"abc\@def@iana.org"
        |> should equal Invalid

    let test65 (f : string -> bool) =
        f @"abc\\@iana.org"
        |> should equal Invalid

    let test66 (f : string -> bool) =
        f @"peter.piper@iana.org"
        |> should equal Valid

    let test67 (f : string -> bool) =
    //Doug\ \"Ace\"\ Lovell@iana.org
        f "Doug\\ \\\"Ace\\\"\\ Lovell@iana.org"
        |> should equal Invalid

    let test68 (f : string -> bool) =
    //"Doug \"Ace\" L."@iana.org
        f "\"Doug \\\"Ace\\\" L.\"@iana.org"
        |> should equal Valid

    let test69 (f : string -> bool) =
        f @"abc@def@iana.org"
        |> should equal Invalid

    let test70 (f : string -> bool) =
        f @"abc\\@def@iana.org"
        |> should equal Invalid

    let test71 (f : string -> bool) =
        f @"abc\@iana.org"
        |> should equal Invalid

    let test72 (f : string -> bool) =
        f @"@iana.org"
        |> should equal Invalid

    let test73 (f : string -> bool) =
        f @"doug@"
        |> should equal Invalid

    let test74 (f : string -> bool) =
    //"qu@iana.org
        f "\"qu@iana.org"
        |> should equal Invalid

    let test75 (f : string -> bool) =
    //ote"@iana.org
        f "ote\"@iana.org"
        |> should equal Invalid

    let test76 (f : string -> bool) =
        f @".dot@iana.org"
        |> should equal Invalid

    let test77 (f : string -> bool) =
        f @"dot.@iana.org"
        |> should equal Invalid

    let test78 (f : string -> bool) =
        f @"two..dot@iana.org"
        |> should equal Invalid

    let test79 (f : string -> bool) =
    //"Doug "Ace" L."@iana.org
        f "\"Doug \"Ace\" L.\"@iana.org"
        |> should equal Invalid

    let test80 (f : string -> bool) =
    //Doug\ \"Ace\"\ L\.@iana.org
        f "Doug\\ \\\"Ace\\\"\\ L\\.@iana.org"
        |> should equal Invalid

    let test81 (f : string -> bool) =
        f @"hello world@iana.org"
        |> should equal Invalid

    let test82 (f : string -> bool) =
        f @"gatsby@f.sc.ot.t.f.i.tzg.era.l.d."
        |> should equal Invalid

    let test83 (f : string -> bool) =
        f @"test@iana.org"
        |> should equal Valid

    let test84 (f : string -> bool) =
        f @"TEST@iana.org"
        |> should equal Valid

    let test85 (f : string -> bool) =
        f @"1234567890@iana.org"
        |> should equal Valid

    let test86 (f : string -> bool) =
        f @"test+test@iana.org"
        |> should equal Valid

    let test87 (f : string -> bool) =
        f @"test-test@iana.org"
        |> should equal Valid

    let test88 (f : string -> bool) =
        f @"t*est@iana.org"
        |> should equal Valid

    let test89 (f : string -> bool) =
        f @"+1~1+@iana.org"
        |> should equal Valid

    let test90 (f : string -> bool) =
        f @"{_test_}@iana.org"
        |> should equal Valid

    let test91 (f : string -> bool) =
    //"[[ test ]]"@iana.org
        f "\"[[ test ]]\"@iana.org"
        |> should equal Valid

    let test92 (f : string -> bool) =
        f @"test.test@iana.org"
        |> should equal Valid

    let test93 (f : string -> bool) =
    //"test.test"@iana.org
        f "\"test.test\"@iana.org"
        |> should equal Valid

    let test94 (f : string -> bool) =
    //test."test"@iana.org
        f "test.\"test\"@iana.org"
        |> should equal Valid

    let test95 (f : string -> bool) =
    //"test@test"@iana.org
        f "\"test@test\"@iana.org"
        |> should equal Valid

    let test96 (f : string -> bool) =
        f @"test@123.123.123.x123"
        |> should equal Valid

    let test97 (f : string -> bool) =
        f @"test@123.123.123.123"
        |> should equal Valid

    let test98(f : string -> bool) =
        f @"test@[123.123.123.123]"
        |> should equal Valid

    let test99(f : string -> bool) =
        f @"test@example.iana.org"
        |> should equal Valid

    let test100 (f : string -> bool) =
        f @"test@example.example.iana.org"
        |> should equal Valid

    let test101 (f : string -> bool) =
        f @"test.iana.org"
        |> should equal Invalid

    let test102 (f : string -> bool) =
        f @"test.@iana.org"
        |> should equal Invalid

    let test103 (f : string -> bool) =
        f @"test..test@iana.org"
        |> should equal Invalid

    let test104 (f : string -> bool) =
        f @".test@iana.org"
        |> should equal Invalid

    let test105 (f : string -> bool) =
        f @"test@test@iana.org"
        |> should equal Invalid

    let test106 (f : string -> bool) =
        f @"test@@iana.org"
        |> should equal Invalid

    let test107 (f : string -> bool) =
        f @"-- test --@iana.org"
        |> should equal Invalid

    let test108 (f : string -> bool) =
        f @"[test]@iana.org"
        |> should equal Invalid

    let test109 (f : string -> bool) =
    //"test\test"@iana.org
        f "\"test\\test\"@iana.org"
        |> should equal Valid

    let test110 (f : string -> bool) =
    //"test"test"@iana.org
        f "\"test\"test\"@iana.org"
        |> should equal Invalid

    let test111 (f : string -> bool) =
        f @"()[]\;:,><@iana.org"
        |> should equal Invalid

    let test112 (f : string -> bool) =
        f @"test@."
        |> should equal Invalid

    let test113 (f : string -> bool) =
        f @"test@example."
        |> should equal Invalid

    let test114 (f : string -> bool) =
        f @"test@.org"
        |> should equal Invalid

    let test115 (f : string -> bool) =
        f @"test@123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012.com"
        |> should equal Invalid

    let test116 (f : string -> bool) =
        f @"test@example"
        |> should equal Valid

    let test117 (f : string -> bool) =
        f @"test@[123.123.123.123"
        |> should equal Invalid

    let test118(f : string -> bool) =
        f @"test@123.123.123.123]"
        |> should equal Invalid

    let test119 (f : string -> bool) =
        f @"NotAnEmail"
        |> should equal Invalid

    let test120 (f : string -> bool) =
        f @"@NotAnEmail"
        |> should equal Invalid

    let test121 (f : string -> bool) =
    //"test\\blah"@iana.org
        f "\"test\\\\blah\"@iana.org"
        |> should equal Valid

    let test122 (f : string -> bool) =
    //"test\blah"@iana.org
        f "\"test\\blah\"@iana.org"
        |> should equal Valid

    let test123 (f : string -> bool) =
    //"test\&#13;blah"@iana.org
        f "\"test\\&#13;blah\"@iana.org"
        |> should equal Valid

    let test124 (f : string -> bool) =
    //"test&#13;blah"@iana.org
        f "\"test&#13;blah\"@iana.org"
        |> should equal Invalid

    let test125 (f : string -> bool) =
    //"test\"blah"@iana.org
        f "\"test\\\"blah\"@iana.org"
        |> should equal Valid

    let test126 (f : string -> bool) =
    //"test"blah"@iana.org
        f "\"test\"blah\"@iana.org"
        |> should equal Invalid

    let test127 (f : string -> bool) =
        f @"customer/department@iana.org"
        |> should equal Valid

    let test128 (f : string -> bool) =
        f @"_Yosemite.Sam@iana.org"
        |> should equal Valid

    let test129 (f : string -> bool) =
        f @"~@iana.org"
        |> should equal Valid

    let test130 (f : string -> bool) =
        f @".wooly@iana.org"
        |> should equal Invalid

    let test131 (f : string -> bool) =
        f @"wo..oly@iana.org"
        |> should equal Invalid

    let test132 (f : string -> bool) =
        f @"pootietang.@iana.org"
        |> should equal Invalid

    let test133 (f : string -> bool) =
        f @".@iana.org"
        |> should equal Invalid

    let test134 (f : string -> bool) =
    //"Austin@Powers"@iana.org
        f "\"Austin@Powers\"@iana.org"
        |> should equal Valid

    let test135 (f : string -> bool) =
        f @"Ima.Fool@iana.org"
        |> should equal Valid

//following 2 are duplicates in the source
    let test136 (f : string -> bool) =
    //"Ima.Fool"@iana.org
        f "\"Ima.Fool\"@iana.org"
        |> should equal Valid

    let test137 (f : string -> bool) =
    //"Ima Fool"@iana.org
        f "\"Ima Fool\"@iana.org"
        |> should equal Valid

    let test138 (f : string -> bool) =
        f @"Ima Fool@iana.org"
        |> should equal Invalid

    let test139 (f : string -> bool) =
        f @"phil.h\@\@ck@haacked.com"
        |> should equal Invalid

    let test140 (f : string -> bool) =
    //"first"."last"@iana.org
        f "\"first\".\"last\"@iana.org"
        |> should equal Valid

    let test141 (f : string -> bool) =
    //"first".middle."last"@iana.org
        f "\"first\".middle.\"last\"@iana.org"
        |> should equal Valid

    let test142 (f : string -> bool) =
    //"first\\"last"@iana.org
        f "\"first\\\\\"last\"@iana.org"
        |> should equal Invalid

    let test143 (f : string -> bool) =
    //"first".last@iana.org
        f "\"first\".last@iana.org"
        |> should equal Valid

    let test144 (f : string -> bool) =
    //first."last"@iana.org
        f "first.\"last\"@iana.org"
        |> should equal Valid

    let test145 (f : string -> bool) =
    //"first"."middle"."last"@iana.org
        f "\"first\".\"middle\".\"last\"@iana.org"
        |> should equal Valid

    let test146 (f : string -> bool) =
    //"first.middle"."last"@iana.org
        f "\"first.middle\".\"last\"@iana.org"
        |> should equal Valid

    let test147 (f : string -> bool) =
    //"first.middle.last"@iana.org
        f "\"first.middle.last\"@iana.org"
        |> should equal Valid

    let test148 (f : string -> bool) =
    //"first..last"@iana.org
        f "\"first..last\"@iana.org"
        |> should equal Valid

    let test149 (f : string -> bool) =
        f @"foo@[\1.2.3.4]"
        |> should equal Invalid

    let test150 (f : string -> bool) =
    //"first\\\"last"@iana.org
        f "\"first\\\\\\\"last\"@iana.org"
        |> should equal Valid

    let test151 (f : string -> bool) =
    //first."mid\dle"."last"@iana.org
        f "first.\"mid\\dle\".\"last\"@iana.org"
        |> should equal Valid

    let test152 (f : string -> bool) =
        f @"Test.&#13;&#10; Folding.&#13;&#10; Whitespace@iana.org"
        |> should equal Valid

    let test153 (f : string -> bool) =
    //first."".last@iana.org
        f "first.\"\".last@iana.org"
        |> should equal Invalid

    let test154 (f : string -> bool) =
        f @"first\last@iana.org"
        |> should equal Invalid

    let test155 (f : string -> bool) =
        f @"Abc\@def@iana.org"
        |> should equal Invalid

    let test156 (f : string -> bool) =
        f @"Fred\ Bloggs@iana.org"
        |> should equal Invalid

    let test157 (f : string -> bool) =
        f @"Joe.\\Blow@iana.org"
        |> should equal Invalid

    let test158 (f : string -> bool) =
        f @"first.last@[IPv6:1111:2222:3333:4444:5555:6666:12.34.567.89]"
        |> should equal Invalid

    let test159 (f : string -> bool) =
    //"test\&#13;&#10; blah"@iana.org
        f "\"test\&#13;&#10; blah\"@iana.org"
        |> should equal Invalid

    let test160 (f : string -> bool) =
    //"test&#13;&#10; blah"@iana.org
        f "\"test&#13;&#10; blah\"@iana.org"
        |> should equal Valid

    let test161 (f : string -> bool) =
        f @"{^c\@**Dog^}@cartoon.com"
        |> should equal Invalid

    let test162 (f : string -> bool) =
        f @"(foo)cal(bar)@(baz)iamcal.com(quux)"
        |> should equal Valid

    let test163 (f : string -> bool) =
        f @"cal@iamcal(woo).(yay)com"
        |> should equal Valid

    let test164 (f : string -> bool) =
    //"foo"(yay)@(hoopla)[1.2.3.4]
        f "\"foo\"(yay)@(hoopla)[1.2.3.4]"
        |> should equal Invalid

    let test165 (f : string -> bool) =
        f @"cal(woo(yay)hoopla)@iamcal.com"
        |> should equal Valid

    let test166 (f : string -> bool) =
        f @"cal(foo\@bar)@iamcal.com"
        |> should equal Valid

    let test167 (f : string -> bool) =
        f @"cal(foo\)bar)@iamcal.com"
        |> should equal Valid

    let test168 (f : string -> bool) =
        f @"cal(foo(bar)@iamcal.com"
        |> should equal Invalid

    let test169 (f : string -> bool) =
        f @"cal(foo)bar)@iamcal.com"
        |> should equal Invalid

    let test170(f : string -> bool) =
        f @"cal(foo\)@iamcal.com"
        |> should equal Invalid

    let test171 (f : string -> bool) =
        f @"first().last@iana.org"
        |> should equal Valid

    let test172 (f : string -> bool) =
        f @"first.(&#13;&#10; middle&#13;&#10; )last@iana.org"
        |> should equal Valid

    let test173 (f : string -> bool) =
        f @"first(12345678901234567890123456789012345678901234567890)last@(1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890)iana.org"
        |> should equal Invalid

    let test174 (f : string -> bool) =
    //first(Welcome to&#13;&#10; the ("wonderful" (!)) world&#13;&#10; of email)@iana.org
        f "first(Welcome to&#13;&#10; the (\"wonderful\" (!)) world&#13;&#10; of email)@iana.org"
        |> should equal Valid

    let test175 (f : string -> bool) =
        f @"pete(his account)@silly.test(his host)"
        |> should equal Valid

    let test176 (f : string -> bool) =
        f @"c@(Chris's host.)public.example"
        |> should equal Valid

    let test177(f : string -> bool) =
        f @"jdoe@machine(comment).  example"
        |> should equal Valid

    let test178 (f : string -> bool) =
        f @"1234   @   local(blah)  .machine .example"
        |> should equal Valid

    let test179 (f : string -> bool) =
        f @"first(middle)last@iana.org"
        |> should equal Invalid

    let test180 (f : string -> bool) =
        f @"first(abc.def).last@iana.org"
        |> should equal Valid

    let test181 (f : string -> bool) =
    //first(a"bc.def).last@iana.org
        f "first(a\"bc.def).last@iana.org"
        |> should equal Valid

    let test182 (f : string -> bool) =
    //first.(")middle.last(")@iana.org
        f "first.(\")middle.last(\")@iana.org"
        |> should equal Valid

    let test183 (f : string -> bool) =
    //first(abc("def".ghi).mno)middle(abc("def".ghi).mno).last@(abc("def".ghi).mno)example(abc("def".ghi).mno).(abc("def".ghi).mno)com(abc("def".ghi).mno)
        f "first(abc(\"def\".ghi).mno)middle(abc(\"def\".ghi).mno).last@(abc(\"def\".ghi).mno)example(abc(\"def\".ghi).mno).(abc(\"def\".ghi).mno)com(abc(\"def\".ghi).mno)"
        |> should equal Invalid

    let test184 (f : string -> bool) =
        f @"first(abc\(def)@iana.org"
        |> should equal Valid

    let test185 (f : string -> bool) =
        f @"first.last@x(1234567890123456789012345678901234567890123456789012345678901234567890).com"
        |> should equal Valid

    let test186 (f : string -> bool) =
        f @"a(a(b(c)d(e(f))g)h(i)j)@iana.org"
        |> should equal Valid

    let test187 (f : string -> bool) =
        f @"a(a(b(c)d(e(f))g)(h(i)j)@iana.org"
        |> should equal Invalid

    let test188 (f : string -> bool) =
        f @"name.lastname@domain.com"
        |> should equal Valid

    let test189 (f : string -> bool) =
        f @".@"
        |> should equal Invalid

    let test190 (f : string -> bool) =
        f @"a@b"
        |> should equal Valid

    let test191 (f : string -> bool) =
        f @"@bar.com"
        |> should equal Invalid

    let test192 (f : string -> bool) =
        f @"@@bar.com"
        |> should equal Invalid

    let test193 (f : string -> bool) =
        f @"a@bar.com"
        |> should equal Valid

    let test194 (f : string -> bool) =
        f @"aaa.com"
        |> should equal Invalid

    let test195 (f : string -> bool) =
        f @"aaa@.com"
        |> should equal Invalid

    let test196 (f : string -> bool) =
        f @"aaa@.123"
        |> should equal Invalid

    let test197 (f : string -> bool) =
        f @"aaa@[123.123.123.123]"
        |> should equal Valid

    let test198 (f : string -> bool) =
        f @"aaa@[123.123.123.123]a"
        |> should equal Invalid

    let test199 (f : string -> bool) =
        f @"aaa@[123.123.123.333]"
        |> should equal Invalid

    let test200 (f : string -> bool) =
        f @"a@bar.com."
        |> should equal Invalid

    let test201 (f : string -> bool) =
        f @"a@bar"
        |> should equal Valid

    let test202 (f : string -> bool) =
        f @"a-b@bar.com"
        |> should equal Valid

    let test203 (f : string -> bool) =
        f @"+@b.c"
        |> should equal Valid

    let test204 (f : string -> bool) =
        f @"+@b.com"
        |> should equal Valid

    let test205 (f : string -> bool) =
        f @"a@-b.com"
        |> should equal Invalid

    let test206 (f : string -> bool) =
        f @"a@b-.com"
        |> should equal Invalid

    let test207 (f : string -> bool) =
        f @"-@..com"
        |> should equal Invalid

    let test208 (f : string -> bool) =
        f @"-@a..com"
        |> should equal Invalid

    let test209 (f : string -> bool) =
        f @"a@b.co-foo.uk"
        |> should equal Valid

    let test210 (f : string -> bool) =
    //"hello my name is"@stutter.com
        f "\"hello my name is\"@stutter.com"
        |> should equal Valid

    let test211 (f : string -> bool) =
    //"Test \"Fail\" Ing"@iana.org
        f "\"Test \\\"Fail\\\" Ing\"@iana.org"
        |> should equal Valid

    let test212 (f : string -> bool) =
        f @"valid@about.museum"
        |> should equal Valid

    let test213 (f : string -> bool) =
        f @"invalid@about.museum-"
        |> should equal Invalid

    let test214 (f : string -> bool) =
        f @"shaitan@my-domain.thisisminekthx"
        |> should equal Valid

    let test215 (f : string -> bool) =
        f @"test@...........com"
        |> should equal Invalid

    let test216 (f : string -> bool) =
        f @"foobar@192.168.0.1"
        |> should equal Valid

    let test217 (f : string -> bool) =
    //"Joe\\Blow"@iana.org
        f "\"Joe\\\\Blow\"@iana.org"
        |> should equal Valid

    let test218 (f : string -> bool) =
        f @"Invalid \&#10; Folding \&#10; Whitespace@iana.org"
        |> should equal Invalid

    let test219 (f : string -> bool) =
        f @"HM2Kinsists@(that comments are allowed)this.is.ok"
        |> should equal Valid

    let test220 (f : string -> bool) =
        f @"user%uucp!path@berkeley.edu"
        |> should equal Valid

    let test221 (f : string -> bool) =
    //"first(last)"@iana.org
        f "\"first(last)\"@iana.org"
        |> should equal Valid

    let test222 (f : string -> bool) =
        f @"&#13;&#10; (&#13;&#10; x &#13;&#10; ) &#13;&#10; first&#13;&#10; ( &#13;&#10; x&#13;&#10; ) &#13;&#10; .&#13;&#10; ( &#13;&#10; x) &#13;&#10; last &#13;&#10; (  x &#13;&#10; ) &#13;&#10; @iana.org"
        |> should equal Valid

    let test223 (f : string -> bool) =
        f @"first.last @iana.org"
        |> should equal Valid

    let test224 (f : string -> bool) =
        f @"test. &#13;&#10; &#13;&#10; obs@syntax.com"
        |> should equal Valid

    let test225 (f : string -> bool) =
        f @"test.&#13;&#10;&#13;&#10; obs@syntax.com"
        |> should equal Invalid

    let test226 (f : string -> bool) =  //\u0000 
    //"Unicode NULL \␀"@char.com
        f "\"Unicode NULL \\\u0000\"@char.com"
        |> should equal Valid

    let test227 (f : string -> bool) =
    //"Unicode NULL ␀"@char.com
        f "\"Unicode NULL \u0000\"@char.com"
        |> should equal Invalid

    let test228 (f : string -> bool) =
    //Unicode NULL \␀@char.com
        f "Unicode NULL \\\u0000@char.com"
        |> should equal Invalid

    let test229 (f : string -> bool) =
        f @"cdburgess+!#$%&'*-/=?+_{}|~test@gmail.com"
        |> should equal Valid

    let test230 (f : string -> bool) =
        f @"first.last@[IPv6:::a2:a3:a4:b1:b2:b3:b4]"
        |> should equal Valid

    let test231 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2:a3:a4:b1:b2:b3::]"
        |> should equal Valid

    let test232 (f : string -> bool) =
        f @"first.last@[IPv6::]"
        |> should equal Invalid

    let test233 (f : string -> bool) =
        f @"first.last@[IPv6:::]"
        |> should equal Valid

    let test234 (f : string -> bool) =
        f @"first.last@[IPv6::::]"
        |> should equal Invalid

    let test235 (f : string -> bool) =
        f @"first.last@[IPv6::b4]"
        |> should equal Invalid

    let test236 (f : string -> bool) =
        f @"first.last@[IPv6:::b4]"
        |> should equal Valid

    let test237 (f : string -> bool) =
        f @"first.last@[IPv6::::b4]"
        |> should equal Invalid

    let test238 (f : string -> bool) =
        f @"first.last@[IPv6::b3:b4]"
        |> should equal Invalid

    let test239 (f : string -> bool) =
        f @"first.last@[IPv6:::b3:b4]"
        |> should equal Valid

    let test240(f : string -> bool) =
        f @"first.last@[IPv6::::b3:b4]"
        |> should equal Invalid

    let test241 (f : string -> bool) =
        f @"first.last@[IPv6:a1::b4]"
        |> should equal Valid

    let test242 (f : string -> bool) =
        f @"first.last@[IPv6:a1:::b4]"
        |> should equal Invalid

    let test243 (f : string -> bool) =
        f @"first.last@[IPv6:a1:]"
        |> should equal Invalid

    let test244 (f : string -> bool) =
        f @"first.last@[IPv6:a1::]"
        |> should equal Valid

    let test245 (f : string -> bool) =
        f @"first.last@[IPv6:a1:::]"
        |> should equal Invalid

    let test246 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2:]"
        |> should equal Invalid

    let test247 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2::]"
        |> should equal Valid

    let test248 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2:::]"
        |> should equal Invalid

    let test249 (f : string -> bool) =
        f @"first.last@[IPv6:0123:4567:89ab:cdef::]"
        |> should equal Valid

    let test250 (f : string -> bool) =
        f @"first.last@[IPv6:0123:4567:89ab:CDEF::]"
        |> should equal Valid

    let test251 (f : string -> bool) =
        f @"first.last@[IPv6:::a3:a4:b1:ffff:11.22.33.44]"
        |> should equal Valid

    let test252 (f : string -> bool) =
        f @"first.last@[IPv6:::a2:a3:a4:b1:ffff:11.22.33.44]"
        |> should equal Valid

    let test253 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2:a3:a4::11.22.33.44]"
        |> should equal Valid

    let test254 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2:a3:a4:b1::11.22.33.44]"
        |> should equal Valid

    let test255 (f : string -> bool) =
        f @"first.last@[IPv6::11.22.33.44]"
        |> should equal Invalid

    let test256 (f : string -> bool) =
        f @"first.last@[IPv6::::11.22.33.44]"
        |> should equal Invalid

    let test257 (f : string -> bool) =
        f @"first.last@[IPv6:a1:11.22.33.44]"
        |> should equal Invalid

    let test258 (f : string -> bool) =
        f @"first.last@[IPv6:a1::11.22.33.44]"
        |> should equal Valid

    let test259 (f : string -> bool) =
        f @"first.last@[IPv6:a1:::11.22.33.44]"
        |> should equal Invalid

    let test260 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2::11.22.33.44]"
        |> should equal Valid

    let test261 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2:::11.22.33.44]"
        |> should equal Invalid

    let test262 (f : string -> bool) =
        f @"first.last@[IPv6:0123:4567:89ab:cdef::11.22.33.44]"
        |> should equal Valid

    let test263 (f : string -> bool) =
        f @"first.last@[IPv6:0123:4567:89ab:cdef::11.22.33.xx]"
        |> should equal Invalid

    let test264 (f : string -> bool) =
        f @"first.last@[IPv6:0123:4567:89ab:CDEF::11.22.33.44]"
        |> should equal Valid

    let test265 (f : string -> bool) =
        f @"first.last@[IPv6:0123:4567:89ab:CDEFF::11.22.33.44]"
        |> should equal Invalid

    let test266 (f : string -> bool) =
        f @"first.last@[IPv6:a1::a4:b1::b4:11.22.33.44]"
        |> should equal Invalid

    let test267 (f : string -> bool) =
        f @"first.last@[IPv6:a1::11.22.33]"
        |> should equal Invalid

    let test268 (f : string -> bool) =
        f @"first.last@[IPv6:a1::11.22.33.44.55]"
        |> should equal Invalid

    let test269 (f : string -> bool) =
        f @"first.last@[IPv6:a1::b211.22.33.44]"
        |> should equal Invalid

    let test270 (f : string -> bool) =
        f @"first.last@[IPv6:a1::b2:11.22.33.44]"
        |> should equal Valid

    let test271 (f : string -> bool) =
        f @"first.last@[IPv6:a1::b2::11.22.33.44]"
        |> should equal Invalid

    let test272 (f : string -> bool) =
        f @"first.last@[IPv6:a1::b3:]"
        |> should equal Invalid

    let test273 (f : string -> bool) =
        f @"first.last@[IPv6::a2::b4]"
        |> should equal Invalid

    let test274 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2:a3:a4:b1:b2:b3:]"
        |> should equal Invalid

    let test275 (f : string -> bool) =
        f @"first.last@[IPv6::a2:a3:a4:b1:b2:b3:b4]"
        |> should equal Invalid

    let test276 (f : string -> bool) =
        f @"first.last@[IPv6:a1:a2:a3:a4::b1:b2:b3:b4]"
        |> should equal Invalid

    let test277 (f : string -> bool) =
        f @"test@test.com"
        |> should equal Valid

    let test278 (f : string -> bool) =
        f @"test@example.com&#10;"
        |> should equal Invalid

    let test279 (f : string -> bool) =
        f @"test@xn--example.com"
        |> should equal Valid

    let test280 (f : string -> bool) =
        f @"test@Bücher.ch"
        |> should equal Valid