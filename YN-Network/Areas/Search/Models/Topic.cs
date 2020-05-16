using System;
namespace YN_Network.Areas.Search.Models
{
    public class Topic
    {
        public string FirstURL { get; set; }
        public string Text { get; set; }
        public string Result { get; set; }
        public Icon Icon { get; set; } = new Icon();
        public Topic()
        {
        }
    }

    public class Icon
    {
        public string URL { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
    }
}
