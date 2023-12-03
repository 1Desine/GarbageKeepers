using UnityEngine;

public class CarriageDriver : MonoBehaviour, IInteractable {




    public void Interact(GameObject actor) {
        if (actor.TryGetComponent(out Character character)) {
            if (SceneSwitcher.inRaid) SceneSwitcher.LoadSceneHome(); 
            else SceneSwitcher.LoadSceneByTask(character.raidTask);
        }
    }


}
