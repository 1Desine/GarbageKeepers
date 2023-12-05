using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneHandler {

    public enum Scene {
        HomeScene,
        RaidScene,
    }


    static public RaidTask raidTask;
    static public bool inRaid => raidTask != null;
    static public Action OnSceneLoaded = () => { };




    static public void LoadScene(Scene scene, RaidTask raidTask = null) {
        SceneHandler.raidTask = raidTask;
        SceneManager.LoadScene(scene.ToString());
        OnSceneLoaded();
    }

}
