using UnityEngine;
using UnityEngine.UI;

public class ButtonBomb : BombModule
{
    private bool isHeld = false; // Флаг удержания кнопки
    private float holdTime = 0f; // Время удержания кнопки
    private BombTimer Timer; // Ссылка на скрипт таймера
    [Range(0, 1)]
    public int mode = 0;
    public int timerNumber = 4;

    public Image indicatorBar; // UI-объект для отображения состояния (если это 2D)
    public Renderer indicatorRenderer; // Материал для 3D-объекта

    public float fillDuration = 1f; // Время заполнения полоски (например, 1 секунда)
    private bool isDefused = false; // Флаг, указывающий, обезврежена ли бомба

    void Update()
    {
        if (isDefused) return; // Если бомба обезврежена, прекращаем обновление

        if (isHeld)
        {
            holdTime += Time.deltaTime; // Увеличиваем время удержания

            // Обновляем заполнение полоски
            if (indicatorBar != null)
            {
                indicatorBar.fillAmount = Mathf.Clamp01(holdTime / fillDuration);
            }
        }
        else
        {
            // Если не удерживаем и бомба ещё не обезврежена, сбрасываем заполнение
            if (indicatorBar != null && indicatorBar.fillAmount > 0)
            {
                indicatorBar.fillAmount = Mathf.Max(indicatorBar.fillAmount - Time.deltaTime / fillDuration, 0);
            }
        }
    }

    private void OnMouseDown()
    {
        if (isDefused) return; // Если бомба уже обезврежена, игнорируем нажатие

        isHeld = true;
        holdTime = 0f; // Сбрасываем таймер при начале удержания
        Debug.Log("Mouse button is being held on the cube.");
        UpdateIndicator(Color.yellow); // Устанавливаем цвет на "удержание"

        // Сбрасываем заполнение полоски
        if (indicatorBar != null)
        {
            indicatorBar.fillAmount = 0f;
        }
    }

    private void OnMouseUp()
    {
        if (isDefused) return; // Если бомба уже обезврежена, игнорируем отпускание

        isHeld = false;

        if (mode == 0)
        {
            if (holdTime < 0.5f) // Если удержание меньше 0.5 секунды
            {
                Debug.Log("Short click detected.");
                DefuseBomb(); // Успешное обезвреживание
            }
            else
            {
                Debug.Log($"Mouse button released after holding for {holdTime:F2} seconds.");
                ModuleIsError();
                UpdateIndicator(Color.red); // Устанавливаем цвет на "ошибка"
            }
        }
        else if (mode == 1)
        {
            if (holdTime < 0.5f)
            {
                Debug.Log("Short click detected.");
                ModuleIsError();
                UpdateIndicator(Color.red); // Ошибка на короткое нажатие
            }
            else
            {
                var timerSec = Mathf.FloorToInt(Timer.timer % 60);
                var timerMin = Mathf.FloorToInt(Timer.timer / 60);
                int number1 = timerSec % 10;
                int number2 = timerSec / 10;
                int number3 = timerMin % 10;
                int number4 = timerMin / 10;
                if (number1 == timerNumber || number2 == timerNumber || number3 == timerNumber || number4 == timerNumber)
                {
                    DefuseBomb(); // Успешное обезвреживание
                }
                else
                {
                    ModuleIsError();
                    UpdateIndicator(Color.red); // Ошибка
                }
            }
        }
    }

    private void Start()
    {
        Timer = transform.parent.parent.GetComponent<BombTimer>();

        // Проверяем, есть ли указанный UI или Renderer
        if (indicatorBar == null && indicatorRenderer == null)
        {
            Debug.LogError("Indicator not assigned!");
        }

        // Убедимся, что полоска изначально пуста
        if (indicatorBar != null)
        {
            indicatorBar.fillAmount = 0f;
        }
    }

    private void UpdateIndicator(Color color)
    {
        if (indicatorBar != null)
        {
            indicatorBar.color = color; // Меняем цвет для UI
        }

        if (indicatorRenderer != null)
        {
            indicatorRenderer.material.color = color; // Меняем цвет для 3D-объекта
        }
    }

    private void DefuseBomb()
    {
        isDefused = true; // Устанавливаем флаг обезвреживания
        ModuleIsComplete();
        UpdateIndicator(Color.green); // Устанавливаем зелёный цвет
        Debug.Log("Bomb successfully defused!");
    }
}
