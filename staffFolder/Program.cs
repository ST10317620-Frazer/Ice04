
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var staff = new List<StaffMember>
{
    new(1, "John", "IT"),
    new(2, "Sarah", "HR"),
    new(3, "Alex", "Finance"),
    new(4, "Thando","PR")
};

// Get all staff
app.MapGet("/staff", () => staff);

// Get staff by ID
app.MapGet("/staff/{id:int}", (int id) =>
    staff.FirstOrDefault(s => s.Id == id) is { } member
        ? Results.Ok(member)
        : Results.NotFound());

app.Run();

record StaffMember(int Id, string Name, string Department);
