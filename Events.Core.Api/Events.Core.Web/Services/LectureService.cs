using Events.Core.Web.Constatnts.ApiClient;
using Events.Core.Web.Dtos;
using Events.Core.Web.Services.Interfaces;
using Newtonsoft.Json;

namespace Events.Core.Web.Services
{
    public class LectureService : ILectureService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public LectureService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient(EventsCoreWebHttpClients.EventsCoreApiClient);
        }
        
        public async Task<IEnumerable<LectureDto>> GetAll()
        {
            var response = await _client.GetAsync(EventsCoreLectureEndpoints.GetAll);
            var apiContent = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<IEnumerable<LectureDto>>(apiContent);

            if (results is not null)
            {
                return results;
            }
            return null;
        }

        public async Task<IEnumerable<LectureDto>> GetByMeetup(int meetupId)
        {
            var response = await _client.GetAsync(EventsCoreLectureEndpoints.GetByMeetup.Replace("{meetupId}", meetupId.ToString()));
            var apiContent = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<IEnumerable<LectureDto>>(apiContent);

            if (results is not null)
            {
                return results;
            }
            return null;
        }

        public async Task<LectureDto> GetById(int id)
        {
            var response = await _client.GetAsync(EventsCoreLectureEndpoints.GetById.Replace("{id}", id.ToString()));
            var apiContent = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<LectureDto>(apiContent);

            if (results is not null)
            {
                return results;
            }
            return null;
        }

        public async Task<LectureDto> Update(LectureDto lectureDto)
        {
            throw new NotImplementedException();
        }

        public async Task<LectureDto> PostLecture(LectureDto lectureDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
