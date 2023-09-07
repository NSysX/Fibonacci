var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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


app.MapGet("api/v1/GetFibonacciNumber", (int index) =>
{
    if (index < 0) throw new ArgumentException("Only positive index number");

    if(index <= 1) return Results.Ok(index); 

    int firstNumber = 0, secondNumber = 1, result = 0;

    for (int i = 2; i <= index; i++)
    {
        result = firstNumber + secondNumber;
        firstNumber = secondNumber;
        secondNumber = result;
    }

    return Results.Ok(result);
})
.Produces(statusCode: StatusCodes.Status200OK)
.Produces(statusCode: StatusCodes.Status400BadRequest)
.WithName("GetFibonacciNumber")
.WithOpenApi();

app.Run();

