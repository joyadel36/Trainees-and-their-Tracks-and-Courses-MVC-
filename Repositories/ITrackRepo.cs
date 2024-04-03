using task1.Models;

namespace task1.Repositories
{
    public interface ITrackRepo
    {
        public List<Track> GetAllTracks();
        public Track GetTrackByID(int ID);
        public void CreateTrack(Track createtrack);
        public void EditTrack(int ID, Track updatetrack);
        public void DeleteTrack(int ID);
    }
}
