using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTheLine : MonoBehaviour
{
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
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.transform.parent.Find("CutedLine").GetComponent<MeshRenderer>().enabled = true;
        ModuleProvoda module = gameObject.transform.parent.parent.parent.GetComponent<ModuleProvoda>();
        module.checkMistakes(gameObject.transform.parent.gameObject);
    }
}
