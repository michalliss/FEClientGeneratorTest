namespace ClientGeneratorTest;

public class Request
{
    public Guid VideoId { get; set; }
}

public class Response
{
    public Guid VideoId { get; set; }
}

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/endpoint/{VideoId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        await SendAsync(new Response { VideoId = req.VideoId });
    }
}