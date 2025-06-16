using dotnet03_web_blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//DI service http
builder.Services.AddHttpClient();
//DI Các service tự tạo
builder.Services.AddScoped<StateNumberService>();
builder.Services.AddScoped<Burger>();
builder.Services.AddScoped<BurgerStateService>();
builder.Services.AddScoped<ProductStateService>();
builder.Services.AddScoped<ProductResfulService>();
builder.Services.AddScoped<RoomService>();


builder.Services.AddCors(option=>{
    option.AddPolicy("allow_origin", policy => {
        // policy.AllowAnyOrigin(); //Cho phép tất cả các client đều có thể gửi dữ liệu đến server
        policy.AllowAnyOrigin()
            .AllowAnyHeader() //Cho phép rq tất cả header
            .AllowAnyMethod(); //Cho phép rq tất cả method (POST,PUT,GET,DELETE,OPTION)
            // .AllowCredentials(); ////Cho phép cookie...
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
