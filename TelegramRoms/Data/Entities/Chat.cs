using System.ComponentModel.DataAnnotations;

namespace TelegramRoms.Data.Entities
{
    class Chat
    {
        [Key]
        public long ChatId { get; set; }
    }
}
