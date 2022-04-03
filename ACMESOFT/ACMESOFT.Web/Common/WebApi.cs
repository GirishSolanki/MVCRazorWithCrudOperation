using ACMESOFT.Common;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
public class WebApi
{
    private string ApiUrl { get; set; }

    public WebApi(string apiUrls)
    {
        ApiUrl = apiUrls;
    }

    public GenericResponse<T> CallApi<T>(string apiName, dynamic parameter, string token = "") where T : class
    {
        string jsonParameter = string.Empty;

        if (parameter != null)
        {
            jsonParameter = JsonConvert.SerializeObject(parameter);
        }
        else
        {
            jsonParameter = JsonConvert.SerializeObject("{  }");
        }

        var result = CallApi(ApiUrl, apiName, jsonParameter, token);

        var apiResponse = JsonConvert.DeserializeObject<GenericResponse<T>>(result);

        return apiResponse;
    }
    private string SendURI(Uri baseAddress, HttpContent content, string token = "")
    {
        var response = string.Empty;
        using (var client = new HttpClient())
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = baseAddress,
                Content = content

            };

            if (!string.IsNullOrEmpty(token))
            {
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            HttpResponseMessage result = client.SendAsync(request).Result;
            var responseContent = result.Content.ReadAsStringAsync().Result;
            response = responseContent;
        }
        return response;
    }

    private string CallApi(string apiUrl, string apiName, string parameter, string token = "")
    {
        Uri u = new Uri(apiUrl + apiName);

        var payload = "";

        if (!string.IsNullOrEmpty(parameter))
        {
            payload = parameter;
        }

        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
        string strResponse = SendURI(u, c, token);
        return strResponse;
    }
}

