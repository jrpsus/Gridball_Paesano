using UnityEngine.UI;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject pauseUI;
    public TheGame theGame;
    public Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        theGame = GameObject.Find("GameStuff").GetComponent<TheGame>();
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (theGame.gameLevel >= 7)
        {
            pauseUI.SetActive(true);
            resultText.text = "GAME COMPLETED";
            resultText.fontSize = 60;
            Time.timeScale = 0.01f;
        }
        if (theGame.lives <= 0)
        {
            pauseUI.SetActive(true);
            resultText.text = "GAME OVER";
            resultText.fontSize = 96;
            Time.timeScale = 0.01f;
        }
    }
}
