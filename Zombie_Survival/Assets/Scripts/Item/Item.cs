using UnityEngine;

public abstract class Item : MonoBehaviour, IItem
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Use(other.gameObject);
            Debug.Log("aa");
        }
    }

    public abstract void Use(GameObject target);

}
