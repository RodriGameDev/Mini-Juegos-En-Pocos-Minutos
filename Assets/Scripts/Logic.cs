using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Logic : MonoBehaviour
{
    public static bool waitingNewSpin = false, gameOver = false;
    public bool spinStopped = false;
    public TextMeshProUGUI totalSpinsText, actualMoneyText, mostMoneyMadeText;

    private int actualMoney, mostMoneyMade;

    private void OnCollisionStay(Collision col)
    {
        if (!Spin.isSpinning && Spin.firstSpinDone && !spinStopped && !waitingNewSpin)
        {
            if (col.gameObject.name == "$100")
            {
                Debug.Log("Added $100");
                actualMoney += 100;
            }

            else if (col.gameObject.name == "$250")
            {
                Debug.Log("Added $250");
                actualMoney += 250;
            }

            else if (col.gameObject.name == "$500")
            {
                Debug.Log("Added $500");
                actualMoney += 500;
            }

            else if (col.gameObject.name == "$750")
            {
                Debug.Log("Added $750");
                actualMoney += 750;
            }

            else if (col.gameObject.name == "$1000")
            {
                Debug.Log("Added $1000");
                actualMoney += 1000;
            }

            else if (col.gameObject.name == "Bankrupt")
            {
                Debug.Log("Bankrupt & Game Over!");
                gameOver = true;
            } 

            StartCoroutine("stopAddingPrizes");

            totalSpinsText.text = Spin.spinCounter.ToString();
            actualMoneyText.text = "$" + actualMoney.ToString();

            if (gameOver)
            {
                if (mostMoneyMade < actualMoney)
                {
                    mostMoneyMade = actualMoney;
                    mostMoneyMadeText.text = "$" + mostMoneyMade.ToString();
                }

                actualMoney = 0;
                Spin.spinCounter = 0;

                totalSpinsText.text = Spin.spinCounter.ToString();
                actualMoneyText.text = "$" + actualMoney.ToString();
            }
        }
    }

    private IEnumerator stopAddingPrizes() //When it lands, just adds once the prize
    {
        yield return new WaitForSeconds(0.00001f);
        spinStopped = true;
        StartCoroutine("startNewSpin");
    }

    private IEnumerator startNewSpin() //Resets bools for a new spin
    {
        yield return new WaitForSeconds(0.00001f);
        spinStopped = false;
        waitingNewSpin = true;
        gameOver = false;
    }
}
