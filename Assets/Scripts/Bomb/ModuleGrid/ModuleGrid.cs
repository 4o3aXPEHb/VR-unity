using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleGrid : BombModule
{
    public int cellsCount = 8;
    [Header("Игрок")]
    public int playerPosX = 0;
    public int playerPosY = 0;
    [Header("Цель")]
    public int targetPosX = 1;
    public int targetPosY = 1;
    public GameObject indicator;

    private PlaneGrid planeGrid;
    // Start is called before the first frame update
    void Start()
    {
        indicator.SetActive(false);
        planeGrid = transform.Find("PlaneGrid").GetComponent<PlaneGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int horizontal, int vertical)
    {
        if (isCompleted == false)
        {
            playerPosX += horizontal;
            playerPosY += vertical;

            if (playerPosX < 0) playerPosX = 0;
            if (playerPosX >= cellsCount) playerPosX = cellsCount - 1;

            if (playerPosY < 0) playerPosY = 0;
            if (playerPosY >= cellsCount) playerPosY = cellsCount - 1;

            if (playerPosX == targetPosX && playerPosY == targetPosY)
            {
                indicator.SetActive(true);
                ModuleIsComplete();
            }

            planeGrid.Render();
        }
    }
}
