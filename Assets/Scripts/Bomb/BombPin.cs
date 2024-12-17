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

        // Подписываемся на события
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        // Отписываемся от событий
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }


    public void ReleasePin()
    {
        isPulled = true;
        transform.SetParent(null); // Открепляем от бомбы
        Debug.Log("pin");

        //включаем крышку
        krishka.GetComponent<BombKrishka>().enable();
    }
    private void OnReleased(SelectExitEventArgs args)
    {
        // Включаем физику для чеки
        rb.isKinematic = false;  // Включаем кинематику
        rb.useGravity = true;  // Отключаем гравитацию
    }
}
