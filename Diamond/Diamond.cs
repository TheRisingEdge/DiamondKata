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
        var row = new char[2];
        row[0] = _inputCharacter;
        row[1] = '\n';

        return new string(row);
    }
}