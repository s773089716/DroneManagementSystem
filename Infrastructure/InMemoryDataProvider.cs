/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-24
 *************************************************************************************************/
using DroneManagementSystem.Core.Infrastructure;
using DroneManagementSystem.Models;

namespace DroneManagementSystem.Infrastructure
{
    public class InMemoryDataProvider : IDataProvider
    {
        #region Public methods --------------------------------------------------------------------
        /// <summary>
        /// This method connect to the text file and scrape data
        /// </summary>
        /// <returns></returns>
        public IList<Drone> GetDronesData()
        {
            return new List<Drone>() 
            { 
                    new Drone() { SerialNumber = "01" , BatteryCapacity = 10, WeightLimit = 100, Model = DroneModel.Heavyweight, State = DroneState.IDLE},
                    new Drone() { SerialNumber = "02" , BatteryCapacity = 20, WeightLimit = 200, Model = DroneModel.Middleweight, State = DroneState.IDLE},
                    new Drone() { SerialNumber = "03" , BatteryCapacity = 30, WeightLimit = 300, Model = DroneModel.Cruiserweight, State = DroneState.IDLE},
                    new Drone() { SerialNumber = "04" , BatteryCapacity = 40, WeightLimit = 400, Model = DroneModel.Lightweight, State = DroneState.IDLE},
                    new Drone() { SerialNumber = "05" , BatteryCapacity = 50, WeightLimit = 500, Model = DroneModel.Cruiserweight, State = DroneState.IDLE},
                    new Drone() { SerialNumber = "06" , BatteryCapacity = 60, WeightLimit = 350, Model = DroneModel.Middleweight, State = DroneState.IDLE},
                    new Drone() { SerialNumber = "07" , BatteryCapacity = 70, WeightLimit = 450, Model = DroneModel.Heavyweight, State = DroneState.IDLE},
                    new Drone() { SerialNumber = "08" , BatteryCapacity = 80, WeightLimit = 150, Model = DroneModel.Cruiserweight, State = DroneState.IDLE},
                    new Drone() { SerialNumber = "09" , BatteryCapacity = 90, WeightLimit = 450, Model = DroneModel.Middleweight, State = DroneState.IDLE},
                    new Drone() { SerialNumber = "10" , BatteryCapacity = 100,WeightLimit = 300, Model = DroneModel.Heavyweight, State = DroneState.IDLE}
            };
        }

        public IList<Medication> GetMedicationsData()
        {
            return new List<Medication>()
            {
                    new Medication() { Name = "Medication 1", Code = "MD_001", Weight = 10.00F, ImagePath = "image1.jpg" },
                    new Medication() { Name = "Medication 2", Code = "MD_002", Weight = 12.00F, ImagePath = "image2.jpg" },
                    new Medication() { Name = "Medication 3", Code = "MD_003", Weight = 15.00F, ImagePath = "image3.jpg" },
                    new Medication() { Name = "Medication 4", Code = "MD_004", Weight = 5.00F, ImagePath = "image4.jpg" },
                    new Medication() { Name = "Medication 5", Code = "MD_005", Weight = 20.00F, ImagePath = "image5.jpg" },
                    new Medication() { Name = "Medication 6", Code = "MD_006", Weight = 50.00F, ImagePath = "image6.jpg" },
                    new Medication() { Name = "Medication 7", Code = "MD_007", Weight = 100.00F, ImagePath = "image7.jpg" },
                    new Medication() { Name = "Medication 8", Code = "MD_008", Weight = 8.00F, ImagePath = "image8.jpg" },
                    new Medication() { Name = "Medication 9", Code = "MD_009", Weight = 30.00F, ImagePath = "image9.jpg" },
                    new Medication() { Name = "Medication 10", Code = "MD_0010", Weight = 40.00F, ImagePath = "image10.jpg" },
                    new Medication() { Name = "Medication 11", Code = "MD_0011", Weight = 60.00F, ImagePath = "image11.jpg" }
            };
        }

        public IList<DispatchConfiguration> GetDispatchConfigurationData()
        {
            return new List<DispatchConfiguration>()
            {
                    new DispatchConfiguration() { MinimumWeight = 25 }
            };
        }
        #endregion
    }
}

