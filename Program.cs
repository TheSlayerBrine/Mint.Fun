using Mint.Fun.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IAuthClient, AuthClient>();
builder.Services.AddSingleton<IAccountClient, AccountClient>();
builder.Services.AddHttpClient("blockchainapi",
    client => { client.BaseAddress = new Uri("http://localhost:5157"); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();