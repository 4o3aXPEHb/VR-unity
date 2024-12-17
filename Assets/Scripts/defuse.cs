using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class defuse : MonoBehaviour
{
    public List<GameObject> SelectedProvods;
    public GameObject SelectedProvod;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedProvods.Count > 0) SelectedProvod = SelectedProvods[0];
        else SelectedProvod = null;

        
    }

    public void Defuse()
    {
        if (SelectedProvod != null)
        {
            SelectedProvod.GetComponent<Provod>().cut();
            SelectedProvods.Remove(SelectedProvod);
            if (SelectedProvods.Count > 0) SelectedProvods[0].GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Provod")
        {
            foreach(GameObject Line in SelectedProvods)
            {
                Line.GetComponent<Outline>().enabled = false;
            }
            other.GetComponent<Outline>().enabled = true;
            SelectedProvods.Insert(0, other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Provod")
        {
            other.GetComponent<Outline>().enabled = false;
            SelectedProvods.Remove(other.gameObject);
            if (SelectedProvods.Count > 0) SelectedProvods[0].GetComponent<Outline>().enabled = true;
        }
    }
}
