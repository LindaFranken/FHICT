using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry.Models.Converters
{
    public class TopicToListConvert
    {
        public Topic ConvertToModel(TopicViewModel tvm)
        {
            Topic t = new Topic();
            {
                t.Title = tvm.Title;
                t.Content = tvm.Content;

            }
            return t;
        }

        public TopicViewModel ConvertToViewModel(Topic t)
        {
            TopicViewModel tvm = new TopicViewModel();
            {
                tvm.Title = t.Title;
                tvm.Content = t.Content;
            }
            return tvm;
        }
    }
}
