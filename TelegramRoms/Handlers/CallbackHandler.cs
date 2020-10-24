using TelegramRoms.Attributes;
using TelegramRoms.Constants;
using TelegramRoms.Data.Entities;
using TelegramRoms.Helpers;
using TelegramRoms.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramRoms.Handlers
{
    class CallbackHandler: BaseHandler
    {
        private readonly IChatService _chatService;
        private readonly ILogger<CallbackHandler> _logger;
        private QueryCallbackContext callbackContext => Context as QueryCallbackContext;

        public CallbackHandler(IChatService chatService,
            ILogger<CallbackHandler> logger)
        {
            _chatService = chatService;
            _logger = logger;
        }
    }
}
