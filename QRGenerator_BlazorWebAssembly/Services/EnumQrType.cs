using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QRGenerator_BlazorWebAssembly.Services;

public enum EnumQrType
{
    [Display(Name = "Normal Text")]
    Text,
    Url,
    [Display(Name = "Phone Number")]
    PhoneNumber
}

public enum ImageType
{
    PNG,
    JPG,
    JPEG,
    
}