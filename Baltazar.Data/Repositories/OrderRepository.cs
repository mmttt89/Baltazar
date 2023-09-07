using System;
using Baltazar.Entity.Entities;

namespace Baltazar.Data.Repositories
{
	public class OrderRepository: BaseRepository<Order>
	{
		public OrderRepository(BaltazarDbContext context) : base(context)
		{
		}
	}
}

