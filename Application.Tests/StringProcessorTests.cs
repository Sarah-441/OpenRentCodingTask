using AutoFixture;
using Fare;
using FluentAssertions;

namespace Application.Tests;

public class StringProcessorTests
{
    IFixture _fixture;

    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture();
        License.Accepted = true;
    }

    [TestCase("nepo", "openerent")]
    public void GivenExampleProvided_WhenProcessIsCalled_ReturnTheExpectedString(string input, string expectedResult)
    {
        // Arrange
        var processor = new StringProcessor();

        // Act
        var result = processor.Process(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    public void GivenAnEmptyInput_WhenGetReverseIsCalled_ReturnAnEmptyString()
    {
        // Arrange
        var input = string.Empty;
        var expectedResult = string.Empty;
        var processor = new StringProcessor();

        // Act
        var result = processor.GetReverse(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    public void GivenAnEmptyInput_WhenGetEarliestCharacterFromAlphabetIsCalled_ReturnAnEmptyString()
    {
        // Arrange
        var input = string.Empty;
        var expectedResult = string.Empty;
        var processor = new StringProcessor();

        // Act
        var result = processor.GetEarliestCharacterFromAlphabet(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    [TestCase("Ab", "A")]
    [TestCase("bA", "A")]
    [TestCase("aB", "a")]
    [TestCase("Ba", "a")]
    public void
        GivenAnInputWithUpperAndLowerCaseLetters_WhenGetEarliestCharacterFromAlphabetIsCalled_ReturnEarliestRegardlessOfCase(
            string input, string expectedResult)
    {
        // Arrange
        var processor = new StringProcessor();

        // Act
        var result = processor.GetEarliestCharacterFromAlphabet(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    public void GivenNoLettersInInput_WhenGetEarliestCharacterFromAlphabetIsCalled_ReturnAnEmptyString()
    {
        // Arrange
        var input = new Xeger("[^a-zA-Z]+").Generate();
        var expectedResult = string.Empty;
        var processor = new StringProcessor();

        // Act
        var result = processor.GetEarliestCharacterFromAlphabet(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    private const string EvenVowelsString = "rent";
    private const string OddVowelsString = "open";

    [Test]
    public void GivenAnEmptyInput_WhenGetOutputFromVowelCountIsCalled_ReturnStringForAnEvenNumberOfVowels()
    {
        // Arrange
        var input = string.Empty;
        var expectedResult = EvenVowelsString;
        var processor = new StringProcessor();

        // Act
        var result = processor.GetOutputFromVowelCount(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    public void
        GivenAnInputWithAnEvenNumberOfVowels_WhenGetOutputFromVowelCountIsCalled_ReturnStringForAnEvenNumberOfVowels()
    {
        // Arrange
        var numberOfVowels = _fixture.Create<int>() * 2;
        var numberOfOtherChars = _fixture.Create<int>();
        var input = new string(new Xeger($"[^aeiouAEIOU]{{{numberOfOtherChars}}}[aeiouAEIOU]{{{numberOfVowels}}}")
            .Generate()
            .Shuffle().ToArray());
        var expectedResult = EvenVowelsString;
        var processor = new StringProcessor();

        // Act
        var result = processor.GetOutputFromVowelCount(input);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    public void
        GivenAnInputWithAnOddNumberOfVowels_WhenGetOutputFromVowelCountIsCalled_ReturnStringForAnOddNumberOfVowels()
    {
        // Arrange
        var numberOfVowels = _fixture.Create<int>() * 2 + 1;
        var numberOfOtherChars = _fixture.Create<int>();
        var input = new string(new Xeger($"[^aeiouAEIOU]{{{numberOfOtherChars}}}[aeiouAEIOU]{{{numberOfVowels}}}")
            .Generate()
            .Shuffle().ToArray());
        var expectedResult = OddVowelsString;
        var processor = new StringProcessor();

        // Act
        var result = processor.GetOutputFromVowelCount(input);

        // Assert
        result.Should().Be(expectedResult);
    }
}
