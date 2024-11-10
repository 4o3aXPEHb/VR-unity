using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleProvoda : MonoBehaviour, IModule
{
    [HideInInspector]
    public List<GameObject> Lines;
    [HideInInspector]
    public int LinesCount = 0;
    [Tooltip("какие провода резать (0-оставить, 1-резать)")]
    public bool[] checkedLines;
    public bool isCompleted = false;

    bool IModule.isCompleted { get => isCompleted; set => isCompleted = value; }

    // Start is called before the first frame update
    void Start()
    {
        //находит объект с проводами
        var lines = transform.Find("Lines");
        LinesCount = lines.childCount;

        for(int i=0; i<LinesCount; i++)
        {
            // добавляет все провода в список
            var lineGameObject = lines.GetChild(i).gameObject;
            Lines.Add(lineGameObject);
            // включает отображение целого провода и выключает порезанный
            lineGameObject.transform.Find("SolidLine").GetComponent<MeshRenderer>().enabled = true;
            lineGameObject.transform.Find("CutedLine").GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // проверка правльно ли порезан провод
    public void checkMistakes(GameObject Line)
    {
        int index = Lines.FindIndex(l => l == Line);
        if (checkedLines[index] == false)
        {
            ModuleIsError();
        }
        else
        {
            // проверка всех проводов на правильность
            for(int i =0; i<LinesCount; i++)
            {
                if (Lines[i].GetComponent<Provod>().isCuted == checkedLines[i])
                {
                    isCompleted = true;
                    continue;
                }
                else
                {
                    isCompleted = false;
                    break;
                }
            }
        }
        if (isCompleted) ModuleIsComplete();
    }

    public void ModuleIsComplete()
    {
        Debug.Log("Module has been defused!");
        gameObject.transform.parent.parent.GetComponent<BombBase>().ModuleIsComplete(gameObject);
    }

    public void ModuleIsError()
    {
        Debug.Log("Module mistake!");
        gameObject.transform.parent.parent.GetComponent<BombBase>().ModuleIsError(gameObject);
    }
}
