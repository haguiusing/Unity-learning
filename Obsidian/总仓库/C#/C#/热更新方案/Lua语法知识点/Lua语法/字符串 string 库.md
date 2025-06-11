[Lua 的字符串库提供了哪些函数？-JavaScript中文网-JavaScript教程资源分享门户](https://www.javascriptcn.com/interview-lua/677f4caa6f8688f8e9faf08e.html)
[6.4 - 字符串操作 | Lua 5.4 中文参考手册](https://atom-l.github.io/lua5.4-manual-zh/6.4.html)

此库提供了字符串操作的通用函数，例如查找和提取子串，或是模式匹配。在Lua中对字符串使用索引时，第一个字符的位置是1（而不是像C代码中的0）。索引可以是负数，以表示从末尾开始倒数的下标。例如最后一个字符的位置是-1，以此类推。

字符串库所提供的函数都放在名为 string 的表中。其同时会设置字符串值的元表，其中 __index 字段指向了 string 表。因此你可以使用面向对象的风格来调用字符串函数。例如 string.byte(s,i) 可以写成 s:byte(i) 的形式。

字符串库中，字符是假定为单字节编码的。
- `string.len(s)`：返回字符串 `s` 的长度。
- `string.lower(s)`：将字符串 `s` 中的所有字符转换为小写。
- `string.upper(s)`：将字符串 `s` 中的所有字符转换为大写。
- `string.reverse(s)`：返回字符串 `s` 的逆序。
- `string.sub(s, i, j)`：返回字符串 `s` 中从位置 `i` 到位置 `j` 的子串。
- `string.find(s, pattern, init, plain)`：在字符串 `s` 中查找模式 `pattern` 的第一次出现，返回匹配的起始和结束位置。
- `string.gsub(s, pattern, repl, n)`：将字符串 `s` 中所有匹配 `pattern` 的部分替换为 `repl`，最多替换 `n` 次。
- `string.match(s, pattern, init)`：在字符串 `s` 中查找模式 `pattern` 的第一次匹配，返回匹配的子串。
- `string.rep(s, n)`：返回字符串 `s` 重复 `n` 次的结果。
- `string.char(...)`：将整数参数转换为对应的字符并返回字符串。
- `string.byte(s, i, j)`：返回字符串 `s` 中从位置 `i` 到位置 `j` 的字符的 ASCII 码。

## 字符串操作
### string.byte (s [, i [, j]])[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.byte)
返回字符串中索引 i 到索引 j 之间的（s[i], s[i+1], ..., s[j]） 的各个字符的数值。参数 i 的默认值为1，j 的默认值为 i 的值。此处遵循和[string.sub](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.sub)中一样的索引规则。

其由字符转换而来的数值在各平台之间不一定都相同。
### string.char (···)[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.char)
接收零个或多个整数参数。返回一个字符串，其长度为传入的参数数量，其中每个字符依次为各参数在内部字符编码中所对应的字符。

其中的编码数值在各平台之间不一定都相同。
### string.dump (function [, strip])[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.dump)
返回包含所给函数的二进制表示（即_二进制块 binary chunk_ ）的字符串，之后对该字符串调用[load](https://atom-l.github.io/lua5.4-manual-zh/6.1.html#load)会返回该函数的拷贝（但是其上值都是新创建的）。如果参数 strip 为真值，那么其二进制块中将不会把该函数所有的调试信息都包含进去，由此可以节省空间。

对于带有上值的函数，二进制块只会存储其上值的数量。被（再次）加载后，这些上值都会是新实例。（相关细节请参见[load](https://atom-l.github.io/lua5.4-manual-zh/6.1.html#load)函数。必要时你可以使用调试库来序列化或重新加载这些函数的上值。）
### string.find (s, pattern [, init [, plain]])[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.find)
在字符串 s 中查找 pattern 参数的第一个匹配（参见[6.4.1](https://atom-l.github.io/lua5.4-manual-zh/6.4.1.html)）。如果找到了，那么 find 函数会分别返回匹配位置的开始和结束索引；否则返回**fail**。第三个可选参数 init 表明从哪里开始搜索，其默认值为1并且可以是负数。第四个参数 plain 为**treu**时会关闭模式匹配机制，从而做直接“查找子串”的操作，参数 pattern 中内容都视为无特殊含义的字符。

如果匹配式 pattern 捕获到了，则表示匹配成功并且会在两个索引后一并返回捕捉到的值。
### string.format (formatstring, ···)[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.format)
第一个参数必须为字符串，后边跟不定数量的参数，返回所组成的格式化字符串。这里的字符串格式化规则与ISO标准C函数 sprintf 相同。但是不支持转义符 F、n、*、h、L、和 l ，并且多出一个额外的转义符 q 。如果有宽度和精度，则限制为两位数。

转义符对布尔、nil、number和字符串的转移结果都是一个定义在Lua源码中的有效常量值。布尔和 nil 的结果都是直接写在代码中的（true、false、nil）。浮点数结果为一个十六进制数，以保证完整精度。字符串的转换结果会被放在双引号之间，会在必要的时候使用合适的转义符，此结果可以在之后供Lua解释器成功读入。例如这样的调用：
```lua
string.format('%q', 'a string with "quotes" and \n new line')
```

会生成这样的字符串：
"a string with \"quotes\" and \
new line"

该转义符不支持修饰符（如标志、宽度、精度）。

转义符 A、a、E、e、f、G、以及 g 都需要一个数字作为参数。转义符 c、d、i、o、u、X、以及 x 需要的是整数。当Lua是由C89标准编译出时，转义符 A 和 a (十六进制浮点数) 都不支持修饰符。

转义符 s 需要一个字符串作为参数，如果传入的参数不是个字符串，那么其将遵循和[tostring](https://atom-l.github.io/lua5.4-manual-zh/6.1.html#tostring)相同的规则转换为一个字符串。如果该转义符有任何修饰符，则对应的字符串参数不应当包含任何嵌入的零。

转义符 p 会使用[lua_topointer](https://atom-l.github.io/lua5.4-manual-zh/6.1.html#lua_topointer)来格式化指针。其会给出一个可以唯一标识表、userdata 、Lua线程、字符串和函数的字符串。对于其他类型的值（number、nil、布尔值），转义符将返回表示空指针的字符串。
### string.gmatch (s, pattern [, init])[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.gmatch)
返回一个迭代器函数，每次调用该迭代器函数都会返回下一个在字符串 s 中对 pattern 的捕获（参见[6.4.1](https://atom-l.github.io/lua5.4-manual-zh/6.4.1.html)）。如果 pattern 没有指定的捕获，那么每次调用就匹配整个 pattern 内容。第三个参数 init 是可选的数字，其表明匹配的起始位置，默认为1且可以传负数。

举个例子，以下这个循环将迭代字符串中的每个单词，并分行打印出来：
```lua
s = "hello world from Lua"
for w in string.gmatch(s, "%a+") do
  print(w)
end
```

下边的例子会将给定字符串中的每个键值对收集起来：
```lua
t = {}
s = "from=world, to=Lua"
for k, v in string.gmatch(s, "(%w+)=(%w+)") do
  t[k] = v
end
```

对于此函数，pattern 开头中的锚点 '^' 将不会生效，因为其会阻止迭代。
### string.gsub (s, pattern, repl [, n])[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.gsub)
拷贝整个字符串 s （或者前 n 个，如果传了此参数的话），将其中每个遇到的 pattern 匹配和捕获（参见[6.4.1](https://atom-l.github.io/lua5.4-manual-zh/6.4.1.html)）根据 repl 来做替换，并将最终的字符串返回。参数 repl 可以是字符串、表、或者函数。同时 gsub 会将遇到的匹配次数作为第二个返回值返回。函数名 gsub 出自_全局替换 Global SUBstitution_ 。

如果参数 repl 是一个字符串，那么其值将被用来做替换。"%" 符为转义符：任何包含在 repl 中的 _%d_ 都被认为是第 _d_ 个捕获项，其中 _d_ 的值可以是1到9，_%0_ 表示整个捕获项，\_\%\%\_ 表示单个 "%" 符。

如果 repl 是个表，则每次匹配时都会使用捕获中的第一个捕获项作为键来对该表作查询。

如果 repl 是个函数，则每次匹配时都会将所有的捕获项先后作为参数传入来调用该函数。

如果从 repl 表或函数中得到的返回是一个字符串或 number ，那么其将会被作为替换用的字符串。否则如果返回的是**nil**或者**false**，那么将不会做替换（即原匹配维持原样）。

以下是部分示例：
```lua
x = string.gsub("hello world", "(%w+)", "%1 %1")
--> x="hello hello world world"

x = string.gsub("hello world", "%w+", "%0 %0", 1)
--> x="hello hello world"

x = string.gsub("hello world from Lua", "(%w+)%s*(%w+)", "%2 %1")
--> x="world hello Lua from"

x = string.gsub("home = $HOME, user = $USER", "%$(%w+)", os.getenv)
--> x="home = /home/roberto, user = roberto"

x = string.gsub("4+5 = $return 4+5$", "%$(.-)%$", function (s)
      return load(s)()
    end)
--> x="4+5 = 9"

local t = {name="lua", version="5.4"}
x = string.gsub("$name-$version.tar.gz", "%$(%w+)", t)
--> x="lua-5.4.tar.gz"
```
### string.len (s)[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.len)
接收一个字符串参数并返回其长度。空串 "" 的长度为0。嵌入的零值也会被计数，所以 "a\000bc\000" 的长度为5。
### string.lower (s)[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.lower)
接收一个字符串参数并拷贝它（不会改动原有的字符串），将其中每个大写的字符都替换为对应的小写形式，将最终的字符串返回。其他的字符都不会被更改。对于大写字母的定义取决于当前的区域设置。
### string.match (s, pattern [, init])[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.match)
在字符串 s 中查找 pattern 的第一个_匹配_（参见[6.4.1](https://atom-l.github.io/lua5.4-manual-zh/6.4.1.html)）。如果找到了，match 会将 pattern 的捕获返回；否则返回 **fail**。如果 pattern 不含有捕获内容，那么将返回整个 pattern 的匹配。第三个参数 init 是一个可选数字参数，其表明搜索的起始位置；默认值为1且可以为负值。
### string.pack (fmt, v1, v2, ···)[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.pack)
返回一个包含了 v1、v2等值的二进制字符串，该字符串是通过格式化字符串 fmt 序列化而来的（参见[6.4.2](https://atom-l.github.io/lua5.4-manual-zh/6.4.2.html)）。
### string.packsize (fmt)[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.packsize)
返回[string.pack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.pack)的结果的长度。该格式化字符串不可以包含变长的选项 's' 或 'z' （参见[6.4.2](https://atom-l.github.io/lua5.4-manual-zh/6.4.2.html)）。
### string.rep (s, n [, sep])[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.rep)
返回一个字符串，其由字符串 s 的 n 个拷贝组成，每个拷贝之前用 sep 间隔开。参数 sep 的默认值为空串（即没有间隔）。如果参数 n 不为正数则返回空串。
（要注意该函数很容易耗尽你的内存。）
### string.reverse (s)[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.reverse)
返回所给字符串 s 的翻转。
### string.sub (s, i [, j])[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.sub)
截取字符串 s 从第 i 个到第 j 个字符并返回；其中 i 和 j 可以是负数。如果 j 缺省，则会被当作 -1 处理（即字符串末尾）。例如，调用 string.sub(s,1,j) 会返回 s 中前 j 个字符，而 string.sub(s, -i) （i为整数）则返回 s 中后 j 个字符。

在转换完负数索引后，如果 i 小于1，则置为1，如果 j 大于字符串长度，则置为字符串长度。在此之后，如果 i 大于 j ，该函数会返回一个空串。
### string.unpack (fmt, s [, pos])[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.unpack)
返回以格式化字符串 fmt 打包（参见[string.pack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.pack)）而来的二进制字符串 s 中的值。可选参数 pos 标记了在 s 中读取的起始位置。读取完这些值后，该函数同时还返回在 s 中第一个不可读字节的位置。
### string.upper (s)[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.upper)
接收一个字符串参数并拷贝它（不会改动原有的字符串），将其中每个小写的字符都替换为对应的大写形式，将最终的字符串返回。其他的字符都不会被更改。对于小写字母的定义取决于当前的区域设置。

## 模式匹配
模式 pattern 在Lua中由常规字符串描述，其被解释为模式以用于模式匹配函数 [string.find](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.find)、[string.gmatch](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.gmatch)、[string.gsub](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.gsub)、以及[string.match](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.match)中。本节会讲述相关语法以及这些字符串的含义。

#### 字符类：[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.1.html#%E5%AD%97%E7%AC%A6%E7%B1%BB)
用以表示一类字符。描述各类字符时，可以使用以下字符的组合：
- **_X_：** (此处的 _x_ 不是_魔法字符 magic characters_ ^$()%.[]*+-? 中的任意一个)表示字符 _x_ 本身。
- **.：** 表示任意字符。
- **%a：** 表示任意字母。
- **%c：** 表示任意控制字符。
- **%d：** 表示任意单个数字（0-9）。
- **%g：** 表示出了空白符以外的任意可打印字符。
- **%l：** 表示任意小写字母。
- **%p：** 表示任意的标点符号。
- **%s：** 表示任意的空白字符。
- **%u：** 表示任意大写字母
- **%w：** 表示任意的字母或数字
- **%x：** 表示十六进制数字符号。
- **%_x_：** （此处的 _x_ 为任意非字母、非数字的字符）表示字符 _x_ 。这是转义_魔法字符 magic characters_ 的标准方式。所有非字母、非数字的字符 （包括所有标点，也包括非魔法字符） 都可以在匹配模式串中使用 '%' 前缀以表示自身。
- **[set]：** 表示包含在 _set_ 中的字符集。可以使用按照字符值升序排列的两个字符来表示一个范围，两个字符使用 '-' 连接。上边说的 _%x_ 形式表示的特殊字符也可以用在这里。其他在 _set_ 中的字符则表示它们本身。例如，[%w_] (或者 [_%w]) 表示一个字母或数字加上一个下划线。[0-7] 表示0到7之间的数字，[0-7%l%-] 则表示一个0到7之间的数字加上一个小写字母以及一个连字符。  
    方括号可以直接放在 _set_ 中的第一个位置，连字符可以直接放在开始或结束的位置，就可以表示它们自身（当然使用转义也可以）。  
    将范围表示和类表示混合使用的行为是未定义的，l类似 [%a-z] 或者 \[a-\%\%\] 的模式串是没有意义的。
- **\[^set]：** 表示 _set_ 的补集，关于 _set_ 可以参见上边的说明。

对于所有表示单个字母的字符类表示（例如 %a、%c 等），其对应的大写形式表示了它们的补集。例如，%S 表示任意非空字符。

对于字母、空格以及其他字符组的定义取决于当前的区域设置。例如 [a-z] 可能并不等效于 %l 。

#### 模式项：[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.1.html#%E6%A8%A1%E5%BC%8F%E9%A1%B9)
一个_模式项 pattern item_ 可以是：
- 单个字符类，将匹配该类中的任何单个字符。
- 单个字符类后跟一个 '*'，将匹配该类中的零个或多个字符。该重复项始终会匹配尽可能长的串。
- 单个字符类后跟一个 '+'，将匹配该类中的一个或多个字符。该重复项始终会匹配尽可能长的串。
- 单个字符类后跟一个 '-'，也将匹配该类中的零个或多个字符。但不同于 '*' 的是，其始终匹配尽可能短的串。
- 单个字符类后跟一个 '?'，将匹配零个或一个遇到该类中的字符。它尽可能地只匹配一个。
- _%n_ ，此处 n 为1到9之间的字符；该项匹配一个等于第 n 个匹配项的子串（见下文）。
- _%bxy_ ，此处的 x 和 y 分别是两个确实的字符，会匹配以 _x_ 开始、以 _y_ 为结尾的项，并且这里的 _x_ 和 _y_ 是_平衡_的。意思是从左往右读取字符串，如果遇到 _x_ 就计数+1，遇到 _y_ 就计数-1，末尾的 _y_ 就是计数到0的那个位置的 _y_ 。例如：%b() 模式项会匹配成对的括号。
- _%f[set]_ ，前向匹配的模式；将匹配位于 _set_ 中的某个字符之前的空串，并且其之前的字符不在 _set_ 之中。这里的 _set_ 集合的含义同之前的描述。所匹配到的空串的开始和结束处应当做 '\0' 处理。

#### 模式：[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.1.html#%E6%A8%A1%E5%BC%8F)
一个_模式 pattern_ 由一系列模式项组成。在模式开始处的 '^' 符会锚定在子串开始处匹配。在模式末尾处的 '\$' 符会锚定在子串末尾处匹配。其他位置处的 '^' 和 '$' 符没有什么特殊含义而只是表示它们本身。

#### 捕获：[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.1.html#%E6%8D%95%E8%8E%B7)
模式中可以包含由括号包围起来的子模式；该子模式被称为_捕获 captures_ 。每次成功匹配时，匹配到的子串中对应子模式的部分会被保存（即_捕获_到了）下来以供之后使用。多个捕获项之间是依据最左括号的顺序排列编号的。例如对于模式 "(a*(.)%w(%s*))" ，首先其最外层（最左边）括号中的部分 "a*(.)%w(%s*)" 被作为第一个捕获项，并且其编号为1；然后再匹配下一个括号中的 "." 作为2号捕获项；最后的括号中的 "%s*" 作为3号捕获项。

有个特例的捕获，() 会捕获当前字符串所在的位置（是个 number）（原文的描述不准确，应当是每个空括号紧跟的字符所在的位置，末尾的空括号就表示匹配到的子串后边的那个字符的位置）。例如，如果我们对字符串 "flaaap" 做捕获 "()aa()" ，那么其会产生两个捕获项：3和5（第一个 a 在3号位置，匹配到的 "aa" 下一个字符位置是5，虽然下一个还是 a ,但是无关紧要，此处举的例子很有误导性）。

#### 多重匹配：[​](https://atom-l.github.io/lua5.4-manual-zh/6.4.1.html#%E5%A4%9A%E9%87%8D%E5%8C%B9%E9%85%8D)
函数[string.gsub](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.gsub)和迭代器[string.gmatch](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.gmatch)会在子串中多次匹配所出的模式。对于这些函数，每个新有效匹配的末尾至少会在之前匹配的末尾位置后隔一个字节。换言之，模式匹配机制永远不会接受空字符串作为紧跟着另一个匹配的下一个匹配（原文中的“immediately after”可以指紧接着的下一个或者是末尾处跟着的，还是不准确。此处应当是指模式匹配机制中一个匹配项的下一个匹配不可能是在其末尾同位置的空字符串）。可以观察以下代码示例：
```lua
string.gsub("abc", "()a*()", print);
--> 1   2
--> 3   3
--> 4   4
```

第二个和第三个结果可以看出，虽然都是匹配的空串，但是其位置仍然不会和上一个匹配的末尾位置重合，只有这样迭代器才会有尽头，而不会是死循环。

## 打包与解包中的格式化字符串
在[string.pack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.pack)、[string.packsize](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.packsize)、以及[string.unpack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.unpack)中的第一个参数是个格式化字符串，其描述了要创建或读取的结构的布局。

格式化字符串由一系列的转换项组成。这些转换项如下所示：
- **<:** 设为小端编码
- **>:** 设为大端编码
- **=:** 设为原生大小端编码，即跟随本地环境设置。
- **![_n_]:** 将最大对齐设为 n (默认跟随本地环境设置)。
- **b:** 一个有符号字节（char）。
- **B:** 一个无符号字节（char）。
- **h:** 一个有符号 short（取决于本地环境大小）。
- **H:** 一个无符号 short（取决于本地环境大小）。
- **l:** 一个有符号的 long（取决于本地环境大小）。
- **L:** 一个无符号的 long（取决于本地环境大小）。
- **j:** 一个[lua_Integer](https://atom-l.github.io/lua5.4-manual-zh/4.6.html#lua_Integer)。
- **J:** 一个[lua_Unsigned](https://atom-l.github.io/lua5.4-manual-zh/4.6.html#lua_Unsigned)。
- **T:** 一个 size_t（取决于本地环境大小）。
- **i[_n_]:** 一个大小为 n 个字节的有符号 int（默认为本地环境大小）。
- **I[_n_]:** 一个大小为 n 个字节的无符号 int（默认为本地环境大小）。
- **f:** 一个 float（取决于本地环境大小）。
- **d:** 一个 double（取决于本地环境大小）。
- **n:** 一个[lua_Number](https://atom-l.github.io/lua5.4-manual-zh/4.6.html#lua_Number)。
- **c_n_:** 一个固定长度为 n 字节的字符串。
- **z:** 一个以零为终止符的字符串。
- **s[n]:** 一个由表示长度的 n 字节大小整数（默认是 size_t）打头的字符串。
- **x:** 填充一个字节
- **X_op_:** 一个根据转换项 op （其他的会被忽略）来对齐的空对象。
- **' ':** (空格)无意义，会被忽略。可以用来隔开各个选项以提升可读性。

（"[_n_]"的意思是指一个可选的整数。）除了填充、空格以及设置项（"xX <=>!" 这些选项）外，每个选项都需要对应一个在[string.pack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.pack)参数或是[string.unpack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.unpack)的结果。

对于 "!_n_"、"s_n_"、"i_n_"、以及 "I_n_" 选项，其中的 _n_ 可以是一个1到16之间的整数。所有的整数选项都会检查移除；[string.pack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.pack)会检查所给的值和大小是否合适；[string.unpack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.unpack)会检查读取的值是否符合Lua中的整数。对于无符号的选项，Lua解释器也会做类似的无符号数检查。

任何以前缀 "!1=" 开始的格式化字符串的意思是，最大对齐为1字节（即不对齐）并且大小端设置跟随本地环境。

本地的大小端设置假设整个系统要么是大端要么是小端。打包函数无法处理混合大小端模式的行为。

对齐机制如下：对于每个转换项，格式化时会做填充使得数据发生偏移，其偏移量为转换项大小和最大偏移量的最小乘数；其最小乘数必须是2的幂，转换项 "c" 和 "z" 不需要对齐；转换项 "s" 的对齐大小与其开头的整数的大小一致。

[string.pack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.pack)使用零值来做填充并且在[string.unpack](https://atom-l.github.io/lua5.4-manual-zh/6.4.html#string.unpack)中会被忽略。
