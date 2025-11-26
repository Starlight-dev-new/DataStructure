using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endGameText;

    [SerializeField] GameObject playeAginButton;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGAME()
    {
        SceneManager.LoadScene("Main");
    }

    public void EndGame(string EndGame)
    {
       Time.timeScale = 0;
        endGameText.text = EndGame;
        endGameText.gameObject.SetActive(true);
        playeAginButton.SetActive(true);
    }
    
}
