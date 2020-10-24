using TelegramRoms.Data.Entities;
using TelegramRoms.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace TelegramRoms.Services.Implementations
{
    class ChatService: IChatService
    {
        private readonly IGlobalRepository _repository;

        public ChatService(IGlobalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Chat> FindChatAsync(long chatId)
        {
            return await _repository.FindAsync<Chat>(chatId);
        }


        public async Task RegisterChatAsync(long chatId)
        {
            try
            {

                Chat chat = new Chat()
                {
                   ChatId = chatId,
                };

                await _repository.AddAsync(chat);
            }
            catch(DbUpdateException)
            {
                throw new Exception("chat is already registered");
            }
        }

    }
}
