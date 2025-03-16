using System.Text.RegularExpressions;

namespace FreelaFlowApi.Application.Extensions;
public static partial class StringExtensions
{
    public static int? TryParseInt32(this string? intMaybe) =>
        int.TryParse(intMaybe, out var result) ? result : null;

    public static bool ValidCPF(this string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = CPFRegex().Replace(cpf.Trim(), "");

        if (cpf.Length != 11)
            return false;

        if (cpf.Distinct().Count() == 1)
            return false;

        var numbers = cpf[..9].Select(x => int.Parse(x.ToString())).ToArray();

        var firstDigit = numbers.Select((x, i) => x * (10 - i)).Sum() % 11;
        firstDigit = firstDigit < 2 ? 0 : 11 - firstDigit;

        numbers = numbers.Append(firstDigit).ToArray();

        var secondDigit = numbers.Select((x, i) => x * (11 - i)).Sum() % 11;
        secondDigit = secondDigit < 2 ? 0 : 11 - secondDigit;

        return cpf.EndsWith($"{firstDigit}{secondDigit}");
    }

    public static bool ValidCNPJ(this string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        cnpj = CNPJRegex().Replace(cnpj.Trim(), "");

        if (cnpj.Length != 14)
            return false;

        if (cnpj.Distinct().Count() == 1)
            return false;

        var numbers = cnpj[..12].Select(x => int.Parse(x.ToString())).ToArray();

        var firstDigit = numbers.Select((x, i) => x * (5 - i)).Sum() % 11;
        firstDigit = firstDigit < 2 ? 0 : 11 - firstDigit;

        numbers = numbers.Append(firstDigit).ToArray();

        var secondDigit = numbers.Select((x, i) => x * (6 - i)).Sum() % 11;
        secondDigit = secondDigit < 2 ? 0 : 11 - secondDigit;

        return cnpj.EndsWith($"{firstDigit}{secondDigit}");
    }

    public static bool IsValidIdDocument(this string idDocument) =>
        idDocument.ValidCPF() || idDocument.ValidCNPJ();

    public static bool IsValidPhoneNumber(this string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        phone = PhoneRegex().Replace(phone, "").Trim();

        return phone.Length switch
        {
            10 => phone.All(char.IsDigit),
            11 => phone.Length > 2 && phone.All(char.IsDigit) && phone[2] == '9',
            _ => false
        };
    }

    public static bool IsValidZipCode(this string zipCode) =>
        zipCode.Length == 8 && zipCode.All(char.IsDigit);

    // This attribute generates a Regex object for the specified pattern at compile time
    [GeneratedRegex(@"[\(\)\-\s]")]
    private static partial Regex PhoneRegex();
    [GeneratedRegex(@"[.\-\/]")]
    private static partial Regex CNPJRegex();
    [GeneratedRegex(@"[.\-]")]
    private static partial Regex CPFRegex();
}