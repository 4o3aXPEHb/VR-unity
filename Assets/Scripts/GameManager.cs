using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int curDefusedBombs = 0;
    public int targetDefusedBombs = 1;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        for (int i=0; i < UI.transform.childCount; i++)
        {
            UI.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bombDefused()
    {
        curDefusedBombs += 1;
        if (curDefusedBombs == targetDefusedBombs)
        {
            Debug.Log("!!!!!YOU WIN!!!!!!");
            UI.SetActive(true);
            UI.transform.Find("Win").gameObject.SetActive(true);
        }
    }

    public void loose()
    {
        Debug.Log("YOU LOOSE  ;( BOOM!");
        UI.SetActive(true);
        UI.transform.Find("Loose").gameObject.SetActive(true);
    }

    public void changeScene(string scene)
    {
        if(scene == "Start")
        {
            SceneManager.LoadScene("Start");
        }
    }
}
