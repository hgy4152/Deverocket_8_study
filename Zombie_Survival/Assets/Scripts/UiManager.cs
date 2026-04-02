using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{

    public Text ammoText;
    public Text scoreText;
    public Text waveText;

    public GameObject gameOver;


    public void OnEnable()
    {
        SetAmmoText(0, 0);
        SetScroeText(0);
        SetWaveText(0, 0);
        SetActiveGameOverUi(false);
    }

    public void SetAmmoText(int magAmmo, int remainAmmo)
    {
        ammoText.text = $"{magAmmo}/{remainAmmo}";
    }
    public void SetScroeText(int score)
    {
        scoreText.text = $"Score : {score}";
    }
    public void SetWaveText(int wave, int count)
    {
        waveText.text = $"Wave: {wave}\nEnemy Left: {count}";
    }

    public void SetActiveGameOverUi(bool active)
    {
        gameOver.SetActive(active);
    }

    public void OnClickRestart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    
    }
}
