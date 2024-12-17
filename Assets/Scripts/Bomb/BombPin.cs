using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable), typeof(Rigidbody))]
public class BombPin : MonoBehaviour
{
    public GameObject krishka;

    private bool isPulled = false;
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        // ������������� �� �������
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        // ������������ �� �������
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }


    public void ReleasePin()
    {
        isPulled = true;
        transform.SetParent(null); // ���������� �� �����
        Debug.Log("pin");

        //�������� ������
        krishka.GetComponent<BombKrishka>().enable();
    }
    private void OnReleased(SelectExitEventArgs args)
    {
        // �������� ������ ��� ����
        rb.isKinematic = false;  // �������� ����������
        rb.useGravity = true;  // ��������� ����������
    }
}
