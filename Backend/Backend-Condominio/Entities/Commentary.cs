using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Entities
{
    public class Commentary
    {
        public int Id { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public int CoversationTopicId { get; set; }

        public ConversationTopic ConversationTopic { get; set; }

    }
}
