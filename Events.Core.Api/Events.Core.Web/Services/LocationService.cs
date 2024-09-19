using Events.Core.Web.Constatnts.ApiClient;
using Events.Core.Web.Dtos;
using Events.Core.Web.Services.Interfaces;
using Newtonsoft.Json;

namespace Events.Core.Web.Services
{
    public class LocationService : ILocationService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public LocationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient(EventsCoreWebHttpClients.EventsCoreApiClient);
        }

        public async Task<IEnumerable<LocationDto>> GetAll()
        {
            var response = await _client.GetAsync(EventsCoreLocationEndpoints.GetAll);
            var apiContent = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<IEnumerable<LocationDto>>(apiContent);

            if (results is not null)
            {
                return results;
            }
            return null;
        }

        public async Task<IEnumerable<LocationDto>> GetByMeetup(int meetupId)
        {
            var response = await _client.GetAsync(EventsCoreLocationEndpoints.GetByMeetup.Replace("{meetupId}", meetupId.ToString()));
            var apiContent = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<IEnumerable<LocationDto>>(apiContent);

            if (results is not null)
            {
                return results;
            }
            return null;
        }

        public async Task<LocationDto> GetById(int id)
        {
            var response = await _client.GetAsync(EventsCoreLocationEndpoints.GetById.Replace("{id}", id.ToString()));
            var apiContent = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<LocationDto>(apiContent);

            if (results is not null)
            {
                return results;
            }
            return null;
        }

        public async Task<LocationDto> Update(LocationDto locationDto)
        {
            throw new NotImplementedException();
        }

        public async Task<LocationDto> Create(LocationDto locationDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
