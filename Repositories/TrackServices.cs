using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using task1.Models;

namespace task1.Repositories
{
    public class TrackServices : ITrackRepo
    {
        public TraineeContext  Context { get; set; }
        public TrackServices(TraineeContext mcontext) {
            Context = mcontext;
        }
        public void CreateTrack(Track createtrack)
        {
            if (createtrack != null)
            {
                Context.Tracks.Add(createtrack);
                Context.SaveChanges();
            }
        }

        public void DeleteTrack(int ID)
        {
            Track? temp= Context.Tracks.Include(t => t.Trainees).Where(t => t.ID == ID).FirstOrDefault();
            if (temp != null)
            {
                Context.Tracks.Remove(temp);
                Context.SaveChanges();
            }
        }

        public void EditTrack(int ID, Track updatetrack)
        {
            Track? temp = Context.Tracks.Include(t => t.Trainees).Where(t => t.ID == ID).FirstOrDefault();
            if (temp != null)
            {
                temp.Name = updatetrack.Name;
                temp.Description = updatetrack.Description;
                Context.SaveChanges();
            }
        }

        public List<Track> GetAllTracks()
        {
            return Context.Tracks.Include(t => t.Trainees).ToList();
        }

        public Track GetTrackByID(int ID)
        {
            return  Context.Tracks.Include(t => t.Trainees).Where(t=>t.ID==ID).FirstOrDefault();
            
        }
    }
}
