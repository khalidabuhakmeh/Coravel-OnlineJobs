using Coravel.Events.Interfaces;

namespace OnlineJobs.Events;

public class SaidHello : IEvent
{
    public string Name { get; set; }

    public SaidHello(string name)
    {
        Name = name;
    }
}

public class SaidHelloListener : IListener<SaidHello>
{
    private readonly ILogger<SaidHelloListener> _logger;

    public SaidHelloListener(ILogger<SaidHelloListener> logger)
    {
        _logger = logger;
    }
    
    public Task HandleAsync(SaidHello broadcasted)
    {
        _logger.LogInformation("[Listener] Said hello to {Name}", broadcasted.Name);
        return Task.CompletedTask;
    }
}