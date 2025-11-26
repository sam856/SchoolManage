using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Feature.Authrntication.Queries.Model
{
    public class AuroizeQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}