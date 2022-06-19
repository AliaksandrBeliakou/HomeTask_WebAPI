namespace WebAPI.HomeTask.NorthwindService.Services
{
	public static class EnumerableHalperExtentions
	{
		public static IEnumerable<TEntity> GetPage<TEntity> (this IEnumerable<TEntity> source, int pageNumber, int count)
		{
			if (source is null)
			{
				throw new ArgumentNullException (nameof (source));
			}

			if (pageNumber < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number cant be less one.");
			}

			if (count < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(count), "Product count on page cant be less one.");
			}

			return source.Skip((pageNumber - 1) * count).Take(count);
		}
	}
}
