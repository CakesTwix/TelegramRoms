using TelegramRoms.Attributes;
using TelegramRoms.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace TelegramRoms.Handlers
{
    class MessageHandler: BaseHandler
    {
        private readonly IChatService _chatService;
        private readonly IMessageService _messageService;
        private readonly ILogger<MessageHandler> _logger;

        public MessageHandler(IChatService chatService, IMessageService messageService, ILogger<MessageHandler> logger)
        {
            _chatService = chatService;
            _messageService = messageService;   
            _logger = logger;
        }

        [Registered]
        [Command("/ping", "/test")]
        public async Task EchoCommandAsync()
        {
            await client.SendChatActionAsync(Context.Message.Chat.Id, ChatAction.Typing);
            await client.SendTextMessageAsync(Context.Message.Chat.Id, "pong");
        }

        [Command("/start")]
        public async Task StartCommandAsync()
        {
            try
            {
                await _chatService.RegisterChatAsync(Context.Message.Chat.Id);
            }
            catch (Exception e)
            {
                await client.SendTextMessageAsync(Context.Message.Chat.Id, e.Message);
                _logger.LogError(e.Message);
            }
        }
    }
}
