# Fork

Fork 是平时在做 C# 项目的时候，收藏整理的一个工具项目，包括各种常用的工具和方法，窗口控件等。

持续完善更新中……

已添加到 Nuget 的库，可直接在 VS 中搜索安装。

# | 模块 | DLL | Nuget | 支持 .NET 版本
---|---|---|---|---
1 | 核心库 | Azylee.Core | [1.0.0.4](https://www.nuget.org/packages/Azylee.Core/) | 4.0
2 | 增强库 | Azylee.Core.Plus | - | 4.0



---

## Azylee.Utils 工具组

> 目前 Azylee.utils 工具组包含以下部分：

1. Azylee.Core ： 基础方法
2. Azylee.Core.Plus ： 带其他引用的扩展方法
3. Azylee.Update ： 更新工具包
4. Azylee.YeahWeb ： Http 及网络相关工具包
5. Azylee.WinformMan ： Winform 窗体管理
6. Azylee.WinformSkin ： Winform 样式和控件

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
    ┣ ArrayTool.cs              // 数组格式化
    ┣ ListTool.cs               // 列表内容判断
    ┗ Ls.cs                     // 列表内容判断（ListTool）
    
  ┣ CurrencyUtils：货币处理
    ┗ RMB.cs：集合处理          // 人民币格式化
    
  ┣ DateTimeUtils：日期时间处理
    ┣ ChineseHourTool.cs        // 中文时辰转换
    ┣ DateTimeConvert.cs        // 日期时间转换
    ┣ DateTimeTool.cs           // 日期时间处理
    ┣ DateTool.cs               // 日期处理
    ┣ TimerTool.cs              // 时间处理
    ┣ TimeStampTool.cs          // 时间戳
    ┣ UnixTimeTool.cs           // Unix 时间换算
    ┗ WeekDayTool.cs            // 时间 - 周 换算
   
  ┣ EncryptUtils：加密解密
    ┣ AesTool.cs                // AES 加密解密
    ┣ DesTool.cs                // DES 加密解密
    ┣ MD5OTool.cs               // MD5 原生算法
    ┗ MD5Tool.cs                // MD5 算法（依赖系统）
    
  ┣ EnumUtils：枚举处理
    ┗ FlagsEnumTool.cs          // 标志枚举运算
   
  ┣ GuidUtils：Guid 处理
    ┗ GuidTool.cs               // Guid 格式处理
    
  ┣ SerializeUtils：序列化工具
    ┗ SerializeTool.cs          // 模型序列化
   
  ┣ StringUtils：字符串处理
    ┣ Str.cs                    // 字符串处理（StringTool）
    ┣ StringArrayTool.cs        // 字符串数组处理
    ┗ StringTool.cs             // 字符串处理
   
  ┗ UnitConvertUtils：单位转换
    ┗ ByteConvertUtils.cs       // 计算机单位换算

● DelegateUtils：定义委托方法
  ┗ ProcessDelegateUtils：进度
    ┣ ProgressDelegate.cs       // 进度委托
    ┗ ProgressEventArgs.cs      // 进度委托参数

● DllUtils：Dll 加载
  ┗ DllInvokeTool.cs            // Dll 加载
  
● DrawingUtils：绘图
  ┗ ColorUtils：颜色
    ┗ ColorStyle.cs             // 颜色
    
● FormUtils：窗体工具
  ┗ FormManTool.cs              // 窗口管理器

● IOUtils：输入输出
  ┣ BinaryUtils：二进制文件
    ┗ BinaryFileTool.cs         // 二进制文件读写
    
  ┣ DirUtils：路径
    ┣ DirFinder.cs              // 目录搜索
    ┗ DirTool.cs                // 目录操作
    
  ┣ ExifUtils：图片信息
    ┣ ExifHelper.cs             // 图片信息查看
    ┗ ExifTagNames.cs           // 信息项
    
  ┣ FileManUtils：文件管理
    ┣ FileWatcher.cs            // 文件监控
    ┗ FileWatcherEventArgs.cs   // 文件监控事件
    
  ┣ FileUtils：文件
    ┣ FileCodeTool.cs           // 文件特征码
    ┣ FileCompressTool.cs       // 文件压缩
    ┣ FileEncryptTool.cs        // 文件加密解密
    ┣ FileFinder.cs             // 文件搜索
    ┣ FilePackageModel.cs       // 文件打包模型
    ┣ FilePackageTool.cs        // 文件打包
    ┗ FileTool.cs               // 文件操作
    
  ┣ ImageUtils：图片
    ┣ AffineTool.cs             // 图片仿射
    ┣ BarCodeToHTML.cs          // 网页一维码
    ┣ CaptchaHelper.cs          // 验证码
    ┣ IconTool.cs               // 生成 Icon
    ┣ ImageHelper.cs            // 缩略图
    ┣ ImageSpliter.cs           // 图片分割
    ┣ RotateImageTool.cs        // 图像旋转
    ┣ ScreenCapture.cs          // 截屏
    ┗ ThunbnailTool.cs          // 缩略图
    
  ┣ PathUtils：路径
    ┗ AppDirTool.cs             // 程序目录操作
    
  ┣ TxtUtils：文本
    ┣ ConfigTool.cs             // 读取配置
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
    
● NetUtils：网络
  ┣ IPFormatter.cs              // IP 格式化检查
  ┣ MacFormatter.cs             // MAC 格式化检查
  ┣ NetConnectionInfo.cs        // 网络连接信息
  ┣ NetFlowService.cs           // 网络流量监控
  ┣ NetflowTool.cs              // 网络流量监控
  ┣ NetPacketTool.cs            // 网络数据包工具
  ┣ NetProcessInfo.cs           // 联网进程信息
  ┣ NetProcessInfo.cs           // 联网进程读取
  ┗ PingTool.cs                 // 网络连通
  
● ProcessUtils：进程
  ┣ ProcessInfoTool.cs          // 进程信息读取
  ┣ ProcessStarter.cs           // 进程启动器
  ┗ ProcessTool.cs              // 进程操作
  
● ProxyUtils：代理
  ┣ SimpleProxyUtils：简单代理
    ┣ RunMode.cs                // 运行模式
    ┗ SimpleProxyTool.cs        // 代理工具
    
● ReflectionUtils：反射
  ┣ AttributeUtils：反射属性
    ┣ AttributeTool.cs          // 加载属性
    ┣ ControlAttribute.cs       // （暂无）
    ┣ ControlAttributeEvent.cs  // （暂无）
    ┗ CustomAttributeHelper.cs  // 加载属性
    
  ┣ ReflectionCoreUtils：反射处理
    ┣ DomainTool.cs             // 应用程序域
    ┗ SimpleReflection.cs       // 反射执行

● TaskUtils：任务
  ┗ TaskSupport.cs              // 辅助启动线程任务
  
● ThreadUtils：线程
  ┣ SleepUtils：线程休眠
    ┣ Sleep.cs                  // 休眠（SleepTool）
    ┗ SleepTool.cs              // 休眠

● VersionUtils：版本
  ┗ VersionTool.cs              // 版本处理
  
● WindowsUtils：系统
  ┣ APIUtils：API
    ┣ ApplicationAPI.cs         // 应用程序：可唤起指定进程的窗口
    ┣ ExplorerAPI.cs            // Explorer：可打开指定文件夹窗口
    ┣ PermissionAPI.cs          // 执行权限
    ┣ SystemSleepAPI.cs         // 系统睡眠
    ┣ WindowsAPI.cs             // 窗口信息
    ┣ WindowsDrawerAPI.cs       // 桌面绘图
    ┗ WindowsHotKeyAPI.cs       // 热键
    
  ┣ BrowserUtils：浏览器
    ┗ BrowserSelector.cs        // 浏览器选择
    
  ┣ ClipboardUtils：剪贴板
    ┗ ClipboardTool.cs          // 剪贴板
    
  ┣ CMDUtils：API
    ┣ CMDNetstatTool.cs         // CMD网络指令包装
    ┗ CMDProcessTool.cs         // CMD进程启动工具
    
  ┣ HookUtils：Hook
    ┣ KeyboardHook.cs           // 键盘钩子
    ┣ KeyboardHookHelper.cs     // （暂无）
    ┗ UserActivityHook.cs       // 用户动作监控
    
  ┣ InfoUtils：信息
    ┣ ComputerInfoTool.cs       // 计算机信息
    ┣ ComputerStatusTool.cs     // 计算机性能计数器
    ┣ NetcardInfoTool.cs        // 网卡信息
    ┣ OSInfoTool.cs             // 操作系统
    ┣ OSName.cs                 // 操作系统清单
    ┣ PatchInfoTool.cs          // 计算机补丁
    ┣ SoftwareInfo.cs           // 软件信息
    ┗ SoftwareTool.cs           // 已装软件列表
    
  ┣ RegisterUtils：注册表
    ┗ RegisterTool.cs           // 操作注册表
    
  ┣ ShareUtils：共享
    ┗ ShareInfoTool.cs           // 计算机共享
  
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

### Azylee.WinformMan
——暂无

### Azylee.WinformSkin
——暂无

---

# 关于作者
- Email：[inc@live.cn](mailto:inc@live.cn)，[yuzhyn@163.com](mailto:yuzhyn@163.com)
- 在使用过程中，遇到问题可以给我发邮件，希望能帮助到你，更期待你的建议 ~~~


![image](https://raw.githubusercontent.com/yuzhengyang/Fork/master/Documents/QRCode/WeiXinQRCodeMini.jpg)