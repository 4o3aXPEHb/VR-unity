using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombModule : MonoBehaviour 
{
    public bool isCompleted = false;
    public void ModuleIsComplete()
    {
        isCompleted = true;
        Debug.Log("Module has been defused!");
        gameObject.transform.parent.parent.GetComponent<BombBase>().ModuleIsComplete(gameObject);
    }
    public void ModuleIsError()
    {
        Debug.Log("Module mistake!");
        gameObject.transform.parent.parent.GetComponent<BombBase>().ModuleIsError(gameObject);
    }
}
