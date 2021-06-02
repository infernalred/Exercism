using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception("Error.");

    public static int? HandleErrorByReturningNullableType(string input)
    {
        int rezult;
        return int.TryParse(input, out rezult) ? rezult : (int?)null;
    }

    public static bool HandleErrorWithOutParam(string input, out int rezult) => int.TryParse(input, out rezult);

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using (disposableObject)
            throw new Exception("Error.");
    }
}
