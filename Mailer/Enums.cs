using System;
using System.Collections.Generic;
using System.Text;

namespace Mailer
{
    public class Enums
    {
        public enum BodyType
        {
            HTML=0,
            Text
        }

        public enum Status
        {
            Sent=0,
            NotSent
        }
    }
}
