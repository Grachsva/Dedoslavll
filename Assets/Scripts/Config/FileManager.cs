using UnityEngine;
using System.IO;
using System.Collections;
using SliderPages;
using UI.Pagination;
using UnityEngine.Video;

public class FileManager : MonoBehaviour
{
    private string filePath;
    private Coroutine checkCoroutine;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private float waitTime = 200f;

    private void OnEnable()
    {
        FillVideo.e_VideoReady += AddTimer;
    }

    private void Start()
    {
        // Определите путь к файлу check.json в папке StreamingAssets
        filePath = Path.Combine(Application.streamingAssetsPath, "check.json");
    }

    private void AddTimer(Page page)
    {
        CheckTiming(page);
    }

    private void CheckTiming(Page page)
    {
        videoPlayer = page.gameObject.GetComponentInChildren<VideoPlayer>();

        // Начинаем корутину для ожидания подготовки видео и получения его длины
        StartCoroutine(PrepareAndSetTimer());
    }

    private IEnumerator PrepareAndSetTimer()
    {
        videoPlayer.Prepare();

        // Ждем, пока видео не будет готово
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Waiting for video to be prepared...");
            waitTime = 120f;
            yield return null;
        }

        // Получаем длину видео в секундах после того, как оно готово
        float videoLength = (float)videoPlayer.length;
        Debug.Log("Video Length: " + videoLength);

        // Устанавливаем время ожидания
        waitTime = videoLength + 10f;

        // Сбрасываем таймер с новым временем ожидания
        ResetTimer(waitTime);
    }

    void Update()
    {
        // Проверка на наличие касаний или нажатий мыши
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // Если произошло касание или нажатие, сбрасываем таймер
            ResetTimer(waitTime);
        }
    }

    // Метод для сброса таймера
    private void ResetTimer(float time)
    {
        if (checkCoroutine != null)
        {
            // Останавливаем текущую корутину
            StopCoroutine(checkCoroutine);
        }

        // Перезапускаем корутину
        checkCoroutine = StartCoroutine(CheckWindowState(time));
    }

    private IEnumerator CheckWindowState(float time)
    {
        // Обновляем значение в check.json на true (делаем окно активным)
        UpdateCheckFile(true);

        // Ждем указанное количество секунд
        yield return new WaitForSeconds(time);

        // Обновляем значение в check.json на false (делаем окно неактивным)
        UpdateCheckFile(false);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            print("OnApplicationFocus");
            UpdateCheckFile(focus);
        }
    }

    private void UpdateCheckFile(bool isActive)
    {
        // Проверяем путь к файлу
        if (string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("File path is null or empty.");
            return;
        }

        // Сериализуем данные в JSON
        CheckData checkData = new CheckData { isActive = isActive };
        string json = JsonUtility.ToJson(checkData);

        if (json == null)
        {
            Debug.LogError("JSON serialization returned null.");
            return;
        }

        try
        {
            // Записываем данные в файл check.json
            File.WriteAllText(filePath, json);
            Debug.Log("File updated: " + filePath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to write to file: " + ex.Message);
        }
    }


    [System.Serializable]
    public class CheckData
    {
        public bool isActive;
    }
}
