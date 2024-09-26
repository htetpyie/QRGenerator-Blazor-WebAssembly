using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using QRCoder;
using QRGenerator_BlazorWebAssembly.Services;

namespace QRGenerator_BlazorWebAssembly.Pages;

public partial class Home
{
    private QRCodeRequestModel Request { get; set; } = new();
    private IBrowserFile? LoadedFile { get; set; }
    private string? QRImage { get; set; }
    private byte[]? QRByte { get; set; }
    private const int MaxAllowedFileCount = 1;

    protected override void OnInitialized()
    {
        Request ??= new();
        GenerateQR();
    }

    private void OnSelectChange(ChangeEventArgs e)
    {
        var value = e?.Value?.ToString() ?? EnumQrType.Text.ToString();
        Request.QRType = value!.ToEnum<EnumQrType>();
        GenerateQR();
    }

    private void OnInputChange(ChangeEventArgs e)
    {
        Request.QRValue = e?.Value?.ToString()!;
        GenerateQR();
    }

    private void OnWhiteColorHexChange(ChangeEventArgs e)
    {
        Request.WhiteColorHex = e?.Value?.ToString()!;
        GenerateQR();
    }

    private void OnDarkColorHexChange(ChangeEventArgs e)
    {
        Request.DarkColorHex = e?.Value?.ToString()!;
        GenerateQR();
    }

    private async Task OnLogoChange(InputFileChangeEventArgs e)
    {
        int maxSize = 1024 * 1024 * 5;
        LoadedFile = e.GetMultipleFiles(MaxAllowedFileCount).FirstOrDefault();
        if (LoadedFile?.Size > maxSize)
        {
            return;
        }

        var fileInByte = await GetBytesFromFile(LoadedFile);
        var logo = new SvgQRCode.SvgLogo(fileInByte);
        Request.Logo = logo;
        GenerateQR();
    }

    private void GenerateQR()
    {
        var response = _qrService.GenerateQR(Request);
        QRImage = string.Format("data:image/svg+xml;base64,{0}", response?.Base64String);
        QRByte = response?.ByteData;
    }

    private async Task<byte[]> GetBytesFromFile(IBrowserFile file, int maxSize = 1024 * 1024 * 5)
    {
        var fileStream = file.OpenReadStream();
        var ms = new MemoryStream();
        await fileStream.CopyToAsync(ms);
        return ms.ToArray();
    }

    private async Task DownloadImage()
    {
        if (QRByte is null) return;
        var fileStream = new MemoryStream(QRByte);
        var fileName = "QRCode.svg";
        using var streamRef = new DotNetStreamReference(stream: fileStream);
        await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
    }
}