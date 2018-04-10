# Fork

Fork 工具包是平时在做 C# winform 客户端的时候，收藏整理的一个项目，包括各种常用的工具和方法，和窗口控件等。

持续完善更新中……

## Azylee.Utils 工具组

> 目前 Azylee.utils 工具组包含以下部分：

1. Azylee.Core ： 基础方法
2. Azylee.Core.Plus ： 带其他引用的扩展方法
3. Azylee.Update ： 更新工具包
4. Azylee.YeahWeb ： Http 及网络相关工具包
5. Azylee.WinformMan ： Winform 窗体管理
6. Azylee.WinformSkin ： Winform 样式和控件
7. Azylee.BlackBox ： 程序运行状态监控

### Azylee.Core 模块：

> - 包含常用的基础工具方法
> - 无需其他引用

```
● AppUtils：程序辅助工具
  ┣ AppLaunchTool.cs            // 程序启动器
  ┣ AppSettleTool.cs            // ——
  ┣ AppUnique.cs                // 程序单开验证
  ┣ PermissionTool.cs           // 权限信息
  ┗ StartupTool.cs              // 开机启动项
 
● DataUtils：数据处理
  ┣ CollectionUtils：集合处理
    ┗ ListTool.cs               // 列表内容判断
    
  ┣ DateTimeUtils：日期时间处理
    ┣ ChineseHourTool.cs        // 中文时辰转换
    ┣ DateTimeConvert.cs        // 日期时间转换
    ┣ DateTimeTool.cs           // 日期时间处理
    ┣ DateTool.cs               // 日期处理
    ┣ TimerTool.cs              // 时间处理
    ┣ UnixTimeTool.cs           // Unix 时间换算
    ┗ WeekDayTool.cs            // 时间 - 周 换算
   
  ┣ EncryptUtils：加密解密
    ┣ AesTool.cs                // AES 加密解密
    ┣ DesTool.cs                // DES 加密解密
    ┗ MD5Tool.cs                // 计算 MD5
   
  ┣ GuidUtils：Guid 处理
    ┗ GuidTool.cs               // Guid 格式处理
   
  ┣ StringUtils：字符串处理
    ┗ StringTool.cs             // 字符串处理
   
  ┗ UnitConvertUtils：单位转换
    ┗ ByteConvertUtils.cs       // 计算机单位换算

● DelegateUtils：定义委托方法
  ┗ ProcessDelegateUtils：进度
    ┣ ProgressDelegate.cs       // 进度委托
    ┗ ProgressEventArgs.cs      // 进度委托参数

● IOUtils：输入输出
  ┣ DirUtils：路径
    ┗ DirTool.cs                // 目录操作
    
  ┣ FileUtils：文件
    ┣ FileCodeTool.cs           // 文件特征码
    ┣ FileCompressTool.cs       // 文件压缩
    ┣ FileEncryptTool.cs        // 文件加密解密
    ┣ FilePackageModel.cs       // 文件打包模型
    ┣ FilePackageTool.cs        // 文件打包
    ┗ FileTool.cs               // 文件操作
    
  ┣ PathUtils：路径
    ┗ AppDirTool.cs             // 程序目录操作
    
  ┣ TxtUtils：文本
    ┣ ConfigTool.cs             // ——
    ┣ IniTool.cs                // 操作 ini 配置文件
    ┣ TxtTool.cs                // 操作文本文件
    ┗ XmlTool.cs                // ——

● LogUtils：日志
  ┣ Log.cs                      // 日志工具
  ┣ LogLevel.cs                 // 日志分级
  ┣ LogModel.cs                 // 日志信息模型
  ┗ LogType.cs                  // 日志分类
  
● ProcessUtils：进程
  ┗ ProcessTool.cs              // 进程操作
  
● TaskUtils：任务
  ┗ TaskSupport.cs              // 辅助启动线程任务

● VersionUtils：版本
  ┗ VersionTool.cs              // 版本处理
  
● WindowsUtils：系统
  ┣ APIUtils：API
    ┣ PermissionAPI.cs          // 执行权限
    ┣ SystemSleepAPI.cs         // 系统睡眠
    ┗ WindowsAPI.cs             // 窗口信息
    
  ┣ InfoUtils：信息
    ┣ ComputerInfoTool.cs       // 计算机信息
    ┗ NetcardInfoTool.cs        // 网卡信息
    
  ┣ RegisterUtils：注册表
    ┗ RegisterTool.cs           // 操作注册表
  
  ┗ ShortcutUtils：快捷方式
    ┗ ShortcutTool.cs           // 操作快捷方式
```

#### Azylee.Core.Plus

#### Azylee.Update

#### Azylee.YeahWeb

#### Azylee.WinformMan

#### Azylee.WinformSkin

#### Azylee.BlackBox
