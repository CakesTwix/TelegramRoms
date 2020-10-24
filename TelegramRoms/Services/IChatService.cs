using TelegramRoms.Data.Entities;
using System.Threading.Tasks;

namespace TelegramRoms.Services
{
    interface IChatService
    {
        Task<Chat> FindChatAsync(long chatId);
        Task RegisterChatAsync(long chatId);
    }
}
