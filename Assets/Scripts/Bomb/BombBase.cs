using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBase : MonoBehaviour
{
    public GameManager gameManager;
    public int maxErrors = 3;
    [SerializeField]
    private int curErrors = 0;
    [SerializeField]
    private bool isCompleted = false;
    [SerializeField]
    private List<GameObject> Modules;
    private int ModulesCount;
    private BombTimer timer;
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
            moduleGameObject.SetActive(false);
        }
    }

    public void Activate()
    {
        timer = gameObject.GetComponent<BombTimer>();
        timer.timerIsRun = true;
        foreach (GameObject module in Modules)
        {
            module.SetActive(true);
        }
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

        if (isCompleted)
        {
            Debug.Log("Bomb has been defused!");
            gameManager.bombDefused();
        }
    }

    public void ModuleIsError(GameObject errorModule)
    {
        curErrors += 1;
        if(curErrors >= maxErrors || errorModule == gameObject) // ... или ошибка в самой бомбе (например таймер)
        {
            gameManager.loose();
        }
    }

}
