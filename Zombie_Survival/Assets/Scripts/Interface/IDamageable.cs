using UnityEngine;

public interface IDamageable 
{
    // 피격체에 넣을거임
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);
}
