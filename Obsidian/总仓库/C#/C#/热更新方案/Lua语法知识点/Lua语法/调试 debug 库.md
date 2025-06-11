该库提供了关于Lua程序的调试接口函数。你应当在使用该库时额外小心。这些函数破坏了Lua代码的基本假设（例如，某个函数内的局部变量不可以在外部访问；userdata 的元表不可以在Lua代码中改变；Lua程序不会crash等）并且它们会破坏其他的安全代码。此外，该库中的一些函数可能很慢。

该库中的所有函数都提供在 debug 表中。所有对Lua线程做操作的函数中的第一个参数都是需要操作的Lua线程。其默认为当前线程。

### debug.debug ()[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.debug)
- **功能**：进入交互式调试模式，允许用户逐行执行代码并检查变量。
- **使用场景**：当需要手动调试代码时，可以使用此函数进入调试模式。

进入可交互模式，运行用户输入的每一个字符串。使用简单的命令和其他调试工具，用户可以查看全局或本地变量、改变它们的值、计算表达式等等。一行只包含单词 cont 的输入会结束这个函数，所以调用者代码会在此处之后继续执行。

注意 debug.debug 的命令在词法上没有嵌入到任何函数中，所以你无法通过本地变量直接访问。

### debug.gethook ([thread])[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.gethook)
- **功能**：获取当前的钩子函数设置。
- **使用场景**：检查当前是否设置了钩子函数及其设置。

返回当前设置在给出Lua线程中的 hook ，有三个值：当前 hook 的函数、当前 hook 的掩码、当前 hook 的数量，同[debug.sethook](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.sethook)函数。

如果没有活跃的 hook 则返回**fail**。

### debug.getinfo ([thread,] f [, what])[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.getinfo)
- **功能**：返回一个包含函数信息的表，如函数名、定义位置、当前行号等。
- **使用场景**：用于获取函数的详细信息，帮助调试和日志记录。

返回带有某个函数的相关信息的表。你可以直接给定一个函数，或者你可以给定一个数字作为参数 f ，意思是运行在给定Lua线程的调用栈的第 f 层的函数：0层为当前函数（getinfo 函数自身）；1层为调用 getinfo 的函数（尾调用除外，其不在调用栈计数中）；以此类推。如果 f 是一个大于活跃数量的数字，则 geinfo 返回**fail**。

