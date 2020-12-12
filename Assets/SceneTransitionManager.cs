using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// https://gamedevbeginner.com/how-to-load-a-new-scene-in-unity-with-a-loading-screen/
/// 
/// </summary>

public class SceneTransitionManager : MonoBehaviour
{
    private string _level; // the level name of the target level, must be exact
    
    private static SceneTransitionManager _instance;
    [SerializeField] private UnityEvent enterEvents;
    [SerializeField] private UnityEvent exitEvents;

    private void Awake()
    {
        //DDOL handler
        if (_instance == null)
            _instance = this;
        else if(_instance != null & _instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        //end DDOL handler
    }

    public void GotoLevel(string incLevel)
    {
        _level = incLevel;
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        enterEvents.Invoke();
        yield return new WaitForSecondsRealtime(1.0f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(_level);
        while (!operation.isDone)
        {
            
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1.0f);
        exitEvents.Invoke();
    }
}
