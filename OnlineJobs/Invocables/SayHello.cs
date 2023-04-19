using Coravel.Invocable;

namespace OnlineJobs.Invocables;

public class SayHello : IInvocable {
    private readonly ILogger<SayHello> _logger;

    public SayHello(ILogger<SayHello> logger)
    {
        _logger = logger;
    }
    
    public Task Invoke()
    {
        _logger.LogInformation("Hi!");
        return Task.CompletedTask;
    }
}