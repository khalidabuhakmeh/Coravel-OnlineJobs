using Coravel.Invocable;

namespace OnlineJobs.Invocables;

public class SayHiTo : IInvocable, IInvocableWithPayload<string>
{
    private readonly ILogger<SayHiTo> _logger;

    public SayHiTo(ILogger<SayHiTo> logger)
    {
        _logger = logger;
    }
    
    public Task Invoke()
    {
        _logger.LogInformation("Hi, {Payload}!", Payload);
        return Task.CompletedTask;
    }

    public string Payload { get; set; } = "World";
}