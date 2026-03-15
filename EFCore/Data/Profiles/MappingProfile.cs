using AutoMapper;
using EFP48.EFCore.Data.Entity;
using EFP48.EFCore.Data.Profiles.ProductProfiles;

namespace EFP48.EFCore.Data.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductCardProfile>()
                .ForMember(dest => dest.CategoryName, opt =>
                {
                    opt.MapFrom((src, dest, destMember, context) =>
                    {
                        if (src.Category is null) return "no-category";
                        return src.Category.Name;
                    });
                });
        }
    }
}
