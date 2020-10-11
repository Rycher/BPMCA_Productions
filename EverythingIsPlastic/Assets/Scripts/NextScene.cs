using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public BoxCollider doorCollider;
    // Update is called once per frame
    private bool nextScene = false;
    public SceneAsset scene;
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Para entrar na porta, favor pressionar (E)");
        nextScene = true;        
    }

    void Update()
    {
        if (nextScene)
        {
            
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Scene2 loading: " + scene.name);
                SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
            }
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        nextScene = false;
    }
}
