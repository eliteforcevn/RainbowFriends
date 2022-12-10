using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool isPlaying = false;

    public float gameTime = 0f;
    public float curGameTime = 0f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        _TimeCount();
    }

    public void _SetPlaying(bool active)
    {
        isPlaying = active;

        GameplayUI.instance.timeCountUI._SetTime(curGameTime);
    }

    public void _SetGameTime(float time)
    {
        gameTime = time;

        curGameTime = 0f;
    }

    void _TimeCount()
    {
        if (gameTime == 0f && curGameTime == 0f || isPlaying == false) return;

        if (curGameTime < gameTime)
        {
            curGameTime += Time.deltaTime;

            if (curGameTime >= gameTime)
            {
                curGameTime = gameTime;
            }

            GameplayUI.instance.timeCountUI._SetTime(gameTime - curGameTime);
        }
    }
}
