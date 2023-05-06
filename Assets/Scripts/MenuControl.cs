using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public Text scoretext;
    public TMP_InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        scoretext.text=new string("Best Score: "+GameManager.Instance.hPlayerName+" : "+GameManager.Instance.highestScore);
        nameInputField.text = GameManager.Instance.cPlayerName;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        
        //AddName(nameInputField);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#else
        Application.Quit();
#endif
    }

    public void AddName()
    {
        GameManager.Instance.cPlayerName = nameInputField.text;
    }


}
