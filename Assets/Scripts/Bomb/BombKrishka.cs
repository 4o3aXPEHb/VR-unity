using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(XRGrabInteractable), typeof(Rigidbody))]
public class BombKrishka : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    public BombBase bomb;

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

    public void enable()
    {
        GetComponent<XRGrabInteractable>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void activateBomb()
    {
        transform.SetParent(null); // ���������� �� �����
        bomb.Activate();
        Debug.Log("����� ������������");
    }
    private void OnReleased(SelectExitEventArgs args)
    {
        // �������� ������ ��� ����
        rb.isKinematic = false;  // �������� ����������
        rb.useGravity = true;  // ��������� ����������
    }
}
