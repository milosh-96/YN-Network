using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using YN_Network.Areas.Jokes.Models;

namespace YN_Network.Areas.Jokes.ViewModels
{
    public class JokesIndexViewModel
    {
        public ICollection<Joke> Jokes { get; set; }
        public bool FilteredByType { get; set; }
        public JokesIndexViewModel()
        {
            this.FilteredByType = false;
        }
    }
}
