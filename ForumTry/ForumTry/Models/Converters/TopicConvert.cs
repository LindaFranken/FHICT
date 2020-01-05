using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry.Models.Converters
{
    public class TopicConvert
    {
        public Topic ConvertToModel(TopicViewModel tvm)
        {
            Topic t = new Topic();
            {
                t.Id = tvm.Id;
                t.Title = tvm.Title;
                t.Content = tvm.Content;
                t.Created = tvm.Created;
                t.ForumID = tvm.ForumID;
                t.Reply = tvm.Reply;
                t.Username = tvm.Username;
            }
            return t;
        }

        public TopicViewModel ConvertToViewModel(Topic t)
        {
            TopicViewModel tvm = new TopicViewModel();
            {
                tvm.Id = t.Id;
                tvm.Title = t.Title;
                tvm.Content = t.Content;
                tvm.Created = t.Created;
                tvm.ForumID = t.ForumID;
                tvm.Reply = t.Reply;
                tvm.Username = t.Username;
            }
            return tvm;
        }
    }
}
