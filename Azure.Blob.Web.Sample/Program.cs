using Azure.Blob.Web.Sample.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation(); 


builder.Services.Configure<AzureStorageConfig>(builder.Configuration.GetSection("AzureStorageConfig"));

// Wire up a single instance of BlobStorage, calling Initialize() when we first use it.
builder.Services.AddSingleton<IStorage>(serviceProvider => {
    var blobStorage = new BlobStorage(serviceProvider.GetService<IOptions<AzureStorageConfig>>());
    blobStorage.Initialize().GetAwaiter().GetResult();
    return blobStorage;
});

builder.Services.AddSingleton<IQueueStorage>(serviceProvider =>
{
    var queueStorage = new QueueStorage(serviceProvider.GetService<IOptions<AzureStorageConfig>>());
    queueStorage.Initialize().GetAwaiter().GetResult();
    return queueStorage;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
