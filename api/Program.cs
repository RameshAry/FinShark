using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();





// "DefaultConnection": "Data Source=localhost;Initial Catalog=finshark;User Id=sa;Password=Einsteins1.;Integrated Security=True;TrustServerCertificate=true;Trusted_Connection=false"
// "DefaultConnection": "Data Source=fin-shark.database.windows.net;Initial Catalog=finshark;User Id=CloudSA0121fa19;Password=AlbertEinsteins1.;Integrated Security=True;TrustServerCertificate=true;Trusted_Connection=false"