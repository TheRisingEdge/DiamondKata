namespace Tests;

public class DiamondTests
{
    [Theory]
    [InlineData('1')]
    [InlineData('3')]
    [InlineData('7')]
    [InlineData('=')]
    [InlineData('~')]
    [InlineData('$')]
    public void DiamondCannotBeConstructedForInvalidCharacters(char inputCharacter)
    {
        Assert.ThrowsAny<Exception>(() => new Diamond(inputCharacter));
    }
}