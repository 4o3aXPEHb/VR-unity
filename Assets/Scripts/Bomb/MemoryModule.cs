using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MemoryModule : MonoBehaviour
{
    // UI Elements
    public TMP_Text displayText;
    public GameObject[] buttons; // Кнопки, на которые можно нажимать
    public TMP_Text[] buttonTexts; // Тексты на кнопках

    // Internal Variables
    private int stage = 1;
    private List<int> displayedNumbers = new List<int>(); // Числа на экране
    private List<int> pressedPositions = new List<int>(); // Запоминает позиции нажатых кнопок
    private List<int> pressedValues = new List<int>(); // Запоминает значения нажатых кнопок

    void Start()
    {
        StartStage();
    }

    void StartStage()
    {
        if (stage > 5)
        {
            Debug.Log("Module Defused!");
            return;
        }

        GenerateRandomNumbers();
        displayText.text = displayedNumbers[stage - 1].ToString();
        Debug.Log($"Stage {stage} started. Display shows {displayedNumbers[stage - 1]}");
    }

    void GenerateRandomNumbers()
    {
        displayedNumbers.Add(Random.Range(1, 5)); // Число от 1 до 4 для отображения на экране

        if (buttonTexts.Length < 4)
        {
            Debug.LogError("buttonTexts массив слишком мал!");
            return;
        }

        List<int> availableNumbers = new List<int> { 1, 2, 3, 4 }; // Доступные уникальные числа для кнопок

        for (int i = 0; i < 4; i++)
        {
            if (buttonTexts[i] != null)
            {
                // Выбираем случайное число из доступных
                int randomIndex = Random.Range(0, availableNumbers.Count);
                int chosenNumber = availableNumbers[randomIndex];
                availableNumbers.RemoveAt(randomIndex); // Удаляем число, чтобы оно не повторялось
                buttonTexts[i].text = chosenNumber.ToString(); // Устанавливаем текст кнопки
            }
            else
            {
                Debug.LogError($"buttonTexts[{i}] не привязан!");
            }
        }
    }


    void OnButtonPress(int pressedIndex)
    {
        int pressedNumber = int.Parse(buttonTexts[pressedIndex].text);

        if (CheckCorrectAnswer(pressedIndex, pressedNumber))
        {
            pressedPositions.Add(pressedIndex);
            pressedValues.Add(pressedNumber);
            Debug.Log($"Correct! Stage {stage} passed.");
            stage++;
            StartStage();
        }
        else
        {
            Debug.Log("Strike! Wrong button pressed.");
        }
    }

    bool CheckCorrectAnswer(int pressedIndex, int pressedNumber)
    {
        int displayedNumber = displayedNumbers[stage - 1];

        switch (stage)
        {
            case 1:
                if (displayedNumber == 1 || displayedNumber == 2)
                    return pressedIndex == 1; // Вторая позиция
                if (displayedNumber == 3)
                    return pressedIndex == 2; // Третья позиция
                return pressedIndex == 3; // Четвёртая позиция

            case 2:
                if (displayedNumber == 1)
                    return pressedNumber == 4; // Кнопка со значением 4
                if (displayedNumber == 2 || displayedNumber == 4)
                    return pressedIndex == pressedPositions[0]; // Та же позиция, что на этапе 1
                return pressedIndex == 0; // Первая позиция

            case 3:
                if (displayedNumber == 1)
                    return pressedNumber == pressedValues[1]; // Та же метка, что на этапе 2
                if (displayedNumber == 2)
                    return pressedNumber == pressedValues[0]; // Та же метка, что на этапе 1
                if (displayedNumber == 3)
                    return pressedIndex == 2; // Третья позиция
                return pressedNumber == 4; // Кнопка со значением 4

            case 4:
                if (displayedNumber == 1)
                    return pressedIndex == pressedPositions[0]; // Та же позиция, что на этапе 1
                if (displayedNumber == 2)
                    return pressedIndex == 0; // Первая позиция
                return pressedIndex == pressedPositions[1]; // Та же позиция, что на этапе 2

            case 5:
                if (displayedNumber == 1)
                    return pressedNumber == pressedValues[0]; // Та же метка, что на этапе 1
                if (displayedNumber == 2)
                    return pressedNumber == pressedValues[1]; // Та же метка, что на этапе 2
                if (displayedNumber == 3)
                    return pressedNumber == pressedValues[3]; // Та же метка, что на этапе 4
                return pressedNumber == pressedValues[2]; // Та же метка, что на этапе 3
        }

        return false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (hit.collider.gameObject == buttons[i])
                    {
                        OnButtonPress(i);
                        break;
                    }
                }
            }
        }

        if (displayText == null)
        {
            Debug.LogError("displayText не привязан в инспекторе!");
            return;
        }

        if (buttons == null || buttons.Length == 0)
        {
            Debug.LogError("Массив buttons не привязан или пуст!");
            return;
        }

        if (buttonTexts == null || buttonTexts.Length == 0)
        {
            Debug.LogError("Массив buttonTexts не привязан или пуст!");
            return;
        }
    }
}
