using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Tests.Entities;

public class CategoryTests
{
    private string _firstExpectedMessage = string.Empty;
    private string _secondExpectedMessage = string.Empty;
    private string _thirdExpectedMessage = string.Empty;

    private readonly Category _category;
    private readonly Exam _exam;
    private readonly Title _title;

    public CategoryTests()
    {
        _title = new Title("teste");
        _category = new Category(_title);
        _exam = new Exam(_title, "Exame de Imagem");
    }

    [Fact]
    public void ShoudReturnErrorWhenTitleIsInvalid()
    {
        //Arrange
        var title = new Title(string.Empty);
        var category = new Category(title);

        //Act
        var result = category.Validate();

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenTitleIsValid()
    {
        //Act
        var result = _category.Validate();

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenAddingInvalidExam()
    {
        //Arrange
        var exam = new Exam(string.Empty, "Exame de imagem");
        _firstExpectedMessage = "O exame adicionado é inválido!";

        //Act
        _category.AddExam(exam);

        var result = _category.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_firstExpectedMessage));
    }

    [Fact]
    public void ShouldReturnSuccessWhenAddingExamValid()
    {
        //Act 
        _category.AddExam(_exam);

        //Assert
        Assert.Contains(_exam, _category.Exams);
    }

    [Fact]
    public void ShouldReturnErrorWhenExamExists()
    {
        //Arrange
        var exam2 = new Exam(_title, "Exame de Imagem");
        _firstExpectedMessage = "Não são permitidos exames repetidos!";

        //Act
        _category.AddExam(_exam);
        _category.AddExam(exam2);

        var result = _category.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.ErrorMessage.Equals(_firstExpectedMessage));
    }

    [Fact]
    public void ShouldReturnSuccessWhenExamDoesNotExists()
    {
        //Arrange
        var exam = new Exam("exam2", "Test");

        //Act
        _category.AddExam(_exam);
        _category.AddExam(exam);

        //Assert
        Assert.Contains(exam, _category.Exams);
    }

    [Fact]
    public void ShouldReturnErrorWhenUpdateIsInvalid()
    {
        //Arrange
        var title = new Title(string.Empty);
        _firstExpectedMessage = "O título não pode ser vazio!";
        _secondExpectedMessage = "O título deve ter no mínimo três letras!";

        //Act
        _category.Update(title, _exam.Status);
        var result = _category.Validate();

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.ErrorMessage.Equals(_firstExpectedMessage)
                 || e.ErrorMessage.Equals(_secondExpectedMessage));
    }

    [Fact]
    public void ShouldReturnSuccessWhenUpdateIsValid()
    {
        //Arrange
        var title = new Title("USG");

        //Act
        _category.Update(title, _category.Status);
        var result = _category.Validate();

        //Assert
        Assert.True(result.IsValid);
    }
}