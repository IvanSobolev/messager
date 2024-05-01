using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddSingleton<IUserManager>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<MessengerContext>();
    optionsBuilder.UseSqlite("Data Source=MessengerDataBase.db"); 
    var MessengerContext = new MessengerContext(optionsBuilder.Options);
    MessengerContext.Database.EnsureCreated(); 
    IUserManager userManager = new UserManager(MessengerContext);

    return userManager;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();