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
            using (_context)
            {
                _context.Set<MovimentationUsecaseModel>().Add(movimentation);
                _context.SaveChanges();
            }
        }

        public List<MovimentationUsecaseModel> getAllMovimentations()
        {
            using (_context)
            {
                return _context.Set<MovimentationUsecaseModel>().ToList();
            }
        }
    }
}
