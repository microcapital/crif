using CRIF.CodeTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRIF.CodeTest2.API.Repositories
{
    public interface INovelRepository
    {
        Novel Get(Guid Id);
        Task<bool> Create(Novel novel);
        Task<bool> Update(Novel novel);
    }
}
