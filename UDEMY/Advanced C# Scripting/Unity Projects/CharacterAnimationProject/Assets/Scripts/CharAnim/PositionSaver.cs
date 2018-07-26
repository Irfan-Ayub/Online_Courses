using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PositionSaver : MonoBehaviour {

    public Vector3 lastPosition = Vector3.zero;
    public Quaternion lastRotation = Quaternion.identity;

    private Transform thisTransform = null;


    void SaveObject()
    {
        // Get Positon and Rotation Data

        // Create Output Path
        string outputPath = Application.persistentDataPath + @"/Objectpostion.json";
        lastPosition = thisTransform.position;
        lastRotation = thisTransform.rotation;

        // Generate Writer Object
        StreamWriter writer = new StreamWriter(outputPath);
        writer.WriteLine(JsonUtility.ToJson(this));
        writer.Close();
        Debug.Log("Outputting to: " + outputPath);

    }

    void LoadObject()
    {
        // Create input Path
        string inputPath = Application.persistentDataPath + @"/Objectpostion.json";

        // Create Stream Rreader Object
        StreamReader reader = new StreamReader(inputPath);
        string JSONString = reader.ReadToEnd();
        Debug.Log("Reading: " + JSONString);
        JsonUtility.FromJsonOverwrite(JSONString, this);
        reader.Close();

        thisTransform.position = lastPosition;
        thisTransform.rotation = lastRotation;
          
    }

    private void Awake()
    {
        thisTransform = gameObject.GetComponent<Transform>();
    }
    // Use this for initialization
    void Start () {

        LoadObject();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        SaveObject();
    }
}
