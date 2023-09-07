using System;
using Baltazar.Entity.Entities;

namespace Baltazar.Data.Repositories
{
	public class ProductRepository: BaseRepository<Product>
	{
		public ProductRepository(BaltazarDbContext context) : base(context)
		{
		}
	}
}

