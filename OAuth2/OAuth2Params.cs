using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2
    {
    class OAuth2Params
        {
        // Set the ListenPort = 0 to let Chilkat randomly select an unused port.
        public int ListenPort { get; set; }

        public string AuthorizationEndpoint { get; set; }
        public string TokenEndpoint { get; set; }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public string Scope { get; set; }
        }
    }
