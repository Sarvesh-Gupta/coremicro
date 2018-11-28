using System;
using System.Threading.Tasks;
using MicroCore.Services.Activities.Domain.Models;

namespace MicroCore.Services.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
         Task<Activity> GetAsync(Guid id);

         Task Add(Activity activity);
    }
}