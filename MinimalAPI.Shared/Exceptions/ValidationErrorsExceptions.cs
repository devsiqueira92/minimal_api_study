namespace MinimalAPI.Shared.Exceptions;

public class ValidationErrorsExceptions : BaseException
{
    public List<string> Messsages { get; set; }
    public string Title { get; set; }
    public int StatusCode { get; set; }

    public ValidationErrorsExceptions(List<string> errorsMesssages) : base(string.Empty)
    {
        Messsages = errorsMesssages;
    }

    public ValidationErrorsExceptions(string errorsMesssages) : base(string.Empty)
    {
        Messsages = new List<string> { errorsMesssages };
    }

    public ValidationErrorsExceptions(string errorsMesssages, string errorTitle) : base(string.Empty)
    {
        Messsages = new List<string> { errorsMesssages };
        StatusCode = 400;
        Title = errorTitle;
    }

    public ValidationErrorsExceptions(List<string> errorsMesssages, string errorTitle) : base(string.Empty)
    {
        Messsages = errorsMesssages;
        StatusCode = 400;
        Title = errorTitle;
    }

}
