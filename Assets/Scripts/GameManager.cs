using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour {
    static public GameManager Instance { get; private set; }

    private Dictionary<int, Character> charactersDictionary = new Dictionary<int, Character>();


    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    static public void RegisterCharacter(Character character) {
        Instance.charactersDictionary.Add(Instance.charactersDictionary.Count, character);
    }
    static public void Unregistercharacter(Character character) {
        Instance.charactersDictionary.Remove(Instance.charactersDictionary.FirstOrDefault(x => x.Value == character).Key);
    }
    static public void SwitchScene(RaidTask raidTask = null) {
        if (SceneHandler.inRaid) SceneHandler.LoadSceneHome();
        else if (raidTask != null) SceneHandler.LoadRaidScene(raidTask);
    }

}
