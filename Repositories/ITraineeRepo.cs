using task1.Models;

namespace task1.Repositories
{
    public interface ITraineeRepo
    {
        public List<Trainee> GetAllTrainees();
        public Trainee GetTraineeByID(int ID);
        public void CreateTrainee(Trainee createtrainee);
        public void EditTrainee(int ID, Trainee updatetrainee);
        public void DeleteTrainee(int ID);
    }
}
