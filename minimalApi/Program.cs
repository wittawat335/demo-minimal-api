var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var model = new List<Bank>
{
    new Bank {Id = 1, NameTH ="กรุงไทย", NameEN="KTC"},
    new Bank {Id = 2, NameTH ="กสิกรไทย", NameEN="KBank"},
    new Bank {Id = 3, NameTH ="ไทยพาณิชย์", NameEN="SCB"},
};

app.MapGet("/bank", () =>
{
    return model;
});

app.MapGet("/bank{id}", (int id) =>
{
    var response = model.Find(x => x.Id == id);
    if (response == null) return Results.NotFound("ไม่มีข้อมูล");

    return Results.Ok(response);
});

app.MapPost("/bank", (Bank request) =>
{
    model.Add(request);
    return model;
});

app.MapPut("/bank/{id}", (Bank request,int id) =>
{
    var data = model.Find(x => x.Id == id);
    if(data == null) return Results.NotFound("ไม่มีข้อมูล");

    data.NameTH = request.NameTH;
    data.NameEN = request.NameEN;

    return Results.Ok(data);
});

app.MapDelete("/bank/{id}", (int id) =>
{
    var data = model.Find(x => x.Id == id);
    if (data == null) return Results.NotFound("ไม่มีข้อมูล");

    model.Remove(data);

    return Results.Ok(data);
});

app.Run();

class Bank
{
    public int Id { get; set; }
    public required string NameTH { get; set; }
    public required string NameEN { get; set; }
}
