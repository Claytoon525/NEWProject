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
    public GameObject endUI;

    [Header("End UI")]
    public TMP_Text endUI_level;
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
        endUI_level.text = "Final Level: " + level;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SetScreen(endUI);
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
        gameUI_time.text = "Time: " + (time *1).ToString("F2");
    }

    public void SetScreen(GameObject screen)
    {
        gameUI.SetActive(false);
        countdownUI.SetActive(false);
        endUI.SetActive(false);
        screen.SetActive(true);
    }

    public void onRestartButton(){
        SceneManager.LoadScene(0);
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
