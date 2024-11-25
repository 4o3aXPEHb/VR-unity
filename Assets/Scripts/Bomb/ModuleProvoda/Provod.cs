using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provod : MonoBehaviour
{

    public bool isCuted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cut()
    {
        gameObject.transform.Find("SolidLine").GetComponent<MeshRenderer>().enabled = false; // выключить целый
        gameObject.transform.Find("CutedLine").GetComponent<MeshRenderer>().enabled = true; // включитьт порезанный
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Outline>().enabled = false;
        isCuted = true;
        ModuleProvoda module = gameObject.transform.parent.parent.GetComponent<ModuleProvoda>();
        module.checkMistakes(gameObject);
    }
}
