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

    [Theory]
    [InlineData('A', "A\n")]
    [InlineData('B', 
        " A \n" +
        "B B\n" +
        " A \n")]
    [InlineData('C', 
        "  A  \n" +
        " B B \n" +
        "C   C\n" +
        " B B \n" +
        "  A  \n")]
    [InlineData('c', 
        "  a  \n" +
        " b b \n" +
        "c   c\n" +
        " b b \n" +
        "  a  \n")]
    public void PrintsExpectedDiamondForInputCharacter(char inputCharacter, string expectedDiamond)
    {
        var diamond = new Diamond(inputCharacter);
        
        Assert.Equal(expectedDiamond, diamond.ToString());
    }
}