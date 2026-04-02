using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UiManager uiManager;
    public ZombieSpawner spawner;
    private int score = 0;
    public bool isGameOver {  get; private set; }



    public void AddScore(int add)
    {
        if (isGameOver)
            return;

        score += add;
        uiManager.SetScroeText(score);
    }

    public void End()
    {

        isGameOver = true;
        spawner.enabled = false;
        uiManager.SetActiveGameOverUi(true);
    }
}
