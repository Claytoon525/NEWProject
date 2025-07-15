using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("Game Variables")]
    public PlayerController player;
    public float time;
    public bool timeActive;
    public int level;

    [Header("Game UI")]
    public TMP_Text gameUI_health;
    public TMP_Text gameUI_level;
    public TMP_Text gameUI_time;

    [Header("Countdown UI")]
    public TMP_Text countdownText;
    public int countdown;

    [Header("Screens")]
    public GameObject countdownUI;
    public GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        time = 0;
        player.enabled = false;
        SetScreen(countdownUI);
        StartCoroutine(CountDownRoutine());
    }


    void startGame()
    {
        SetScreen(gameUI);
        timeActive = true;
        level = 1;
    }

    public void endGame()
    {
        timeActive = false;
        player.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeActive)
        {
            time += Time.deltaTime;
        }
        gameUI_health.text = "Health: " + player.health;
        gameUI_level.text = "Level: " + level;
        gameUI_time.text = "Time: " + (time *10).ToString("F2");
    }

    public void SetScreen(GameObject screen)
    {
        gameUI.SetActive(false);
        countdownUI.SetActive(false);
        screen.SetActive(true);
    }
    IEnumerator CountDownRoutine()
    {
        countdownText.gameObject.SetActive(true);
        for(int i = 3; i > 0; i --)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        player.enabled = true;
        startGame();
    }
}
