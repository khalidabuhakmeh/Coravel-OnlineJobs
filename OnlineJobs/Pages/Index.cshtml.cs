using Coravel.Events.Interfaces;
using Coravel.Queuing.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineJobs.Events;
using OnlineJobs.Invocables;

namespace OnlineJobs.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    
    [BindProperty]
    public string Name { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public RedirectToPageResult OnPost([FromServices] IQueue queue, [FromServices]IDispatcher dispatcher)
    {
        queue.QueueInvocableWithPayload<SayHiTo, string>(Name);
        dispatcher.Broadcast(new SaidHello(Name));
        return RedirectToPage("index");
    }
}