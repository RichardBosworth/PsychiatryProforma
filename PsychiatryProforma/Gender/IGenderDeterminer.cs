using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace PsychiatryProforma.Gender
{
    public interface IGenderDeterminer
    {
        bool IsNameMale( string forename );
    }

    public class WebApiGenderDeterminer : IGenderDeterminer
    {
        public bool IsNameMale( string forename )
        {
            string url = "https://gender-api.com/get";

            RestClient restClient = new RestClient(url);
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddQueryParameter("name", forename);
            restRequest.AddQueryParameter("key", "wTyAbPEjSJKLzKDCVe");
            var restResponse = restClient.Execute<GenderAPIResult>(restRequest);
            var restResponseData = restResponse.Data;
            if ( restResponseData.gender.ToLower() == "male" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class GenderAPIResult
    {
        public string name { get; set; }
        public string gender { get; set; }

        public int accuracy { get; set; }
    }
}