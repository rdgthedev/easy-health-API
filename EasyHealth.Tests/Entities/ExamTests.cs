using System.Xml.XPath;
using EasyHealth.Domain.Entities;

namespace EasyHealth.Tests.Entities;

public class ExamTests
{
    private string _expectedErrorMessage = string.Empty;

    [Fact]
    public void ShouldReturnErrorWhenExamIsInvalid()
    {
        //Arrange
        _expectedErrorMessage = "O título deve ter no mínimo três letras!";
        var exam = new Exam("te", "exame de imagem");

        //Act
        var result = exam.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_expectedErrorMessage));
    }

    [Fact]
    public void ShouldReturnSuccessWhenExamIsValid()
    {
        //Arrange
        var exam = new Exam("teste", "testando");
        
        //Act
        var result = exam.Validate();
        
        //Assert
        Assert.True(result.IsValid);
    }
}