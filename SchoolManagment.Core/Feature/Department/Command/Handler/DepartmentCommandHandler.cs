using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Feature.Department.Command.Model;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Core.Feature.Department.Command.Handler
{
    public class DepartmentCommandHandler : ResponseHandler,
        IRequestHandler<AddDepartmentCommand, Response<string>>,
        IRequestHandler<UpdateDepartmentCommand, Response<string>>,
        IRequestHandler<DeleteDepartmentCommand, Response<string>>


    {

        #region   Feilds
        private readonly IDepartmentServices DepartmentServices;
        private readonly IMapper mapper;

        #endregion

        #region Constractor 
        public DepartmentCommandHandler(IDepartmentServices departmentServices, IMapper mapper)
        {


            DepartmentServices = departmentServices;
            this.mapper = mapper;
        }


        #endregion

        #region Handle Function 


        public async Task<Response<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Department = mapper.Map<SchoolManagement.Data.Entities.Department>(request);
            var result = await DepartmentServices.AddDepartment(Department);
            if (result != "Success")
            {
                return BadRequest<string>();
            }
            else
            {

                return Created("");


            }
        }

        public async Task<Response<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var daepartment = mapper.Map<SchoolManagement.Data.Entities.Department>(request);

            var result = await DepartmentServices.Update(daepartment);
            if (result != "Success")
            {
                return (BadRequest<string>());
            }
            else
            {
                return Success("Updated Successfully");
            }
        }


        public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.Id);
            var result = await DepartmentServices.DeleteById(request.Id);
            if (result == "Success")
                return Deleted<string>();

            else if (result == "Not Found")
            {
                return NotFound<string>();
            }
            return BadRequest<string>();
        }

        #endregion



    }
}

