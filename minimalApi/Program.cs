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

var books = new List<Book>
{
    new Book {Id = 1, Title ="test1", Author="author1"},
    new Book {Id = 2, Title ="test2", Author="author2"},
    new Book {Id = 3, Title ="test3", Author="author3"},
    new Book {Id = 4, Title ="test4", Author="author4"},
};

app.MapGet("/book", () =>
{
    return books;
});

app.MapGet("/book{id}", (int id) =>
{
    return books.Find(x => x.Id ==id);
});

app.Run();

class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
}
