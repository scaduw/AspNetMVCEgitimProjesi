var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Uygulamada MVC controller view yapısını kullanacağız

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // http den https ye otomatik yönlendire yap
app.UseStaticFiles(); // Uygulamada statik doyalar(wwwroot içerisindekiler) kullanılabilsin

app.UseRouting(); // Uygulamada Routing mekanizmasını aktif et

app.UseAuthentication(); // Uygulamada oturum açma işlemini aktif et
app.UseAuthorization(); // Uygulamada yetkilendirme kullanımını aktif et

app.MapControllerRoute( // uygulamada kullanacağımız routing yapısı
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Eğer birden fazla routing kullanacaksak bu alana ekleyebiliriz
app.Run(); // Uygulamayı çalıştır
