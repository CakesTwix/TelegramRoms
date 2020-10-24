using TelegramRoms.Data.Entities;
using TelegramRoms.Helpers;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramRoms.Handlers
{
    abstract class BaseHandler
    {
        public QueryContext Context { get; set; }

        protected TelegramBotClient client => Context.TelegramBotClient;

    }
}
