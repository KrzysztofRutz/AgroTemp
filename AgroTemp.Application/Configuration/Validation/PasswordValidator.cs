namespace AgroTemp.Application.Configuration.Validation;

internal class PasswordValidator
{
    public static bool HasSpecialCharacter(string password)
    {
        bool isValid = false;

        foreach (char c in password)
        {
            if (!char.IsLetterOrDigit(c))
            {
                isValid = true;
                break;
            }
        }

        return isValid;
    }

    public static bool HasNumberCharacter(string password)
    {
        bool isValid = false;

        foreach (char c in password)
        {
            if (char.IsNumber(c))
            {
                isValid = true;
                break;
            }
        }

        return isValid;
    }
}
