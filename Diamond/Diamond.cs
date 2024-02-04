namespace DiamondKata;

public class Diamond
{
    private readonly char _inputCharacter;

    public Diamond(char inputCharacter)
    {
        _inputCharacter = char.IsAsciiLetter(inputCharacter) ? inputCharacter: throw new ArgumentException("Diamond can only be built for alphabet characters");
    }
}