using System.Diagnostics;

namespace NetUtils.ManagedResult;

[DebuggerStepThrough]
public abstract record ManagedResult(bool Success, List<string> Issues, object? ResultObject)
{
    public bool Fail => !Success;
    public string IssuesTextAggregate => string.Join("\n", Issues);
};

[DebuggerStepThrough]
public record ManagedResult<T>(bool Success, List<string> Issues, T? Result) : ManagedResult(Success, Issues, Result) 
{
    public static ManagedResult<T> Successful(T? result)
    {
        return new ManagedResult<T>(true, new List<string>(), result);
    }

    public static ManagedResult<T> Failed(List<string> issues)
    {
        return new ManagedResult<T>(false, issues, default);
    }

    public static ManagedResult<T> Failed(string issue)
    {
        return new ManagedResult<T>(false, new List<string> {issue}, default);
    }

    public ManagedResult(T? result) : this(true, new List<string>(), result)
    {
    }

    public ManagedResult(bool success, string issue) : this(success, new List<string> { issue }, default)
    {
    }

    public ManagedResult(bool success, List<string> issues) : this(success, issues, default)
    {
    }
}