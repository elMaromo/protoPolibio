using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public Transform placeFromTV, placeFarAway, playerCamera;
    public bool startFromTV;
    public float timeToMove;
    public float howCloseToTv;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        if (startFromTV)
        {
            Vector3 posInitPlayer = placeFromTV.position;
            posInitPlayer += placeFromTV.forward * howCloseToTv;
            playerCamera.position = posInitPlayer;
            playerCamera.rotation = placeFromTV.rotation;

            playerCamera.DOMove(placeFarAway.position, timeToMove);
            playerCamera.DORotate(placeFarAway.eulerAngles, timeToMove);
        }
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





