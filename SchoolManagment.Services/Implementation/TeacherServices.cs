using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagment.Services.Abstract;
using SchoolManagment.Services.Abstract.AuthServices;

namespace SchoolManagment.Services.Implementation
{

    public class TeacherServices : ITeacherSevice
    {
        #region Fields

        private readonly ITeacherRepositiryCls _teacherRepositiry;
        private readonly ITeacherAssigment _teacherAssigment;
        private readonly ITeacherAttendence _teacherAttendence;
        private readonly ICurrentUserServices currentUserServices;

        #endregion
        #region Constractor

        public TeacherServices(ITeacherRepositiryCls _teacherRepositiry, ITeacherAssigment _teacherAssigment, ITeacherAttendence _teacherAttendence, ICurrentUserServices currentUserServices)
        {
            this._teacherRepositiry = _teacherRepositiry;
            this._teacherAssigment = _teacherAssigment;
            this._teacherAttendence = _teacherAttendence;
            this.currentUserServices = currentUserServices;
        }


        #endregion
        #region Methods 



        public async Task<string> AddAssigment(Assignment assignment)
        {

            var teacherId = currentUserServices.GetUserId();

            var isOwner = await _teacherRepositiry.IsTeacherOwnClass(assignment.ClassId, teacherId);
            if (!isOwner)
                return "UnUothrized";

            assignment.CreatedByTeacherId = teacherId;

            var result = await _teacherAssigment.AddAsync(assignment);

            if (result == null)
                return "Failed to add assignment.";

            return "Assignment added successfully.";
        }

        public async Task<string> AddAttendence(Attendence attendence)
        {
            var teacherId = currentUserServices.GetUserId();

            var isOwner = await _teacherRepositiry.IsTeacherOwnClass(attendence.ClassId, teacherId);
            if (!isOwner)
                return "UnUothrized";


            attendence.MarkedbyTeacherId = teacherId;

            var result = await _teacherAttendence.AddAsync(attendence);
            if (result == null)
            {
                return "Failed to add attendence.";
            }
            return "Attendence added successfully.";



        }




        public async Task<string> CreateClass(Class cls)
        {
            cls.TeacherId = currentUserServices.GetUserId();

            var result = await _teacherRepositiry.AddAsync(cls);
            if (result == null)
            {
                return "Failed to create class.";
            }
            return "Class created successfully.";




        }



        public async Task<string> DeActiveCls(int id)
        {
            var teacherId = currentUserServices.GetUserId();

            var isOwner = await _teacherRepositiry.IsTeacherOwnClass(id, teacherId);
            if (!isOwner)
                return "UnUothrized";
            return await _teacherRepositiry.DeActiveCls(id);


        }


        public async Task<Assignment> GetAssigmentByClassId(int classId)
        {
            var teacherId = currentUserServices.GetUserId();

            var isOwner = await _teacherRepositiry.IsTeacherOwnClass(classId, teacherId);
            if (!isOwner)
                return null;
            return await _teacherAssigment.GetAssigmentByClassId(classId);

        }

        public async Task<List<Attendence>> GetAttendenceByClassId(int classId)
        {
            var teacherId = currentUserServices.GetUserId();
            var isOwner = await _teacherRepositiry.IsTeacherOwnClass(classId, teacherId);
            if (!isOwner)
                return null;

            return await _teacherAttendence.GetAttendenceByClassId(classId);


        }

        public async Task<string> PosTGrade(Submission sumssion)
        {
            var teacherId = currentUserServices.GetUserId();
            var assignment = await _teacherAssigment.GetAssigment(sumssion.AssignmentId);


            var isOwner = await _teacherRepositiry.IsTeacherOwnClass(assignment.Class.Id, teacherId);
            if (!isOwner)
                return "UnUothrized";
            sumssion.GradeByTeacherId = teacherId;
            return await _teacherAssigment.PosTGrade(sumssion);
        }

        public async Task<string> UpdateCls(Class cls)
        {
            var teacherId = currentUserServices.GetUserId();

            var isOwner = await _teacherRepositiry.IsTeacherOwnClass(cls.Id, teacherId);
            if (!isOwner)
                return "UnUothrized";

            try
            {
                cls.TeacherId = teacherId;
                await _teacherRepositiry.UpdateAsync(cls);
                return "Class updated successfully.";
            }
            catch (Exception ex)
            {
                // هنا ممكن تسجل اللوج للـ exception
                return $"Failed to update class: {ex.Message}";
            }
        }

        public async Task<string> AssignStudentTocls(StudentClass studentClass)
        {
            var teacherId = currentUserServices.GetUserId();

            var isOwner = await _teacherRepositiry.IsTeacherOwnClass(studentClass.ClassId, teacherId);
            if (!isOwner)
                return "UnUothrized";

            return await _teacherRepositiry.AssignStudentTocls(studentClass);
        }

        #endregion
    }
}
