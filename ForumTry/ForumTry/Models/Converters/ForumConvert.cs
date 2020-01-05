using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry.Models.Converters
{
    public class ForumConvert
    {
        public Forum ConvertToModel(ForumViewModel fvm)
        {
            Forum f = new Forum();
            {
                f.Id = fvm.Id;
                f.Title = fvm.Title;
                f.Description = fvm.Description;
            }
            return f;
        }

        public ForumViewModel ConvertToViewModel(Forum f)
        {
            ForumViewModel fvm = new ForumViewModel();
            {
                fvm.Id = f.Id;
                fvm.Title = f.Title;
                fvm.Description = f.Description;
            }
            return fvm;
        }
    }
}
