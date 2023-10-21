# Welcome
This sample tutorial shows how to build modern CLI terminals similar in a non english language.

The "pi-cli" framework handles the entire CLI infrastructure,  so your focus is on building modern CLI apps and services. For more details, see our [documentation](https://docs.perpetualintelligence.com/articles/pi-cli/intro.html).

The tutorial uses our [demo license](https://docs.perpetualintelligence.com/articles/pi-demo/intro.html).
The code in `Program.cs` specifies the license key location. You can download the license key file in that location or set your path.
```
    // Download the license file in this location or specify your location
    options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json";
```

## Command Registry
The `CommandRegistry.cs` source file contains the Unicode (Chinese) sample commands and arguments registration.

## Hosted Service
The `UnicodeHostedService.cs` implement the sample hosted service to enable terminal lifecycle tracking and UX customization.

## Runners
The `Runners` folder defines the sample Unicode CLI command runners.

## Unicode
The sample enables console unicode inputs and outputs in `Program.cs`.

```
Console.Title = "unicode cli sample";
Console.InputEncoding = System.Text.Encoding.Unicode;
Console.OutputEncoding = System.Text.Encoding.Unicode;
```

> **Note:** You need to install language packs and fonts in your OS and configure console Terminal or console application to accept, process, and display the Unicode characters.

The example below shows some English comments to tell you what is going on. The production Unicode terminals will typically only have the local user language syntax and texts.

Example Run:
```
$ 統一碼
Running root command (Chinese)
運行示例 `統一碼`.
將您的應用、服務或工具帶到命令行。
$ 統一碼 測試
Running grouped command (Chinese)
運行示例分組命令 '測試'.
以任何用戶語言展示 Unicode CLI 命令。
$ 統一碼 測試 打印 --第一的 第一個值 --第二 --第三 第三 --第四 25.36
Running sub-command (Chinese)
你好 CLI 終端
Print arguments and options (Chinese)
打印 Unicode 命令參數
第一的=第一個值
第二=True
第三=第三
第四=25.36
$
```
