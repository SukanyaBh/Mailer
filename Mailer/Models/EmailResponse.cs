using System;
using System.Collections.Generic;
using System.Text;
using static Mailer.Enums;

namespace Mailer.Models
{
    public class EmailResponse
    {
        public Status SentStatus { get; set; }
    }
}
