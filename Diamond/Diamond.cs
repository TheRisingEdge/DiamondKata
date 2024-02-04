using System.Text;

namespace DiamondKata;

public class Diamond
{
    private readonly char _inputCharacter;

    public Diamond(char inputCharacter)
    {
        _inputCharacter = char.IsAsciiLetter(inputCharacter) ? inputCharacter: throw new ArgumentException("Diamond can only be built for alphabet characters");
    }

    public override string ToString()
    {
        var topHalfCharacters = CharacterRange('A', _inputCharacter);
        var bottomHalfCharacters = CharacterRange('A', _inputCharacter).Reverse().Skip(1);
        var topToBottomCharacters = topHalfCharacters.Concat(bottomHalfCharacters);

        var (_, columns, midRowIndex) = MeasureDiamondSizeFor(_inputCharacter);

        var diamondLines = topToBottomCharacters
            .Select(c => PlaceCharacterOnLine(c, columns, midRowIndex));

        return Stringify(diamondLines);
    }

    private (int rows, int columns, int midRowIndex) MeasureDiamondSizeFor(char inputCharacter)
    {
        var columns = (inputCharacter - 'A') * 2 + 1;
        
        return (columns, columns, columns / 2);
    }

    private char[] PlaceCharacterOnLine(char character, int lineSize, int lineMidIndex)
    {
        var characterMidOffset = 'A' - character;
        var firstAppearanceIndex = lineMidIndex + characterMidOffset;
        var secondAppearanceIndex = lineMidIndex - characterMidOffset;

        var line = EmptyLine(lineSize);
        line[firstAppearanceIndex] = character;
        line[secondAppearanceIndex] = character;

        return line;
    }
    
    private static char[] EmptyLine(int size) 
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