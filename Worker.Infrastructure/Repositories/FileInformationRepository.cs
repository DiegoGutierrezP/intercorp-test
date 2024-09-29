using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Application.Dtos;
using Worker.Application.Extensions;
using Worker.Application.Interfaces;
using Worker.Domain.Entities;
using Worker.Infrastructure.Context;

namespace Worker.Infrastructure.Repositories
{
    public class FileInformationRepository : GenericRepository<FileInformation>, IFileInformationRepository
    {
        public FileInformationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<FileInformation?> GetLastFile()
        {
            return await this.DbSet.OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task<PaginatedResponse<FileInformation>> GetAllPaginated(int pageNumber, int pageSize, string regex = null)
        {
            var query = this.DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(regex))
                query = query.Where(x => EF.Functions.Like(x.RegEx, $"{regex}%"));

            var totalCount = await query.CountAsync();
           
            var items = await query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResponse<FileInformation>
            {
                Items = items,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                CurrentPage = pageNumber
            };
        }
    }
}
