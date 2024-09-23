namespace QRGenerator_BlazorWebAssembly.Services;

public class QRCodeRequestModel
{
    public string Text { get; set; }
    public EnumQrType QRType { get; set; }
}