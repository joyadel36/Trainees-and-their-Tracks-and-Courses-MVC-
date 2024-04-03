using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Repositories
{
    public class CourseServices : IcourseRepo
    {

        public TraineeContext Context { get; set; }
        public CourseServices(TraineeContext mcontext)
        {
            Context = mcontext;
        }
        public void CreateCourse(Course createcourse)
        {
            if (createcourse != null)
            {
                Context.Courses.Add(createcourse);
                Context.SaveChanges();
            }
        }

        public void DeleteCourse(int ID)
        {
            Course? temp = Context.Courses.Where(c => c.ID == ID).FirstOrDefault();
            if (temp != null)
            {
                Context.Courses.Remove(temp);
                Context.SaveChanges();
            }
        }

        public void EditCourse(int ID, Course updatecourse)
        {
            Course? temp = Context.Courses.Where(c => c.ID == ID).FirstOrDefault();
            if (temp != null)
            {
                temp.Grade =updatecourse.Grade;
                temp.Topic =updatecourse.Topic;
                Context.SaveChanges();
            }
        }

        public List<Course> GetAllCourses()
        {
            return Context.Courses.Include(c=>c.T_rainee).ToList();
        }

        public Course GetCourseByID(int ID)
        {
            return Context.Courses.Include(c => c.T_rainee).Where(c => c.ID==ID).FirstOrDefault();
        }
    }
}
