# 项目名称：CSharpEnrich

## 简介

CSharpEnrich是一个C#工具库，它提供了一些基础功能封装，使得数据转换、类型比对等操作更加容易。这个类库旨在简化C#编程过程中的一些常见任务，提高开发效率。

## 功能

- 数据转换：可以直接在string类型的数据上调用str.ToInt()方法，尝试将其转换成int数据类型。
- 类型比对：提供了一系列类型比对的方法，方便进行类型判断和转换。

## 使用方法

1. 首先，将 `CSharpEnrich.dll` 添加到你的项目中。你可以通过NuGet包管理器或者直接下载源代码并添加到项目中。

2. 此库的扩展自命名空间为 `System` ，引入 System，可以直接使用

```csharp
using System;
```

3. 使用CSharpEnrich提供的功能。例如，将字符串转换为整数：

```csharp
string str = "123";
int num = str.ToInt();
Console.WriteLine(num); // int:123 or throw err
```

4. 使用类型比对功能：

```csharp
object o = null;
bool res = DataValidator.IsDefault(o);
Console.WriteLine(res); // True
```

## 注意事项

- 在使用CSharpEnrich之前，请确保已经正确安装并配置了.NET环境。
- 请根据实际需求选择合适的方法进行数据转换和类型比对，避免不必要的错误。
