using MovimentationsApi.Data;
using MovimentationsApi.Models;

namespace MovimentationsApi.Repositories
{
    public class MovimentationRepository
    {
        private readonly MovimentationsContext context;

        public MovimentationRepository(MovimentationsContext context)
        {
            this.context = context; 
        }

        public void SaveMovimentation(MovimentationUsecaseModel movimentation)
        {
            movimentation.Date = DateTime.Now;
            context.Movimentations.Add(movimentation);
            context.SaveChanges();
        }

        public List<MovimentationUsecaseModel> getAllMovimentations()
        {
            return context.Movimentations.ToList();
        }
    }
}
