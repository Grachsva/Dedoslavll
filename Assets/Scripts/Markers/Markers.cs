using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buttons
{
    public class Markers : MonoBehaviour
    {
        private CameraMovement _cameraMovement;

        [SerializeField] private GameObject marksers_0;
        [SerializeField] private GameObject marksers_1;
        [SerializeField] private GameObject marksers_2;
        [SerializeField] private GameObject marksers_3;
        [SerializeField] private GameObject marksers_4;
        [SerializeField] private GameObject marksers_5;
        [SerializeField] private GameObject marksers_6;

        private void Start()
        {
            _cameraMovement = FindObjectOfType<CameraMovement>();
        }

        void OnEnable()
        {
            CameraMovement.e_CameraMoved += ChangeMarkers;
            CameraMovement.e_CameraMoving += ChangeMarkers;
        }


        public void ChangeMarkers()
        {
            if (_cameraMovement._isMoving)
            {
                marksers_0.SetActive(false);
                marksers_1.SetActive(false);
                marksers_2.SetActive(false);
                marksers_3.SetActive(false);
                marksers_4.SetActive(false);
                marksers_5.SetActive(false);
                marksers_6.SetActive(false);

                Time.timeScale = 1f;
                //print("play");
                //Time.timeScale = 1;
                //Application.targetFrameRate = 60; // Восстанавливаем рендеринг до нормального значения
                //if (Camera.main != null)
                //    Camera.main.enabled = true;

                return;
            }

            //else
            //{
            //    Time.timeScale = 0f;
            //    Application.Unload();
            //    //print("stop");
            //    //Time.timeScale = 0;
            //    //Application.targetFrameRate = 1;  // Ограничение до 1 кадра в секунду
            //    //if (Camera.main != null)
            //    //    Camera.main.enabled = false;
            //}
       

            if (_cameraMovement._currentPos == 0)
            {
                marksers_0.SetActive(true);
                marksers_1.SetActive(false);
                marksers_2.SetActive(false);
                marksers_3.SetActive(false);
                marksers_4.SetActive(false);
                marksers_5.SetActive(false);
                marksers_6.SetActive(false);
            }
            else if (_cameraMovement._currentPos == 1)
            {
                marksers_0.SetActive(false);
                marksers_1.SetActive(true);
                marksers_2.SetActive(false);
                marksers_3.SetActive(false);
                marksers_4.SetActive(false);
                marksers_5.SetActive(false);
                marksers_6.SetActive(false);
            }
            else if (_cameraMovement._currentPos == 2)
            {
                marksers_0.SetActive(false);
                marksers_1.SetActive(false);
                marksers_2.SetActive(true);
                marksers_3.SetActive(false);
                marksers_4.SetActive(false);
                marksers_5.SetActive(false);
                marksers_6.SetActive(false);
            }
            else if (_cameraMovement._currentPos == 3)
            {
                marksers_0.SetActive(false);
                marksers_1.SetActive(false);
                marksers_2.SetActive(false);
                marksers_3.SetActive(true);
                marksers_4.SetActive(false);
                marksers_5.SetActive(false);
                marksers_6.SetActive(false);
            }
            else if (_cameraMovement._currentPos == 4)
            {
                marksers_0.SetActive(false);
                marksers_1.SetActive(false);
                marksers_2.SetActive(false);
                marksers_3.SetActive(false);
                marksers_4.SetActive(true);
                marksers_5.SetActive(false);
                marksers_6.SetActive(false);
            }
            else if (_cameraMovement._currentPos == 5)
            {
                marksers_0.SetActive(false);
                marksers_1.SetActive(false);
                marksers_2.SetActive(false);
                marksers_3.SetActive(false);
                marksers_4.SetActive(false);
                marksers_5.SetActive(true);
                marksers_6.SetActive(false);
            }
            else if (_cameraMovement._currentPos == 6)
            {
                marksers_0.SetActive(false);
                marksers_1.SetActive(false);
                marksers_2.SetActive(false);
                marksers_3.SetActive(false);
                marksers_4.SetActive(false);
                marksers_5.SetActive(false);
                marksers_6.SetActive(true);
            }
        }
    }

    public enum MarkserStates
    {
        //CornerTower,
        //SpasskayaTower,
        //PyatnitskayaTower,
        //TowerOnVspol,
        //NikolskyOnGate,
        //StNicholasCathedral,
        //DitchWithWater,
        //LakeBeloe,
        //LakeMokhovoe

        //1. Угловая башня 
        //2. Спасская башня
        //3. Пятницкая башня
        //4. Башня на Всполе
        //5. Никольские ворота
        //6. Никольский собор
        //7. Ров с водой
        //8. Озеро Белое
        //9. Озеро Моховое
    }
}