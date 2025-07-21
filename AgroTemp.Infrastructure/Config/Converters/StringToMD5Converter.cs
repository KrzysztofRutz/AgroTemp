using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Cryptography;
using System.Text;

namespace AgroTemp.Infrastructure.Config.Converters;

internal class StringToMD5Converter : ValueConverter<string, string>
{
    public StringToMD5Converter()
        :base(d => StringToMd5(d),
            d => d.ToString()
            )
    {
    }

    private static string StringToMd5(string input)
    {
        var sb = new StringBuilder();
        using var md5 = MD5.Create();

        if (string.IsNullOrEmpty(input))
        {
            return string.Empty; // Return empty string if input is null or empty
        }

        // Conversion string to byte array
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);

        // Calculate MD5 hash from byte array
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        // Convert byte array to hexadecimal string 
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
    }
}
