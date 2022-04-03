using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(config => { config.Filters.Add<GobalErrorHandlerAttribute>(); });

builder.Services.AddDbContext<ACMESOFT.Data.AcmesoftDataContext>
               (option => option.UseSqlServer(builder.Configuration.GetConnectionString("ACMESOFTApiConnectionString").ToString())
               .EnableSensitiveDataLogging());
builder.Services.AddTransient<ACMESOFT.IService.IAcmesoftServices, ACMESOFT.Service.AcmesoftServices>();
builder.Services.AddTransient<ACMESOFT.IService.IUserService, ACMESOFT.Service.UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corspolicy",
    corspolicybuilder =>
    {
        corspolicybuilder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("corspolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
