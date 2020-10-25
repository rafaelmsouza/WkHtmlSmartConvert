dotnet pack -c Release .\WkHtmlSmartConvert\
dotnet remove .\WebTeste package WkHtmlSmartConvert
dotnet add .\WebTeste\ package WkHtmlSmartConvert
dotnet clean .\WebTeste\ 
dotnet build .\WebTeste\ --no-restore
ls .\WebTeste\