using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

	public Dialogue dialogue;

    // Properties of this DialogueTrigger
    public bool onAwake;
    public bool isTrigger;
    public bool sign;
    public bool nonRepeatable;

    // Destroying of this DialogueTrigger
    public bool destroyNow;
    public bool destroyAfter;

    private bool waitForEnd;

    // Current state of this DialogueTrigger
    private bool alreadyTriggered;

    public GameObject summonAfter;
    public GameObject nextDialogue;

    private void OnEnable()
    {
        if (onAwake) TriggerDialogue();
    }

    private void Update()
    {
        if (waitForEnd && DialogueManager.endConvo) Destroy(gameObject, .1f);
        if (alreadyTriggered && summonAfter != null && DialogueManager.endConvo)
        {
            summonAfter.SetActive(true);
            if (summonAfter.name == "Win Scene Transition") summonAfter.GetComponent<Animator>().Play("scene_transition_in");
        }

        if (alreadyTriggered && nextDialogue != null && DialogueManager.endConvo)
        {
            nextDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    public void TriggerDialogue()
	{
        if (alreadyTriggered && nonRepeatable) return;

        StartCoroutine(FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue));
        if (destroyNow && !sign) Destroy(gameObject, .1f);
        if (destroyAfter) waitForEnd = true;

        alreadyTriggered = true;
    }
}