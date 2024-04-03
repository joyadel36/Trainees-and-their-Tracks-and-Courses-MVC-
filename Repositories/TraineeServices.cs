using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Repositories
{
    public class TraineeServices : ITraineeRepo
    {

        public TraineeContext Context { get; set; }
        public TraineeServices(TraineeContext mcontext)
        {
            Context = mcontext;
        }
        public void CreateTrainee(Trainee createtrainee)
        {
            if (createtrainee != null)
            {
                Context.Trainees.Add(createtrainee);
                Context.SaveChanges();
            }
        }

        public void DeleteTrainee(int ID)
        {
            Trainee? temp = Context.Trainees.Where(c => c.ID == ID).FirstOrDefault();
            if (temp != null)
            {
                Context.Trainees.Remove(temp);
                Context.SaveChanges();
            }
        }

        public void EditTrainee(int ID, Trainee updatetrainee)
        {
            Trainee? temp = Context.Trainees.Where(c => c.ID == ID).FirstOrDefault();
            if (temp != null)
            {
                temp.Email = updatetrainee.Email;
                temp.Name = updatetrainee.Name;
                temp.Birthdate = updatetrainee.Birthdate;
                temp.TR_ID = updatetrainee.TR_ID;
                temp.PhoneNum = updatetrainee.PhoneNum;
                temp.gender = updatetrainee.gender;
                Context.SaveChanges();
            }
        }

        public List<Trainee> GetAllTrainees()
        {
            return Context.Trainees.Include(t => t.T_rack).ToList();
        }

        public Trainee GetTraineeByID(int ID)
        {
            return Context.Trainees.Include(t=>t.T_rack).Include(t=>t.Courses).Where(t => t.ID == ID).FirstOrDefault();
        }
    }
}
