using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module1_Lines : MonoBehaviour
{

    public List<GameObject> Lines;
    public int LinesCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        var lines = transform.Find("Lines");
        LinesCount = lines.childCount;

        for(int i=0; i<LinesCount; i++)
        {
            var lineGameObject = lines.GetChild(i).gameObject;
            Lines.Add(lineGameObject);
            lineGameObject.transform.Find("CutedLine").GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
