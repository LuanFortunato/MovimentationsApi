using Microsoft.AspNetCore.Mvc;
using MovimentationsApi.Models;
using MovimentationsApi.Repositories;
using MovimentationsApi.ViewModels;

namespace MovimentationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentationsController : ControllerBase
    {
        private readonly MovimentationRepository _repository;

        public MovimentationsController(MovimentationRepository repository)
        {

            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllMovimentations()
        {
            try
            {
                var result = _repository.getAllMovimentations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SaveMovimentation(MovimentationViewModel movimentationViewModel)
        {
            try
            {
                var movimentationUsecaseModel = new MovimentationUsecaseModel();
                movimentationUsecaseModel.Product_Id = movimentationViewModel.Product_Id;
                movimentationUsecaseModel.Quantity = movimentationViewModel.Quantity;
                movimentationUsecaseModel.Date = DateTime.Now;

                _repository.SaveMovimentation(movimentationUsecaseModel);
                return Ok("Movimentação salva com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMovimentation(int id)
        {
            try
            {
                var movimentation = _repository.GetMovimentation(id);
                return Ok(movimentation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteMovimentation(int id)
        {
            try
            {
                _repository.DeleteMovimentation(id);
                return Ok("Movimentação deletada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
