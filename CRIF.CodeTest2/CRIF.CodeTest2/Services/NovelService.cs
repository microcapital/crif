using CRIF.CodeTest2.API.Repositories;
using CRIF.CodeTest2.Models;
using System;
using System.Threading.Tasks;

namespace CRIF.CodeTest2.API.Services
{
    public class NovelService: INovelService
    {
        private readonly INovelRepository _novelRepository;
        public NovelService(INovelRepository novelRepository)
        {
            _novelRepository = novelRepository;
        }

        public async Task Save(Novel novel)
        {
           var noveStored= GetById(novel.Id);
            if( noveStored!=null)
             await _novelRepository.Update(novel);
            await _novelRepository.Create(novel);
        }

        public Novel GetById(Guid id)
        {
            var result = _novelRepository.Get(id);

            return result;
        }

    }
}
