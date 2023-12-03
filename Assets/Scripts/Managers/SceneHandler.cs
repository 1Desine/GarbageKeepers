using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class SceneHandler : MonoBehaviour {
    static public SceneHandler Instance { get; private set; }


    [SerializeField] SceneReference homeScene;


    static public RaidTask raidTask;
    static public bool inRaid => raidTask != null;


    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



    static public void LoadSceneHome() {
        raidTask = null;
        SceneManager.LoadScene(Instance.homeScene.Name);
    }
    static public void LoadRaidScene(RaidTask raidTask) {
        SceneHandler.raidTask = raidTask;
        SceneManager.LoadScene(raidTask.raidScene.Name);
    }

}
