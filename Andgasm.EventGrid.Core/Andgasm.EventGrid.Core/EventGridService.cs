using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Andgasm.EventGrid.Core
{
    public class EventGridService<T>
    {
        public string Agent { get; set; }
        public string Endpoint { get; set; }
        public string Key { get; set; }

        public EventGridService(EventGridSettings settings)
        {
            Endpoint = settings.Endpoint;
            Key = settings.Key;
        }

        public async Task SendEventGridEvent(T resource, string eventtype)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("aeg-sas-key", Key);
            client.DefaultRequestHeaders.UserAgent.ParseAdd(Agent);

            var evts = new List<dynamic>();
            dynamic evt = new ExpandoObject();
            evt.Id = Guid.NewGuid().ToString();
            evt.Subject = eventtype;
            evt.EventType = eventtype;
            evt.EventTime = DateTime.Now;
            evt.Data = resource;
            evts.Add(evt);

            var payload = JsonConvert.SerializeObject(evts);
            var req = new HttpRequestMessage(HttpMethod.Post, Endpoint)
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };
            var resp = await client.SendAsync(req);
        }
    }
}
