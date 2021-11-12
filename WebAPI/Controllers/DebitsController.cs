using Business.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
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
    public class DebitsController : ControllerBase
    {
       
        IDebitService _debitService;
        public DebitsController(IDebitService debitService)
        {
            _debitService = debitService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _debitService.GetList();
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _debitService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(DebitForAddDto debit)
        {
           
            var result = _debitService.Add(debit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DebitForAddDto debit)
        {

            var result = _debitService.Delete(debit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(DebitForAddDto debit)
        {

            var result = _debitService.Update(debit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
