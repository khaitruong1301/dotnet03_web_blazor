using System.Security.Claims;
using System.Text;
using Blazored.LocalStorage;
using dotnet03_web_blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Components.Authorization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//JWT
// 1. Đọc key, issuer và audience từ appsettings.json
var key = builder.Configuration["jwt:key"];           // Khóa bí mật để ký token
var issuer = builder.Configuration["jwt:issuer"];     // Issuer (bên phát hành token)
var audience = builder.Configuration["jwt:audience"]; // Audience (người nhận token)
Console.WriteLine($@"{key} - {issuer} - {audience}");

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // Xác thực key bí mật của token
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuer = true,// Xác thực Issuer 
                    ValidIssuer = issuer, // Phải khớp với Issuer trong token
                    ValidateAudience = true,    // Xác thực Audience
                    ValidAudience = audience, // Phải khớp với Audience trong token
                    ValidateLifetime = true, // Xác thực thời gian hết hạn của token
                    ClockSkew = TimeSpan.Zero, // Bỏ qua độ trễ thời gian giữa server và client (ngăn lỗi thời gian)
                    RoleClaimType = ClaimTypes.Role, // Ánh xạ claim role, (blazor auth client)
                    NameClaimType = ClaimTypes.Name,
                };
            });

//Xét cứng 2 quyền kiểm tra
builder.Services.AddAuthorization(options =>
{
          // Chính sách chỉ cho phép Admin truy cập
          options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
          // Chính sách chỉ cho phép User truy cập
          options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});
// 4. Thêm AuthorizationCore để sử dụng trong Blazor Components (Phần view)
builder.Services.AddAuthorizationCore();

//5. DI JWT service vừa tạo
builder.Services.AddScoped<JwtAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


// DI localstorage
builder.Services.AddBlazoredLocalStorage();

//DI service http
builder.Services.AddHttpClient();
//DI Các service tự tạo
builder.Services.AddScoped<StateNumberService>();
builder.Services.AddScoped<Burger>();
builder.Services.AddScoped<BurgerStateService>();
builder.Services.AddScoped<ProductStateService>();
builder.Services.AddScoped<ProductResfulService>();
builder.Services.AddScoped<RoomService>();


builder.Services.AddCors(option =>
{
    option.AddPolicy("allow_origin", policy =>
    {
        // policy.AllowAnyOrigin(); //Cho phép tất cả các client đều có thể gửi dữ liệu đến server
        policy.WithOrigins("http://127.0.0.1:5501", "*")
            .AllowAnyHeader() //Cho phép rq tất cả header
            .AllowAnyMethod() //Cho phép rq tất cả method (POST,PUT,GET,DELETE,OPTION)
            .AllowCredentials(); ////Cho phép cookie...
    });
});


//DI map controllers
builder.Services.AddControllers();
//Swagger
builder.Services.AddSwaggerGen();
//signalr
builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors("allow_origin");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSwagger();
app.UseSwaggerUI();

//Middle ware phân quyền
app.UseAuthentication();  //401 : lỗi xác thực
app.UseAuthorization(); //403: forbiden lỗi chưa đủ quyền

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//blazor hub server có sẵn khi tạo ứng dụng blazor
app.MapBlazorHub();
//hub ta tự tạo quản lý room
app.MapHub<RoomHub>("/roomhub");

app.MapFallbackToPage("/_Host");
app.MapControllers();

app.Run();
