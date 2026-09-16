namespace Application;

public interface IStringProcessor
{
    string Process(string input);
    string GetReverse(string input);
    string GetEarliestCharacterFromAlphabet(string input);
    string GetOutputFromVowelCount(string input);
}