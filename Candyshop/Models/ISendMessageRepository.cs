using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public interface ISendMessageRepository
    {
        public IEnumerable<SendMessage> GetAllMessages { get; }
        public void AddMessage(SendMessage sendMessage);
    }
}
