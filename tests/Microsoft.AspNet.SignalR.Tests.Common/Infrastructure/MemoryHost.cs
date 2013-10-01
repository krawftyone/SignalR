using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Testing;
using Owin;

namespace Microsoft.AspNet.SignalR.Hosting.Memory
{
    public class MemoryHost : DefaultHttpClient, IDisposable
    {
        //private readonly CancellationTokenSource _shutDownTokenSource = new CancellationTokenSource();
        //private readonly CancellationToken _shutDownToken;
        //private string _instanceName;
        //private readonly Lazy<string> _defaultInstanceName;
        private TestServer _host;

        //public string InstanceName
        //{
        //    get
        //    {
        //        return _instanceName ?? _defaultInstanceName.Value;
        //    }
        //    set
        //    {
        //        _instanceName = value;
        //    }
        //}

        //public MemoryHost()
        //{
        //    _shutDownToken = _shutDownTokenSource.Token;
        //    _defaultInstanceName = new Lazy<string>(() => Process.GetCurrentProcess().GetUniqueInstanceName(_shutDownToken));
        //}

        public void Configure(Action<IAppBuilder> startup)
        {
            _host = TestServer.Create(startup);
        }


        protected override HttpMessageHandler CreateHandler(Client.IConnection connection)
        {
            return _host.Handler;
        }

        public void Dispose()
        {
            _host.Close();
        }

        //public void Initialize(Client.IConnection connection)
        //{
        //}

        //public async Task<Client.Http.IResponse> Get(string url, Action<Client.Http.IRequest> prepareRequest, bool isLongRunning)
        //{
        //    var uri = new Uri(url);
        //    string localUrl = uri.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped);
        //    HttpResponseMessage response = await _host.HttpClient.GetAsync(localUrl);
        //    return new HttpResponseMessageWrapper(response);
        //}

        //public Task<Client.Http.IResponse> Post(string url, Action<Client.Http.IRequest> prepareRequest, IDictionary<string, string> postData, bool isLongRunning)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Client.Http.IResponse> Get(string url)
        //{
        //    return Get(url, disableWrites: false);
        //}

        //public Task<Client.Http.IResponse> Get(string url, bool disableWrites)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Client.Http.IResponse> Post(string url, IDictionary<string, string> postData, bool isLongRunning)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
