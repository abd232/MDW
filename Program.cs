using MDW.Context;
using Microsoft.EntityFrameworkCore;
using Models;
using MDW.Data;
//using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MDW.Controllers;
using Npgsql;
using static System.Net.Mime.MediaTypeNames;
using System;
using Newtonsoft.Json;
using System.Net.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MDWDbContext>(option=>option.UseNpgsql(builder.Configuration.GetConnectionString("MDW")));
var app = builder.Build();

//using StreamReader reader = new("Data\\drugs.json");
//var json = reader.ReadToEnd();
/*var cString = "Host=localhost;Port=5432;Database=mdw;Username=postgres;Password=19112000";
await using var conn = new NpgsqlConnection(cString);
await conn.OpenAsync();
string jsonContent = System.IO.File.ReadAllText("Data\\drugs.json");

// Deserialize the JSON content into a C# object
var jsonData = JsonConvert.DeserializeObject<Root>(jsonContent);

// Access the 'data' array
List<Drug> dataArray = jsonData.Data;

// Display the information from the 'data' array
Console.WriteLine("Drug Information:");
foreach (Drug d in dataArray)
{
    await using (var cmd = new NpgsqlCommand("insert into drugs (drugname,genericnames,dosetype,company) values (@value1, @value2, @value3, @value4)", conn))
    {
        cmd.Parameters.AddWithValue("@value1", d.drugname);
        cmd.Parameters.AddWithValue("@value2", d.genericnames);
        cmd.Parameters.AddWithValue("@value3", d.dosetype);
        cmd.Parameters.AddWithValue("@value4", d.company);
        cmd.ExecuteNonQueryAsync();
    }
}*/
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