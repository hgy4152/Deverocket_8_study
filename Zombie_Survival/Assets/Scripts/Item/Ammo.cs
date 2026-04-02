using UnityEngine;

public class Ammo : Item
{
    public override void Use(GameObject target)
    {
        var gun = target.GetComponent<PlayerShooter>().gun;
        gun.ammoRemain += 50;
        gun.uiManager.SetAmmoText(gun.magAmmo, gun.ammoRemain);

        Destroy(gameObject);
        Debug.Log("총알");
    }
}
