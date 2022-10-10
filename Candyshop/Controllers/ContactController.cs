using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISendMessageRepository _sendMessageRepository;
        public ContactController(ISendMessageRepository sendMessageRepository)
        {
            _sendMessageRepository = sendMessageRepository;
        }
        public IActionResult Index()
        {
            var newSendMessageViewModel = new SendMessageViewModel();
            return View(newSendMessageViewModel);
        }
        public IActionResult CreateMessage(SendMessageViewModel sendMessageVM)
        {
            _sendMessageRepository.AddMessage(sendMessageVM.SendMessage);
            return RedirectToAction(nameof(MessageSend));
        }

        public IActionResult MessageSend()
        {
            return View();
        }
    }
}
