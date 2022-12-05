## 0.1.0 -> 0.2.0

Updated to .NET 7.  
This update basically brings the language to life, finally fixed the bug where you had to change the object type to read a different type of data.  
The compiled executable is much faster thanks to the [Native AOT](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/) introduced in .NET 7.  
Unfortunately it only works on win-x64 and Linux-x64 (it also works for win-arm64 and linux-arm64, but I don't own any ARM machines to compile it to those targets) for now, the other platforms still use [ReadyToRun](https://learn.microsoft.com/en-us/dotnet/core/deploying/ready-to-run).
