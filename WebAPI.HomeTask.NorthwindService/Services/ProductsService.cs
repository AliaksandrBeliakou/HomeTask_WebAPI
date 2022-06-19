using AutoMapper;
using WebAPI.HomeTask.NorthwindService.Data.Entities;
using WebAPI.HomeTask.NorthwindService.Services;
using WebAPI.HomeTask.NorthwindService.Services.Interfaces;
using WebAPI.HomeTask.NorthwindService.ViewModels;
using WebAPI.HomeTaskRopositories.Interfaces;

namespace WebAPI.HomeTaskServices
{
	public class ProductsService : IProductsService
	{
		private readonly IProductsRepository productsRepository;
		private readonly IMapper mapper;

		public ProductsService(IProductsRepository productsRepository, IMapper mapper)
		{
			this.productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
			this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public int Add(ProductInsertVM product)
		{
			if (product is null)
			{
				throw new ArgumentNullException(nameof(product));
			}

			var entity = mapper.Map<Product>(product);
			productsRepository.Add(entity);
			return entity.ProductId;
		}

		public ProductVM GetProductById(int id)
		{
			var product = productsRepository.GetById(id);
			return mapper.Map<ProductVM>(product);
		}

		public IEnumerable<ProductVM> GetProducts(int pageNumber, int count)
		{
			return productsRepository.GetAll().GetPage(pageNumber, count).Select(p => mapper.Map<ProductVM>(p));
		}

		public IEnumerable<ProductVM> GetProductsByCategory(int categoryId, int pageNumber, int count)
		{
			return productsRepository.GetAll()
				.Where(p => p.CategoryID == categoryId)
				.GetPage(pageNumber, count)
				.Select(p => mapper.Map<ProductVM>(p));
		}

		public void Remove(int id)
		{
			productsRepository.Delete(id);
		}

		public void Update(ProductVM product)
		{
			if (product is null)
			{
				throw new ArgumentNullException(nameof(product));
			}

			productsRepository.Update(mapper.Map<Product>(product));
		}
	}
}
