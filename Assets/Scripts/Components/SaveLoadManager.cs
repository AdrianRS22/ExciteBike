using UnityEngine;
using System.IO;

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
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(fullPath + fileName + ".json", jsonData);
        Debug.LogFormat("El dato ha sido guardado correctamente en {0}", fullPath);
    }

    public static T LoadData<T>(string path, string fileName)
    {
        string fullPath = $"{Application.dataPath}/{path}/{fileName}.json";
        if (File.Exists(fullPath))
        {
            string textJson = File.ReadAllText(fullPath);
            var fileObject = JsonUtility.FromJson<T>(textJson);
            return fileObject;
        }
        else
        {
            return default;
        }
    }
}
