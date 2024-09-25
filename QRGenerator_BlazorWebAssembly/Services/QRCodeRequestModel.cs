using System.Drawing;
using System.Reflection.Emit;
using QRCoder;

namespace QRGenerator_BlazorWebAssembly.Services;

public class QRCodeRequestModel
{
    public string QRValue { get; set; } = "https://github.com/htetpyie";
    public EnumQrType QRType { get; set; } = EnumQrType.Url;
    public SvgQRCode.SvgLogo? Logo { get; set; }
    public string DarkColorHex { get; set; } = "#A9A9A9";
    public string WhiteColorHex { get; set; } = "#ffffff";
}