using AutoMapper;
using WebAPI.HomeTask.NorthwindService.Data.Entities;
using WebAPI.HomeTask.NorthwindService.ViewModels;

namespace WebAPI.HomeTask.NorthwindService.Services
{
	public class MappingRules : Profile
	{
		public MappingRules()
		{
			CreateMap<CategoryVM, Category>()
				.ForMember(entity => entity.CategoryName, o => o.MapFrom(vm => vm.Name))
				.ForMember(entity => entity.CategoryId, o => o.MapFrom(vm => vm.Id));

			CreateMap<Category, CategoryVM>()
				.ForMember(vm => vm.Name, o => o.MapFrom(entity => entity.CategoryName))
				.ForMember(vm => vm.Id, o => o.MapFrom(entity => entity.CategoryId));

			CreateMap<CategoryInsertVM, Category>()
				.ForMember(entity => entity.CategoryName, o => o.MapFrom(vm => vm.Name));

			CreateMap<CategoryUpdateVM, Category>()
				.ForMember(entity => entity.CategoryName, o => o.MapFrom(vm => vm.Name));

			CreateMap<ProductVM, Product>()
				.ForMember(entity => entity.ProductId, o => o.MapFrom(vm => vm.Id));

			CreateMap<Product, ProductVM>().DisableCtorValidation()
				.ForMember(vm => vm.Id, o => o.MapFrom(entity => entity.ProductId));

			CreateMap<ProductInsertVM, Product>();
			CreateMap<ProductUpdateVM, Product>();
		}
	}
}
