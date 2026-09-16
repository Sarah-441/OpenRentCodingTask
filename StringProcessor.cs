using System.Text.RegularExpressions;

namespace Application;

public class StringProcessor : IStringProcessor
{
    private readonly Regex _vowelRegex = new Regex("[aeiou]", RegexOptions.IgnoreCase);

    public string Process(string? input)
    {
        // Treat null as an empty string
        input ??= string.Empty;
        return $"{GetReverse(input)}{GetEarliestCharacterFromAlphabet(input)}{GetOutputFromVowelCount(input)}";
    }

    public string GetReverse(string input)
    {
        return new string(input.Reverse().ToArray());
    }

    public string GetEarliestCharacterFromAlphabet(string input)
    {
        var firstLetter = input.OrderBy(char.ToLower).FirstOrDefault(char.IsLetter);
        return firstLetter == default(char) ? string.Empty : firstLetter.ToString();
    }

    public string GetOutputFromVowelCount(string input)
    {
        var matchCount = _vowelRegex.Matches(input).Count;
        var matchCountIsOdd = matchCount % 2 == 1;
        return matchCountIsOdd ? "open" : "rent";
    }
}