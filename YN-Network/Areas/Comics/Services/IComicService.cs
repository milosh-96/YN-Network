using System;
using YN_Network.Areas.Comics.Models;

namespace YN_Network.Areas.Comics.Services
{
    public interface IComicService
    {
        public Comic GetTodayComic();
    }
}