这里返回的表中所能包含的字段同[lua_getinfo](https://atom-l.github.io/lua5.4-manual-zh/4.6.html#lua_getinfo)，字符串参数 what 描述了那些要填充的字段。参数 what 默认获取所有可用的信息，除了有效行的表。如果有选项 'f' 则会将该函数自身添加到一个名为 func 的字段上。如果有选项 'L' 则会将有效行的表添加到名为 activelines 的字段上。

例如，表达式 debug.getinfo(1,"n").name 会返回当前函数的名称，如果可以找到合理的名称的话。表达式 debug.getinfo(print) 则会返回带有[print](https://atom-l.github.io/lua5.4-manual-zh/6.1.html#print)函数所有相关信息的表。

### debug.getlocal ([thread,] f, local)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.getlocal)
- **功能**：获取指定函数的局部变量的值。
- **使用场景**：在调试过程中，检查特定局部变量的值。

返回在某个函数中 local 索引处的局部变量的名称和值，该函数位于调用栈上的第 f 层。该函数不但可以访问本地变量，也可以访问闯入的参数和临时变量。

第一个参数或本地变量的索引是1，以此类推，往后的顺序都依据代码中的声明先后而来，此处只计数函数的当前作用域中的活跃变量。编译时的常量可能并没有加在声明列表中，其会被编译器优化掉。负数索引引用了可变参数：-1表示第一个可变参数。当给出索引处没有变量时该函数会返回**fail**，并在超出调用层数时抛出一个错误。（你可以调用[debug.getinfo](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.getinfo)来检查给定的层数是否有效。）

由 '(' （开圆括号）打头的变量名表示变量的名称未知（例如像循环控制变量之类的内部变量，以及代码块中没有调试信息的变量）。

参数 f 也可以是个函数。在这种情况下，getlocal 只返回该函数中各个参数的名称。

### debug.getmetatable (value)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.getmetatable)
- **功能**：获取指定对象的元表。
- **使用场景**：用于检查或操作对象的元表。

返回给定 value 的元表，没有元表则返回**nil**。

### debug.getregistry ()[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.getregistry)
- **功能**：返回 Lua 注册表，这是一个全局的 Lua 表，用于存储 Lua 内部状态。
- **使用场景**：用于访问或修改 Lua 的内部状态。

返回注册表（参见[4.3](https://atom-l.github.io/lua5.4-manual-zh/4.3.html)）。

### debug.getupvalue (f, up)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.getupvalue)
- **功能**：获取指定函数的上值（upvalue）的值。
- **使用场景**：用于检查闭包中的上值。

返回在函数 f 中索引为 up 的 upvalue 的名称和值。不存在相应 upvalue 则返回**fail**。

（对于Lua函数，upvalue 是在该函数中使用的外部局部变量，随之包含在该闭包中。）

对于C函数，该函数使用空字符串 "" 作为所有 upvalue 的名称。

变量名 '?'（问号）表示该变量的名称未知（代码块中不带调试信息的变量）。

### debug.getuservalue (u, n)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.getuservalue)
返回给出的 userdata 参数 u 对应的第 n 个 user value ，以及一个布尔值，如果没有相应的 user value 时，这个布尔值为**false**。

### debug.sethook ([thread,] hook, mask [, count])[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.sethook)
- **功能**：设置一个钩子函数，当特定事件（如函数调用、返回、行执行）发生时调用。
- **使用场景**：用于监控程序的执行流程。

设置调试 hook 。字符串参数 mask 和数字参数 count 表明了触发 hook 的时机。mask 可以由以下字符组合而成，其各含义为：

- **'c'：** 每次发生函数调用时触发 hook 。
- **'r'：** 每次发生函数返回时触发 hook 。
- **'c'：** 每次执行到下一行代码时触发 hook 。

此外，当 count 不为零时，该 hook 会在每执行 count 条指令后触发。

不带参数调用该函数时，会关闭 hook 。

每当 hook 被触发，其第一个传入的参数为描述了触发事件的字符串："call"、"tail call"、"return"、"line"、和 "count"。对于行事件，还会将新行的行数作为 hook 的第二个参数传入。在 hook 内部，你可以对第 2 层调用 getinfo 来获取关于当前函数更多的信息。（第0层是 getinfo 函数本身，第一层是这个 hook 函数。）

### debug.setlocal ([thread,] level, local, value)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.setlocal)
- **功能**：设置指定函数的局部变量的值。
- **使用场景**：在调试过程中，修改局部变量的值以测试不同情况。

将处于调用栈的第 level 层的函数中索引为 local 的局部变量赋值为 value 。如果没有相应的局部变量，该函数会返回**fail**，并且如果当 level 超出了调用层数，则会另外抛出一个错误。（你可以调用 getinfo 以确认层数是否有效。）否则，其会返回局部变量的名称。

更多关于变量索引和名称的信息请参考[debug.getlocal](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.getlocal)。

### debug.setmetatable (value, table)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.setmetatable)
- **功能**：设置指定对象的元表。
- **使用场景**：用于修改对象的元表，改变其行为。

将给定的 value 的元表设置为给定的 table（可以是个**nil**）。并返回 value 本身。

### debug.setupvalue (f, up, value)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.setupvalue)
该函数会将函数 f 中索引为 up 的 upvalue 设置为给定值 value 。当不存在相应的 upvalue 时会返回**fail**。否则会返回上值的名称。

更多关于上值的信息请参考[debug.getupvalue](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.getupvalue)。

### debug.setuservalue (udata, value, n)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.setuservalue)
- **功能**：设置指定函数的上值（upvalue）的值。
- **使用场景**：用于修改闭包中的上值。

将给定的 udata 中的第 n 个 user value 设为 value 值。参数 udata 必须是一个 full userdata 。

返回 usdata，或者当不存在相应的 userdata 和 user value 时返回**fail**。

### debug.traceback ([thread,] [message [, level]])[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.traceback)
- **功能**：返回当前的调用栈信息，通常用于生成错误信息。
- **使用场景**：在捕获错误时，生成详细的调用栈信息。

如果 message 未缺省并且既不是个字符串或**nil**，该函数不会做进一步处理并直接返回 message 。否则会返回一个带上了这个 message 的调用栈回溯信息。可选字符串参数 message 回被加到回溯信息的开头。可选数字参数 level 制定了从调用栈的哪一层开始回溯（默认为1，是调用 traceback 的函数）。

### debug.upvalueid (f, n)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.upvalueid)
返回给定函数中的第 n 个上值的唯一索引（是个 light userdata）。

这个唯一索引使得程序可以分辨不同的闭包是否共享了某个上值。对于Lua闭包所共享的某个上值（即访问同名的外部局部变量）将返回相同的索引。

### debug.upvaluejoin (f1, n1, f2, n2)[​](https://atom-l.github.io/lua5.4-manual-zh/6.10.html#debug.upvaluejoin)
使得Lua闭包 f1 中的第 n1 个上值引用Lua闭包 f2 中的第 n2 个上值。