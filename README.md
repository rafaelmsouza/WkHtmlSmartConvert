# WkHtmlSmartConvert

[![Build status](https://dev.azure.com/rafaelmsouza/WkHtmlSmartConvert/_apis/build/status/CI)](https://dev.azure.com/rafaelmsouza/WkHtmlSmartConvert/_build/latest?definitionId=2)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=wkhtmlsmartconvert_master&metric=coverage)](https://sonarcloud.io/dashboard?id=wkhtmlsmartconvert_master)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=wkhtmlsmartconvert_master&metric=security_rating)](https://sonarcloud.io/dashboard?id=wkhtmlsmartconvert_master)

This project implements the conversion of HTML to PDF using [wkhtmltopdf](https://github.com/wkhtmltopdf/wkhtmltopdf). It works only at windows and linux, on x64 arch.

## NuGet Packages

| Package | Version | Downloads |
| --- | --- | --- |
| [WkHtmlSmartConvert](https://www.nuget.org/packages/WkHtmlSmartConvert/) | [![NuGet](https://img.shields.io/nuget/v/WkHtmlSmartConvert)](https://www.nuget.org/packages/WkHtmlSmartConvert/) | [![NuGet](https://img.shields.io/nuget/dt/WkHtmlSmartConvert)](https://www.nuget.org/packages/WkHtmlSmartConvert/) |
| [WkHtmlSmartConvert.Embedded](https://www.nuget.org/packages/WkHtmlSmartConvert.Embedded) | [![NuGet](https://img.shields.io/nuget/v/WkHtmlSmartConvert.Embedded)](https://www.nuget.org/packages/WkHtmlSmartConvert.Embedded) | [![NuGet](https://img.shields.io/nuget/dt/WkHtmlSmartConvert.Embedded)](https://www.nuget.org/packages/WkHtmlSmartConvert.Embedded) |

Packages with suport to .Net Core **2.1**, **3.1** and .Net **5.0** 

## Getting Started

1. Install the standard nuget package into your application.

    ```bash
    dotnet add package WkHtmlSmartConvert
    ```

2. In the `ConfigureServices` method of `Startup.cs`, register the WkHtmlSmartConvert.
  
    ```csharp
    services
        .AddWkHtmlSmartConvert()
        .AddPdf();
    ``` 
    or, you can configure global options to every conversion, see [PdfOptions](https://github.com/rafaelmsouza/WkHtmlSmartConvert/blob/master/src/WkHtmlSmartConvert/PdfOptions.cs).

    ```csharp
    services
        .AddWkHtmlSmartConvert()
        .AddPdf(options =>
            {
                options.PageOrientation = PageOrientation.Landscape,
                options.IsGrayScale = true,
                options.Copies = 2,
                options.PageSize = PageSize.A0
            });
    ```

### Embedded files
The standard configuration looks for [wkhtmltopdf](https://github.com/wkhtmltopdf/wkhtmltopdf) installed on host and the environment variable **PATH** correctly configure, but instead of this, you can use the [wkhtmltopdf](https://github.com/wkhtmltopdf/wkhtmltopdf) embedded on the application.

1. Install the additional nuget package into your application.

    ```bash
    dotnet add package WkHtmlSmartConvert.Embedded
    ```

2. Configure **AddEmbedded** just after **AddWkHtmlSmartConvert**.

    ```csharp
    services
        .AddWkHtmlSmartConvert()
        .AddEmbedded()
        .AddPdf();
    ```

 
## Convert HTML to PDF

You **must** inject **IPdfConvert** and call method **ConvertAsync**

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

