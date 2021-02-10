using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform DoorArt;

    // Start is called before the first frame update
    private float doorAngle = 0;
    private float animTimer = 0;
    private bool animIsPlaying = false;
    private float animLength = 0.5f;
    private bool isClosed = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //did user click on tick?



        if (animIsPlaying)
        {
            if (!isClosed)
            {
                animTimer += Time.deltaTime; //playing animation
            }
            else
            {
                animTimer -= Time.deltaTime;
            }

            float percent = animTimer / animLength;

            if (percent < 0 && isClosed)
            {
                percent=- 0;
                animIsPlaying = false;
            }
            if (percent > 1 && !isClosed)
            {
                percent = 1;
                animIsPlaying = false;
            }

            DoorArt.localRotation = Quaternion.Euler(0, doorAngle * percent, 0); //set angle of doorArt
        }
    }
    public void PlayerInteract(Vector3 position)
    {
        if (animIsPlaying)
        {
            return;
        }

        if (Inventory.main.hasKey == false) return;

        Vector3 disToPlayer = position - transform.position;
        disToPlayer = disToPlayer.normalized;
        bool playerOnOtherSide = (Vector3.Dot(disToPlayer, transform.forward) > 0f);

        isClosed = !isClosed;

        doorAngle = 90;
        if (playerOnOtherSide)
        {
            doorAngle = -90;
        }

        animIsPlaying = true;
        
        if (isClosed)
        {
            animTimer = animLength;
        }
        else
        {
            animTimer = 0;
        }

    }
} 
