![[Lesson39.cs]]

### 回顾自定义协议生成工具中的配置文件
- **命名空间：** `System.Net`
- **自定义协议配置工具相关知识点中**：使用的是 XML 文件进行配置。
- 只需要基于 XML 的规则，按照一定规则配置协议信息，之后获取 XML 数据用于生成代码文件。
- 在 Protobuf 中原理是一样的，只不过 Protobuf 中有自己的配置规则，也自定义了对应的配置文件后缀格式。

### 配置后缀
- **后缀统一使用：** `.proto`
- 可以通过多个后缀为 `.proto` 的配置文件进行配置。

### 配置规则
![[test.proto]]

![[test2.proto]]

#### 规则1: 第一行版本号
```
syntax = "proto3";
```
如果不写，默认使用 `proto2`。

#### 规则2: 注释方式
```
// 注释方式1
/* 注释方式2 */
```

#### 规则3: 命名空间
```
package 命名空间名;
```

#### 规则4: 消息类
```
message 类名 {
    // 字段声明
}
```

#### 规则5: 成员类型和唯一编号
- 浮点数：`float`, `double`
- 整数：`int32`, `int64`, `uint32`, `uint64`, `fixed32`, `fixed64`, `sfixed32`, `sfixed64`
- 其它类型：`bool`, `string`, `bytes`
- 配置成员时需要默认给它们一个编号，从1开始，用于标识中的字段消息二进制格式。

#### 规则6: 特殊标识
- `required`: 必须赋值的字段
- `optional`: 可以不赋值的字段
- `repeated`: 数组

#### 规则7: 枚举
```
enum 枚举名 {
    常量1 = 0; // 第一个常量必须映射到0
    常量2 = 1;
}
```

#### 规则8: 默认值
- `string`: 空字符串
- `bytes`: 空字节
- `bool`: `false`
- 数值: `0`
- 枚举: `0`
- message: 取决于语言，C# 为空

#### 规则9: 允许嵌套

#### 规则10: 保留字段
- 为了避免更新时重新使用已经删除了的编号，利用 `reserved` 关键字来保留字段，这些内容就不能再被使用了。

#### 规则11: 导入定义
```
import "配置文件路径";
```
如果在某一个配置中使用了另一个配置的类型，则需要导入另一个配置文件名。
### 示例代码
```
syntax = "proto3"; // 决定了 proto 文档的版本号

// 规则1：版本号

// 规则2：注释方式
// 注释方式一
/* 注释方式二 */

// 规则11：导入定义
// 两个配置在同一路径可以这样写，在不同路径要包含文件夹路径
import "test2.proto";

// 规则3：命名空间
package GamePlayerTest; // 这决定了命名空间

// 规则4：消息类
message TestMsg {
    // 规则5：成员类型 和 唯一编号

    // 浮点数
    // = 1 不代表默认值，而是代表唯一编号，方便我们进行序列化和反序列化的处理
    // 规则6：特殊标识
    // required: 必须赋值的字段
    required float testF = 1; // C# - float
    // optional: 可以不赋值的字段
    optional double testD = 2; // C# - double

    // 变长编码
    // 所谓变长，就是会根据数字的大小来使用对应的字节数来存储，1 2 4
    // Protobuf 帮助我们优化的部分，可以尽量少的使用字节数来存储内容
    int32 testInt32 = 3; // C# - int 它不太适用于来表示负数，请使用 sint32
    // 1 2 4 8
    int64 testInt64 = 4; // C# - long 它不太适用于来表示负数，请使用 sint64

    // 更实用与表示负数类型的整数
    sint32 testSInt32 = 5; // C# - int 适用于来表示负数的整数
    sint64 testSInt64 = 6; // C# - long 适用于来表示负数的整数

    // 无符号 变长编码
    // 1 2 4
    uint32 testUInt = 7; // C# - uint 变长的编码
    uint64 testULong = 8; // C# - ulong 变长的编码

    // 固定字节数的类型
    fixed32 testFixed32 = 9; // C# - uint 它通常用来表示大于2的28次方的数，比 uint32 更有效，始终是4个字节
    fixed64 testFixed64 = 10; // C# - ulong 它通常用来表示大于2的56次方的数，比 uint64 更有效，始终是8个字节

    sfixed32 testSFixed32 = 11; // C# - int 始终4个字节
    sfixed64 testSFixed64 = 12; // C# - long 始终8个字节

    // 其它类型
    bool testBool = 13; // C# - bool
    string testStr = 14; // C# - string
    bytes testBytes = 15; // C# - BytesString 字节字符串

    // 数组 List
    repeated int32 listInt = 16; // C# - 类似 List<int> 的使用
    // 字典 Dictionary
    map<int32, string> testMap = 17; // C# - 类似 Dictionary<int, string> 的使用

    // 规则7：枚举
    // 枚举成员变量的声明需要唯一编码
    TestEnum testEnum = 18;

    // 规则8:默认值
    // 声明自定义类对象 需要唯一编码
    // 默认值是 null
    TestMsg2 testMsg2 = 19;

    // 规则9：允许嵌套
    // 嵌套一个类在另一个类当中，相当于是内部类
    message TestMsg3 {
        int32 testInt32 = 1;
    }

    TestMsg3 testMsg3 = 20;

    // 规则9：允许嵌套
    enum TestEnum2 {
        NORMAL = 0; // 第一个常量必须映射到0
        BOSS = 1;
    }

    TestEnum2 testEnum2 = 21;

    // 规则10:保留字段
    // int32 testInt3233333 = 22;

    bool testBool2123123 = 23;

    // 告诉编译器 22 被占用，不准用户使用
    // 之所以有这个功能，是为了在版本不匹配时，反序列化时，不会出现结构不统一，解析错误的问题
    reserved 22;
    reserved testInt3233333;

    // 规则11：导入定义
    GameSystemTest.HeartMsg testHeart = 24;
}

// 规则7：枚举的声明
enum TestEnum {
    NORMAL = 0; // 第一个常量必须映射到0
    BOSS = 5;
}

// 规则8:默认值
message TestMsg2 {
    int32 testInt32 = 1;
}

syntax = "proto3"; // 决定了 proto 文档的版本号
package GameSystemTest; // 这决定了命名空间

message HeartMsg {
    int64 time = 1;
}
```

### 总结
- 我们需要掌握 Protobuf 的配置规则，之后才能使用工具将其转为 C# 脚本文件。