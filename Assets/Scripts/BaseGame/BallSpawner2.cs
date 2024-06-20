using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallSpawner2 : MonoBehaviour
{
    public int initialBallsAmount = 3;
    public float spawnDelaySeconds = 2;
    public float BallsRate = 1;
    public float forceMultiplier = 20;
    public BallControllerV2 ballPrefab;
    public TextMeshProUGUI ballsText;
    public Image ballsImage;
    public Vector2 minDir;
    public Vector2 maxDir;
    private int ballsAvailable;
    private int destroyedBallsCounter;
    public event Action OnBallsEmpty;

    private void Start()
    {
        ballsAvailable = initialBallsAmount;
        UpdateBallsText();
        SpawnBallInSeconds(spawnDelaySeconds);
    }

    public void OnBallDestroyed()
    {
        destroyedBallsCounter++;
        if (destroyedBallsCounter < BallsRate)
        {
            return;
        }

        SpawnBallInSeconds(spawnDelaySeconds);
        destroyedBallsCounter = 0;
    }

    private void SpawnBallInSeconds(float seconds)
    {
        if (ballsAvailable <= 0)
        {
            ballsImage.color = new Color(ballsImage.color.r, ballsImage.color.g, ballsImage.color.b, .1f);
            OnBallsEmpty?.Invoke();
            return;
        }

        for (int i = 0; i < Mathf.Min(BallsRate,ballsAvailable); i++)
        {
            StartCoroutine(SpawnBallCoroutine(seconds));
        }
    }

    private IEnumerator SpawnBallCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        var forceX = Random.Range(minDir.x, maxDir.x);
        var forceY = Random.Range(minDir.y, maxDir.y);
        Vector2 ballForce = new Vector2(forceX, forceY);
        ball.Init(this, ballForce * Random.Range(forceMultiplier - 10, forceMultiplier + 10));
        ballsAvailable--;
        UpdateBallsText();
    }

    private void UpdateBallsText()
    {
        ballsText.text = "x" + ballsAvailable;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)minDir * forceMultiplier);
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)maxDir * forceMultiplier);
    }
}