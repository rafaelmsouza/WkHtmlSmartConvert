# <img width="26px" height="26px" styles="" src="https://raw.githubusercontent.com/rafaelmsouza/WkHtmlSmartConvert/master/assets/icon.svg"> WkHtmlSmartConvert

[![Build status](https://dev.azure.com/rafaelmsouza/WkHtmlSmartConvert/_apis/build/status/CI)](https://dev.azure.com/rafaelmsouza/WkHtmlSmartConvert/_build/latest?definitionId=2)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=wkhtmlsmartconvert&metric=coverage)](https://sonarcloud.io/dashboard?id=wkhtmlsmartconvert)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=wkhtmlsmartconvert&metric=security_rating)](https://sonarcloud.io/dashboard?id=wkhtmlsmartconvert)

Best wrapper of wkhtmltopdf. This project implements convertetion of HTML to PDF, working in windows e linux only on x64 arch.

## NuGet Packages

| Package | Version |
| --- | --- | --- |
| [WkHtmlSmartConvert](https://www.nuget.org/packages/Roslynator.Analyzers) | [![NuGet](https://img.shields.io/nuget/v/WkHtmlSmartConvert)](https://www.nuget.org/packages/WkHtmlSmartConvert/) |
| [WkHtmlSmartConvert.Embedded](https://www.nuget.org/packages/Roslynator.CodeAnalysis.Analyzers) | [![NuGet](https://img.shields.io/nuget/v/Roslynator.CodeAnalysis.Analyzers.svg)](https://www.nuget.org/packages/Roslynator.CodeAnalysis.Analyzers) |


## Getting Started #

1. Install the standard Nuget package into your application.

    ```
    dotnet add package WkHtmlSmartConvert
    ```

2. In the `ConfigureServices` method of `Startup.cs`, register the WkHtmlSmartConvert.
  
    ```csharp
    services
        .AddWkHtmlSmartConvert()
        .AddPdf();
    ``` 
    or, you can configure global options to every convertion, see [PdfOptions](https://github.com/rafaelmsouza/WkHtmlSmartConvert/blob/master/src/WkHtmlSmartConvert/PdfOptions.cs).

    ```csharp
    services
        .AddWkHtmlSmartConvert()
        .AddPdf(options =>
            {
                options.PageOrientation = PageOrientation.options.Landscape,
                options.IsGrayScale = true,
                options.Copies = 2,
                options.PageSize = PageSize.A0
            });
    ```

 
## Convert HTML to PDF

You **must** inject **IPdfConvert** and call :

```csharp
public class ExamplePdfConvert
{
    private readonly IPdfConvert _pdfConvert
    
    public ExamplePdfConvert(IPdfConvert pdfConvert){
        _pdfConvert = pdfConvert;
    }

    public async Task<byte[]> GeneratePdfAsync() { 
        var buffer = await _pdfConvert.ConvertAsync("<html>Hello World!</html>");
        return buffer;
    }
}
```