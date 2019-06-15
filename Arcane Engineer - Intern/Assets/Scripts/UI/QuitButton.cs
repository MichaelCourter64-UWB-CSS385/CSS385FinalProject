using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    [SerializeField] GameObject buttonHolder;

    Button button;

    void Awake()
    {
        button = buttonHolder.GetComponent<Button>();
    }

    void OnEnable()
    {
        button.onClick.AddListener(QuitGame);
    }

    void OnDisable()
    {
        button.onClick.RemoveListener(QuitGame);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
