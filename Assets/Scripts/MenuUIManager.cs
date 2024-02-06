using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bestScoreText.text = "Best Score : " + SavesManager.Instance.bestPlayerName + " : " + SavesManager.Instance.bestScore;
    }

    public void StartNew(){
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
