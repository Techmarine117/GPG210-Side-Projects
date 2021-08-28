using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class objCreator : ScriptableWizard
{
    public Transform desiredPosition;
    public GameObject Object;
    public int numberOfobjects;
    public int radius;


    [MenuItem("tool/objectCreator")]
   static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<objCreator>("object Creator", "Create Object");
    }

    private void OnWizardCreate()
    {
        int i = 0;
        if(numberOfobjects > 0)
        {
            GameObject[] objects = new GameObject[numberOfobjects];
            foreach (var item in objects)
            {
                i++;
                Vector2 pos = new Vector2(desiredPosition.position.x, desiredPosition.position.z) + Random.insideUnitCircle * radius;
                Vector3 FinalPosition = new Vector3(pos.x, desiredPosition.position.y, pos.y);
                GameObject instance =  GameObject.Instantiate(Object, FinalPosition, Quaternion.identity);
                instance.name = "object " + i.ToString();
            }

        }
        else
        {
            GameObject singleObject = GameObject.Instantiate(Object,desiredPosition.position,Quaternion.identity);
        }
    }

  
}
