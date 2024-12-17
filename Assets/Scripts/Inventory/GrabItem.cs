using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabItem : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    public GameObject parent;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        parent = transform.parent.gameObject;

        // ������������� �� �������
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        // ������������ �� �������
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }
    private void OnReleased(SelectExitEventArgs args)
    {
        // �������� ������ ��� ����
        rb.isKinematic = false;  // �������� ����������
        rb.useGravity = true;  // ��������� ����������
        transform.SetParent(parent.transform);
    }
}
