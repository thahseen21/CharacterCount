using Business.ViewModel;

namespace Business.Test;

public class UnitTest1 : TestBase
{
    [Theory]
    [InlineData("aabcc")]
    public void GetCharacterCount_ValidString_True(string input)
    {
        //Arrange
        var output = new List<CharacterCountVm>() { 
                new CharacterCountVm() { Count = 2, Key= 'a' },
                new CharacterCountVm() { Count = 1, Key= 'b' },
                new CharacterCountVm() { Count = 2, Key= 'c' } 
            };

        //Act
        var result = characterCount.GetCharcterCount(input);

        //Assert
        Assert.Equivalent(output, result, true);
    }

    [Theory]
    [InlineData("aab cc")]
    public void GetCharacterCount_ValidStringWithSpace_True(string input)
    {
        //Arrange
        var output = new List<CharacterCountVm>() {
                new CharacterCountVm() { Count = 2, Key= 'a' },
                new CharacterCountVm() { Count = 1, Key= 'b' },
                new CharacterCountVm() { Count = 2, Key= 'c' }
            };

        //Act
        var result = characterCount.GetCharcterCount(input);

        //Assert
        Assert.Equivalent(output, result, true);
    }

    [Theory]
    [InlineData("aab cc#%#/\"")]
    public void GetCharacterCount_ValidStringWithSpecialCharacters_True(string input)
    {
        //Arrange
        var output = new List<CharacterCountVm>() {
                new CharacterCountVm() { Count = 2, Key= 'a' },
                new CharacterCountVm() { Count = 1, Key= 'b' },
                new CharacterCountVm() { Count = 2, Key= 'c' },
                new CharacterCountVm() { Count = 2, Key= '#' },
                new CharacterCountVm() { Count = 1, Key= '%' },
                new CharacterCountVm() { Count = 1, Key= '/' },
                new CharacterCountVm() { Count = 1, Key= '"' },
            };

        //Act
        var result = characterCount.GetCharcterCount(input);

        //Assert
        Assert.Equivalent(output, result, true);
    }

    [Theory]
    [InlineData("                   ")]
    public void GetCharacterCount_FullSpace_True(string input)
    {
        //Arrange
        var output = new List<CharacterCountVm>();

        //Act
        var result = characterCount.GetCharcterCount(input);

        //Assert
        Assert.Equivalent(output, result, true);
    }

    [Theory]
    [ClassData(typeof(LongStringTestData))]
    public void GetCharacterCount_LongString_True(string input)
    {
        //Arrange
        var output = new List<CharacterCountVm>() {
                new CharacterCountVm() { Count = 2, Key= 'a' },
                new CharacterCountVm() { Count = 1, Key= 'b' },
                new CharacterCountVm() { Count = 2, Key= 'c' },
                new CharacterCountVm() { Count = 2, Key= '#' },
                new CharacterCountVm() { Count = 1, Key= '%' },
                new CharacterCountVm() { Count = 1, Key= '/' },
                new CharacterCountVm() { Count = 1, Key= '"' },
            };

        //Act
        var result = characterCount.GetCharcterCount(input);

        //Assert
        Assert.NotEmpty(result);
    }
}