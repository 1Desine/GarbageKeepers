using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoard : MonoBehaviour, IInteractable {

    [SerializeField] List<RaidTask> tasksAvailible;


    public void Interact(GameObject actor) {
        if (actor.TryGetComponent(out Character character)) {
            character.SetRaidTask(tasksAvailible[0]);
        }

    }

}
