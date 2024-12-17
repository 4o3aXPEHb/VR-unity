using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchCollider : MonoBehaviour
{
    public GameObject SearchPoint;
    [SerializeField]
    public float DistanceToBomb;
    //[Range(0,10)]
    //public float peepRate;
    //public float peepScale = 0;
    public List<GameObject> bombs = new List<GameObject>();

    public float maxDistance = 10f; // ������������ ���������� ��� �����������
    public float minInterval = 0.1f; // ����������� �������� ����� ���������
    public float maxInterval = 1f;  // ������������ �������� ����� ���������
    private float timer = 0f;       // ������ ��� �����


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bombs.Count != 0)
        {
            Transform nearestBomb = bombs.OrderBy(b => Vector3.Distance(SearchPoint.transform.position, b.transform.position)).FirstOrDefault().transform;
            DistanceToBomb = Vector3.Distance(SearchPoint.transform.position, nearestBomb.transform.position);
            //float MinDistance = 100000;
            //foreach (GameObject bomb in bombs)
            //{
            //    float CurDistance = Vector3.Distance(SearchPoint.transform.position, bomb.transform.position);
            //    if (CurDistance < MinDistance) MinDistance = CurDistance;
            //}
            //DistanceToBomb = MinDistance;
        }
        else DistanceToBomb = -1;

        if(DistanceToBomb != -1)
        {
            if (DistanceToBomb <= maxDistance)
            {
                // ��������������� ���������� ��������� ��������
                float interval = Mathf.Lerp(minInterval, maxInterval, DistanceToBomb / maxDistance);

                // ������ ��� ��������������� �����
                timer -= Time.deltaTime;
                if (timer <= 0f)
                {
                    Debug.Log("PEEP!!");
                    timer = interval;
                }
            }
            //peepScale += peepRate / DistanceToBomb;
            //if(peepScale > 100)
            //{
            //    peepScale = 0;
            //    Debug.Log("PEEP!!");
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            bombs.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            bombs.Remove(other.gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.tag);
    //}


}
