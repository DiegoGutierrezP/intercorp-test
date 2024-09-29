using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Application.Dtos;
using Worker.Domain.Entities;

namespace Worker.Application.Interfaces
{
    public interface IFileInformationRepository : IGenericRepository<FileInformation>
    {
        Task<FileInformation> GetLastFile();
        Task<PaginatedResponse<FileInformation>> GetAllPaginated(int pageNumber, int pageSize, string? regex = null);
    }
}
