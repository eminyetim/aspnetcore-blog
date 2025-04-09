using AutoMapper;
using BlogApp.DTOs.Blog;
using BlogApp.DTOs.Category;
using BlogApp.Entitiy;

namespace BlogApp.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CreateCategoryDto, Category>(); // CreateCategoryDto to Category and vice versa
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<Blog, BlogDetailDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.User.Username));
        }
    }

}
