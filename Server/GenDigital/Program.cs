using System.Collections.Generic;
using Parsers;
using Types;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();

// Dummy Cors for sake of interview
app.UseCors(policy => policy.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader());

app.MapGet("/", () => "Hello World!");

app.MapGet("/isprime/{number}", (int number) =>
{
  PrimeParser parser = new PrimeParser(number);
  bool isEven = number % 2 == 0;
  int endValue = number * number;
  List<PrimeNode> _t = parser.sieveOfEratosthenes();
  return _t;
});

app.Run();
