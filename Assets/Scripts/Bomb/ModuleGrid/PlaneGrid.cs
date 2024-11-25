using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGrid : MonoBehaviour
{
    private Texture2D _texture;
    [SerializeField] private int resolution = 128;
    [SerializeField] private int lineWidth = 2;
    [SerializeField] private int playerWidth = 2;
    private Color gridColor = new Color(72, 61, 139);
    public Color col1 = Color.red;
    public Color col2 = new Color(255,144,0);
    public Color col3 = new Color(0, 200, 250);
    public Color col4 = new Color(30, 90, 250);

    private int cellsCount;
    private int cellWidth;
    private ModuleGrid module;
    // Start is called before the first frame update
    void Start()
    {
        module = transform.parent.GetComponent<ModuleGrid>();
        cellsCount = module.cellsCount;

        _texture = new Texture2D(resolution, resolution);
        GetComponent<Renderer>().material.mainTexture = _texture;

        _texture.filterMode = FilterMode.Point;

        cellWidth = resolution / cellsCount;
        Render();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Color checkColor()
    {
        var x = module.playerPosX - module.targetPosX;
        var y = module.playerPosY - module.targetPosY;

        if (x < 0) x = -x;
        if (y < 0) y = -y;
        var len = Math.Sqrt(x * x + y * y);
        Color color;
        if (len < 2.5f)
        {
            color = col1;
        }
        else if(len < 4.3f)
        {
            color = col2;
        }
        else if(len < 6.7f)
        {
            color = col3;
        }
        else
        {
            color = col4;
        }
        return color;
    }

    public void Render()
    {
        _texture.Reinitialize(resolution,resolution);
        int step = (int)Math.Floor((decimal)resolution / cellsCount);

        //сетка по Х
        int offset = 0;
        for (int i = 0; i < lineWidth; i++)
        {
            for (int x = 0; x < resolution; x += step)
            {
                for (int y = 0; y < resolution; y++)
                {
                    _texture.SetPixel(x - offset, y, gridColor);
                }
            }
            offset += 1;
        }

        //сетка по у
        offset = 0;
        for (int i = 0; i < lineWidth; i++)
        {
            for (int x = 0; x < resolution; x++)
            {
                for (int y = 0; y < resolution; y += step)
                {
                    _texture.SetPixel(x, y - offset, gridColor);
                }
            }
            offset += 1;
        }

        //игрок
        int xPos = module.playerPosX * cellWidth + cellWidth / 2 - playerWidth / 2;
        int yPos = module.playerPosY * cellWidth + cellWidth / 2 - playerWidth / 2;
        for (int i = 0; i < playerWidth; i++)
        {
            for (int j = 0; j < playerWidth; j++)
            {
                _texture.SetPixel(xPos + i, yPos + j, checkColor());
            }
        }

        _texture.Apply();
    }
}
