using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Application.Interfaces;
using Worker.Domain.Entities;
using Worker.Infrastructure.Context;

namespace Worker.Infrastructure.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Activity?> GetLastActivity()
        {
            return await this.DbSet.OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();
        }
    }
}
