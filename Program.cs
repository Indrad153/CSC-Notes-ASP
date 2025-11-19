using Microsoft.EntityFrameworkCore;
using CSCNotes.DAL;
using CSCNotes.Repo;


var builder = WebApplication.CreateBuilder(args);


// Connection string needs to be degined in appsettngs.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<NotesDbContext>(options =>
options.UseSqlServer(connectionString));


builder.Services.AddScoped<INoteRepo, NoteRepo>();


builder.Services.AddControllersWithViews();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();


app.UseAuthorization();


app.MapControllerRoute(
name: "default",
pattern: "{controller=Notes}/{action=Index}/{id?}");

//Application URL can be defined in Launch.json for now its running on 5156 and 7022 port
app.Run();