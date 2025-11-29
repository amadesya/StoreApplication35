using StoreApplication35.Contexts;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Dbde3512Context>(); //+ добавляет контекст
builder.Services.AddSession(); //+ сессия для логина
builder.Services.AddHttpContextAccessor(); //+ для отображения данных сессии

var app = builder.Build();

//+ настройка отображения вещественный чисел
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU") 
{
    NumberFormat = {NumberDecimalSeparator = "."}
};

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthentication(); //+добавили аутентификацию
app.UseSession(); //+добавить сессию
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
