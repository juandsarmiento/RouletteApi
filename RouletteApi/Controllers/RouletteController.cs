using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouletteApi;
using RouletteApi.Entities;
using RouletteApi.Exceptions;


namespace RuletaApi.Controllers
{
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private ICollectionRoulletes<Roulette,Bet> roulettes;
        public RouletteController(ICollectionRoulletes<Roulette,Bet> roulettes)
        {
            this.roulettes = roulettes;
        }
        [HttpPost]
        [Route("[controller]")]
        public ActionResult<int> CreateRoulette([FromBody] Roulette roulette)
        {
            roulettes.CreateElement(roulette: roulette);

            return Ok(roulette.Id);
        }
        [HttpPatch]
        [Route("[controller]/{rouletteId}/open")]
        public ActionResult OpenRoulette(string rouletteId)
        {
            try
            {
                roulettes.OpenRoulette(rouletteId:rouletteId);

                return Accepted(1);
            }
            catch
            {

                return Problem();
            }   
        }
        [HttpPost]
        [Route("[controller]/{rouletteId}/bet")]
        public IActionResult CreateBet(string rouletteId, [FromBody] Bet bet)
        {
            try
            {
                string userId = Request.Headers["userId"];
                if (userId == null)
                {

                    return Forbid("You are not logged");
                }
                bet.UserId = userId;
                bet.DateCreation = DateTime.Now;
                roulettes.AddBet(rouletteId:rouletteId,bet:bet);

                return Created("","");
            }
            catch(BusinessExceptionBase e)
            {

                return Problem(e.Message);
            }catch(ArgumentException e)
            {

                return Problem(e.Message);
            }
        }
        [HttpPatch]
        [Route("[controller]/{rouletteId}/close")]
        public ActionResult CloseRoulette(string rouletteId)
        {
            
            return Ok(roulettes.CloseBets(rouletteId: rouletteId));
        }
        [HttpGet]
        [Route("[controller]")]
        public ActionResult<IEnumerable<Roulette>> GetRoulettes()
        {

            return Ok(roulettes.GetElements().ToList());
        }
    }
}
