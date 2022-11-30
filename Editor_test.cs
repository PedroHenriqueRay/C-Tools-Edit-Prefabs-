using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Editor_test : EditorWindow
{
    string objectBaseName = "";
    int objectID = 1;
    GameObject objectToSpawn;
    float objectScale;
    float spawnRadius = 5f;

    [MenuItem("Tools/BasicOBJSpawner")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Editor_test));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel); // the title

        objectBaseName = EditorGUILayout.TextField("Base Name", objectBaseName);                                                //put the value on the string

        objectID = EditorGUILayout.IntField("Object ID", objectID);                                                             //put the value on the int varible
        objectScale = EditorGUILayout.Slider("Object Scale", objectScale, 0.5f,3f);                                             //put a slider, you can define a value base on a limit number define by 0.5f and 3f
        spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);                                                  //put the value on the float varible
        objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", objectToSpawn, typeof(GameObject), false) as GameObject; //put the GO on the variable. the "false" value means you can't put a scene obj on the field

        //put a button on GUI and when the developer press him the object will gonna spawn 
        if(GUILayout.Button("spawnRadius Object"))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if(objectToSpawn == null)
        {
            Debug.LogError("Error: Please assign an object to be spawned");
            return;
        }
        if(objectBaseName == string.Empty)
        {
            Debug.LogError("Error: Please assign an name for the object");
            return;
        }

        Vector3 spawnCircle = Random.insideUnitCircle * spawnRadius;               //random variable 
        Vector3 spawnPos = new Vector3(spawnCircle.x,spawnCircle.y,spawnCircle.z); //put the random variable on a Vector3 variable 

        GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);//Instantiate the OBJ
        newObject.name = objectBaseName + "(" + objectID + ")";
        newObject.transform.localPosition = spawnPos;
        newObject.transform.localScale = new Vector3(objectScale, objectScale, objectScale);

        //add a ID
        objectID++;
    }



}
