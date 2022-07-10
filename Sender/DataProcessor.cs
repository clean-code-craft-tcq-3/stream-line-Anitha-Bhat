using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Sender
{
  public class DataProcessor
  {
    private static int numberOfSample = 20;
    [ExcludeFromCodeCoverage]
    static void Main(string[] args)
    {
      List<SensorParameter> sensorDataReadings = GetSensorParameters(200, 0, 400, 200);
      LogSensorReadingsOnConsole(sensorDataReadings);

    }
    
    
    public static List<SensorParameter> GetSensorParameters(int maxTemperature, int minTemperature, int maxSOC, int minSOC)
    {
      List<SensorParameter> sensorParameterList = new List<SensorParameter>();
      List<int> temperatureInputSample = GetTemperatureInputSample(maxTemperature, minTemperature);
      List<int> socInputSample = GetSOCInputSample(maxSOC, minSOC);
      for (int i = 0; i < numberOfSample; i++)
      {
        SensorParameter sensorParam = new SensorParameter();
        sensorParam.StateOfCharge = socInputSample[i];
        sensorParam.Temperature = temperatureInputSample[i];
        sensorParameterList.Add(sensorParam);
      }
      return sensorParameterList;
    }
    
    private static List<int> GetTemperatureInputSample(int maxValue, int minValue)
    {
      return GenerateInputSamples(maxValue, minValue);
    }

    private static List<int> GetSOCInputSample(int maxValue, int minValue)
    {
      return GenerateInputSamples(maxValue, minValue);
    }

    private static List<int> GenerateInputSamples(int maxValue, int minValue)
    {
      List<int> randomSampleList = new List<int>();
      for (int i = 0; i < numberOfSample; i++)
      {
        int randomNum = (new Random()).Next(minValue, maxValue);
        randomSampleList.Add(randomNum);
      }

      return randomSampleList;
    }


    public static string ConvertInputToJsonFormat(List<SensorParameter> sensorReading)
    {
      string jsonFormatReading = JsonSerializer.Serialize(sensorReading);

      return jsonFormatReading;
    }

    public static void LogSensorReadingsOnConsole(List<SensorParameter> sensorDataReadings)
    {
      string readingInJson = ConvertInputToJsonFormat(sensorDataReadings);
      Console.WriteLine(readingInJson);
    }
  }
}
