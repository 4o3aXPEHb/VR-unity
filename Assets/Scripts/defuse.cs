using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defuse : MonoBehaviour
{
    public GameObject BombModule;
    public List<GameObject> CurSolidLines;
    public GameObject CurSolidLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurSolidLines.Count > 0) CurSolidLine = CurSolidLines[0];
        else CurSolidLine = null;

        if (Input.GetKey(KeyCode.G) && CurSolidLine!=null)
        {
            CurSolidLine.GetComponent<MeshRenderer>().enabled = false;
            CurSolidLine.transform.parent.Find("CutedLine").GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SolidLine")
        {
            other.GetComponent<Outline>().enabled = true;
            CurSolidLines.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SolidLine")
        {
            other.GetComponent<Outline>().enabled = false;
            CurSolidLines.Remove(other.gameObject);
        }
    }
}
