using Azure.Blob.Web.Sample.Models;
using Microsoft.AspNetCore.Mvc;

namespace Azure.Blob.Web.Sample.Controllers
{
    public class QueueController : Controller
    {
        public QueueController(IQueueStorage _queueStorage)
        {
            QueueStorage = _queueStorage;
        }

        public IQueueStorage QueueStorage { get; }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string Message)
        {
            await QueueStorage.WriteMessage(Message);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var message = await QueueStorage.ReadMessage();


            return Ok(message.Body.ToString());
        }
    }
}
