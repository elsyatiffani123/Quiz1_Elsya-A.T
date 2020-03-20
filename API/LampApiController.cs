using Microsoft.AspNetCore.Mvc;
using Quiz1_Elsya_A.T.Model;
using Quiz1_Elsya_A.T.Models;
using Quiz1_Elsya_A.T.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz1_Elsya_A.T.API
{
    [Route("api/v1/lampu")]
    [ApiController]
    public class LampuApiController : ControllerBase
    {
        private readonly LampuService ServiceMan;

        public LampuApiController(LampuService lampuService)
        {
            this.ServiceMan = lampuService;
        }

        [HttpGet("all-lamp", Name = "allLamp")]
        public async Task<IActionResult> GetAllLampAsync()
        {
            var lamps = await ServiceMan.GetAllLamps();
            return Ok(lamps);
        }

        [HttpPost("insert", Name = "insertLamp")]
        public async Task<ActionResult<ResponseModel>> InsertNewLampAsync([FromBody]LampuModel value)
        {
            var isSuccess = await ServiceMan.InsertLamp(value);
            return Ok(new ResponseModel
            {
                ResponseMessage = "Success to insert new data."
            });
        }

        [HttpPut("update", Name = "updateLamp")]
        public async Task<ActionResult<ResponseModel>> UpdateLampAsync([FromBody] LampuModel value)
        {
            var isSuccess = await ServiceMan.UpdateLampAsync(value);

            if (isSuccess == false)
            {
                return BadRequest(new ResponseModel
                {
                    ResponseMessage = "ID Not Found!!!"
                });
            }

            return Ok(new ResponseModel
            {
                ResponseMessage = $"Success update data {value.NamaLampu}"
            });
        }

        [HttpDelete("delete", Name = "deleteLamp")]
        public async Task<ActionResult<ResponseModel>> DeleteLampAsync([FromBody] LampuModel value)
        {
            var isSuccess = await ServiceMan.DeleteLampAsync(value.IdLampu);

            if (isSuccess == false)
            {
                return BadRequest(new ResponseModel
                {
                    ResponseMessage = "Id not found"
                });
            }

            return Ok(new ResponseModel
            {
                ResponseMessage = $"Success delete lamp {value.NamaLampu}"
            });
        }

        [HttpGet("specific-lamp", Name = "getSpesificLamp")]
        public async Task<ActionResult<LampuModel>> GetSpecificLampAsync(Guid? idLamp)
        {
            if (idLamp.HasValue == false)
            {
                return BadRequest(null);
            }

            var lamp = await ServiceMan.GetSpesificEmployeeAsync(idLamp.Value);
            if (lamp == null)
            {
                return BadRequest(null);
            }
            return Ok(lamp);
        }


        [HttpGet("filter-data")]
        public async Task<ActionResult<List<LampuModel>>> GetFilterDataAsync([FromQuery] int pageIndex, int itemPerPage, string filterByName)
        {
            var data = await ServiceMan.GetAsync(pageIndex, itemPerPage, filterByName);

            return Ok(data);
        }

        [HttpGet("total-data")]
        public ActionResult<int> GetTotalData()
        {
            var totalData = ServiceMan.GetTotalData();

            return Ok(totalData);
        }
    }
}
