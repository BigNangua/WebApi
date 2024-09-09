using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// ���� Serilog
var logFolder = $"logs/{DateTime.Now:yyyy-MM-dd}";
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(
        path: $"{logFolder}/info.log",
        restrictedToMinimumLevel: LogEventLevel.Information,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    .WriteTo.File(
        path: $"{logFolder}/error.log",
        restrictedToMinimumLevel: LogEventLevel.Error,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    .CreateLogger();
builder.Host.UseSerilog();

// ��ӿ���������
builder.Services.AddControllers();

// ��� Swagger ����
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ���� Swagger �м��
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ʹ�ÿ�����
app.MapControllers();

app.Run();
