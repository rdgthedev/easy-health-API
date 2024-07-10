using EasyHealth.Domain.Enums;

namespace EasyHealth.Domain.ValueObjects;

public class Document
{
    public Document(
        string code, 
        string type)
    {
        Code = code;
        Type = Enum.Parse<EDocumentType>(type, ignoreCase: true);
    }

    public string Code { get; private set; }
    public EDocumentType Type { get; private set; }
}