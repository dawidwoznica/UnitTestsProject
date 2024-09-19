namespace MyProject.Tests;

using System.Reflection;
using Newtonsoft.Json;
using Xunit.Sdk;

public class JsonFileData(string jsonPath) : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        if(testMethod is null)
            throw new ArgumentNullException(nameof(testMethod));

        var currentDirectory = Directory.GetCurrentDirectory();
        var path = Path.GetRelativePath(currentDirectory, jsonPath);

        if(!File.Exists(path))
            throw new ArgumentException($"The file {path} does not exist.");

        var jsonData = File.ReadAllText(path);
        var dataCases = JsonConvert.DeserializeObject<IEnumerable<object[]>>(jsonData);

        return dataCases;
    }
}