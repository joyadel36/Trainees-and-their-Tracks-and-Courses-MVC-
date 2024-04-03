using task1.Models;

namespace task1.Repositories
{
    public interface IcourseRepo
    {
        public List<Course> GetAllCourses();
        public Course GetCourseByID(int ID);
        public void CreateCourse( Course createcourse);
        public void EditCourse(int ID,Course updatecourse);
        public void DeleteCourse(int ID);


    }
}
