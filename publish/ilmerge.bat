SET version="v5.0.0"

"..\src\packages\ilmerge.2.14.1208\tools\ILMerge.exe" "..\src\BatchGuy.App\bin\Release\BatchGuy.App.exe" "..\src\packages\System.Linq.Dynamic.1.0.4\lib\net40\System.Linq.Dynamic.dll" "..\src\packages\log4net.2.0.4\lib\net45-full\log4net.dll" "..\src\packages\Newtonsoft.Json.7.0.1\\lib\net45\Newtonsoft.Json.dll" /out:"BatchGuy-%version%-win64.exe"  /target:winexe /targetplatform:v4 /ndebug