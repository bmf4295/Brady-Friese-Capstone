using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public Button startButton;
    public Object mainMenu;

    void Start()
    {
        startButton.onClick.AddListener(changeScene);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
