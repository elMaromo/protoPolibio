using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public bool startFromTV;
    public float timeToMove;
    public float masterVolume;
    public float masterBrightness;

    private int maxFps = 144;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = maxFps;
        }

        DontDestroyOnLoad(gameObject);
    }



    public void LoadScenewithDelay(string sceneName, float delay)
    {
        StartCoroutine(LoadScene(sceneName, delay));
    }

    public IEnumerator LoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);

        yield return null;
    }
}





