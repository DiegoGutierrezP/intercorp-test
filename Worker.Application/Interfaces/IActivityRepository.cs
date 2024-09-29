using System;
using Worker.Domain.Entities;

namespace Worker.Application.Interfaces
{
    public interface IActivityRepository : IGenericRepository<Activity>
    {
        Task<Activity> GetLastActivity();
    }
}
