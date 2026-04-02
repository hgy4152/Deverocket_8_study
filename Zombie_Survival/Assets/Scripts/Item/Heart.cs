using UnityEngine;

public class Heart : Item
{
    public override void Use(GameObject target)
    {
        var health = target.GetComponent<PlayerHealth>();

        if(health != null )
        {
            health.Heal(50);
            health.uiHealth.fillAmount = health.Health / health.startingHealth;
        }



        Destroy(gameObject);
        Debug.Log("하트");
    }
}
