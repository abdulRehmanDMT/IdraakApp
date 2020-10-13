using IdraakApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace IdraakApp.Services
{
    public class HttpRequests
    {
        private HttpClientService httpClient;

        public HttpRequests()
        {
            httpClient = new HttpClientService();
        }

        public async Task<Response> GetLocationByIp()
        {
            Response response;

            try
            {
                string jsonResponse = await httpClient.GetAsync($"{ApiRoutes.MicUrls.IpInfoUrl}");

                response = new Response()
                {
                    Message = "Operation is successfull",
                    ResultData = jsonResponse,
                    Status = ResponseStatus.OK
                };
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Status = ResponseStatus.Error,
                    Message = ex.Message,
                    ResultData = null
                };
            }

            return response;
        }

        public async Task<Response> GetCountryDetailByCountryCode(string countryCode)
        {
            Response response;

            try
            {
                string jsonResponse = await httpClient.GetAsync($"{ApiRoutes.Base.BaseUrl}{ApiRoutes.IdraakCountries.GetCountryDetailByCountryCode}{countryCode}");

                response = new Response()
                {
                    Message = "Operation is successfull",
                    ResultData = jsonResponse,
                    Status = ResponseStatus.OK
                };
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Status = ResponseStatus.Error,
                    Message = ex.Message,
                    ResultData = null
                };
            }

            return response;
        }
    }
}
