using CRIF.CodeTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRIF.CodeTest2.API.Services
{
    public interface INovelService
    {
        Novel GetById(Guid Id);
        Task Save(Novel novel);
    }
}
