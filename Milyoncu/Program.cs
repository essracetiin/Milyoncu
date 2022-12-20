using Azure;
using Microsoft.EntityFrameworkCore;
using Milyoncu.API;
using Milyoncu.Core;
using Milyoncu.Dal;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using Milyoncu.Repos.Concrete;
using Milyoncu.Uow;
using System.Text.Json.Serialization;
using APIResponseModel = Milyoncu.API.APIResponseModel;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MilyoncuContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));
builder.Services.AddScoped<IBasketRep, BasketRep<Basket>>();
builder.Services.AddScoped<ICategoryRep,CategoryRep<Category>>();
builder.Services.AddScoped<IEventRep, EventRep<Event>>();
builder.Services.AddScoped<ITicketRep, TicketRep<Ticket>>();
builder.Services.AddScoped<IUserRep, UserRep<User>>();
builder.Services.AddScoped<IWalletRep, WalletRep<Wallet>>();
builder.Services.AddScoped<ILotteryRep, LotteryRep<Lottery>>();
builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped<APIResponseModel>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
