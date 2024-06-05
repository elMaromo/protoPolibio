using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallSpawner2 : MonoBehaviour
{
    public int initialBallsAmount = 3;
    public BallControllerV2 ballPrefab;
    public TextMeshProUGUI ballsText;
    public Vector2 minDir;
    public Vector2 maxDir;
    public float forceMultiplier;
    private int ballsAvailable;

    public event Action OnBallsEmpty; 

    private void Start()
    {
        ballsAvailable = initialBallsAmount;
        UpdateBallsText();
        SpawnBallInSeconds(2);
    }

    public void OnBallDestroyed()
    {
        SpawnBallInSeconds(2);
    }

    private void SpawnBallInSeconds(float seconds)
    {
        if (ballsAvailable <= 0)
        {
            //ballImage.color=new Color(ballImage.color.r,ballImage.color.g,ballImage.color.b,.1f);
            OnBallsEmpty?.Invoke();
            return;
        }
        ballsAvailable--;
        
        StartCoroutine(SpawnBallCoroutine(seconds));
    }

    private IEnumerator SpawnBallCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        UpdateBallsText();
        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        var forceX = Random.Range(minDir.x, maxDir.x);
        var forceY = Random.Range(minDir.y, maxDir.y);
        Vector2 ballForce = new Vector2(forceX,forceY);
        ball.Init(this,ballForce*forceMultiplier);
    }

    private void UpdateBallsText()
    {
        ballsText.text = "x" + ballsAvailable;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.green;
        Gizmos.DrawLine(transform.position,transform.position+(Vector3)minDir*forceMultiplier);
        Gizmos.DrawLine(transform.position,transform.position+(Vector3)maxDir*forceMultiplier);
    }
}