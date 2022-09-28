using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public static bool isSpinning = false, firstSpinDone = false;
    public static int spinCounter;
    [SerializeField] private float startSpeed, subSpeed;

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(0, 0, startSpeed, Space.World);
            //transform.Rotate(0, startSpeed, 0);
            startSpeed -= subSpeed;
        }
        if (startSpeed <= 0)
        {
            startSpeed = 0;
            isSpinning = false;
        }
    }

    public void SpinMoneyWheel()
    {
        startSpeed = Random.Range(2.000f, 5.000f);
        subSpeed = Random.Range(0.003f, 0.009f);
        isSpinning = true;
        spinCounter++;

        if (spinCounter == 1) firstSpinDone = true;

        Logic.waitingNewSpin = false;
    }
}
