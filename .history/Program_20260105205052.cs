using infeubackend.Interfaces;
using infeubackend.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});


// Add services to the container.
builder.Services.AddHttpClient<IFireService, FireService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(120);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://infeu.vercel.app/") // Replace with your frontend domain
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
