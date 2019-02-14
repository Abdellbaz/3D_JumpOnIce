using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathController : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        SceneLoader("Game");
    }
    public void SceneLoader(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}

