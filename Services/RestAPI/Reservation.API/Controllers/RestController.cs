using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.API.Infrastructure;
using Reservation.API.Models;

namespace Reservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public RestController(IReservationService reservationService)
        {
            this._reservationService = reservationService;
        }
        [HttpGet("{id}")]
        public ReservationDTO Get(int id)
        {
            return _reservationService.GetRestByBkgNumber(id);
        }
    }
}
