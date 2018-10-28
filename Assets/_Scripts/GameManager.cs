using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {


    public bool recording = true;
    public bool paused = false;

    private float fixedDeltaTime;


    private void Start()
    {
        PlayerPrefsManager.Unlocklevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(1));
        print(PlayerPrefsManager.IsLevelUnlocked(2));

        fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update ()
    {
        if (CrossPlatformInputManager.GetButton ("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && !paused)
        {
            PauseGame();
        }
        print("update");
	}

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        paused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
        paused = false;
    }
}
