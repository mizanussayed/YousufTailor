using System.Globalization;

namespace YSPT.Configurations.Helpers;

public static class MSISDNHelper
{
    public static string CreateWithGlobalIdentifier(string number)
    {
        return number.Length switch
        {
            < 9 => throw new Exception($"Number {number} must be equal to 9 or more to proceed"),
            9 => string.Create(CultureInfo.InvariantCulture, $"8801{number}"),
            10 => string.Create(CultureInfo.InvariantCulture, $"880{number}"),
            11 => string.Create(CultureInfo.InvariantCulture, $"88{number}"),
            13 => number,
            > 13 => throw new Exception($"Number {number} must be less than 13 characters to proceed"),
            _ => throw new Exception($"Invalid number {number}"),
        };
    }

    public static string CreateWithoutGlobalIdentifier(string? number)
    {
        return number?.Length switch
        {
            null => string.Empty,
            < 9 => string.Empty,
            9 => string.Create(CultureInfo.InvariantCulture, $"01{number}"),
            10 => string.Create(CultureInfo.InvariantCulture, $"0{number}"),
            11 => number,
            12 => string.Empty,
            13 => number[2..],
            14 => number[3..],
            >= 15 => string.Empty,
        };
    }

    public static string CreateWithoutGlobalIdentifierWithoutZero(string number)
    {
        return number.Length switch
        {
            < 9 => throw new Exception($"Number {number} must be equal to 9 or more to proceed"),
            9 => string.Create(CultureInfo.InvariantCulture, $"1{number}"),
            10 => number,
            11 => number[1..],
            12 => throw new Exception($"Invalid number {number}"),
            13 => number[3..],
            14 => number[4..],
            >= 15 => throw new Exception($"Number {number} must be less than 15 characters to proceed"),
        };
    }
}


