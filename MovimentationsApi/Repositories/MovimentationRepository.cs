using MovimentationsApi.Models;

namespace MovimentationsApi.Repositories
{
    public class MovimentationRepository
    {
        private readonly List<MovimentationUsecaseModel> movimentations = new List<MovimentationUsecaseModel>();

        public void SaveMovimentation(MovimentationUsecaseModel movimentation)
        {
            movimentation.Date = DateTime.Now;
            movimentations.Add(movimentation);
        }

        public List<MovimentationUsecaseModel> getAllMovimentations()
        {
            return movimentations;
        }
    }
}
