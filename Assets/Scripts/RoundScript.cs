using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoundScript : MonoBehaviour
{
    public GameObject handMeshGo;
    public GameObject dayTimeController;
    public GameObject EnemyContainer;
    public int maxLifes;
    public GameObject RestartToolTip;
    public GameObject Score;
    public GameObject Plattform;

    private int lifes;
    private bool gameOver = false;

    private void Start()
    {
        lifes = maxLifes;
    }

    private void UpdateHand()
    {
        handMeshGo.GetComponent<LifeIndicatorScript>().SetHealthPercentage((float)lifes / maxLifes);
        //Debug.Log($"Now at {lifes} life/s ({(float)lifes / maxLifes * 100}%)");
    }

    private void UpdateDayTime()
    {
        
        if(!gameOver) dayTimeController.GetComponent<DayCycle>().setDayTime(24 - (float)lifes / maxLifes * 16);
        //print(24 - (float)lifes / maxLifes * 16);
    }

    public void IncreaseLifes(int plus = 1)
    {
        if (lifes >= maxLifes)
        {
            return;
        }

        //Debug.Log($"Gained {plus} life/s");
        lifes += plus;
        UpdateHand();
        UpdateDayTime();
    }

    public void DecreaseLifes(int minus = 1)
    {
        if (lifes <= 0)
        {
            return;
        }

        //Debug.Log($"Lost {minus} life/s");

        lifes -= minus;
        UpdateHand();
        UpdateDayTime();

        if (lifes <= 0)
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        if (!gameOver)
        {
            gameOver = true;
            foreach (Transform child in EnemyContainer.transform)
            {
                child.gameObject.GetComponentInChildren<EnemyHitScript>().InitiateDeath();
                Score.GetComponent<ScoreScript>().DecreaseScore();

            }
            GameObject.Find("Score").GetComponent<ScoreScript>().CollectResults();
            GetComponent<WaveScript>().enabled = false;

            RestartToolTip.SetActive(true);

            Debug.Log("GAME OVER");
            //GameObject hand = GameObject.Find("Hand rigged_animated");
            //Destroy(hand);
        }
    }

    public void ReStart(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            GetComponent<WaveScript>().resetValues();
            foreach (Transform child in EnemyContainer.transform)
            {
                if (child.gameObject.GetComponentInChildren<EnemyHitScript>().dying)
                {
                    Destroy(child.Find("SparkEffect"));
                    Destroy(child.gameObject); // prevent further action from enemys falling after restart

                }
                else
                {  // die normally
                    child.gameObject.GetComponentInChildren<EnemyHitScript>().InitiateDeath();
                    Score.GetComponent<ScoreScript>().DecreaseScore();
                }

            }

            foreach(Transform child in Plattform.transform)
            {
                if(child.tag.Equals("TowerController"))
                {
                    child.Find("ControllerHitbox").GetComponent<TowerControllerScript>().resetController();
                }
            }
            
            GetComponent<WaveScript>().enabled = false;
            lifes = maxLifes;
            gameOver = false;
            GetComponent<WaveScript>().enabled = true;
            Score.GetComponent<ScoreScript>().score = 0;
            Score.GetComponent<ScoreScript>().UpdateText();
            Score.GetComponent<ScoreScript>().scoring = true;
            dayTimeController.GetComponent<DayCycle>().resetDayTime();


            RestartToolTip.SetActive(false);
            UpdateHand();
            UpdateDayTime();

            Debug.Log("New round");
        }
    }
}
