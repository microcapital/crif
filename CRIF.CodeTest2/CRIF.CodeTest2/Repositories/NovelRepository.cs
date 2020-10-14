using CRIF.CodeTest2.API.Contexts;
using CRIF.CodeTest2.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRIF.CodeTest2.API.Repositories
{
    public class NovelRepository : INovelRepository
    {
        private readonly IServiceScope _scope;
        private readonly NovelDatabaseContext _databaseContext;
        public NovelRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();

            _databaseContext = _scope.ServiceProvider.GetRequiredService<NovelDatabaseContext>();
        }

        public async Task<bool> Create(Novel novel)
        {
            var success = false;

            _databaseContext.Novels.Add(novel);

            var numberOfItemsCreated = await _databaseContext.SaveChangesAsync();

            if (numberOfItemsCreated == 1)
                success = true;
            return success;
        }


        public async Task<bool> Update(Novel novel)
        {
            var success = false;

            var existingNovel= Get(novel.Id);

            if (existingNovel != null)
            {
                existingNovel.Title = novel.Title;
                existingNovel.Name= novel.Name;

                _databaseContext.Novels.Attach(existingNovel);

                var numberOfItemsUpdated = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsUpdated == 1)
                    success = true;
            }

            return success;
        }
        public Novel Get(Guid id)
        {
            var result = _databaseContext.Novels
                                .Where(x => x.Id == id)
                                .FirstOrDefault();
            return result;
        }

    }
}
