using System;
using System.IO;
using UnityEngine;

namespace CodingTest.Recording
{
    public class RecordSerializer : MonoBehaviour
    {
        public void Save(RecordData data)
        {
            string json = JsonUtility.ToJson(data);

            try
            {
                using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + data.name + ".json"))
                    writer.Write(json);
                Debug.Log("Saved Record Data on JSON format");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }

        public RecordData Load(string name)
        {
            try
            {
                using (StreamReader reader = new StreamReader(Application.persistentDataPath + name + ".json"))
                {
                    string jsonData = reader.ReadToEnd();
                    return JsonUtility.FromJson<RecordData>(jsonData);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }
    }
}