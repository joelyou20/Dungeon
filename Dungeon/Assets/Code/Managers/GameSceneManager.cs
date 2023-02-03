using Assets.Code.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace Assets.Code.Managers
{
    public static class GameSceneManager
    {
        private static List<string> _scenesVisited = new List<string>();

        public static GameObject PlayerSpawn => GameObject.FindGameObjectWithTag(Enum.GetName(typeof(Tags), Tags.Respawn));

        public static int SceneCount => SceneManager.sceneCountInBuildSettings;

        // TODO: Get all scenes in Scenes folder. Can begin to categorize scenes into different folders for different levels.
        //  (i.e. FolderName: "Red-Level", retrieve all scenes, randomly select next level or specifically select level from list.
        public static List<string> GetScenes()
        {
            List<string> scenes = new List<string>();

            for (int i = 0; i < SceneCount; i++)
            {
                string scene = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                scenes.Add(scene);
            }

            return scenes;
        }


        public static string GetNextRandomScene()
        {
            string[] scenes = GetScenes().Where(x => x != "StartupScene" && !_scenesVisited.Contains(x)).ToArray();

            if (!scenes.Any()) HandleNoScenesRemaining();

            Random random = new Random();
            int index = random.Next(scenes.Count() - 1);

            return scenes[index];
        }

        private static void HandleNoScenesRemaining()
        {
            throw new NotImplementedException();
        }

        public static void LoadNextRandomScene() => LoadScene(GetNextRandomScene());
        public static void LoadScene(Scene scene) => LoadScene(scene.name);

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            _scenesVisited.Add(sceneName);
            PlayerManager.SetPlayer();
        }

        public static void ResetScenesVisited() => _scenesVisited.Clear();
    }
}
