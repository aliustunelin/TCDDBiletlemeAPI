using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
}

var app = builder.Build();

{
    // yukarıdan aşağıya iner burası adım adım ve error kısmı yakalar hatatyı, errorcontroller.cs içinden -> ErrorController.cs
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}



