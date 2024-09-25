using System.Reflection.Emit;

namespace QRGenerator_BlazorWebAssembly.Services;

public static class Extensions
{
    public static string GetName<T>(this T enumObj) where T : Enum
    {
        return Enum.GetName(typeof(T), enumObj) ?? "";
    }

    public static int GetValue<T>(this T enumObj) where T : Enum
    {
        return Convert.ToInt32(enumObj);
    }
}