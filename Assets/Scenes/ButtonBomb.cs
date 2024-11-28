using UnityEngine;

public class ButtonBomb: MonoBehaviour
{
    private bool isHeld = false;
    private float holdTime = 0f;

    void Update()
    {
        if (isHeld)
        {
            holdTime += Time.deltaTime; // Увеличиваем время удержания
        }
    }

    private void OnMouseDown()
    {
        isHeld = true;
        holdTime = 0f; // Сбрасываем таймер при начале удержания
        Debug.Log("Mouse button is being held on the cube.");
    }

    private void OnMouseUp()
    {
        isHeld = false;
        Debug.Log($"Mouse button released after {holdTime:F2} seconds.");
        // Добавьте свою логику при отпускании кнопки
    }
}
