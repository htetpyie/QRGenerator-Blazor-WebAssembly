using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

namespace QRGenerator_BlazorWebAssembly.Services;

public class QRCodeService
{
    public byte[] GenerateQR()
    {
        var qrGenerator = new QRCodeGenerator();
        var qrCodedData = qrGenerator.CreateQrCode("QR test", QRCodeGenerator.ECCLevel.Q);
        CustomQRCode qrCode = new CustomQRCode(qrCodedData);
        Bitmap logoImage = new Bitmap(@"wwwroot/img/aircodlogo.jpg");

        using (Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20, Color.Black, Color.WhiteSmoke, logoImage))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeAsBitmap.Save(ms, ImageFormat.Png);
                string base64String = Convert.ToBase64String(ms.ToArray());
                SaveImage(ms.ToArray());
                return ms.ToArray();
            }
        }
    }

    public void SaveImage(byte[] qrCodeImage)
    {
        var filePath = Directory.GetCurrentDirectory() + "/QRImage.png";
        File.WriteAllBytes(filePath, qrCodeImage);
    }
}