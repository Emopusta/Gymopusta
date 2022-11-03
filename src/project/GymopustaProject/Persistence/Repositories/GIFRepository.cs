using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GIFRepository : EfRepositoryBase<GIF, BaseDbContext>, IGIFRepository
    {
        public GIFRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
