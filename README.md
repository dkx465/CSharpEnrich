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

## API 列表

- String
  - ToInt
  
    - > 使用 int.TryParse 实现
  - ToLong
  
    - > 使用 long.TryParse 实现
  - ToDecimal
  
    - > 使用 decimal.TryParse 实现
  - ToDateTime
  
    - > 使用 DateTime.TryParse 实现
  - ToBool
  
    - > 将字符串转换为 Bool 值，当值为 null、empty、"" 时，值为 False 反之为 True
  - ToInstance<T>
  
    - > 将字符串序列化为 T 类型的实体，使用 JsonConvert.DeserializeObject<T>实现
  - ToBytes
  
    - > 转换成 byte[] 数组，使用Encoding.UTF8.GetBytes() 实现
  - ToBase64
  
    - > 转换成 base64 编码，使用Convert.ToBase64String() 实现
  - ToMD5
  
    - > 将字符串进行MD5加密
      >
      > 配置 StringExtension.SignDefaultSaltType 属性决定加盐的方式
      >
      > 配置 StringExtension.SignDefaultSalt 属性决定盐的默认值
- DateTime
  - ToTimeStamp
  
    - > 将日期转换为时间戳，1970-01-01 00:00:00 至传入 datetime 的秒数
- Object
  - ToJson
  
    - > 将实体序列化为字符串，使用 JsonConvert.SerializeObject实现
  - ToJsonAndSign
  
    - > 将实体转换成Json并进行MD5签名
  
      ```C#
      object o = new {a = 1};
      Console.WriteLine(o.ToJsonAndSign()); // {"a":1,"signature":"869c907b30795c8ceda1a1ff23d52773"}
      ```
  
- Decimal

  - ToChineseAmount

    - > 将 decimal 格式的金额转换成中文大写金额，要求 [0 - 999999999999.9999] 之间，超出金额要求的范围时抛出异常


## 注意事项

- 在使用`CSharpEnrich`之前，请确保已经正确安装并配置了.NET环境。

  - `CSharpEnrich` 依赖 `Newtonsoft.json`

- 请根据实际需求选择合适的方法进行数据转换和类型比对，避免不必要的错误。

  
