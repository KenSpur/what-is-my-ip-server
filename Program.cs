var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context => {
  var ipAddress = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
  await context.Response.WriteAsJsonAsync(new { IpAddress = ipAddress });
});

app.Run();