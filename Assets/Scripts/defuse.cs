using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class defuse : MonoBehaviour
{
    public GameObject BombModule;
    public List<GameObject> SelectedSolidLines;
    public GameObject SelectedSolidLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedSolidLines.Count > 0) SelectedSolidLine = SelectedSolidLines[0];
        else SelectedSolidLine = null;

        if (Input.GetKey(KeyCode.G) && SelectedSolidLine!=null)
        {
            SelectedSolidLine.GetComponent<CutTheLine>().cut();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SolidLine")
        {
            other.GetComponent<Outline>().enabled = true;
            SelectedSolidLines.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SolidLine")
        {
            other.GetComponent<Outline>().enabled = false;
            SelectedSolidLines.Remove(other.gameObject);
        }
    }
}
