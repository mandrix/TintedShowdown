using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField, Range(1f, 3f)] private float totalTime = 2f;

    private float currentTime = 0f;
    private bool isTiming = false;

    public ActionPlayerManager[] players;
    // Start is called before the first frame update
    private void Start()
    {
        // Iniciar la Coroutine al inicio del juego
        StartCoroutine(RoundAttack());
        currentTime = totalTime;
        timerImage.fillAmount = 1f;
        StartTimer(true);
    }

    private void Update()
    {
        if (isTiming)
        {
            currentTime -= Time.deltaTime;

            float fillAmount = currentTime / totalTime;
            timerImage.fillAmount = fillAmount;

            if (currentTime <= 0f)
            {
                currentTime = totalTime;
                timerImage.fillAmount = 1f;
            }
        }
    }

    public void StartTimer(bool state)
    {
        isTiming = state;
    }

    private IEnumerator RoundAttack()
    {
        yield return new WaitForSeconds(totalTime);
        foreach (ActionPlayerManager player in players)
        {
            player.Action();
        }
        StartCoroutine(RoundAttack());
    }
}
