using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachine
{
    public class MarkersHide : MonoBehaviour
    {
        [SerializeField] private List<Button> bigLabels = new List<Button>();

        private void Start()
        {
            // Устанавливаем слушателей на все кнопки в списке
            foreach (Button label in bigLabels)
            {
                Button localLabel = label; // Локальная переменная для захвата значения в замыкании
                label.onClick.AddListener(() => OnButtonClick(localLabel));
            }
        }

        private void OnButtonClick(Button clickedButton)
        {
            foreach (Button label in bigLabels)
            {
                // Получаем трансформ родительской панели, к которой привязаны кнопка и текст
                Transform parentTransform = label.transform.parent.parent;

                // Находим элементы: Frame 206 (предположительно 0-й элемент) и текст (предположительно 1-й элемент)
                //Transform frame206 = parentTransform.GetChild(0); // Frame 206
                Image frame206 = parentTransform.GetComponent<Image>(); // Frame 206
                Transform ButtonPanel = parentTransform.GetChild(1).GetChild(0); // кнопка
                Transform textPanel = parentTransform.GetChild(0); // текст

                // Активируем или деактивируем Frame 206 и текст в зависимости от того, является ли кнопка нажатой
                bool isActive = (label == clickedButton);
                frame206.enabled = !isActive; // Скрываем Frame 206, если кнопка нажата
                textPanel.gameObject.SetActive(!isActive); // Скрываем текст, если кнопка нажата
                ButtonPanel.gameObject.SetActive(!isActive); // Скрываем текст, если кнопка нажата

                // Управляем дополнительной панелью (3-й элемент)
                Transform extraPanel = parentTransform.GetChild(2);
                extraPanel.gameObject.SetActive(isActive); // Отображаем доп панель только для нажатой кнопки

                SetSliderState();
            }
        }

        public void ResetMarkers()
        {
            foreach (Button label in bigLabels)
            {
                // Получаем трансформ родительской панели, к которой привязаны кнопка и текст
                Transform parentTransform = label.transform.parent.parent;

                // Находим элементы: Frame 206 (предположительно 0-й элемент) и текст (предположительно 1-й элемент)
                //Transform frame206 = parentTransform.GetChild(0); // Frame 206
                Image frame206 = parentTransform.GetComponent<Image>(); // Frame 206
                Transform ButtonPanel = parentTransform.GetChild(1).GetChild(0); // кнопка
                Transform textPanel = parentTransform.GetChild(0); // текст

                // Активируем или деактивируем Frame 206 и текст в зависимости от того, является ли кнопка нажатой
                frame206.enabled = true; // Скрываем Frame 206, если кнопка нажата
                textPanel.gameObject.SetActive(true); // Скрываем текст, если кнопка нажата
                ButtonPanel.gameObject.SetActive(true); // Скрываем текст, если кнопка нажата

                // Управляем дополнительной панелью (3-й элемент)
                Transform extraPanel = parentTransform.GetChild(2);
                extraPanel.gameObject.SetActive(false); // Отображаем доп панель только для нажатой кнопки
            }
        }

        private void SetSliderState()
        {
            FindObjectOfType<StateMachineButtons>().ChangeState(States.Slider);
        }
    }
}
