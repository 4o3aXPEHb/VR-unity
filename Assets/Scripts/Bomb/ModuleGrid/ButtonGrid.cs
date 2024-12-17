using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGrid : MonoBehaviour
{
    public int horizontalDirection;
    public int verticalDirection;
    private ModuleGrid module;
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        module = transform.parent.parent.GetComponent<ModuleGrid>();
    }


    public void OnMouseDown()
    {
        module.Move(horizontalDirection, verticalDirection);
    }
}
