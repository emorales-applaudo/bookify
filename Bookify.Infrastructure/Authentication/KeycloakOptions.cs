using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Authentication
{
    public sealed class KeycloakOptions
    {
        public string AdminUrl { get; set; }
        public string TokenUrl { get; set; }
        public string AdminClientId { get; set; }
        public string AdminClientSecret { get; set; }
        public string AuthClientId { get; set; }
        public string AuthClientSecret { get; set; }
    }
}
