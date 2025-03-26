
using mDBConn.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<IProductRepository,ProductRepository>();
builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<ICartRepository,CartRepository>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<IUserRepository,UserRepository>();
builder.Services.AddSingleton<UserDetailsService>();
builder.Services.AddSingleton<IUserDetailsRepository,UserDetailsRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200","http://localhost:3000","https://gracemart-frontend-build.vercel.app/") // Another localhost
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
var app = builder.Build(); 
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseStaticFiles();
app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


