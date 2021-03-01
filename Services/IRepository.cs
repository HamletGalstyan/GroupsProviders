using GroupsProviders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupsProviders.Services
{
    public interface IRepository
    {
        Task<List<GroupsViewModel>> GetGroups();
    }
}
