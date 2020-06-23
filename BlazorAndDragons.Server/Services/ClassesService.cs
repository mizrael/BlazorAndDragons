using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorAndDragons.Server.HttpClients;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace BlazorAndDragons.Server.Services
{
    public class ClassesService : Classes.ClassesBase
    {
        private readonly IDnDClient _client;

        public ClassesService(IDnDClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public override async Task<GetAllResponse> GetAll(Empty request, ServerCallContext context)
        {
            var classes = await _client.GetAllClassesAsync();
            
            var result = new GetAllResponse();
            result.Data.AddRange(classes.Results.Select(c => new GetAllResponse.Types.ClassArchiveItem()
            {
                Id = c.Index,
                Name = c.Name
            }));

            return result;
        }

        public override async Task<GetDetailsResponse> GetDetails(GetDetailsRequest request, ServerCallContext context)
        {
            var details = await _client.GetClassAsync(request.Id);
            if (null == details)
                return null;
            var result = new GetDetailsResponse()
            {
                Id = details.Index,
                Name = details.Name,
                HitDie = details.Hit_Die
            };
            if(null != details.Proficiencies)
                result.Proficiencies.AddRange(details.Proficiencies.Select(p => new GetDetailsResponse.Types.Proficiency()
                {
                    Name = p.Name
                }));

            return result;
        }
    }
}
