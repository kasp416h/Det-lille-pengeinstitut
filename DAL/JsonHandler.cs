using System.Collections.Generic;
using Newtonsoft.Json;

namespace DAL
{
    public class JsonHandler
    {
        private string FilePath;
        public JsonHandler(string filePath) 
        {
            FilePath = filePath;
        }
        public List<T> Read<T>()
        {
            string fileContent = File.ReadAllText(FilePath);

            List<T>? entities = JsonConvert.DeserializeObject<List<T>>(fileContent);

            return entities;
        }
        public void Write<T>(List<T> entities) 
        {
            string updatedFileContent = JsonConvert.SerializeObject(entities, Formatting.Indented);

            File.WriteAllText(FilePath, updatedFileContent);
        }
    }
}
