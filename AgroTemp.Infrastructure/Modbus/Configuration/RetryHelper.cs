namespace AgroTemp.Infrastructure.Modbus.Configuration;

public class RetryHelper
{
    public static async Task<T> RetryAsync<T>(Func<Task<T>> func, TimeSpan retryInterval, int retryCount)
    {
        try
        {
            return await func();
        }
        catch when (retryCount > 0)
        {
            await Task.Delay(retryInterval);
            return await RetryAsync(func, retryInterval, retryCount - 1);
        }
    }

    public static async Task RetryAsync(Func<Task> func, TimeSpan retryInterval, int retryCount)
    {
        try
        {
            await func();
        }
        catch when (retryCount > 0)
        {
            await Task.Delay(retryInterval);
            await RetryAsync(func, retryInterval, retryCount - 1);
        }
    }
}
