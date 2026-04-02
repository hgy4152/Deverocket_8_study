using UnityEngine;

public class Coin : Item
{
    public override void Use(GameObject target)
    {
        var manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        manager.AddScore(100);


        Destroy(gameObject);
        Debug.Log("코인");
    }
}
