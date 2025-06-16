namespace Demo_Lec2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            /* Custome Middlewares */
            //app.Use(async (HttpContext, next) =>
            //{
            //    await HttpContext.Response.WriteAsync("1/MiddleWare1\n");
            //    await next();
            //    await HttpContext.Response.WriteAsync("5/Middleware1\n");
            //});
            //app.Use(async (HttpContext, next) =>
            //{
            //    await HttpContext.Response.WriteAsync("2/Middleware2\n");
            //    await next();
            //    return; // Short Circuiting
            //    await HttpContext.Response.WriteAsync("4/Middleware2\n");
            //});
            //app.Run(async HttpContext =>
            //{
            //    await HttpContext.Response.WriteAsync("3/End of Pipeline\n");
            //});
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
