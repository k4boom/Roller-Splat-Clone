using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Button beginButton;
    public Button quitButton;
    void Start()
    {
        Button btn = beginButton.GetComponent<Button>();
        btn.onClick.AddListener(StartGameHandler);
        Button btn2 = quitButton.GetComponent<Button>();
        btn2.onClick.AddListener(QuitGameHandler);
    }

    void StartGameHandler() {
       SceneManager.LoadScene(1);
    }

    void QuitGameHandler() {
       Application.Quit();
    }
}
