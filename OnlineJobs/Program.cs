using Coravel;
using Coravel.Pro;
using Microsoft.EntityFrameworkCore;
using OnlineJobs.Events;
using OnlineJobs.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddNewtonsoftJson();
builder.Services.AddDbContext<Database>();
builder.Services.AddCoravelPro(typeof(Database));

// add listener for event
builder.Services.AddTransient<SaidHelloListener>();

var app = builder.Build();

var events = app.Services.ConfigureEvents();
events.Register<SaidHello>().Subscribe<SaidHelloListener>();

// migrate the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Database>();
    db.Database.Migrate();
} 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseCoravelPro();
app.MapRazorPages();
app.Run();