using System.Collections.Generic;

namespace blokklist_api
{
    public class Configuration
    {
        private string _authToken;
        private Dictionary<string, string> _headers;
        private string _userAgent;

        public Configuration(string authToken, string userAgent)
        {
            _authToken = authToken;
            _userAgent = userAgent;
            _headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Authorization", $"Bearer {_authToken}" },
                { "User-Agent", _userAgent }

            };
        }

        public IReadOnlyDictionary<string, string> GetHeaders() => _headers;
    }
}
