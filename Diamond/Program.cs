// See https://aka.ms/new-console-template for more information

using DiamondKata;

char inputCharacter = args switch
{
    [{ Length: 1 } firstArg] => firstArg[0],
    _ => throw new ArgumentException("Diamond can only be called with a single alphabet character")
};

Console.Write(new Diamond(inputCharacter));