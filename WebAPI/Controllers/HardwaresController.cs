using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwaresController : ControllerBase
    {
        IHardwareService _hardwareService;
        public HardwaresController(IHardwareService hardwareService)
        {
            _hardwareService = hardwareService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(string key = null)
        {
            var result = _hardwareService.GetList(key);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("add")]
        public IActionResult Add(Hardware hardware)
        {
            var result = _hardwareService.Add(hardware);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("delete")]
        public IActionResult Delete(Hardware hardware)
        {
            var result = _hardwareService.Delete(hardware);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(Hardware hardware)
        {
            var result = _hardwareService.Update(hardware);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id )
        {
            var result = _hardwareService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
