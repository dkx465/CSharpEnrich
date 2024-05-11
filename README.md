# CSharpEnrich

### 概述

这个类库是一个C#工具库，它提供了一些基础功能封装，使得数据转换、类型比对等操作更加容易。例如，你可以直接在string类型的数据上调用`str.ToInt()`方法，尝试将其转换成int数据类型。这个类库旨在简化C#编程过程中的一些常见任务，提高开发效率。

**示例：**

```c#
string str = "123";
str.ToInt(); // 123
str = "abc";
str.ToInt(); // throw err
```

### 基础类型扩展方法

##### `String`

- ToInt
- ToLong
- ToDecimal
- ToDateTime
- ToBool