using Microsoft.AspNetCore.Mvc;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers;

public class MessagesController : Controller
{
    public IActionResult Index()
    {
        List<Message> messages = Message.GetMessages();
        return View(messages);
    }

    public IActionResult Details(int id)
    {
        Message message = Message.GetDetails(id);
        return View(message);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Message message)
    {
        Message.Post(message);
        return RedirectToAction("Index");
    }
}