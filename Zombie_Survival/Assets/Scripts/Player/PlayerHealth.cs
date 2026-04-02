using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    public Image uiHealth;

    public AudioClip hitClip;
    public AudioClip deathClip;

    private AudioSource playerAudioSource;
    private Animator playerAnimator;

    private PlayerShooter playerShooter;
    private PlayerMovement playerMovement;

    public void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        uiHealth.gameObject.SetActive(true);
        uiHealth.fillAmount = 1f;
        playerMovement.enabled = true;
        playerShooter.enabled = true;
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if(!IsDead)
        {
            playerAudioSource.PlayOneShot(hitClip);

        }

        base.OnDamage(damage, hitPoint, hitNormal);
        uiHealth.fillAmount = Health / startingHealth;

    }


    public override void Die()
    {
        base.Die();

        uiHealth.gameObject.SetActive(false);

        playerAudioSource.PlayOneShot(deathClip);
        playerAnimator.SetTrigger("Die");

        playerMovement.enabled = false;
        playerShooter.enabled = false;


        

    }
}
