using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBase : MonoBehaviour
{
    public int maxErrors = 3;
    [SerializeField]
    private int curErrors = 0;
    [SerializeField]
    private bool isCompleted = false;
    [SerializeField]
    private List<GameObject> Modules;
    private int ModulesCount;
    // Start is called before the first frame update
    void Start()
    {
        //находит объект с модулями
        var modules = transform.Find("Modules");
        ModulesCount = modules.childCount;

        for (int i = 0; i < ModulesCount; i++)
        {
            // добавляет модуль в список
            var moduleGameObject = modules.GetChild(i).gameObject;
            Modules.Add(moduleGameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModuleIsComplete(GameObject comletedModule)
    {
        // проверка всех модулей на правильность
        foreach (GameObject m in Modules)
        {
            if (m.GetComponent<BombModule>().isCompleted == true)
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
        
        if (isCompleted) Debug.Log("Bomb has been defused!");
    }

    public void ModuleIsError(GameObject errorModule)
    {
        curErrors += 1;
        if(curErrors >= maxErrors || errorModule == gameObject) // ... или ошибка в самой бомбе (например таймер)
        {
            Debug.Log("BooM!");
        }
    }
}
