# Fork

Fork 是平时在做 C# 项目的时候，收藏整理的一个工具项目，包括各种常用的工具和方法，窗口控件等。

持续完善更新中……

------

## Azylee.Utils 工具组

> 目前 Azylee.utils 工具组包含以下部分：

1. Azylee.Core ： 基础方法
2. Azylee.Core.Plus ： 带其他引用的扩展方法
3. Azylee.Update ： 更新工具包
4. Azylee.YeahWeb ： Http 及网络相关工具包
5. Azylee.WinformSkin ： Winform 样式和控件

### Azylee.Core 模块：

> - 包含常用的基础工具方法
> - 无需其他引用

```
● AppUtils：程序辅助工具
  ┣ AppInfoTool.cs              // 程序信息
  ┣ AppLaunchTool.cs            // 程序启动器
  ┣ AppSettleTool.cs            // （暂无）
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
    
  ┣ SerializeUtils：序列化工具
    ┗ SerializeTool.cs          // 模型序列化
   
  ┣ StringUtils：字符串处理
    ┗ StringTool.cs             // 字符串处理
   
  ┗ UnitConvertUtils：单位转换
    ┗ ByteConvertUtils.cs       // 计算机单位换算

● DelegateUtils：定义委托方法
  ┗ ProcessDelegateUtils：进度
    ┣ ProgressDelegate.cs       // 进度委托
    ┗ ProgressEventArgs.cs      // 进度委托参数

● IOUtils：输入输出
  ┣ BinaryUtils：二进制文件
    ┗ BinaryFileTool.cs         // 二进制文件读写
    
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
    ┣ ConfigTool.cs             // （暂无）
    ┣ IniTool.cs                // 操作 ini 配置文件
    ┣ TxtTool.cs                // 操作文本文件
    ┗ XmlTool.cs                // （暂无）

● LogUtils：日志
  ┣ SimpleLogUtils
    ┣ Log.cs                    // 日志工具
    ┣ LogLevel.cs               // 日志分级
    ┣ LogModel.cs               // 日志模型
    ┗ LogType.cs                // 日志分类
  
  ┣ StatusLogUtils
    ┣ StatusLog.cs              // 状态日志工具
    ┗ StatusLogModel.cs         // 状态日志模型
    
● ProcessUtils：进程
  ┗ ProcessTool.cs              // 进程操作
  
● TaskUtils：任务
  ┗ TaskSupport.cs              // 辅助启动线程任务

● VersionUtils：版本
  ┗ VersionTool.cs              // 版本处理
  
● WindowsUtils：系统
  ┣ APIUtils：API
    ┣ ApplicationAPI.cs         // 应用程序：可唤起指定进程的窗口
    ┣ ExplorerAPI.cs            // Explorer：可打开指定文件夹窗口
    ┣ PermissionAPI.cs          // 执行权限
    ┣ SystemSleepAPI.cs         // 系统睡眠
    ┗ WindowsAPI.cs             // 窗口信息
    
  ┣ CMDUtils：API
    ┣ CMDNetstatTool.cs         // CMD网络指令包装
    ┗ CMDProcessTool.cs         // CMD进程启动工具
    
  ┣ InfoUtils：信息
    ┣ ComputerInfoTool.cs       // 计算机信息
    ┣ ComputerStatusTool.cs     // 计算机性能计数器
    ┗ NetcardInfoTool.cs        // 网卡信息
    
  ┣ RegisterUtils：注册表
    ┗ RegisterTool.cs           // 操作注册表
  
  ┗ ShortcutUtils：快捷方式
    ┗ ShortcutTool.cs           // 操作快捷方式
```

### Azylee.Core.Plus
依赖：Azylee.Core

> - 为其他引用提供扩展
> - 可能引用其他dll文件

```
● DataUtils：数据处理
  ┗ JsonUtils
    ┣ ConvertJson.cs            // 程序启动器
    ┗ JsonTool.cs               // 开机启动项
```

### Azylee.Update
依赖：Azylee.Core、Azylee.Core.Plus

> - 为exe程序提供升级方案

```
● UpdateUtils：数据处理
  ┣ AppUpdateInfo.cs            // 更新配置模型
  ┗ AppUpdateTool.cs            // 更新工具
```

### Azylee.YeahWeb
依赖：Azylee.Core、Azylee.Core.Plus

> - 提供网络工具

```
● BaiDuWebAPI：面向百度开发
  ┗ IPLocationAPI：IP定位
    ┣ IPLocationModel.cs        // 位置模型
    ┣ IPLocationTool.cs         // 获取IP定位
    ┗ IPLocationWebModel.cs     // API返回位置模型
  
● FTPUtils：FTP工具
  ┗ FTPTool.cs                  // FTP工具
  
● HttpUtils：Http工具
  ┣ HttpTool.cs                 // 常规Http工具
  ┗ HttpToolPlus.cs             // 增强Http工具（如携带Cookie）
```


### Azylee.WinformSkin
——暂无

---

# 关于作者
- Email：[inc@live.cn](mailto:inc@live.cn)，[yuzhyn@163.com](mailto:yuzhyn@163.com)
- 在使用过程中，遇到问题可以给我发邮件，希望能帮助到你，更期待你的建议 ~~~



![image](https://raw.githubusercontent.com/yuzhengyang/Fork/master/Documents/QRCode/WeiXinQRCodeMini.jpg)