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

        // Подписываемся на события
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        // Отписываемся от событий
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }
    private void OnReleased(SelectExitEventArgs args)
    {
        // Включаем физику для чеки
        rb.isKinematic = false;  // Включаем кинематику
        rb.useGravity = true;  // Отключаем гравитацию
        transform.SetParent(parent.transform);
    }
}
