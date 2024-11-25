using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleProvoda : BombModule
{
    [HideInInspector]
    public List<GameObject> Lines;
    [HideInInspector]
    public int LinesCount = 0;
    [Tooltip("����� ������� ������ (0-��������, 1-������)")]
    public bool[] checkedLines;


    // Start is called before the first frame update
    void Start()
    {
        //������� ������ � ���������
        var lines = transform.Find("Lines");
        LinesCount = lines.childCount;

        for(int i=0; i<LinesCount; i++)
        {
            // ��������� ��� ������� � ������
            var lineGameObject = lines.GetChild(i).gameObject;
            Lines.Add(lineGameObject);
            // �������� ����������� ������ ������� � ��������� ����������
            lineGameObject.transform.Find("SolidLine").GetComponent<MeshRenderer>().enabled = true;
            lineGameObject.transform.Find("CutedLine").GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �������� �������� �� ������� ������
    public void checkMistakes(GameObject Line)
    {
        int index = Lines.FindIndex(l => l == Line);
        if (checkedLines[index] == false)
        {
            ModuleIsError();
        }
        else
        {
            // �������� �������� (������ �� ������� ����� ������) �� ������������
            for(int i =0; i<LinesCount; i++)
            {
                if (checkedLines[i] == false) continue;
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
}
