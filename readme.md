# Coravel Pro Jobs Runner Sample

This repository has a [Coravel Pro](https://www.pro.coravel.net/) sample I wrote to see what the experience is like. I have some thoughts (mostly positive), with feedback as to what I would like to have in the future. As a TL;DR my thoughts are **very positive**.

## The Good

- The Admin dashboard is very nice with extensibility points to make it your admin dashboard for all things (not just jobs).
- Separation of `Invocables` and `Scheduling` is similar to Quartz.NET and makes a lot of sense. It's easy to create reusable jobs while scheduling them at different times.
- The scheduling mechanism supports Cron and an intuitive human-friendly UI. 
- The programming model is straight forward and hooked into ASP.NET Core's services collection.
- Interfaces like `IDestructive` give you ways to denote different invocables as potentially disruptive to operations.
- The `IQueue` interface allows you to use Coravel as a background processor for long-running tasks.
- Eventing system to broadcast events to multiple listeners. (Mediator pattern).
- Entity Framework Core is nice.
- The Pro licensing is affordable and reasonable.

## Potential For Improvement

- Having separate Pro and OSS docs has me jumping between two sites. Combining them would make the learning experience better.
- Invocable context and logger are missing. The ability to output milestones and logs to the dashboard for jobs would make things more user-friendly.
- No configuration options on the dashboard for urls.
- Some folks might not want EF Core, but it's easy enough to work around.
- Lack of formalized retry is a bummer, but the author clearly says that's your (the developer's) domain, not theirs.
- Events and Listeners use a bit too much setup with calls to `ConfigureEvents` and then wiring things up. It's not as "zero config" as invocables.
- Nitpick, but the lack of a generic version for `AddCoravelPro` seems like an oversight.
- NewtonSoftJson is required.
- Polling the database (SQLite in this case) seems slower than I would expect.

## Conclusion

Coravel Pro has a lot of potential to be a great OSS offering for many looking to add background jobs to their applications. It was relatively easy to get started, especially for folks with EF Core experience.

I recommend giving it a try, but I have not tried it in extreme production scenarios, so your mileage may vary