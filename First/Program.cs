using First.Data;
using First.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;

//*builder allows you create different object wit same constructor
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));


//*Scoped dependency injection , means that this will get created everytime it request is made
builder.Services.AddScoped<IActorService,ActorService>();
//*so before creating the actual instance we're  configuring the necessary thing
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//*serving the static files
app.UseStaticFiles();


//*routing 
app.UseRouting();

//*
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
AppDbInitializercs.Seed(app);
app.Run();


/*const express = require('express');
const app = express();
const path = require('path');
const { Pool } = require('pg');

// Middleware for JSON parsing
app.use(express.json());

// Serve static files
app.use(express.static (path.join(__dirname, 'public')));

// Database connection
const pool = new Pool({
  connectionString: process.env.DATABASE_URL,
});

// Route handling
app.get('/', (req, res) => {
    res.send('Home Page');
});

app.use((err, req, res, next) => {
    // Error handling middleware
    res.status(500).send('Something broke!');
});

// Start server
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
console.log(`Server is running on port ${ PORT}`);
});
*/