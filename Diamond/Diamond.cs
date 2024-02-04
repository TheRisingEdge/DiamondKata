using System.Text;

namespace DiamondKata;

public class Diamond
{
    private readonly char _inputCharacter;
    private readonly char _startOfTheAlphabetCharacter;
    
    private readonly record struct CharacterLinePositions(char Character, int FirstIndex, int SecondIndex);

    public Diamond(char inputCharacter)
    {
        _inputCharacter = char.IsAsciiLetter(inputCharacter) ? inputCharacter: throw new ArgumentException("Diamond can only be built for alphabet characters");
        _startOfTheAlphabetCharacter = char.IsAsciiLetterLower(inputCharacter) ? 'a' : 'A';
    }

    public override string ToString()
    {
        var topToBottomCharacters = GetTopToBottomCharactersFor(_inputCharacter).ToArray();

        var lineSize = topToBottomCharacters.Length;

        var diamondLines = topToBottomCharacters
            .Select(character => ComputeCharacterPositionsOnLineOfSize(character, lineSize))
            .Select(characterPositions => CreateLineWithCharacter(characterPositions, lineSize));

        return Stringify(diamondLines);
    }
    
    private IEnumerable<char> GetTopToBottomCharactersFor(char inputCharacter)
    {
        var topHalfCharacters = CharacterRange(_startOfTheAlphabetCharacter, inputCharacter);
        var bottomHalfCharacters = CharacterRange(_startOfTheAlphabetCharacter, inputCharacter).Reverse().Skip(1);
        
        return topHalfCharacters.Concat(bottomHalfCharacters);
    }

    private CharacterLinePositions ComputeCharacterPositionsOnLineOfSize(char character, int lineSize)
    {
        var lineMiddle = lineSize / 2;
        var offsetFromMiddle = _startOfTheAlphabetCharacter - character;

        return new CharacterLinePositions(character, lineMiddle - offsetFromMiddle, lineMiddle + offsetFromMiddle);
    }

    private static char[] CreateLineWithCharacter(CharacterLinePositions characterPositions, int lineSize)
    {
        var line = CreateEmptyLine(lineSize);
        line[characterPositions.FirstIndex] = characterPositions.Character;
        line[characterPositions.SecondIndex] = characterPositions.Character;

        return line;
    }
    
    private static char[] CreateEmptyLine(int size) 
    {
        var line = new char[size];
        
        for (var i = 0; i < size; i++)
        {
            line[i] = ' ';
        }

        return line;
    }

    private static IEnumerable<char> CharacterRange(char startCharacter, char endCharacter)
    {
        var count = endCharacter - startCharacter + 1;

        return Enumerable.Range(startCharacter, count)
            .Select(c => (char)c);
    }

    private static string Stringify(IEnumerable<char[]> diamondLines)
    {
        var sb = new StringBuilder();

        foreach (var line in diamondLines)
        {
            sb.Append(line);
            sb.Append('\n');
        }

        return sb.ToString();
    }
}