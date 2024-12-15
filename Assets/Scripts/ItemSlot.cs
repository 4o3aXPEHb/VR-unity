using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSlot : MonoBehaviour
{
    public Transform attachPoint; // Точка, к которой прикрепляется предмет
    public Transform dropPoint;
    private GameObject currentItem;
    private Outline outline;

    private void Start()
    {
        outline = transform.Find("Zone").GetComponent<Outline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, подходит ли предмет для этого слота
        if (other.CompareTag("Item"))
        {
            AttachItem(other.gameObject);
            outline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item") && other.gameObject == currentItem)
        {
            DetachItem();
            outline.enabled = false;
        }
    }

    private void AttachItem(GameObject item)
    {
        // Убираем предыдущий предмет (если есть)
        if (currentItem != null)
        {
            DetachItem();
        }

        // Прикрепляем новый предмет
        currentItem = item;
        item.transform.SetParent(attachPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.GetComponent<Rigidbody>().isKinematic = true; // Отключаем физику
    }

    public void DetachItem()
    {
        if (currentItem != null)
        {
            currentItem.transform.SetParent(null);
            currentItem.transform.position = dropPoint.position;
            currentItem.GetComponent<Rigidbody>().isKinematic = false; // Включаем физику
            currentItem = null;
        }
    }
}

