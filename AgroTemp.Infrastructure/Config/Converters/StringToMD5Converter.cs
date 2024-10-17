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
        using (MD5 md5 = MD5.Create())
        {
            // Konwersja stringa na tablicę bajtów
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            // Obliczanie skrótu MD5
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Konwersja tablicy bajtów na string w formacie heksadecymalnym
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
        }
        return sb.ToString();
    }
}
