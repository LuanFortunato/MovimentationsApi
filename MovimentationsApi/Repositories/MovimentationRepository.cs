using Microsoft.EntityFrameworkCore;
using MovimentationsApi.Data;
using MovimentationsApi.Models;

namespace MovimentationsApi.Repositories
{
    public class MovimentationRepository
    {
        private readonly MovimentationsContext _context;

        public MovimentationRepository(MovimentationsContext context)
        {
            _context = context;
        }

        public void SaveMovimentation(MovimentationUsecaseModel movimentation)
        {
            _context.Set<MovimentationUsecaseModel>().Add(movimentation);
            _context.SaveChanges();
        }

        public List<MovimentationUsecaseModel> getAllMovimentations()
        {
            return _context.Set<MovimentationUsecaseModel>().ToList();
        }

        public MovimentationUsecaseModel GetMovimentation(int id)
        {
            var movimentation = _context.Set<MovimentationUsecaseModel>().Find(id);
            if (movimentation == null)
            {
                throw new ArgumentNullException();
            }
            return movimentation;
        }

        public void DeleteMovimentation(int id)
        {
            var movimentation = GetMovimentation(id);
            _context.Entry<MovimentationUsecaseModel>(movimentation).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
