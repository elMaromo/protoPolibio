using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour
{
    private BallSpawner2 _ballSpawner;
    private QuestsController _questsController;
    public string nextLevelName;

    [Header("Screen")]
    [SerializeField] private GameObject _screenGameObject;
    [SerializeField]private Material _defaultScreenMat;
    [SerializeField]private Material _whiteNoiseScreenMat;
    private MeshRenderer _screenMeshRenderer;

    private void Start()
    {
        _ballSpawner = FindObjectOfType<BallSpawner2>();
        _questsController = FindObjectOfType<QuestsController>();

        _ballSpawner.OnBallsEmpty += CheckWinLose;

        _screenMeshRenderer = _screenGameObject.GetComponent<MeshRenderer>();
        _screenMeshRenderer.material = _defaultScreenMat;
    }

    private void CheckWinLose()
    {
        if (_questsController.NumberOfQuestsCompleted > 0)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    private void Win()
    {
        StartCoroutine(WinCoroutine());
    }

    private void Lose()
    {
        StartCoroutine(LoseCoroutine());
    }

    private IEnumerator WinCoroutine()
    {
        print("VICTORY!!");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevelName);
    }

    private IEnumerator LoseCoroutine()
    {
        print("GAMEOVER");
        _screenMeshRenderer.material = _whiteNoiseScreenMat;
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        _ballSpawner.OnBallsEmpty -= CheckWinLose;
    }
}