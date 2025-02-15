﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoboFactory.Utils
{
    [InitializeOnLoad]
    public class HelpersUtil
    {
        private const string LauncherPath = "Assets/Components/Scenes/Launcher.unity";
        private const string AuthPath = "Assets/Components/Scenes/Auth.unity";
        private const string LoaderPath = "Assets/Components/Scenes/Loader.unity";
        private const string FactoryPath = "Assets/Components/Scenes/Factory.unity";
        private const string BattlePath = "Assets/Components/Scenes/Battle.unity";
        private const string UnitTestPath = "Assets/Components/Scenes/UnitTest.unity";
        
        static HelpersUtil()
        {
            EditorApplication.update = Update;
        }

        [MenuItem("Helper/Open Launcher", false, 1)]
        public static void OpenLauncher()
        {
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene(LauncherPath);
        }
        
        [MenuItem("Helper/Open Auth", false, 1)]
        public static void Auth()
        {
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene(AuthPath);
        }
        
        [MenuItem("Helper/Open Loader", false, 2)]
        public static void OpenLoader()
        {
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene(LoaderPath);
        }
        
        [MenuItem("Helper/Open Factory", false, 3)]
        public static void OpenFactory()
        {
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene(FactoryPath);
        }
        
        [MenuItem("Helper/Open Battle", false, 4)]
        public static void OpenBattle()
        {
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene(BattlePath);
        }
        
        [MenuItem("Helper/Open Unit Test", false, 11)]
        public static void OpenUnitTest()
        {
            EditorSceneManager.OpenScene(UnitTestPath);
        }

        [MenuItem("Helper/Run Launcher", false, 101)]
        public static void RunAuthentication()
        {
            if (!EditorApplication.isPlaying)
            {
                PlayerPrefs.SetString("restoreScenePath", SceneManager.GetActiveScene().path);
                EditorSceneManager.SaveOpenScenes();
                EditorSceneManager.OpenScene(LauncherPath);
                PlayerPrefs.SetInt("needRestore", 1);
                EditorApplication.isPlaying = true;
            }
        }
        
        private static void Update()
        {
            if (!EditorApplication.isPlaying &&
                !EditorApplication.isPlayingOrWillChangePlaymode &&
                PlayerPrefs.GetInt("needRestore") == 1)
            {
                PlayerPrefs.SetInt("needRestore", 0);
                EditorSceneManager.OpenScene(PlayerPrefs.GetString("restoreScenePath"));
            }
        }
        
        [MenuItem("Helper/Run Unit Test", false, 102)]
        public static void RunUnitTest()
        {
            EditorSceneManager.OpenScene(UnitTestPath);
            EditorApplication.isPlaying = true;
        }
        
        [MenuItem("Helper/Reset PlayerPrefs", false, 201)]
        public static void ResetPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
#endif