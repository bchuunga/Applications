using Events.Core.Web.Constatnts.ApiClient;
using Events.Core.Web.Dtos;
using Events.Core.Web.Services.Interfaces;
using Newtonsoft.Json;

namespace Events.Core.Web.Services
{
    public class MeetupService : IMeetupService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public MeetupService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient(EventsCoreWebHttpClients.EventsCoreApiClient);
        }
        
        public async Task<IEnumerable<MeetupDto>> GetAll()
        {
            var response = await _client.GetAsync(EventsCoreMeetupEndpoints.GetAll);
            var apiContent = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<IEnumerable<MeetupDto>>(apiContent);
            
            if(results is not null)
            {
                return results;
            }
            return null;
        }

        public async Task<MeetupDto> GetById(int id)
        {
            var response = await _client.GetAsync(EventsCoreMeetupEndpoints.GetById.Replace("{id}", id.ToString()));
            var apiContent = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<MeetupDto>(apiContent);

            if (results is not null)
            {
                return results;
            }
            return null;
        }

        public async Task<IEnumerable<MeetupDto>> GetByUser(Guid userId)
        {
            var response = await _client.GetAsync(EventsCoreMeetupEndpoints.GetAll);
            var apiContent = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<IEnumerable<MeetupDto>>(apiContent);

            if (results is not null)
            {
                return results;
            }
            return null;
        }

        public async Task<MeetupDto> Update(MeetupDto meetupDto)
        {
            throw new NotImplementedException();
        }

        public async Task<MeetupDto> Create(MeetupDto meetupDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
