using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int SlotID = 0;
    private int randomValue;
    private int randomSlot;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;
    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        SlotMachine.HandlePulled += StartRotating;
    }

    void StartRotating()
    {
        stoppedSlot = " ";
        StartCoroutine("Rotate");
    }

    private void SetSlot()
    {
        if (rowStopped)
        {
            if (randomSlot == 0)
            {
                transform.position.Set(transform.position.x, -9.3f, transform.position.z);
                stoppedSlot = "Slot A";
                Debug.Log(stoppedSlot);
            }
            else if (randomSlot == 1)
            {
                transform.position.Set(transform.position.x, -5.5f, transform.position.z);
                stoppedSlot = "Slot B";
                Debug.Log(stoppedSlot);
            }
            else if (randomSlot == 2)
            {
                transform.position.Set(transform.position.x, -1.7f, transform.position.z);
                stoppedSlot = "Slot C";
                Debug.Log(stoppedSlot);
            }
            else if (randomSlot == 3)
            {
                transform.position.Set(transform.position.x, -2.1f, transform.position.z);
                stoppedSlot = "Slot D";
                Debug.Log(stoppedSlot);
            }
            else if (randomSlot == 4)
            {
                transform.position.Set(transform.position.x, -5.9f, transform.position.z);
                stoppedSlot = "Slot E";
                Debug.Log(stoppedSlot);
            }
            else if (randomSlot == 5)
            {
                transform.position.Set(transform.position.x, -9.3f, transform.position.z);
                stoppedSlot = "Slot F";
                Debug.Log(stoppedSlot);
            }
        }
    }

    private IEnumerator Rotate()
    {
        randomSlot = Random.Range(0, 6);

        rowStopped = false;
        timeInterval = 0.025f;

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -3.8f)
            {
                transform.position = new Vector2(transform.position.x, 1.75f);

                transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

                yield return new WaitForSeconds(timeInterval);
            }
        }

        randomValue = Random.Range(60, 100);

        switch (randomValue % 3)
        {
            case 1:
                randomValue = +2;
                break;
            case 2:
                randomValue += 1;
                break;
        }

        for (int i = 0; i < randomValue; i++)
        {
            if (transform.position.y <= -3.8f)
                transform.position = new Vector2(transform.position.x, 1.75f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
                timeInterval = 0.025f;
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.01f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.015f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
                timeInterval = 0.02f;

            yield return new WaitForSeconds(timeInterval);
        }

        rowStopped = true;
        SetSlot();
    }

    private void OnDestroy()
    {
        //SlotMachine
    }
}
