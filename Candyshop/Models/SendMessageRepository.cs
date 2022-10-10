using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public class SendMessageRepository : ISendMessageRepository
    {
        private readonly AppDbContext _appDbContext;
        public SendMessageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<SendMessage> GetAllMessages
        {

            get
            {
                return _appDbContext.SendMessages;
            }

        }
        public void AddMessage(SendMessage sendMessage)
        {
            _appDbContext.SendMessages.Add(sendMessage);
            _appDbContext.SaveChanges();
        }
    }
}
