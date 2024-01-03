using Microsoft.EntityFrameworkCore;
using minimalApi.DBContexts;
using minimalApi.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MinimalApiDemoContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

# region sample no DB

var model = new List<Bank>
{
    new Bank {Id = 1, NameTH ="กรุงไทย", NameEN="KTC"},
    new Bank {Id = 2, NameTH ="กสิกรไทย", NameEN="KBank"},
    new Bank {Id = 3, NameTH ="ไทยพาณิชย์", NameEN="SCB"},
};

app.MapGet("/api/bank", () =>
{
    return model;
});

app.MapGet("/api/bank{id}", (int id) =>
{
    var response = model.Find(x => x.Id == id);
    if (response == null) return Results.NotFound("ไม่มีข้อมูล");

    return Results.Ok(response);
});

app.MapPost("/api/bank", (Bank request) =>
{
    model.Add(request);
    return model;
});

app.MapPut("/api/bank/{id}", (Bank request,int id) =>
{
    var data = model.Find(x => x.Id == id);
    if(data == null) return Results.NotFound("ไม่มีข้อมูล");

    data.NameTH = request.NameTH;
    data.NameEN = request.NameEN;

    return Results.Ok(data);
});

app.MapDelete("/api/bank/{id}", (int id) =>
{
    var data = model.Find(x => x.Id == id);
    if (data == null) return Results.NotFound("ไม่มีข้อมูล");

    model.Remove(data);

    return Results.Ok(data);
});

# endregion

# region use Db,EF Core

app.MapGet("/api/Agents", async (MinimalApiDemoContext context) => await context.Agents.ToListAsync()); //

app.MapGet("/api/Agents{code}", async (MinimalApiDemoContext context, string code) =>
    await context.Agents.FindAsync(code) is Agent agent ? Results.Ok(agent) : Results.NotFound("ไม่เจอข้อมูล"));

app.MapPost("/api/Agents", async (MinimalApiDemoContext context, Agent request) =>
{
    context.Agents.Add(request);
    await context.SaveChangesAsync();

    return Results.Ok(await context.Agents.ToListAsync());
});

app.MapPut("/api/Agents/{code}", async (MinimalApiDemoContext context, Agent request, string code) =>
{
    var data = await context.Agents.FindAsync(code);
    if (data == null) return Results.NotFound("ไม่มีข้อมูล");

    data.AgentName = request.AgentName;
    await context.SaveChangesAsync();

    return Results.Ok(await context.Agents.ToListAsync());
});

app.MapDelete("/api/Agents/{code}", async (MinimalApiDemoContext context, string code) =>
{
    var data = await context.Agents.FindAsync(code);
    if (data == null) return Results.NotFound("ไม่มีข้อมูล");

    context.Remove(data);
    await context.SaveChangesAsync();

    return Results.Ok(await context.Agents.ToListAsync());
});

# endregion

app.Run();

public class Bank
{
    public int Id { get; set; }
    public required string NameTH { get; set; }
    public required string NameEN { get; set; }
}
