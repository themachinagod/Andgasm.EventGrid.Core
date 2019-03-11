using System;
using System.Collections.Generic;
using System.Text;

namespace Andgasm.EventGrid.Core
{
    public class EventGridSettings
    {
        public string Endpoint { get; set; }
        public string Key { get; set; }

        public EventGridSettings(string endpoint, string key)
        {
            Endpoint = endpoint;
            Key = key;
        }
    }
}
