using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.WebUI.Tests.Mocks
{
    public class MockHttpConext : HttpContextBase
    {
        private MockRequest request;
        private MockResponse response;
        private HttpCookieCollection cookies;

        public MockHttpConext()
        {
            this.cookies = new HttpCookieCollection();
            this.response = new MockResponse(cookies);
            this.request = new MockRequest(cookies);
        }

        public override HttpRequestBase Request
        {
            get {
                return this.request;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return this.response;
            }
        }
    }

    public class MockResponse : HttpResponseBase
    {
        private readonly HttpCookieCollection cookies;

        public MockResponse(HttpCookieCollection cookies)
        {
            this.cookies = cookies;
        }

        public override HttpCookieCollection Cookies 
        {
            get {
                return this.cookies;
            }
        }
    }

    public class MockRequest : HttpRequestBase
    {
        private readonly HttpCookieCollection cookies;

        public MockRequest(HttpCookieCollection cookies)
        {
            this.cookies = cookies;
        }

        public override HttpCookieCollection Cookies
        {
            get
            {
                return this.cookies;
            }
        }
    }
}
