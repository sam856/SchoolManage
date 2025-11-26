using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Department.Queries.Model;
using SchoolManagment.Core.Result;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Department.Queries.Handler
{
    public class DepartmentHandlerQuery : ResponseHandler,
        IRequestHandler<GetAllDepartmentQuery, Response<List<DepartmentDto>>>,
                IRequestHandler<GetDepartmentByIdQuery, Response<DepartmentDto>>

    {
        #region feilds
        private readonly IDepartmentServices DepartmentServices;
        private readonly IMapper mapper;
        #endregion


        #region Constractor
        public DepartmentHandlerQuery(IDepartmentServices DepartmentServices, IMapper mapper)
        {
            this.DepartmentServices = DepartmentServices;
            this.mapper = mapper;
        }


        #endregion


        #region Handler Function


        public async Task<Response<List<DepartmentDto>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var Dapartments = await DepartmentServices.GetAll();
            var result = mapper.Map<List<DepartmentDto>>(Dapartments);
            return Success(result);
        }


        public async Task<Response<DepartmentDto>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var Dapartments = await DepartmentServices.GetById(request.Id);
            if (Dapartments == null)
            {
                return NotFound<DepartmentDto>();
            }

            var result = mapper.Map<DepartmentDto>(Dapartments);
            return Success(result);


        }
        #endregion


    }

}
