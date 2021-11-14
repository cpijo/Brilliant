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
            container.RegisterType<IStudentResultsRepository, StudentResultsRepository>();
            container.RegisterType<IStudentRepository, StudentsRepository>();
            container.RegisterType<ICoursesRepository, CoursesRepository>();
            container.RegisterType<ISubjectRepository, SubjectRepository>();
            container.RegisterType<IGradesRepository, GradesRepository>();
            container.RegisterType<ISubjectResultRepository, SubjectResultRepository>();
            container.RegisterType<ITeacherRepository, TeacherRepository>();

            container.RegisterType<IGradeTeacherRepository, GradeTeacherRepository>();
            container.RegisterType<ISubjectTeacherRepository, SubjectTeacherRepository>();
            //container.RegisterType<IStudentSubjectMarksRepository, StudentSubjectMarksRepository>();
            container.RegisterType<IStudentAttendanceRepository, StudentAttendanceRepository>();
            container.RegisterType<IGradeClassRepository, GradeClassRepository>();
            container.RegisterType<IStudentMarksRepository, StudentMarksRepository>();
            container.RegisterType<ITeacherRegisterRepository, TeacherRegisterRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}