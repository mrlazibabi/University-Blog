using Microsoft.EntityFrameworkCore;
using University_Blog.Data;
using University_Blog.Repositories.Implement;
using University_Blog.Repositories;
using University_Blog.Services.Implement;
using University_Blog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add CORS
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//Add DbContext
builder.Services.AddDbContext<UniversityBlogContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityBlog"));
});

//Add Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Life Cycle DI : AddSingleton(). AddTransient(), AddScope()
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

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
