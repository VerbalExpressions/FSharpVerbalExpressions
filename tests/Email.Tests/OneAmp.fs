namespace Email.Tests

open Xunit

[<Trait("Kind", "Complex")>]
module OneAmp =

    let oneAmp (email : string) =

        if email.StartsWith("@") || email.EndsWith("@") then
            false
        else

            let s = email.Split '@'
            
            if s.Length = 1 then
                false
            else
                if s.Length = 2 then
                    true
                else
                    let x = 
                        Array.take (s.Length - 1) s
                        |> Array.filter (fun x -> x.Contains("\"") )
                    x.Length = (s.Length - 1)

    [<Fact>]
    let test1 () =
        oneAmp
        |> RFC822.test1 

    [<Fact>]
    let test2 () =
        oneAmp
        |> RFC822.test2

    [<Fact>]
    let test3 () =
        oneAmp
        |> RFC822.test3

    [<Fact>]
    let test4 () =
        oneAmp
        |> RFC822.test4

    [<Fact>]
    let test5 () =
        oneAmp
        |> RFC822.test5

    [<Fact>]
    let test6 () =
        oneAmp
        |> RFC822.test6

    [<Fact>]
    let test7 () =
        oneAmp
        |> RFC822.test7

    [<Fact>]
    let test8 () =
        oneAmp
        |> RFC822.test8

    [<Fact>]
    let test9 () =
        oneAmp
        |> RFC822.test9

    [<Fact>]
    let test10 () =
        oneAmp
        |> RFC822.test10

    [<Fact>]
    let test11 () =
        oneAmp
        |> RFC822.test11

    [<Fact>]
    let test12 () =
        oneAmp
        |> RFC822.test12

    [<Fact>]
    let test13 () =
        oneAmp
        |> RFC822.test13

    [<Fact>]
    let test14 () =
        oneAmp
        |> RFC822.test14

    [<Fact>]
    let test15 () =
        oneAmp
        |> RFC822.test15

    [<Fact>]
    let test16 () =
        oneAmp
        |> RFC822.test16

    [<Fact>]
    let test17 () =
        oneAmp
        |> RFC822.test17

    [<Fact>]
    let test18 () =
        oneAmp
        |> RFC822.test18

    [<Fact>]
    let test19 () =
        oneAmp
        |> RFC822.test19

    [<Fact>]
    let test20 () =
        oneAmp
        |> RFC822.test20

    [<Fact>]
    let test21 () =
        oneAmp
        |> RFC822.test21

    [<Fact>]
    let test22 () =
        oneAmp
        |> RFC822.test22

    [<Fact>]
    let test23 () =
        oneAmp
        |> RFC822.test23

    [<Fact>]
    let test24 () =
        oneAmp
        |> RFC822.test24

    [<Fact>]
    let test25 () =
        oneAmp
        |> RFC822.test25

    [<Fact>]
    let test26 () =
        oneAmp
        |> RFC822.test26

    [<Fact>]
    let test27 () =
        oneAmp
        |> RFC822.test27

    [<Fact>]
    let test28 () =
        oneAmp
        |> RFC822.test28

    [<Fact>]
    let test29 () =
        oneAmp
        |> RFC822.test29

    [<Fact>]
    let test30 () =
        oneAmp
        |> RFC822.test30

    [<Fact>]
    let test31 () =
        oneAmp
        |> RFC822.test31

    [<Fact>]
    let test32 () =
        oneAmp
        |> RFC822.test32

    [<Fact>]
    let test33 () =
        oneAmp
        |> RFC822.test33

    [<Fact>]
    let test34 () =
        oneAmp
        |> RFC822.test34

    [<Fact>]
    let test35 () =
        oneAmp
        |> RFC822.test35

    [<Fact>]
    let test36 () =
        oneAmp
        |> RFC822.test36

    [<Fact>]
    let test37 () =
        oneAmp
        |> RFC822.test37

    [<Fact>]
    let test38 () =
        oneAmp
        |> RFC822.test38

    [<Fact>]
    let test39 () =
        oneAmp
        |> RFC822.test39

    [<Fact>]
    let test40 () =
        oneAmp
        |> RFC822.test40

    [<Fact>]
    let test41 () =
        oneAmp
        |> RFC822.test41

    [<Fact>]
    let test42 () =
        oneAmp
        |> RFC822.test42

    [<Fact>]
    let test43 () =
        oneAmp
        |> RFC822.test43

    [<Fact>]
    let test44 () =
        oneAmp
        |> RFC822.test44

    [<Fact>]
    let test45 () =
        oneAmp
        |> RFC822.test45

    [<Fact>]
    let test46 () =
        oneAmp
        |> RFC822.test46

    [<Fact>]
    let test47 () =
        oneAmp
        |> RFC822.test47

    [<Fact>]
    let test48 () =
        oneAmp
        |> RFC822.test48

    [<Fact>]
    let test49 () =
        oneAmp
        |> RFC822.test49

    [<Fact>]
    let test50 () =
        oneAmp
        |> RFC822.test50

    [<Fact>]
    let test51 () =
        oneAmp
        |> RFC822.test51

    [<Fact>]
    let test52 () =
        oneAmp
        |> RFC822.test52

    [<Fact>]
    let test53 () =
        oneAmp
        |> RFC822.test53

    [<Fact>]
    let test54 () =
        oneAmp
        |> RFC822.test54

    [<Fact>]
    let test55 () =
        oneAmp
        |> RFC822.test55

    [<Fact>]
    let test56 () =
        oneAmp
        |> RFC822.test56

    [<Fact>]
    let test57 () =
        oneAmp
        |> RFC822.test57

    [<Fact>]
    let test58 () =
        oneAmp
        |> RFC822.test58

    [<Fact>]
    let test59 () =
        oneAmp
        |> RFC822.test59

    [<Fact>]
    let test60 () =
        oneAmp
        |> RFC822.test60

    [<Fact>]
    let test61 () =
        oneAmp
        |> RFC822.test61

    [<Fact>]
    let test62 () =
        oneAmp
        |> RFC822.test62

    [<Fact>]
    let test63 () =
        oneAmp
        |> RFC822.test63

    [<Fact>]
    let test64 () =
        oneAmp
        |> RFC822.test64

    [<Fact>]
    let test65 () =
        oneAmp
        |> RFC822.test65

    [<Fact>]
    let test66 () =
        oneAmp
        |> RFC822.test66

    [<Fact>]
    let test67 () =
        oneAmp
        |> RFC822.test67

    [<Fact>]
    let test68 () =
        oneAmp
        |> RFC822.test68

    [<Fact>]
    let test69 () =
        oneAmp
        |> RFC822.test69

    [<Fact>]
    let test70 () =
        oneAmp
        |> RFC822.test70

    [<Fact>]
    let test71 () =
        oneAmp
        |> RFC822.test71

    [<Fact>]
    let test72 () =
        oneAmp
        |> RFC822.test72

    [<Fact>]
    let test73 () =
        oneAmp
        |> RFC822.test73

    [<Fact>]
    let test74 () =
        oneAmp
        |> RFC822.test74

    [<Fact>]
    let test75 () =
        oneAmp
        |> RFC822.test75

    [<Fact>]
    let test76 () =
        oneAmp
        |> RFC822.test76

    [<Fact>]
    let test77 () =
        oneAmp
        |> RFC822.test77

    [<Fact>]
    let test78 () =
        oneAmp
        |> RFC822.test78

    [<Fact>]
    let test79 () =
        oneAmp
        |> RFC822.test79

    [<Fact>]
    let test80 () =
        oneAmp
        |> RFC822.test80

    [<Fact>]
    let test81 () =
        oneAmp
        |> RFC822.test81

    [<Fact>]
    let test82 () =
        oneAmp
        |> RFC822.test82

    [<Fact>]
    let test83 () =
        oneAmp
        |> RFC822.test83

    [<Fact>]
    let test84 () =
        oneAmp
        |> RFC822.test84

    [<Fact>]
    let test85 () =
        oneAmp
        |> RFC822.test85

    [<Fact>]
    let test86 () =
        oneAmp
        |> RFC822.test86

    [<Fact>]
    let test87 () =
        oneAmp
        |> RFC822.test87

    [<Fact>]
    let test88 () =
        oneAmp
        |> RFC822.test88

    [<Fact>]
    let test89 () =
        oneAmp
        |> RFC822.test89

    [<Fact>]
    let test90 () =
        oneAmp
        |> RFC822.test90

    [<Fact>]
    let test91 () =
        oneAmp
        |> RFC822.test91

    [<Fact>]
    let test92 () =
        oneAmp
        |> RFC822.test92

    [<Fact>]
    let test93 () =
        oneAmp
        |> RFC822.test93

    [<Fact>]
    let test94 () =
        oneAmp
        |> RFC822.test94

    [<Fact>]
    let test95 () =
        oneAmp
        |> RFC822.test95

    [<Fact>]
    let test96 () =
        oneAmp
        |> RFC822.test96

    [<Fact>]
    let test97 () =
        oneAmp
        |> RFC822.test97

    [<Fact>]
    let test98 () =
        oneAmp
        |> RFC822.test98

    [<Fact>]
    let test99 () =
        oneAmp
        |> RFC822.test99

    [<Fact>]
    let test100 () =
        oneAmp
        |> RFC822.test100

    [<Fact>]
    let test101 () =
        oneAmp
        |> RFC822.test101

    [<Fact>]
    let test102 () =
        oneAmp
        |> RFC822.test102

    [<Fact>]
    let test103 () =
        oneAmp
        |> RFC822.test103

    [<Fact>]
    let test104 () =
        oneAmp
        |> RFC822.test104

    [<Fact>]
    let test105 () =
        oneAmp
        |> RFC822.test105

    [<Fact>]
    let test106 () =
        oneAmp
        |> RFC822.test106

    [<Fact>]
    let test107 () =
        oneAmp
        |> RFC822.test107

    [<Fact>]
    let test108 () =
        oneAmp
        |> RFC822.test108

    [<Fact>]
    let test109 () =
        oneAmp
        |> RFC822.test109

    [<Fact>]
    let test110 () =
        oneAmp
        |> RFC822.test110

    [<Fact>]
    let test111 () =
        oneAmp
        |> RFC822.test111

    [<Fact>]
    let test112 () =
        oneAmp
        |> RFC822.test112

    [<Fact>]
    let test113 () =
        oneAmp
        |> RFC822.test113

    [<Fact>]
    let test114 () =
        oneAmp
        |> RFC822.test114

    [<Fact>]
    let test115 () =
        oneAmp
        |> RFC822.test115

    [<Fact>]
    let test116 () =
        oneAmp
        |> RFC822.test116

    [<Fact>]
    let test117 () =
        oneAmp
        |> RFC822.test117

    [<Fact>]
    let test118 () =
        oneAmp
        |> RFC822.test118

    [<Fact>]
    let test119 () =
        oneAmp
        |> RFC822.test119

    [<Fact>]
    let test120 () =
        oneAmp
        |> RFC822.test120

    [<Fact>]
    let test121 () =
        oneAmp
        |> RFC822.test121

    [<Fact>]
    let test122 () =
        oneAmp
        |> RFC822.test122

    [<Fact>]
    let test123 () =
        oneAmp
        |> RFC822.test123

    [<Fact>]
    let test124 () =
        oneAmp
        |> RFC822.test124

    [<Fact>]
    let test125 () =
        oneAmp
        |> RFC822.test125

    [<Fact>]
    let test126 () =
        oneAmp
        |> RFC822.test126

    [<Fact>]
    let test127 () =
        oneAmp
        |> RFC822.test127

    [<Fact>]
    let test128 () =
        oneAmp
        |> RFC822.test128

    [<Fact>]
    let test129 () =
        oneAmp
        |> RFC822.test129

    [<Fact>]
    let test130 () =
        oneAmp
        |> RFC822.test130

    [<Fact>]
    let test131 () =
        oneAmp
        |> RFC822.test131

    [<Fact>]
    let test132 () =
        oneAmp
        |> RFC822.test132

    [<Fact>]
    let test133 () =
        oneAmp
        |> RFC822.test133

    [<Fact>]
    let test134 () =
        oneAmp
        |> RFC822.test134

    [<Fact>]
    let test135 () =
        oneAmp
        |> RFC822.test135

    [<Fact>]
    let test136 () =
        oneAmp
        |> RFC822.test136

    [<Fact>]
    let test137 () =
        oneAmp
        |> RFC822.test137

    [<Fact>]
    let test138 () =
        oneAmp
        |> RFC822.test138

    [<Fact>]
    let test139 () =
        oneAmp
        |> RFC822.test139

    [<Fact>]
    let test140 () =
        oneAmp
        |> RFC822.test140

    [<Fact>]
    let test141 () =
        oneAmp
        |> RFC822.test141

    [<Fact>]
    let test142 () =
        oneAmp
        |> RFC822.test142

    [<Fact>]
    let test143 () =
        oneAmp
        |> RFC822.test143

    [<Fact>]
    let test144 () =
        oneAmp
        |> RFC822.test144

    [<Fact>]
    let test145 () =
        oneAmp
                |> RFC822.test145

    [<Fact>]
    let test146 () =
        oneAmp
        |> RFC822.test146

    [<Fact>]
    let test147 () =
        oneAmp
        |> RFC822.test147

    [<Fact>]
    let test148 () =
        oneAmp
        |> RFC822.test148

    [<Fact>]
    let test149 () =
        oneAmp
        |> RFC822.test149

    [<Fact>]
    let test150 () =
        oneAmp
        |> RFC822.test150

    [<Fact>]
    let test151 () =
        oneAmp
        |> RFC822.test151

    [<Fact>]
    let test152 () =
        oneAmp
        |> RFC822.test152

    [<Fact>]
    let test153 () =
        oneAmp
        |> RFC822.test153

    [<Fact>]
    let test154 () =
        oneAmp
        |> RFC822.test154

    [<Fact>]
    let test155 () =
        oneAmp
        |> RFC822.test155

    [<Fact>]
    let test156 () =
        oneAmp
        |> RFC822.test156

    [<Fact>]
    let test157 () =
        oneAmp
        |> RFC822.test157

    [<Fact>]
    let test158 () =
        oneAmp
        |> RFC822.test158

    [<Fact>]
    let test159 () =
        oneAmp
        |> RFC822.test159

    [<Fact>]
    let test160 () =
        oneAmp
        |> RFC822.test160

    [<Fact>]
    let test161 () =
        oneAmp
        |> RFC822.test161

    [<Fact>]
    let test162 () =
        oneAmp
        |> RFC822.test162

    [<Fact>]
    let test163 () =
        oneAmp
        |> RFC822.test163

    [<Fact>]
    let test164 () =
        oneAmp
        |> RFC822.test164

    [<Fact>]
    let test165 () =
        oneAmp
        |> RFC822.test165

    [<Fact>]
    let test166 () =
        oneAmp
        |> RFC822.test166

    [<Fact>]
    let test167 () =
        oneAmp
        |> RFC822.test167

    [<Fact>]
    let test168 () =
        oneAmp
        |> RFC822.test168

    [<Fact>]
    let test169 () =
        oneAmp
        |> RFC822.test169

    [<Fact>]
    let test170 () =
        oneAmp
        |> RFC822.test170

    [<Fact>]
    let test171 () =
        oneAmp
        |> RFC822.test171

    [<Fact>]
    let test172 () =
        oneAmp
        |> RFC822.test172

    [<Fact>]
    let test173 () =
        oneAmp
        |> RFC822.test173

    [<Fact>]
    let test174 () =
        oneAmp
        |> RFC822.test174

    [<Fact>]
    let test175 () =
        oneAmp
        |> RFC822.test175

    [<Fact>]
    let test176 () =
        oneAmp
        |> RFC822.test176

    [<Fact>]
    let test177 () =
        oneAmp
        |> RFC822.test177

    [<Fact>]
    let test178 () =
        oneAmp
        |> RFC822.test178

    [<Fact>]
    let test179 () =
        oneAmp
        |> RFC822.test179

    [<Fact>]
    let test180 () =
        oneAmp
        |> RFC822.test180

    [<Fact>]
    let test181 () =
        oneAmp
        |> RFC822.test181

    [<Fact>]
    let test182 () =
        oneAmp
        |> RFC822.test182

    [<Fact>]
    let test183 () =
        oneAmp
        |> RFC822.test183

    [<Fact>]
    let test184 () =
        oneAmp
        |> RFC822.test184

    [<Fact>]
    let test185 () =
        oneAmp
        |> RFC822.test185

    [<Fact>]
    let test186 () =
        oneAmp
        |> RFC822.test186

    [<Fact>]
    let test187 () =
        oneAmp
        |> RFC822.test187

    [<Fact>]
    let test188 () =
        oneAmp
        |> RFC822.test188

    [<Fact>]
    let test189 () =
        oneAmp
        |> RFC822.test189

    [<Fact>]
    let test190 () =
        oneAmp
        |> RFC822.test190

    [<Fact>]
    let test191 () =
        oneAmp
        |> RFC822.test191

    [<Fact>]
    let test192 () =
        oneAmp
        |> RFC822.test192

    [<Fact>]
    let test193 () =
        oneAmp
        |> RFC822.test193

    [<Fact>]
    let test194 () =
        oneAmp
        |> RFC822.test194

    [<Fact>]
    let test195 () =
        oneAmp
        |> RFC822.test195

    [<Fact>]
    let test196 () =
        oneAmp
        |> RFC822.test196

    [<Fact>]
    let test197 () =
        oneAmp
        |> RFC822.test197

    [<Fact>]
    let test198 () =
        oneAmp
        |> RFC822.test198

    [<Fact>]
    let test199 () =
        oneAmp
        |> RFC822.test199

    [<Fact>]
    let test200 () =
        oneAmp
        |> RFC822.test200

    [<Fact>]
    let test201 () =
        oneAmp
        |> RFC822.test201

    [<Fact>]
    let test202 () =
        oneAmp
        |> RFC822.test202

    [<Fact>]
    let test203 () =
        oneAmp
        |> RFC822.test203

    [<Fact>]
    let test204 () =
        oneAmp
        |> RFC822.test204

    [<Fact>]
    let test205 () =
        oneAmp
        |> RFC822.test205

    [<Fact>]
    let test206 () =
        oneAmp
        |> RFC822.test206

    [<Fact>]
    let test207 () =
        oneAmp
        |> RFC822.test207

    [<Fact>]
    let test208 () =
        oneAmp
        |> RFC822.test208

    [<Fact>]
    let test209 () =
        oneAmp
        |> RFC822.test209

    [<Fact>]
    let test210 () =
        oneAmp
        |> RFC822.test210

    [<Fact>]
    let test211 () =
        oneAmp
        |> RFC822.test211

    [<Fact>]
    let test212 () =
        oneAmp
        |> RFC822.test212

    [<Fact>]
    let test213 () =
        oneAmp
        |> RFC822.test213

    [<Fact>]
    let test214 () =
        oneAmp
        |> RFC822.test214

    [<Fact>]
    let test215 () =
        oneAmp
        |> RFC822.test215

    [<Fact>]
    let test216 () =
        oneAmp
        |> RFC822.test216

    [<Fact>]
    let test217 () =
        oneAmp
        |> RFC822.test217

    [<Fact>]
    let test218 () =
        oneAmp
        |> RFC822.test218

    [<Fact>]
    let test219 () =
        oneAmp
        |> RFC822.test219

    [<Fact>]
    let test220 () =
        oneAmp
        |> RFC822.test220

    [<Fact>]
    let test221 () =
        oneAmp
        |> RFC822.test221

    [<Fact>]
    let test222 () =
        oneAmp
        |> RFC822.test222

    [<Fact>]
    let test223 () =
        oneAmp
        |> RFC822.test223

    [<Fact>]
    let test224 () =
        oneAmp
        |> RFC822.test224

    [<Fact>]
    let test225 () =
        oneAmp
        |> RFC822.test225

    [<Fact>]
    let test226 () =
        oneAmp
        |> RFC822.test226

    [<Fact>]
    let test227 () =
        oneAmp
        |> RFC822.test227

    [<Fact>]
    let test228 () =
        oneAmp
        |> RFC822.test228

    [<Fact>]
    let test229 () =
        oneAmp
        |> RFC822.test229

    [<Fact>]
    let test230 () =
        oneAmp
        |> RFC822.test230

    [<Fact>]
    let test231 () =
        oneAmp
        |> RFC822.test231

    [<Fact>]
    let test232 () =
        oneAmp
        |> RFC822.test232

    [<Fact>]
    let test233 () =
        oneAmp
        |> RFC822.test233

    [<Fact>]
    let test234 () =
        oneAmp
        |> RFC822.test234

    [<Fact>]
    let test235 () =
        oneAmp
        |> RFC822.test235

    [<Fact>]
    let test236 () =
        oneAmp
        |> RFC822.test236

    [<Fact>]
    let test237 () =
        oneAmp
        |> RFC822.test237

    [<Fact>]
    let test238 () =
        oneAmp
        |> RFC822.test238

    [<Fact>]
    let test239 () =
        oneAmp
        |> RFC822.test239

    [<Fact>]
    let test240 () =
        oneAmp
        |> RFC822.test240

    [<Fact>]
    let test241 () =
        oneAmp
        |> RFC822.test241

    [<Fact>]
    let test242 () =
        oneAmp
        |> RFC822.test242

    [<Fact>]
    let test243 () =
        oneAmp
        |> RFC822.test243

    [<Fact>]
    let test244 () =
        oneAmp
        |> RFC822.test244

    [<Fact>]
    let test245 () =
        oneAmp
        |> RFC822.test245

    [<Fact>]
    let test246 () =
        oneAmp
        |> RFC822.test246

    [<Fact>]
    let test247 () =
        oneAmp
        |> RFC822.test247

    [<Fact>]
    let test248 () =
        oneAmp
        |> RFC822.test248

    [<Fact>]
    let test249 () =
        oneAmp
        |> RFC822.test249

    [<Fact>]
    let test250 () =
        oneAmp
        |> RFC822.test250

    [<Fact>]
    let test251 () =
        oneAmp
        |> RFC822.test251

    [<Fact>]
    let test252 () =
        oneAmp
        |> RFC822.test252

    [<Fact>]
    let test253 () =
        oneAmp
        |> RFC822.test253

    [<Fact>]
    let test254 () =
        oneAmp
        |> RFC822.test254

    [<Fact>]
    let test255 () =
        oneAmp
        |> RFC822.test255

    [<Fact>]
    let test256 () =
        oneAmp
        |> RFC822.test256

    [<Fact>]
    let test257 () =
        oneAmp
        |> RFC822.test257

    [<Fact>]
    let test258 () =
        oneAmp
        |> RFC822.test258

    [<Fact>]
    let test259 () =
        oneAmp
        |> RFC822.test259

    [<Fact>]
    let test260 () =
        oneAmp
        |> RFC822.test260

    [<Fact>]
    let test261 () =
        oneAmp
        |> RFC822.test261

    [<Fact>]
    let test262 () =
        oneAmp
        |> RFC822.test262

    [<Fact>]
    let test263 () =
        oneAmp
        |> RFC822.test263

    [<Fact>]
    let test264 () =
        oneAmp
        |> RFC822.test264

    [<Fact>]
    let test265 () =
        oneAmp
        |> RFC822.test265

    [<Fact>]
    let test266 () =
        oneAmp
        |> RFC822.test266

    [<Fact>]
    let test267 () =
        oneAmp
        |> RFC822.test267

    [<Fact>]
    let test268 () =
        oneAmp
        |> RFC822.test268

    [<Fact>]
    let test269 () =
        oneAmp
        |> RFC822.test269

    [<Fact>]
    let test270 () =
        oneAmp
        |> RFC822.test270

    [<Fact>]
    let test271 () =
        oneAmp
        |> RFC822.test271

    [<Fact>]
    let test272 () =
        oneAmp
        |> RFC822.test272

    [<Fact>]
    let test273 () =
        oneAmp
        |> RFC822.test273

    [<Fact>]
    let test274 () =
        oneAmp
        |> RFC822.test274

    [<Fact>]
    let test275 () =
        oneAmp
        |> RFC822.test275

    [<Fact>]
    let test276 () =
        oneAmp
        |> RFC822.test276

    [<Fact>]
    let test277 () =
        oneAmp
        |> RFC822.test277

    [<Fact>]
    let test278 () =
        oneAmp
        |> RFC822.test278

    [<Fact>]
    let test279 () =
        oneAmp
        |> RFC822.test279

    [<Fact>]
    let test280 () =
        oneAmp
        |> RFC822.test280

                    
        

