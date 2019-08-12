using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts.Models
{
    public class EmailAttachment
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
