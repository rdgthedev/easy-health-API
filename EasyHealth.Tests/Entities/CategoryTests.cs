using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;

namespace EasyHealth.Tests.Entities;

public class CategoryTests
{
    private readonly Category _category;
    private readonly Exam _exam;

    public CategoryTests()
    {
        _category = new Category("teste");
        _exam = new Exam("Usg", "Exame de Imagem");
    }

    [Fact]
    public void ShoudReturnErrorWhenNameIsInvalid()
    {
        //Arrange
        var category = new Category(string.Empty);

        //Act + Assert
        Assert.False(category.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenNameIsValid()
        => Assert.True(_category.IsValid);


    [Fact]
    public void ShouldReturnErrorWhenInactive()
    {
        //Act
        _category.UpdateStatus(EStatus.Inactive);

        //Act + Assert
        Assert.Equal(EStatus.Inactive, _category.Status);
    }

    [Fact]
    public void ShouldReturnSuccessWhenActive()
        => Assert.Equal(EStatus.Active, _category.Status);

    [Fact]
    public void ShouldReturnUnableToAddExamExceptionWhenAddingInvalidExam()
    {
        //Arrange
        var exam = new Exam("", "Exame de imagem");

        //Act + Assert
        var exception = Assert.Throws<UnableToAddExamException>(() => _category.AddExam(exam));
        Assert.Equal("Exame inválido!", exception.Message);
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
    public void ShouldReturnUnableToAddExamExceptionWhenExamExists()
    {
        //Arrange
        var exam2 = new Exam("Usg", "Exame de Imagem");

        //Act
        _category.AddExam(_exam);

        //Assert
        var exception = Assert.Throws<UnableToAddExamException>(() => _category.AddExam(exam2));
        Assert.Equal("A categoria já possuí esse exame!", exception.Message);
    }

    [Fact]
    public void ShouldReturnSuccessWhenExamDoesNotExists()
    {
        //Arrange
        var exam = new Exam("Exam", "Test");

        //Act
        _category.AddExam(_exam);
        _category.AddExam(exam);

        //Assert
        Assert.Contains(exam, _category.Exams);
    }

    [Fact]
    public void ShouldReturnUnableToChangeNameExceptionWhenUpdateNameIsInvalid()
    {
        //Act + Assert
        var exception = Assert.Throws<UnableToChangeNameException>(() => _category.UpdateName(""));
        Assert.Equal("Não foi possível alterar o nome!", exception.Message);
    }

    [Fact]
    public void ShouldReturnSuccessWhenUpdateNameIsValid()
    {
        //Arrange
        const string name = "teste";

        //Act
        _category.UpdateName(name);

        //Assert
        Assert.Equal(name, _category.Name);
    }

    [Fact]
    public void ShouldReturnUnableToChangeStatusExceptionWhenUpdateStatusIsEqualToCurrent()
    {
        //Act + Assert
        var exception = Assert.Throws<UnableToChangeStatusException>(
            () => _category.UpdateStatus(EStatus.Active));
        Assert.Equal("Este é o status atual da categoria!", exception.Message);
    }

    [Fact]
    public void ShouldReturnUnableToChangeStatusExceptionWhenUpdateStatusIsNotEqualToCurrent()
    {
        //Act
        _category.UpdateStatus(EStatus.Inactive);

        //Assert
        Assert.Equal(EStatus.Inactive, _category.Status);
    }
}