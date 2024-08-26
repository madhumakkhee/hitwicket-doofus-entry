using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonExtractor : MonoBehaviour
{
    public JsonData jsonData;

    void Start()
    {
        // Load the JSON file as a text asset
        TextAsset jsonText = Resources.Load<TextAsset>("json/doofus_diary");

        // Parse the JSON
        jsonData = JsonUtility.FromJson<JsonData>(jsonText.text);
    }
}

public class Pulpit : MonoBehaviour
{
    private JsonExtractor jsonExtractor;

    void Start()
    {
        jsonExtractor = new JsonExtractor();
        float minPulpitDestroyTime = jsonExtractor.jsonData.pulpitData.minPulpitDestroyTime;
        // ...
    }
}

[System.Serializable]
public class JsonData
{
    public PlayerData playerData;
    public PulpitData pulpitData;
}

[System.Serializable]
public class PlayerData
{
    public int speed;
}

[System.Serializable]
public class PulpitData
{
    public float minPulpitDestroyTime;
    public float maxPulpitDestroyTime;
    public float pulpitSpawnTime;
}