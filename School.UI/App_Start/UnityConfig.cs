using School.Services.Interface;
using School.Services.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace School.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ILoginRepository, LoginRepository>();

            container.RegisterType<ICoursesRepository, CoursesRepository>();

            container.RegisterType<IGradesRepository, GradesRepository>();
            container.RegisterType<IGradeTeacherRepository, GradeTeacherRepository>();
            container.RegisterType<IGradeClassRepository, GradeClassRepository>();

            container.RegisterType<ISubjectResultRepository, SubjectResultRepository>();
            container.RegisterType<ISubjectRepository, SubjectRepository>();
            container.RegisterType<ISubjectTeacherRepository, SubjectTeacherRepository>();

            container.RegisterType<IStudentResultsRepository, StudentResultsRepository>();
            container.RegisterType<IStudentRepository, StudentsRepository>();
            container.RegisterType<IStudentMarksRepository, StudentMarksRepository>();
            container.RegisterType<IStudentRegisterRepository, StudentRegisterRepository>();
            container.RegisterType<IStudentAttendanceRepository, StudentAttendanceRepository>();
            //container.RegisterType<IStudentSubjectMarksRepository, StudentSubjectMarksRepository>();

            container.RegisterType<ITeacherRepository, TeacherRepository>();
            container.RegisterType<ITeacherRegisterRepository, TeacherRegisterRepository>();
            container.RegisterType<IRolesRepository, RolesRepository>();
            container.RegisterType<IUserRolesRepository, UserRolesRepository>();
            //An error occurred when trying to create a controller of type 'School.UI.Controllers.LogInController'. 
            //Make sure that the controller has a parameterless public constructor.
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}