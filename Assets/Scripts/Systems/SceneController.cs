using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene("SamplePlayScene");
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("Main");
    }

    public void GameLose()
    {
        SceneManager.LoadScene("PlayerLose");
    }

    public void GameWin()
    {
        SceneManager.LoadScene("Congratulation");
    }

    public void GameExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
