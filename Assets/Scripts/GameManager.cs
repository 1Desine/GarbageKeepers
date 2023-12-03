using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
    static public GameManager Instance { get; private set; }

    private Dictionary<int, Character> charactersDictionary = new Dictionary<int, Character>();


    private void Awake() {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    static public void RegisterCharacter(Character character) {
        Instance.charactersDictionary.Add(Instance.charactersDictionary.Count, character);
    }
    static public void Unregistercharacter(Character character) {
        Instance.charactersDictionary.Remove(Instance.charactersDictionary.FirstOrDefault(x => x.Value == character).Key);
    }
    static public void PlaceCharacterAtSpawnPosition(Character character) {
        List<Transform> spawnTransforms = ScenePropperties.GetSpawnPositions();

        int spawnPositionIndex = Instance.charactersDictionary.FirstOrDefault(_ => _.Value == character).Key % spawnTransforms.Count;

        character.transform.position = spawnTransforms[spawnPositionIndex].position;
        character.transform.rotation = spawnTransforms[spawnPositionIndex].rotation;
    }


}
