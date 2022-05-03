using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastRentACar.Domain.AppSettings
{
    public class Settings
    {
        public JWTSettings JWTSettings { get; set; }

        public RSASettings RSASettings { get; set; }

        public SMTPSettings SMTPSettings { get; set; }

        public WebSiteSettings WebSiteSettings { get; set; }
    }
}
