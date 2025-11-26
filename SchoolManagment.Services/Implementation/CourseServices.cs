using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Services.Implementation
{
    public class CourseServices : ICourseServices
    {
        #region Fields
        private readonly ICourseRepositiry _courseRepositiry;
        #endregion



        #region Constractor 

        public CourseServices(ICourseRepositiry courseRepositiry)
        {
            _courseRepositiry = courseRepositiry;
        }

        #endregion




        #region Handle Functions


        public async Task<string> DeleteAsync(int id)

        {

            var trans = _courseRepositiry.BeginTransaction();
            var result = await _courseRepositiry.DeleteAsync(id);
            if (!result)
            {
                await trans.RollbackAsync();
                return "Faild";
            }

            await trans.CommitAsync();
            return "Success";
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _courseRepositiry.GetAllAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _courseRepositiry.GetByIdAsync(id);
        }


        public async Task<bool> ISCodeExist(string name)
        {
            return await _courseRepositiry.ISCodeExist(name);
        }


        public async Task<string> UpdateAsync(Course course)
        {
            var result = _courseRepositiry.UpdateAsync(course);

            if (result != null)
            {
                return "Updated Successfully";
            }
            else
            {
                return "Update Failed";
            }
        }


        public async Task<string> AddAsync(Course course)
        {
            var result = await _courseRepositiry.AddAsync(course)
                ;
            if (result != null)
            {
                return "Added Successfully";
            }
            else
            {
                return "Add Failed";
            }
        }


        #endregion


    }
}
