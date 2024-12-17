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

        // Подписываемся на события
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        // Отписываемся от событий
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    public void enable()
    {
        GetComponent<XRGrabInteractable>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void activateBomb()
    {
        transform.SetParent(null); // Открепляем от бомбы
        bomb.Activate();
        Debug.Log("бомба активирована");
    }
    private void OnReleased(SelectExitEventArgs args)
    {
        // Включаем физику для чеки
        rb.isKinematic = false;  // Включаем кинематику
        rb.useGravity = true;  // Отключаем гравитацию
    }
}
