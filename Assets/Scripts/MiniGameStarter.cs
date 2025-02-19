using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameStarter : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public GameObject GameLoadingText;
    public bool inputLoadScene = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(inputLoadScene = true) 
        {
            CheckLoadScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    //플레이어와 충돌했을 때(Game1Starter Is Trigger를 켰기때문에 OnTirigger 사용
    {
        GameLoadingText.SetActive(true);
        inputLoadScene = true;    
    }

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("씬 이름이 설정되지 않았습니다.");
        }
    }

    protected void CheckLoadScene()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameLoadingText.SetActive(false);
            inputLoadScene = false;
            LoadScene();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            GameLoadingText.SetActive(false);
            inputLoadScene = false;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        GameLoadingText.SetActive(false);
        inputLoadScene = false;

    }
}
