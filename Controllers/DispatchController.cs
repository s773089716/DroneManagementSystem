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
using DroneManagementSystem.BackgroundServices;
#endregion
namespace DroneManagementSystem.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        #region Private Variables -----------------------------------------------------------------
        private IDispatchService _dispatchService;
        private readonly ILogger<DispatchController> _logger;        
        #endregion

        #region Constructors ----------------------------------------------------------------------        
        public DispatchController(IDispatchService dispatchService, ILogger<DispatchController> logger)
        {
            //TODO: Need to use proper logging provider and be injected through middleware
            _logger = logger;
            _dispatchService = dispatchService;
        }
        #endregion

        #region Web Methods -----------------------------------------------------------------------
        
        [HttpGet]        
        [Route("GetAvailableDrones")]
        public async Task<ActionResult<DronesListResponse>> GetAvailableDrones()
        {            
            DronesListRequest request = new DronesListRequest {};
            DronesListResponse response = new DronesListResponse();

            try
            {
                response = await _dispatchService.GetAvailableDrones(request);                

                if (response.Drones != null)
                    return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageType = DTOMessageType.Error;
            }

            return new BadRequestObjectResult(response);
        }

        [HttpGet]
        [Route("GetDroneBatterLevel")]
        public async Task<ActionResult<DroneBatteryLevelResponse>> GetDroneBatterLevel()
        {
            DroneBatteryLevelResponse response = new DroneBatteryLevelResponse();
            string serialNumber = Request.Query[QueryStringKey.SerialNumber];

            if (String.IsNullOrEmpty(serialNumber))
                serialNumber = String.Empty;
            
            try
            {
                DroneBatteryLevelRequest request = new DroneBatteryLevelRequest { SerialNumber = serialNumber };
                response = await _dispatchService.GetDroneBatteryLevel(request);

                if (response.BatteryLevel > -1)
                    return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageType = DTOMessageType.Error;
            }

            return new BadRequestObjectResult(response);
        }

        [HttpPost]
        [Route("RegisterDrone")]
        public async Task<ActionResult<RegisterDroneResponse>> RegisterDrone(RegisterDroneRequest request)
        {
            RegisterDroneResponse response = new RegisterDroneResponse();
            try
            {
                response = await _dispatchService.RegisterDrone(request);

                if (response.Drone != null)
                    return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageType = DTOMessageType.Error;
            }

            return new BadRequestObjectResult(response);
        }

        [HttpPost]
        [Route("LoadMedications")]
        public async Task<ActionResult<LoadMedicationsResponse>> LoadMedications(LoadMedicationsRequest request)
        {
            LoadMedicationsResponse response = new LoadMedicationsResponse();
            try
            {
                response = await _dispatchService.AddMedicationItemsToDrone(request);

                if (response.Drone != null)
                    return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageType = DTOMessageType.Error;
            }

            return new BadRequestObjectResult(response);            
        }

        [HttpGet]        
        [Route("GetMedications")]
        public async Task<ActionResult<GetMedicationResponse>> GetMedications()
        {
            string serialNumber = Request.Query[QueryStringKey.SerialNumber];

            if (String.IsNullOrEmpty(serialNumber))
                serialNumber = String.Empty;

            GetMedicationResponse response = new GetMedicationResponse();
            GetMedicationRequest request = new GetMedicationRequest { SerialNumber = serialNumber };            

            try
            {
                response = await _dispatchService.GetMedicationItemsOfDrone(request);

                if (response.Medications != null)
                    return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageType = DTOMessageType.Error;
            }

            return new BadRequestObjectResult(response);
        }

        #endregion
    }
}
