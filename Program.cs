var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context => {
  var headers = context.Request.Headers;
  var ipAddress = headers.ContainsKey("X-Forwarded-For") 
    ? headers["X-Forwarded-For"].FirstOrDefault()
    : context.Connection.RemoteIpAddress?.MapToIPv4().ToString();
  await context.Response.WriteAsJsonAsync(new { IpAddress = ipAddress });
});

app.Run();