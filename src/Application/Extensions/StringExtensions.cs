namespace FreelaFlowApi.Application.Extensions;
public static class StringExtensions
{
    public static int? TryParseInt32(this string? intMaybe) =>
        int.TryParse(intMaybe, out var result) ? result : null;

    public static bool ValidCPF(this string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = cpf.Trim().Replace(".", "").Replace("-", "");

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

        cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

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

    public static bool ValidIdDocument(this string idDocument) =>
        idDocument.ValidCPF() || idDocument.ValidCNPJ();
}