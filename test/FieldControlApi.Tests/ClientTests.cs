using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Tests
{
    /*
        [ ] Authenticate should set _authenticationToken when ok
        [ ] Authenticate should throws AuthenticationException when fail

        [ ] SetAuthenticationToken should set request.Token when _authenticationToken is not null
        [ ] SetAuthenticationToken should throws ClientNotAuthenticatedException when _authenticationToken is null or empty

        [ ] Send should call _httpRequester.ExecuteRequest
    */

    [TestFixture]
    public class ClientTests
    {
       
    }
}
