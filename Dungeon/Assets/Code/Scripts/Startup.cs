using Assets.Code.Enums;
using Assets.Code.Managers;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    public SceneNames FirstSceneName;

    void Start()
    {
        GameSceneManager.LoadScene(Enum.GetName(typeof(SceneNames), FirstSceneName));
    }
}
