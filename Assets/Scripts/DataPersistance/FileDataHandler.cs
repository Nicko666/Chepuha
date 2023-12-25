using System;
using System.IO;
using UnityEngine;

public class FileDataHandler
{
    private string _filePath = "";

    private string _fileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        _filePath = dataDirPath;
        _fileName = dataFileName; 

    }

    public LocalData Load()
    {
        string fullPath = Path.Combine(_filePath, _fileName);

        LocalData data = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                data = JsonUtility.FromJson<LocalData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load data \n" + e);
            }
        }

        return data;

    }

    public void Save(LocalData data)
    {
        string fullPath = Path.Combine(_filePath, _fileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to save data \n" + e);
        }

    }


}
