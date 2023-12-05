using UnityEngine;

public class CarriageDriver : MonoBehaviour, IInteractable {


    public void Interact(GameObject actor) {
        if (actor.TryGetComponent(out Character character)) {
            if (SceneHandler.inRaid) {
                if (SceneHandler.raidTask.IsEnoughItemsCollected(character.inventory.GetItemsList())) {

                    SceneHandler.LoadScene(SceneHandler.Scene.HomeScene);
                }
            }
            else if (character.GetRaidTask() != null) SceneHandler.LoadScene(SceneHandler.Scene.RaidScene, character.GetRaidTask());
        }
    }


}
