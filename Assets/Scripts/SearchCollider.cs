using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCollider : MonoBehaviour
{
    public GameObject SearchPoint;
    [SerializeField]
    public float DistanceToBomb;
    [Range(0,10)]
    public float peepRate;
    public float peepScale = 0;
    public List<GameObject> bombs = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bombs.Count != 0)
        {
            float MinDistance = 100000;
            foreach (GameObject bomb in bombs)
            {
                float CurDistance = Vector3.Distance(SearchPoint.transform.position, bomb.transform.position);
                if (CurDistance < MinDistance) MinDistance = CurDistance;
            }
            DistanceToBomb = MinDistance;
        }
        else DistanceToBomb = -1;

        if(DistanceToBomb != -1)
        {
            peepScale += peepRate / DistanceToBomb;
            if(peepScale > 100)
            {
                peepScale = 0;
                Debug.Log("PEEP!!");
            }
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
