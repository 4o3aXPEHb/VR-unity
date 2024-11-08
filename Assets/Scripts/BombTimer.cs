using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    [Range(10, 600)]
    [Tooltip("в секундах")]
    public float timer; // in sec
    public bool timerIsRun = false;
    private TextMeshPro tmpro;

    // Start is called before the first frame update
    void Start()
    {
        tmpro = transform.Find("TimerText").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRun)
        {
            timer -= Time.deltaTime;
            var timerSec = Mathf.FloorToInt(timer % 60);
            var timerMin = Mathf.FloorToInt(timer / 60);
            tmpro.text = string.Format("{0:00}:{1:00}",timerMin,timerSec);
        }
        if (timer < 0)
        {
            timerIsRun = false;
            timer = 0;
            tmpro.text = "00:00";
        }
    }
}
