using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sender;

namespace SenderTests
{
  [TestClass]
  public class SenderTests
  {
    [TestMethod("Test method to get the input Parameter")]
    public void CountInputReadings()
    {
      List<SensorParameter> inputReadings = DataProcessor.GetSensorParameters(400,200,700,500);

      Assert.AreEqual(inputReadings.Count,20);
    }

    [TestMethod("Test ConvertInputToJsonFormat converts data to json ")]
    public void ConvertInputToJsonTest()
    {
      string expectedOutput =
        "[{\"Temperature\":9,\"StateOfCharge\":10},{\"Temperature\":19,\"StateOfCharge\":20}]";
      List<SensorParameter> sensorList=new List<SensorParameter>();
      SensorParameter sensorData1 = new SensorParameter { Temperature = 9, StateOfCharge = 10 };
      SensorParameter sensorData2 = new SensorParameter { Temperature = 19, StateOfCharge = 20 };
      sensorList.Add(sensorData1);
      sensorList.Add(sensorData2);
      string jsonString = DataProcessor.ConvertInputToJsonFormat(sensorList);
      Assert.AreEqual(jsonString, expectedOutput);
    }
  }
}
