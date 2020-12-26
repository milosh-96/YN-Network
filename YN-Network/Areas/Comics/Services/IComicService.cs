using System;
using System.Threading.Tasks;
using YN_Network.Areas.Comics.Models;

namespace YN_Network.Areas.Comics.Services
{
    public interface IComicService
    {
        public Task<Comic> GetTodayComic();
    }
}
