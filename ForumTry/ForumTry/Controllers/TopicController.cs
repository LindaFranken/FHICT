using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumTry.Models;
using ForumTry.Context.Interfaces;
using ForumTry.Models.Converters;
using Microsoft.AspNetCore.Http;

namespace ForumTry.Controllers
{
    public class TopicController : Controller
    {

        private TopicRepository tr;

        public TopicController(TopicRepository tr)
        {
            this.tr = tr;
        }

        public IActionResult Post(int id)
        {
            TopicConvert tc = new TopicConvert();

            Topic topic = tr.GetByID(id);
            TopicViewModel tvm = tc.ConvertToViewModel(topic);
            tvm.Id = id;
            tvm.replies = tr.GetAllReplies(id);

            return View(tvm);
        }

        public IActionResult Index(int id)
        {
            TopicViewModel tvm = new TopicViewModel();
            tvm.ForumID = id;
            tvm.topicList = tr.GetAll(id);

            return View(tvm);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            TopicViewModel tv = new TopicViewModel();
            tv.ForumID = id;

            return View(tv);
        }

        [HttpPost]
        public IActionResult Create(TopicViewModel tvm)
        {
            TryValidateModel(tvm);
            TopicConvert tc = new TopicConvert();
            Topic t = tc.ConvertToModel(tvm);
            t.Username = HttpContext.Session.GetString("Username");
            tr.Create(t);

            return RedirectToAction("Post", "Topic", new { id = t.Id });
        }

        [HttpPost]
        public IActionResult Reactie(TopicViewModel tvm)
        {
            TryValidateModel(tvm);
            tr.Reply(tvm.Reply, tvm.Id);

            return RedirectToAction("Post", "Topic", new { id = tvm.Id});
        }
    }
}