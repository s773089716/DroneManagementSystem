/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-22
 *************************************************************************************************/
#region Packages/Usings ---------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DroneManagementSystem.Core.Services;
using DroneManagementSystem.DTOs;
using DroneManagementSystem.Infrastructure;
#endregion
namespace DroneManagementSystem.Controllers
{
    /// <summary>
    /// Provides stem related web methods
    /// </summary>    
    //[Route("")]
    //[Route("api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        #region Private Variables -----------------------------------------------------------------
        private IDispatchService _dispatchService = null;
        private readonly ILogger<DispatchController> _logger;
        #endregion

        #region Constructors ----------------------------------------------------------------------
        // GET: api/Stems
        /// <summary>
        /// Stem constructor. Injected instances will be assigned here.
        /// </summary>
        /// <param name="stemService">Service which is used to get data</param>
        /// <param name="logger">Logger service to be used</param>
        public DispatchController(IDispatchService dispatchService, ILogger<DispatchController> logger)
        {
            //TODO: Need to use proper logging provider and be injected through middleware
            _logger = logger;
            _dispatchService = dispatchService;
        }
        #endregion

        #region Web Methods -----------------------------------------------------------------------
        /// <summary>
        /// Returns the requested stem data. And returns 404 if data not found.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("api/[controller]/GetAvailableDrones")]
        [Route("GetAvailableDrones")]
        public async Task<ActionResult<AvailableDronesListResponse>> GetAvailableDrones()
        {            
            AvailableDronesListRequest request = new AvailableDronesListRequest {};
            AvailableDronesListResponse response = await _dispatchService.GetAvailableDrones(request);

            if (response.Drones != null && response.Drones.Count > 0)
                return Ok(response);

            return NotFound();
        }

        [HttpGet]
        [Route("GetDroneBatterLevel")]
        public async Task<ActionResult<DroneBatteryLevelResponse>> GetDroneBatterLevel()
        {
            string serialNumber = Request.Query[QueryStringKey.SerialNumber];

            if (String.IsNullOrEmpty(serialNumber))
                serialNumber = String.Empty;

            DroneBatteryLevelRequest request = new DroneBatteryLevelRequest { SerialNumber = serialNumber };
            DroneBatteryLevelResponse response = await _dispatchService.GetDroneBatteryLevel(request);

            if (response.BatteryLevel > -1)
                return Ok(response);

            return NotFound();
        }

        #endregion
    }
}
