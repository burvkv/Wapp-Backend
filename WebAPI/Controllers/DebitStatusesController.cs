using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitStatusesController : ControllerBase
    {
        IDebitStatusService _debitStatusService;
        public DebitStatusesController(IDebitStatusService debitStatusService)
        {
            _debitStatusService = debitStatusService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _debitStatusService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(DebitStatus debitStatus)
        {
            var result = _debitStatusService.Add(debitStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DebitStatus debitStatus)
        {
            var result = _debitStatusService.Delete(debitStatus);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
