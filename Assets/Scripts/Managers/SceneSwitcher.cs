using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class SceneSwitcher : MonoBehaviour {
    static public SceneSwitcher Instance { get; private set; }


    [SerializeField] SceneReference homeScene;


    static public bool inRaid { get; private set; } = false;


    private void Awake() {
        DontDestroyOnLoad(gameObject);

        Instance = this;
    }



    static public void LoadSceneHome() {
        SceneManager.LoadScene(Instance.homeScene.Name);

        inRaid = false;
    }
    static public void LoadSceneByTask(RaidTask raidTask) {
        if (raidTask == null) return;
        else Debug.Log(raidTask.ToString());
        SceneManager.LoadScene(raidTask.raidScene.Name);

        inRaid = true;
    }

}
