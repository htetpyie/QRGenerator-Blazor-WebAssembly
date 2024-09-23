using System.Text;

namespace QRGenerator_BlazorWebAssembly.Services;

public class QRCodeResponseModel
{
    public string? SvgString { get; set; }
    public byte[]? ByteData => SvgString != null ? Encoding.UTF8.GetBytes(SvgString) : null;
    public string? Base64String => ByteData is not null ? Convert.ToBase64String(ByteData) : null;
}