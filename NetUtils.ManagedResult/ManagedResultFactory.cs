using System.Diagnostics;

namespace NetUtils.ManagedResult;

[DebuggerStepThrough]
public static class ManagedResultFactory
{
    public static ManagedResult<T> Successful<T>(T? result) => ManagedResult<T>.Successful(result);
    public static ManagedResult<T> Failed<T>(string issue) => ManagedResult<T>.Failed(new List<string>{issue});
    public static ManagedResult<T> Failed<T>(List<string> issues) => ManagedResult<T>.Failed(issues);
    public static ManagedResult<T> Failed<T>(string issue, List<string> inheritedIssues) => ManagedResult<T>.Failed(new List<string>(){issue}.Concat(inheritedIssues).ToList());

    //public static object Failed<T>(List<string> issues, Type type)
    //{
    //    // Get the generic type definition
    //    Type genericType = typeof(ManagedResult<>);

    //    // Make the generic type with the provided type argument
    //    Type constructedType = genericType.MakeGenericType(type);

    //    // Create an instance of the constructed type
    //    return Activator.CreateInstance(constructedType;

    //}
}