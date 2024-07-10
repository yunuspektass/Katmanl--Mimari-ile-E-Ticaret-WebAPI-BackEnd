using System.Configuration;
using Microsoft.EntityFrameworkCore;
using NSwag;
using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.BLL.DesignPatterns.GenericRepository.ConcManager;
using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.BLL.Mapper;
using Project.BLL.ServiceSettings;
using Project.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyContext"));
});

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddTransient<IMailService, MailManager>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddAutoMapper(typeof(MappingProduct)); // AutoMapper bağımlılığı ekledim 
builder.Services.AddAutoMapper(typeof(MappingCategory));
//ProductRepository sınıfını bağımlılığını scoped yaşam döngüsüyle enjekte ettim
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CategoryRepository>();
//Swagger için controllers ekle
//Controller için bağımlılık enjeksiyonu sağlar 
builder.Services.AddControllers();



//Swagger NSwag servislerini ekledim
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "My API";
        document.Info.Description = "ASP.NET Core Web API";
        
    };
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// NSwag'ı JSON endpoint olarak sunmak için middleware etkinleştirdim.
app.UseOpenApi();

//NSwag'ı UI'yi web de sunmak için middleware etkinleştirdim. 
//NSwag JSON endpoint'ini belirt 
app.UseSwaggerUi(settings =>
{
    settings.Path = "/swagger";
    settings.DocumentPath = "/swagger/v1/swagger.json";
});

app.UseAuthorization();

app.MapControllers(); // HTTP isteklerini mapler 
app.MapRazorPages();

app.Run();