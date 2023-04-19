using Coravel.Invocable;

namespace OnlineJobs.Invocables;

public class Fail : IInvocable
{
    public Task Invoke()
    {
        throw new Exception("💩");
    }
}