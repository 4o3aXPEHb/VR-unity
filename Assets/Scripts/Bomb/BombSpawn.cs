using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public GameObject bomb;
    BombBase bombBase;
    public int targetDigTimes = 4;
    private int currentDigTimes = 0;

    // Start is called before the first frame update
    private void Start()
    {
        bomb = transform.Find("Bomb").gameObject;
        bombBase = bomb.GetComponent<BombBase>();
    }
    public void Spawn()
    {
        currentDigTimes++;
        if(currentDigTimes == targetDigTimes)
        {
            transform.Find("Kucha").gameObject.SetActive(false);
            bomb.SetActive(true);
        }
    }
}
