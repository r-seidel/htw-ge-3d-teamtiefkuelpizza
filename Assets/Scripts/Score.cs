using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    
    public GameObject scoreDisplay;
    public static int score = 0;


    private void Start()
    {
        score = 0;
    }
    public void Update()
    {
        scoreDisplay.GetComponent<Text>().text = "Score: " + score;
    }

}