using Assets.Code.Enums;
using Assets.Code.Managers;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    public SceneNames FirstSceneName;
    public GameObject Player;

    void Start()
    {

        GameSceneManager.LoadScene(Enum.GetName(typeof(SceneNames), FirstSceneName));
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Instantiate(Player, GameSceneManager.PlayerSpawn.transform);
    }
}
