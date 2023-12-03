using UnityEngine;

public class CarriageDriver : MonoBehaviour, IInteractable {




    public void Interact(GameObject actor) {
        if (actor.TryGetComponent(out Character character)) {
            GameManager.SwitchScene(character.GetRaidTask());
        }
    }


}
