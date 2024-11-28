using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGrid : MonoBehaviour
{
    public int horizontalDirection;
    public int verticalDirection;
    private ModuleGrid module;
    // Start is called before the first frame update
    void Start()
    {
        module = transform.parent.parent.GetComponent<ModuleGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        module.Move(horizontalDirection, verticalDirection);
    }
}
