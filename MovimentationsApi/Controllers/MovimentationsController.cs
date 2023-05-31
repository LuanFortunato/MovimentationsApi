﻿using Microsoft.AspNetCore.Http;
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
        private readonly MovimentationRepository repository;

        public MovimentationsController(MovimentationRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<MovimentationUsecaseModel>> GetAllMovimentations()
        {
            try
            {
                var result = repository.getAllMovimentations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SaveMovimentation(MovimentationViewModel movimentationViewModel)
        {
            try
            {
                var movimentationUsecaseModel = new MovimentationUsecaseModel();
                movimentationUsecaseModel.Product_Id = movimentationViewModel.Product_Id;
                movimentationUsecaseModel.Quantity = movimentationViewModel.Quantity;

                repository.SaveMovimentation(movimentationUsecaseModel);
                return Ok("Movimentação salva com sucesso!");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}