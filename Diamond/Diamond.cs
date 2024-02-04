namespace DiamondKata;

public class Diamond
{
    private readonly char _inputCharacter;

    public Diamond(char inputCharacter)
    {
        _inputCharacter = inputCharacter switch
        {
            >= 'A' and <= 'Z' => inputCharacter,
            >= 'a' and <= 'z' => inputCharacter,
            _ => throw new ArgumentException("Diamond can only be built for alphabet characters")
        };
    }
}