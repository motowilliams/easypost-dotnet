using System;
using System.Net.Http;

namespace Easypost
{
    public interface IEncodable
    {
        FormUrlEncodedContent AsFormUrlEncodedContent();
    }
}