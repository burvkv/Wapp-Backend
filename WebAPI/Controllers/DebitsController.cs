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

        [HttpGet("getallbyhardwaretype")]
        public IActionResult GetAllByHardwareType(string hardwareType)
        {
            var result = _debitService.GetList();
            if (result.Success)
            {
                result.Data.Where(d => d.HardwareType.Equals(hardwareType));
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbydebitstatus")]
        public IActionResult GetAllByDebitStatus(string status)
        {
            var result = _debitService.GetList();
            if (result.Success)
            {
                result.Data.Where(d => d.DebitStatus.Equals(status));
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyownername")]
        public IActionResult GetAllByOlderOwnerName(string ownerName)
        {
            var result = _debitService.GetList();
            if (result.Success)
            {
                result.Data.Where(d => d.OwnerName.Equals(ownerName));
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("sortbydate")]
        public IActionResult GetAllByAddedDate()
        {
            var result = _debitService.GetList();
            if (result.Success)
            {
                result.Data.OrderBy(d => d.LastChange);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyprojectname")]
        public IActionResult GetAllByProjectName(string projectName)
        {
            var result = _debitService.GetList();
            if (result.Success)
            {
                result.Data.Where(d=>d.ProjectName.Equals(projectName));
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
        public IActionResult Add(Debit debit)
        {
           
            var result = _debitService.Add(debit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Debit debit)
        {

            var result = _debitService.Delete(debit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Debit debit)
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
