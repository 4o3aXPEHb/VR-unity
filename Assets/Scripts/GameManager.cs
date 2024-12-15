using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int curDefusedBombs = 0;
    int targetDefusedBombs = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bombDefused()
    {
        curDefusedBombs += 1;
        if (curDefusedBombs == targetDefusedBombs) Debug.Log("!!!!!YOU WIN!!!!!!");
    }

    public void loose()
    {
        Debug.Log("YOU LOOSE  ;( BOOM!");
    }
}
