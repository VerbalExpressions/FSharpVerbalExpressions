namespace Email.Tests

open FsVerbalExpressions.VerbalExpression
open Xunit

[<Trait("Kind", "Complex")>]
module ComplexEmail =

    [<Literal>]
    /// RFC 5322 Official Standard regex from http://emailregex.com/
    let ComplexEmailRegex = """(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])"""
    let complexEmailRegex = new VerbEx(ComplexEmailRegex)

    [<Fact>]
    let test1 () =
        complexEmailRegex.IsMatch
        |> RFC822.test1 

    [<Fact>]
    let test2 () =
        complexEmailRegex.IsMatch
        |> RFC822.test2

    [<Fact>]
    let test3 () =
        complexEmailRegex.IsMatch
        |> RFC822.test3

    [<Fact>]
    let test4 () =
        complexEmailRegex.IsMatch
        |> RFC822.test4

    [<Fact>]
    let test5 () =
        complexEmailRegex.IsMatch
        |> RFC822.test5

    [<Fact>]
    let test6 () =
        complexEmailRegex.IsMatch
        |> RFC822.test6

    [<Fact>]
    let test7 () =
        complexEmailRegex.IsMatch
        |> RFC822.test7

    [<Fact>]
    let test8 () =
        complexEmailRegex.IsMatch
        |> RFC822.test8

    [<Fact>]
    let test9 () =
        complexEmailRegex.IsMatch
        |> RFC822.test9

    [<Fact>]
    let test10 () =
        complexEmailRegex.IsMatch
        |> RFC822.test10

    [<Fact>]
    let test11 () =
        complexEmailRegex.IsMatch
        |> RFC822.test11

    [<Fact>]
    let test12 () =
        complexEmailRegex.IsMatch
        |> RFC822.test12

    [<Fact>]
    let test13 () =
        complexEmailRegex.IsMatch
        |> RFC822.test13

    [<Fact>]
    let test14 () =
        complexEmailRegex.IsMatch
        |> RFC822.test14

    [<Fact>]
    let test15 () =
        complexEmailRegex.IsMatch
        |> RFC822.test15

    [<Fact>]
    let test16 () =
        complexEmailRegex.IsMatch
        |> RFC822.test16

    [<Fact>]
    let test17 () =
        complexEmailRegex.IsMatch
        |> RFC822.test17

    [<Fact>]
    let test18 () =
        complexEmailRegex.IsMatch
        |> RFC822.test18

    [<Fact>]
    let test19 () =
        complexEmailRegex.IsMatch
        |> RFC822.test19

    [<Fact>]
    let test20 () =
        complexEmailRegex.IsMatch
        |> RFC822.test20

    [<Fact>]
    let test21 () =
        complexEmailRegex.IsMatch
        |> RFC822.test21

    [<Fact>]
    let test22 () =
        complexEmailRegex.IsMatch
        |> RFC822.test22

    [<Fact>]
    let test23 () =
        complexEmailRegex.IsMatch
        |> RFC822.test23

    [<Fact>]
    let test24 () =
        complexEmailRegex.IsMatch
        |> RFC822.test24

    [<Fact>]
    let test25 () =
        complexEmailRegex.IsMatch
        |> RFC822.test25

    [<Fact>]
    let test26 () =
        complexEmailRegex.IsMatch
        |> RFC822.test26

    [<Fact>]
    let test27 () =
        complexEmailRegex.IsMatch
        |> RFC822.test27

    [<Fact>]
    let test28 () =
        complexEmailRegex.IsMatch
        |> RFC822.test28

    [<Fact>]
    let test29 () =
        complexEmailRegex.IsMatch
        |> RFC822.test29

    [<Fact>]
    let test30 () =
        complexEmailRegex.IsMatch
        |> RFC822.test30

    [<Fact>]
    let test31 () =
        complexEmailRegex.IsMatch
        |> RFC822.test31

    [<Fact>]
    let test32 () =
        complexEmailRegex.IsMatch
        |> RFC822.test32

    [<Fact>]
    let test33 () =
        complexEmailRegex.IsMatch
        |> RFC822.test33

    [<Fact>]
    let test34 () =
        complexEmailRegex.IsMatch
        |> RFC822.test34

    [<Fact>]
    let test35 () =
        complexEmailRegex.IsMatch
        |> RFC822.test35

    [<Fact>]
    let test36 () =
        complexEmailRegex.IsMatch
        |> RFC822.test36

    [<Fact>]
    let test37 () =
        complexEmailRegex.IsMatch
        |> RFC822.test37

    [<Fact>]
    let test38 () =
        complexEmailRegex.IsMatch
        |> RFC822.test38

    [<Fact>]
    let test39 () =
        complexEmailRegex.IsMatch
        |> RFC822.test39

    [<Fact>]
    let test40 () =
        complexEmailRegex.IsMatch
        |> RFC822.test40

    [<Fact>]
    let test41 () =
        complexEmailRegex.IsMatch
        |> RFC822.test41

    [<Fact>]
    let test42 () =
        complexEmailRegex.IsMatch
        |> RFC822.test42

    [<Fact>]
    let test43 () =
        complexEmailRegex.IsMatch
        |> RFC822.test43

    [<Fact>]
    let test44 () =
        complexEmailRegex.IsMatch
        |> RFC822.test44

    [<Fact>]
    let test45 () =
        complexEmailRegex.IsMatch
        |> RFC822.test45

    [<Fact>]
    let test46 () =
        complexEmailRegex.IsMatch
        |> RFC822.test46

    [<Fact>]
    let test47 () =
        complexEmailRegex.IsMatch
        |> RFC822.test47

    [<Fact>]
    let test48 () =
        complexEmailRegex.IsMatch
        |> RFC822.test48

    [<Fact>]
    let test49 () =
        complexEmailRegex.IsMatch
        |> RFC822.test49

    [<Fact>]
    let test50 () =
        complexEmailRegex.IsMatch
        |> RFC822.test50

    [<Fact>]
    let test51 () =
        complexEmailRegex.IsMatch
        |> RFC822.test51

    [<Fact>]
    let test52 () =
        complexEmailRegex.IsMatch
        |> RFC822.test52

    [<Fact>]
    let test53 () =
        complexEmailRegex.IsMatch
        |> RFC822.test53

    [<Fact>]
    let test54 () =
        complexEmailRegex.IsMatch
        |> RFC822.test54

    [<Fact>]
    let test55 () =
        complexEmailRegex.IsMatch
        |> RFC822.test55

    [<Fact>]
    let test56 () =
        complexEmailRegex.IsMatch
        |> RFC822.test56

    [<Fact>]
    let test57 () =
        complexEmailRegex.IsMatch
        |> RFC822.test57

    [<Fact>]
    let test58 () =
        complexEmailRegex.IsMatch
        |> RFC822.test58

    [<Fact>]
    let test59 () =
        complexEmailRegex.IsMatch
        |> RFC822.test59

    [<Fact>]
    let test60 () =
        complexEmailRegex.IsMatch
        |> RFC822.test60

    [<Fact>]
    let test61 () =
        complexEmailRegex.IsMatch
        |> RFC822.test61

    [<Fact>]
    let test62 () =
        complexEmailRegex.IsMatch
        |> RFC822.test62

    [<Fact>]
    let test63 () =
        complexEmailRegex.IsMatch
        |> RFC822.test63

    [<Fact>]
    let test64 () =
        complexEmailRegex.IsMatch
        |> RFC822.test64

    [<Fact>]
    let test65 () =
        complexEmailRegex.IsMatch
        |> RFC822.test65

    [<Fact>]
    let test66 () =
        complexEmailRegex.IsMatch
        |> RFC822.test66

    [<Fact>]
    let test67 () =
        complexEmailRegex.IsMatch
        |> RFC822.test67

    [<Fact>]
    let test68 () =
        complexEmailRegex.IsMatch
        |> RFC822.test68

    [<Fact>]
    let test69 () =
        complexEmailRegex.IsMatch
        |> RFC822.test69

    [<Fact>]
    let test70 () =
        complexEmailRegex.IsMatch
        |> RFC822.test70

    [<Fact>]
    let test71 () =
        complexEmailRegex.IsMatch
        |> RFC822.test71

    [<Fact>]
    let test72 () =
        complexEmailRegex.IsMatch
        |> RFC822.test72

    [<Fact>]
    let test73 () =
        complexEmailRegex.IsMatch
        |> RFC822.test73

    [<Fact>]
    let test74 () =
        complexEmailRegex.IsMatch
        |> RFC822.test74

    [<Fact>]
    let test75 () =
        complexEmailRegex.IsMatch
        |> RFC822.test75

    [<Fact>]
    let test76 () =
        complexEmailRegex.IsMatch
        |> RFC822.test76

    [<Fact>]
    let test77 () =
        complexEmailRegex.IsMatch
        |> RFC822.test77

    [<Fact>]
    let test78 () =
        complexEmailRegex.IsMatch
        |> RFC822.test78

    [<Fact>]
    let test79 () =
        complexEmailRegex.IsMatch
        |> RFC822.test79

    [<Fact>]
    let test80 () =
        complexEmailRegex.IsMatch
        |> RFC822.test80

    [<Fact>]
    let test81 () =
        complexEmailRegex.IsMatch
        |> RFC822.test81

    [<Fact>]
    let test82 () =
        complexEmailRegex.IsMatch
        |> RFC822.test82

    [<Fact>]
    let test83 () =
        complexEmailRegex.IsMatch
        |> RFC822.test83

    [<Fact>]
    let test84 () =
        complexEmailRegex.IsMatch
        |> RFC822.test84

    [<Fact>]
    let test85 () =
        complexEmailRegex.IsMatch
        |> RFC822.test85

    [<Fact>]
    let test86 () =
        complexEmailRegex.IsMatch
        |> RFC822.test86

    [<Fact>]
    let test87 () =
        complexEmailRegex.IsMatch
        |> RFC822.test87

    [<Fact>]
    let test88 () =
        complexEmailRegex.IsMatch
        |> RFC822.test88

    [<Fact>]
    let test89 () =
        complexEmailRegex.IsMatch
        |> RFC822.test89

    [<Fact>]
    let test90 () =
        complexEmailRegex.IsMatch
        |> RFC822.test90

    [<Fact>]
    let test91 () =
        complexEmailRegex.IsMatch
        |> RFC822.test91

    [<Fact>]
    let test92 () =
        complexEmailRegex.IsMatch
        |> RFC822.test92

    [<Fact>]
    let test93 () =
        complexEmailRegex.IsMatch
        |> RFC822.test93

    [<Fact>]
    let test94 () =
        complexEmailRegex.IsMatch
        |> RFC822.test94

    [<Fact>]
    let test95 () =
        complexEmailRegex.IsMatch
        |> RFC822.test95

    [<Fact>]
    let test96 () =
        complexEmailRegex.IsMatch
        |> RFC822.test96

    [<Fact>]
    let test97 () =
        complexEmailRegex.IsMatch
        |> RFC822.test97

    [<Fact>]
    let test98 () =
        complexEmailRegex.IsMatch
        |> RFC822.test98

    [<Fact>]
    let test99 () =
        complexEmailRegex.IsMatch
        |> RFC822.test99

    [<Fact>]
    let test100 () =
        complexEmailRegex.IsMatch
        |> RFC822.test100

    [<Fact>]
    let test101 () =
        complexEmailRegex.IsMatch
        |> RFC822.test101

    [<Fact>]
    let test102 () =
        complexEmailRegex.IsMatch
        |> RFC822.test102

    [<Fact>]
    let test103 () =
        complexEmailRegex.IsMatch
        |> RFC822.test103

    [<Fact>]
    let test104 () =
        complexEmailRegex.IsMatch
        |> RFC822.test104

    [<Fact>]
    let test105 () =
        complexEmailRegex.IsMatch
        |> RFC822.test105

    [<Fact>]
    let test106 () =
        complexEmailRegex.IsMatch
        |> RFC822.test106

    [<Fact>]
    let test107 () =
        complexEmailRegex.IsMatch
        |> RFC822.test107

    [<Fact>]
    let test108 () =
        complexEmailRegex.IsMatch
        |> RFC822.test108

    [<Fact>]
    let test109 () =
        complexEmailRegex.IsMatch
        |> RFC822.test109

    [<Fact>]
    let test110 () =
        complexEmailRegex.IsMatch
        |> RFC822.test110

    [<Fact>]
    let test111 () =
        complexEmailRegex.IsMatch
        |> RFC822.test111

    [<Fact>]
    let test112 () =
        complexEmailRegex.IsMatch
        |> RFC822.test112

    [<Fact>]
    let test113 () =
        complexEmailRegex.IsMatch
        |> RFC822.test113

    [<Fact>]
    let test114 () =
        complexEmailRegex.IsMatch
        |> RFC822.test114

    [<Fact>]
    let test115 () =
        complexEmailRegex.IsMatch
        |> RFC822.test115

    [<Fact>]
    let test116 () =
        complexEmailRegex.IsMatch
        |> RFC822.test116

    [<Fact>]
    let test117 () =
        complexEmailRegex.IsMatch
        |> RFC822.test117

    [<Fact>]
    let test118 () =
        complexEmailRegex.IsMatch
        |> RFC822.test118

    [<Fact>]
    let test119 () =
        complexEmailRegex.IsMatch
        |> RFC822.test119

    [<Fact>]
    let test120 () =
        complexEmailRegex.IsMatch
        |> RFC822.test120

    [<Fact>]
    let test121 () =
        complexEmailRegex.IsMatch
        |> RFC822.test121

    [<Fact>]
    let test122 () =
        complexEmailRegex.IsMatch
        |> RFC822.test122

    [<Fact>]
    let test123 () =
        complexEmailRegex.IsMatch
        |> RFC822.test123

    [<Fact>]
    let test124 () =
        complexEmailRegex.IsMatch
        |> RFC822.test124

    [<Fact>]
    let test125 () =
        complexEmailRegex.IsMatch
        |> RFC822.test125

    [<Fact>]
    let test126 () =
        complexEmailRegex.IsMatch
        |> RFC822.test126

    [<Fact>]
    let test127 () =
        complexEmailRegex.IsMatch
        |> RFC822.test127

    [<Fact>]
    let test128 () =
        complexEmailRegex.IsMatch
        |> RFC822.test128

    [<Fact>]
    let test129 () =
        complexEmailRegex.IsMatch
        |> RFC822.test129

    [<Fact>]
    let test130 () =
        complexEmailRegex.IsMatch
        |> RFC822.test130

    [<Fact>]
    let test131 () =
        complexEmailRegex.IsMatch
        |> RFC822.test131

    [<Fact>]
    let test132 () =
        complexEmailRegex.IsMatch
        |> RFC822.test132

    [<Fact>]
    let test133 () =
        complexEmailRegex.IsMatch
        |> RFC822.test133

    [<Fact>]
    let test134 () =
        complexEmailRegex.IsMatch
        |> RFC822.test134

    [<Fact>]
    let test135 () =
        complexEmailRegex.IsMatch
        |> RFC822.test135

    [<Fact>]
    let test136 () =
        complexEmailRegex.IsMatch
        |> RFC822.test136

    [<Fact>]
    let test137 () =
        complexEmailRegex.IsMatch
        |> RFC822.test137

    [<Fact>]
    let test138 () =
        complexEmailRegex.IsMatch
        |> RFC822.test138

    [<Fact>]
    let test139 () =
        complexEmailRegex.IsMatch
        |> RFC822.test139

    [<Fact>]
    let test140 () =
        complexEmailRegex.IsMatch
        |> RFC822.test140

    [<Fact>]
    let test141 () =
        complexEmailRegex.IsMatch
        |> RFC822.test141

    [<Fact>]
    let test142 () =
        complexEmailRegex.IsMatch
        |> RFC822.test142

    [<Fact>]
    let test143 () =
        complexEmailRegex.IsMatch
        |> RFC822.test143

    [<Fact>]
    let test144 () =
        complexEmailRegex.IsMatch
        |> RFC822.test144

    [<Fact>]
    let test145 () =
        complexEmailRegex.IsMatch
                |> RFC822.test145

    [<Fact>]
    let test146 () =
        complexEmailRegex.IsMatch
        |> RFC822.test146

    [<Fact>]
    let test147 () =
        complexEmailRegex.IsMatch
        |> RFC822.test147

    [<Fact>]
    let test148 () =
        complexEmailRegex.IsMatch
        |> RFC822.test148

    [<Fact>]
    let test149 () =
        complexEmailRegex.IsMatch
        |> RFC822.test149

    [<Fact>]
    let test150 () =
        complexEmailRegex.IsMatch
        |> RFC822.test150

    [<Fact>]
    let test151 () =
        complexEmailRegex.IsMatch
        |> RFC822.test151

    [<Fact>]
    let test152 () =
        complexEmailRegex.IsMatch
        |> RFC822.test152

    [<Fact>]
    let test153 () =
        complexEmailRegex.IsMatch
        |> RFC822.test153

    [<Fact>]
    let test154 () =
        complexEmailRegex.IsMatch
        |> RFC822.test154

    [<Fact>]
    let test155 () =
        complexEmailRegex.IsMatch
        |> RFC822.test155

    [<Fact>]
    let test156 () =
        complexEmailRegex.IsMatch
        |> RFC822.test156

    [<Fact>]
    let test157 () =
        complexEmailRegex.IsMatch
        |> RFC822.test157

    [<Fact>]
    let test158 () =
        complexEmailRegex.IsMatch
        |> RFC822.test158

    [<Fact>]
    let test159 () =
        complexEmailRegex.IsMatch
        |> RFC822.test159

    [<Fact>]
    let test160 () =
        complexEmailRegex.IsMatch
        |> RFC822.test160

    [<Fact>]
    let test161 () =
        complexEmailRegex.IsMatch
        |> RFC822.test161

    [<Fact>]
    let test162 () =
        complexEmailRegex.IsMatch
        |> RFC822.test162

    [<Fact>]
    let test163 () =
        complexEmailRegex.IsMatch
        |> RFC822.test163

    [<Fact>]
    let test164 () =
        complexEmailRegex.IsMatch
        |> RFC822.test164

    [<Fact>]
    let test165 () =
        complexEmailRegex.IsMatch
        |> RFC822.test165

    [<Fact>]
    let test166 () =
        complexEmailRegex.IsMatch
        |> RFC822.test166

    [<Fact>]
    let test167 () =
        complexEmailRegex.IsMatch
        |> RFC822.test167

    [<Fact>]
    let test168 () =
        complexEmailRegex.IsMatch
        |> RFC822.test168

    [<Fact>]
    let test169 () =
        complexEmailRegex.IsMatch
        |> RFC822.test169

    [<Fact>]
    let test170 () =
        complexEmailRegex.IsMatch
        |> RFC822.test170

    [<Fact>]
    let test171 () =
        complexEmailRegex.IsMatch
        |> RFC822.test171

    [<Fact>]
    let test172 () =
        complexEmailRegex.IsMatch
        |> RFC822.test172

    [<Fact>]
    let test173 () =
        complexEmailRegex.IsMatch
        |> RFC822.test173

    [<Fact>]
    let test174 () =
        complexEmailRegex.IsMatch
        |> RFC822.test174

    [<Fact>]
    let test175 () =
        complexEmailRegex.IsMatch
        |> RFC822.test175

    [<Fact>]
    let test176 () =
        complexEmailRegex.IsMatch
        |> RFC822.test176

    [<Fact>]
    let test177 () =
        complexEmailRegex.IsMatch
        |> RFC822.test177

    [<Fact>]
    let test178 () =
        complexEmailRegex.IsMatch
        |> RFC822.test178

    [<Fact>]
    let test179 () =
        complexEmailRegex.IsMatch
        |> RFC822.test179

    [<Fact>]
    let test180 () =
        complexEmailRegex.IsMatch
        |> RFC822.test180

    [<Fact>]
    let test181 () =
        complexEmailRegex.IsMatch
        |> RFC822.test181

    [<Fact>]
    let test182 () =
        complexEmailRegex.IsMatch
        |> RFC822.test182

    [<Fact>]
    let test183 () =
        complexEmailRegex.IsMatch
        |> RFC822.test183

    [<Fact>]
    let test184 () =
        complexEmailRegex.IsMatch
        |> RFC822.test184

    [<Fact>]
    let test185 () =
        complexEmailRegex.IsMatch
        |> RFC822.test185

    [<Fact>]
    let test186 () =
        complexEmailRegex.IsMatch
        |> RFC822.test186

    [<Fact>]
    let test187 () =
        complexEmailRegex.IsMatch
        |> RFC822.test187

    [<Fact>]
    let test188 () =
        complexEmailRegex.IsMatch
        |> RFC822.test188

    [<Fact>]
    let test189 () =
        complexEmailRegex.IsMatch
        |> RFC822.test189

    [<Fact>]
    let test190 () =
        complexEmailRegex.IsMatch
        |> RFC822.test190

    [<Fact>]
    let test191 () =
        complexEmailRegex.IsMatch
        |> RFC822.test191

    [<Fact>]
    let test192 () =
        complexEmailRegex.IsMatch
        |> RFC822.test192

    [<Fact>]
    let test193 () =
        complexEmailRegex.IsMatch
        |> RFC822.test193

    [<Fact>]
    let test194 () =
        complexEmailRegex.IsMatch
        |> RFC822.test194

    [<Fact>]
    let test195 () =
        complexEmailRegex.IsMatch
        |> RFC822.test195

    [<Fact>]
    let test196 () =
        complexEmailRegex.IsMatch
        |> RFC822.test196

    [<Fact>]
    let test197 () =
        complexEmailRegex.IsMatch
        |> RFC822.test197

    [<Fact>]
    let test198 () =
        complexEmailRegex.IsMatch
        |> RFC822.test198

    [<Fact>]
    let test199 () =
        complexEmailRegex.IsMatch
        |> RFC822.test199

    [<Fact>]
    let test200 () =
        complexEmailRegex.IsMatch
        |> RFC822.test200

    [<Fact>]
    let test201 () =
        complexEmailRegex.IsMatch
        |> RFC822.test201

    [<Fact>]
    let test202 () =
        complexEmailRegex.IsMatch
        |> RFC822.test202

    [<Fact>]
    let test203 () =
        complexEmailRegex.IsMatch
        |> RFC822.test203

    [<Fact>]
    let test204 () =
        complexEmailRegex.IsMatch
        |> RFC822.test204

    [<Fact>]
    let test205 () =
        complexEmailRegex.IsMatch
        |> RFC822.test205

    [<Fact>]
    let test206 () =
        complexEmailRegex.IsMatch
        |> RFC822.test206

    [<Fact>]
    let test207 () =
        complexEmailRegex.IsMatch
        |> RFC822.test207

    [<Fact>]
    let test208 () =
        complexEmailRegex.IsMatch
        |> RFC822.test208

    [<Fact>]
    let test209 () =
        complexEmailRegex.IsMatch
        |> RFC822.test209

    [<Fact>]
    let test210 () =
        complexEmailRegex.IsMatch
        |> RFC822.test210

    [<Fact>]
    let test211 () =
        complexEmailRegex.IsMatch
        |> RFC822.test211

    [<Fact>]
    let test212 () =
        complexEmailRegex.IsMatch
        |> RFC822.test212

    [<Fact>]
    let test213 () =
        complexEmailRegex.IsMatch
        |> RFC822.test213

    [<Fact>]
    let test214 () =
        complexEmailRegex.IsMatch
        |> RFC822.test214

    [<Fact>]
    let test215 () =
        complexEmailRegex.IsMatch
        |> RFC822.test215

    [<Fact>]
    let test216 () =
        complexEmailRegex.IsMatch
        |> RFC822.test216

    [<Fact>]
    let test217 () =
        complexEmailRegex.IsMatch
        |> RFC822.test217

    [<Fact>]
    let test218 () =
        complexEmailRegex.IsMatch
        |> RFC822.test218

    [<Fact>]
    let test219 () =
        complexEmailRegex.IsMatch
        |> RFC822.test219

    [<Fact>]
    let test220 () =
        complexEmailRegex.IsMatch
        |> RFC822.test220

    [<Fact>]
    let test221 () =
        complexEmailRegex.IsMatch
        |> RFC822.test221

    [<Fact>]
    let test222 () =
        complexEmailRegex.IsMatch
        |> RFC822.test222

    [<Fact>]
    let test223 () =
        complexEmailRegex.IsMatch
        |> RFC822.test223

    [<Fact>]
    let test224 () =
        complexEmailRegex.IsMatch
        |> RFC822.test224

    [<Fact>]
    let test225 () =
        complexEmailRegex.IsMatch
        |> RFC822.test225

    [<Fact>]
    let test226 () =
        complexEmailRegex.IsMatch
        |> RFC822.test226

    [<Fact>]
    let test227 () =
        complexEmailRegex.IsMatch
        |> RFC822.test227

    [<Fact>]
    let test228 () =
        complexEmailRegex.IsMatch
        |> RFC822.test228

    [<Fact>]
    let test229 () =
        complexEmailRegex.IsMatch
        |> RFC822.test229

    [<Fact>]
    let test230 () =
        complexEmailRegex.IsMatch
        |> RFC822.test230

    [<Fact>]
    let test231 () =
        complexEmailRegex.IsMatch
        |> RFC822.test231

    [<Fact>]
    let test232 () =
        complexEmailRegex.IsMatch
        |> RFC822.test232

    [<Fact>]
    let test233 () =
        complexEmailRegex.IsMatch
        |> RFC822.test233

    [<Fact>]
    let test234 () =
        complexEmailRegex.IsMatch
        |> RFC822.test234

    [<Fact>]
    let test235 () =
        complexEmailRegex.IsMatch
        |> RFC822.test235

    [<Fact>]
    let test236 () =
        complexEmailRegex.IsMatch
        |> RFC822.test236

    [<Fact>]
    let test237 () =
        complexEmailRegex.IsMatch
        |> RFC822.test237

    [<Fact>]
    let test238 () =
        complexEmailRegex.IsMatch
        |> RFC822.test238

    [<Fact>]
    let test239 () =
        complexEmailRegex.IsMatch
        |> RFC822.test239

    [<Fact>]
    let test240 () =
        complexEmailRegex.IsMatch
        |> RFC822.test240

    [<Fact>]
    let test241 () =
        complexEmailRegex.IsMatch
        |> RFC822.test241

    [<Fact>]
    let test242 () =
        complexEmailRegex.IsMatch
        |> RFC822.test242

    [<Fact>]
    let test243 () =
        complexEmailRegex.IsMatch
        |> RFC822.test243

    [<Fact>]
    let test244 () =
        complexEmailRegex.IsMatch
        |> RFC822.test244

    [<Fact>]
    let test245 () =
        complexEmailRegex.IsMatch
        |> RFC822.test245

    [<Fact>]
    let test246 () =
        complexEmailRegex.IsMatch
        |> RFC822.test246

    [<Fact>]
    let test247 () =
        complexEmailRegex.IsMatch
        |> RFC822.test247

    [<Fact>]
    let test248 () =
        complexEmailRegex.IsMatch
        |> RFC822.test248

    [<Fact>]
    let test249 () =
        complexEmailRegex.IsMatch
        |> RFC822.test249

    [<Fact>]
    let test250 () =
        complexEmailRegex.IsMatch
        |> RFC822.test250

    [<Fact>]
    let test251 () =
        complexEmailRegex.IsMatch
        |> RFC822.test251

    [<Fact>]
    let test252 () =
        complexEmailRegex.IsMatch
        |> RFC822.test252

    [<Fact>]
    let test253 () =
        complexEmailRegex.IsMatch
        |> RFC822.test253

    [<Fact>]
    let test254 () =
        complexEmailRegex.IsMatch
        |> RFC822.test254

    [<Fact>]
    let test255 () =
        complexEmailRegex.IsMatch
        |> RFC822.test255

    [<Fact>]
    let test256 () =
        complexEmailRegex.IsMatch
        |> RFC822.test256

    [<Fact>]
    let test257 () =
        complexEmailRegex.IsMatch
        |> RFC822.test257

    [<Fact>]
    let test258 () =
        complexEmailRegex.IsMatch
        |> RFC822.test258

    [<Fact>]
    let test259 () =
        complexEmailRegex.IsMatch
        |> RFC822.test259

    [<Fact>]
    let test260 () =
        complexEmailRegex.IsMatch
        |> RFC822.test260

    [<Fact>]
    let test261 () =
        complexEmailRegex.IsMatch
        |> RFC822.test261

    [<Fact>]
    let test262 () =
        complexEmailRegex.IsMatch
        |> RFC822.test262

    [<Fact>]
    let test263 () =
        complexEmailRegex.IsMatch
        |> RFC822.test263

    [<Fact>]
    let test264 () =
        complexEmailRegex.IsMatch
        |> RFC822.test264

    [<Fact>]
    let test265 () =
        complexEmailRegex.IsMatch
        |> RFC822.test265

    [<Fact>]
    let test266 () =
        complexEmailRegex.IsMatch
        |> RFC822.test266

    [<Fact>]
    let test267 () =
        complexEmailRegex.IsMatch
        |> RFC822.test267

    [<Fact>]
    let test268 () =
        complexEmailRegex.IsMatch
        |> RFC822.test268

    [<Fact>]
    let test269 () =
        complexEmailRegex.IsMatch
        |> RFC822.test269

    [<Fact>]
    let test270 () =
        complexEmailRegex.IsMatch
        |> RFC822.test270

    [<Fact>]
    let test271 () =
        complexEmailRegex.IsMatch
        |> RFC822.test271

    [<Fact>]
    let test272 () =
        complexEmailRegex.IsMatch
        |> RFC822.test272

    [<Fact>]
    let test273 () =
        complexEmailRegex.IsMatch
        |> RFC822.test273

    [<Fact>]
    let test274 () =
        complexEmailRegex.IsMatch
        |> RFC822.test274

    [<Fact>]
    let test275 () =
        complexEmailRegex.IsMatch
        |> RFC822.test275

    [<Fact>]
    let test276 () =
        complexEmailRegex.IsMatch
        |> RFC822.test276

    [<Fact>]
    let test277 () =
        complexEmailRegex.IsMatch
        |> RFC822.test277

    [<Fact>]
    let test278 () =
        complexEmailRegex.IsMatch
        |> RFC822.test278

    [<Fact>]
    let test279 () =
        complexEmailRegex.IsMatch
        |> RFC822.test279

    [<Fact>]
    let test280 () =
        complexEmailRegex.IsMatch
        |> RFC822.test280
