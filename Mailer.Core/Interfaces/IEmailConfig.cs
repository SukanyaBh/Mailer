using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Core.Interfaces
{
    public interface IEmailConfig
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
