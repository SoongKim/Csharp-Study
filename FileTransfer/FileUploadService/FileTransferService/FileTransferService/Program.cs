using FileTransferService.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using FileTransferService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
// Map controllers
app.MapControllers();

app.Run();