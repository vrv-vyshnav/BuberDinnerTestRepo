namespace BuberDinner.Domain.Common;
public class Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T? Value { get; }
    public List<string>? Errors { get; }

    private Result(bool isSuccess, T? value, List<string>? errors)
    {
        IsSuccess = isSuccess;
        Value = value;
        Errors = errors;
    }

    public static Result<T> Success(T value) =>
        new Result<T>(true, value, null);

    public static Result<T> Failure(List<string> errors) =>
        new Result<T>(false, default, errors);

    public static Result<T> Failure(string error) =>
        new Result<T>(false, default, new List<string> { error });
}