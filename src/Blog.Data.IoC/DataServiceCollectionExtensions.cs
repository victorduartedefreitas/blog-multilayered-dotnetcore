using Blog.Data.Components.Repository;
using Blog.Data.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
