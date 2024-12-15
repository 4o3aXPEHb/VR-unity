using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSlot : MonoBehaviour
{
    public Transform attachPoint; // �����, � ������� ������������� �������
    public Transform dropPoint;
    private GameObject currentItem;
    private Outline outline;

    private void Start()
    {
        outline = transform.Find("Zone").GetComponent<Outline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������� ��� ����� �����
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
        // ������� ���������� ������� (���� ����)
        if (currentItem != null)
        {
            DetachItem();
        }

        // ����������� ����� �������
        currentItem = item;
        item.transform.SetParent(attachPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.GetComponent<Rigidbody>().isKinematic = true; // ��������� ������
    }

    public void DetachItem()
    {
        if (currentItem != null)
        {
            currentItem.transform.SetParent(null);
            currentItem.transform.position = dropPoint.position;
            currentItem.GetComponent<Rigidbody>().isKinematic = false; // �������� ������
            currentItem = null;
        }
    }
}

