using BlogApp.Data;
using BlogApp.Repositories;
using BlogApp.Repositories.Abstract;
using BlogApp.Repositories.Concrete;
using BlogApp.Services.Abstract;
using BlogApp.Services.Concrete;

namespace BlogApp.Extensions
{
    public static class ServicesExtensions
    {

        public static void AddServicesExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); //Generic ifade olduğu için bu şekilde yapıyoruz.
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IAccountService, AccountService>();


            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<IUserService, UserService>();
        }
    }
}
