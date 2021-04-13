using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class SaveLoadManager
{
    public static void SaveData<T>(T data, string path, string fileName)
    {
        string fullPath = $"{Application.dataPath}/{path}/";
        bool folderExist = Directory.Exists(fullPath);

        if (!folderExist)
        {
            Directory.CreateDirectory(fullPath);
        }
        string jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(fullPath + fileName + ".json", jsonData);
        Debug.LogFormat("El dato ha sido guardado correctamente en {0}", fullPath);
    }

    public static T LoadData<T>(string path, string fileName)
    {
        string fullPath = $"{Application.dataPath}/{path}/{fileName}.json";
        if (File.Exists(fullPath))
        {
            string textJson = File.ReadAllText(fullPath);
            var fileObject = JsonConvert.DeserializeObject<T>(textJson);
            return fileObject;
        }
        else
        {
            return default;
        }
    }
}
