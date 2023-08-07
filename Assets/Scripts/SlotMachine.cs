using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private Text prizeText;

    [SerializeField]
    private Slot[] slots;

    private int prizeValue;

    private bool resultsChecked = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnPlay()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!slots[0].rowStopped || !slots[1].rowStopped || !slots[2].rowStopped)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }

        if (slots[0].rowStopped && slots[1].rowStopped && slots[2].rowStopped && !resultsChecked)
        {
            CheckResult();
            prizeText.enabled = true;
            prizeText.text = "Prize: " + prizeValue;
        }
    }

    public void OnClicked()
    {
        if (slots[0].rowStopped && slots[1].rowStopped && slots[2].rowStopped)
        {
            Debug.Log("Clicked");
            HandlePulled();
        }
    }

    private void CheckResult()
    {
        if(slots[0].stoppedSlot == "Slot F" && slots[1].stoppedSlot != "Slot F" && slots[2].stoppedSlot != "Slot F")
        {
            prizeValue = 500;
        }
        else if (slots[0].stoppedSlot == "Slot E" && slots[1].stoppedSlot == "Slot E" && slots[2].stoppedSlot == "Slot E")
        {
            prizeValue = 100;
        }
        else if (slots[0].stoppedSlot == "Slot D" && slots[1].stoppedSlot == "Slot D" && slots[2].stoppedSlot == "Slot D")
        {
            prizeValue = 50;
        }
        else if (slots[0].stoppedSlot == "Slot C" && slots[1].stoppedSlot == "Slot C" && slots[2].stoppedSlot == "Slot C")
        {
            prizeValue = 20;
        }
        else if (slots[0].stoppedSlot == "Slot B" && slots[1].stoppedSlot == "Slot B" && slots[2].stoppedSlot == "Slot B")
        {
            prizeValue = 15;
        }
        else if (slots[0].stoppedSlot == "Slot A" && slots[1].stoppedSlot == "Slot A" && slots[2].stoppedSlot == "Slot A")
        {
            prizeValue = 10;
        }
        else if (slots[0].stoppedSlot == "Slot A" && slots[1].stoppedSlot == "Slot A" && slots[2].stoppedSlot != "Slot A")
        {
            prizeValue = 5;
        }
        else if (slots[0].stoppedSlot == "Slot A" && slots[1].stoppedSlot != "Slot A" && slots[2].stoppedSlot != "Slot A")
        {
            prizeValue = 2;
        }
        else
        {
            prizeValue = 0;
        }

        resultsChecked = true;
    }
}
