using AutoMapper;
using BlogApp.DTOs.Blog;
using BlogApp.Entitiy;

namespace BlogApp.Mapping
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<CreateBlogDto, Blog>();
            CreateMap<UpdateBlogDto, Blog>();
            CreateMap<Blog, UpdateBlogDto>();
            CreateMap<UpdateBlogDto, Blog>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore()); // güncellenmeyecekse
        }
    }
}
