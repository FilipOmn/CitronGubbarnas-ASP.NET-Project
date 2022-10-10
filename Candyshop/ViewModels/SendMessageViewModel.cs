using Candyshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.ViewModels
{
    public class SendMessageViewModel
    {
        public SendMessage SendMessage { get; set; }
        public IEnumerable<SendMessage> SendMessages { get; set; }
    }

}
