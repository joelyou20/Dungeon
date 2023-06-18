using Assets.Code.Enums;
using Assets.Code.Managers;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    public SceneNames FirstSceneName;

    public void Start()
    {
        InitializePlayer();
        InitializeScene();
    }

    private void InitializePlayer()
    {
        PlayerController player = PlayerController.Create(Vector3.zero);
        GameObject canvas = GameObject.Find(nameof(Canvas));
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(player);
        player.Start();
    }

    private void InitializeScene()
    {
        GameSceneManager.LoadScene(Enum.GetName(typeof(SceneNames), FirstSceneName));
    }
}
