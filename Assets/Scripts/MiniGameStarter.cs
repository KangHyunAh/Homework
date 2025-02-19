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
    //�÷��̾�� �浹���� ��(Game1Starter Is Trigger�� �ױ⶧���� OnTirigger ���
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
            Debug.LogError("�� �̸��� �������� �ʾҽ��ϴ�.");
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
