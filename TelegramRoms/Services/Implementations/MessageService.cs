using TelegramRoms.Data.Entities;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TelegramRoms.Services.Implementations
{
    class MessageService: IMessageService
    {
        private readonly IChatService _chatService;

        public MessageService(IChatService chatService)
        {
            _chatService = chatService;
        }

    }
}
