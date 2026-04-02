using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum Stats
    {
        Ready,
        Empty,
        Reloading
    }

    public Stats GunState {  get; private set; }
    public Transform fireTransform;
    public UiManager uiManager;
    public LayerMask targetLayer;

    public ParticleSystem muzzleEffect;
    public ParticleSystem shellEffect;

    private LineRenderer bulletLineEffect;
    private AudioSource gunAudioPlayer;

    private float fireDistance = 50f;
    public GunData gunData;


    private Coroutine coShot;
    private float lastFireTime;
    public int ammoRemain = 100;
    public int magAmmo = 25;

    private void Awake()
    {
        gunAudioPlayer = GetComponent<AudioSource>();
        bulletLineEffect = GetComponent<LineRenderer>();

        bulletLineEffect.positionCount = 2;
        bulletLineEffect.enabled = false;
    }

    private void OnEnable()
    {
        ammoRemain = gunData.startAmmoRemain;
        magAmmo = gunData.magCapacity;

        GunState = Stats.Ready;
        lastFireTime = 0f;

        uiManager.SetAmmoText(magAmmo, ammoRemain);
    }


    public void Fire()
    {
        if(GunState == Stats.Ready && Time.time > lastFireTime + gunData.timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();

        }
    }


    private void Shot()
    {
        Vector3 hitPosition = Vector3.zero;

        Ray ray = new Ray(fireTransform.position, fireTransform.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, fireDistance, targetLayer))
        {
            hitPosition = hit.point;

            // 인터페이스도 getcomponent 가능함
            var target = hit.collider.GetComponent<IDamageable>();
            if (target != null)
            {
                target.OnDamage(gunData.damage, hit.point, hit.normal);
            }
        }
        else
        {
            hitPosition = fireTransform.position + fireTransform.forward *fireDistance;
        }

        if (coShot != null)
        {
            StopCoroutine(coShot);
            coShot = null;
        }

        coShot = StartCoroutine(CoshotEffect(hitPosition));

        magAmmo--;

        if(magAmmo <= 0)
        {
            GunState = Stats.Empty;
        }

        uiManager.SetAmmoText(magAmmo, ammoRemain);

    }

    private IEnumerator CoshotEffect(Vector3 hitPosition)
    {
        muzzleEffect.Play();
        shellEffect.Play();

        gunAudioPlayer.PlayOneShot(gunData.shotClip);

        bulletLineEffect.SetPosition(0, fireTransform.position);
        bulletLineEffect.SetPosition(1, hitPosition);
        bulletLineEffect.enabled =true;

        yield return new WaitForSeconds(0.03f);


        bulletLineEffect.enabled = false;
    }

    public bool Reload()
    {
        if(GunState != Stats.Reloading && magAmmo < gunData.magCapacity && ammoRemain != 0)
        {
            GunState = Stats.Reloading;
            StartCoroutine(CoReload());
            return true;
        }

        return false;
    }

    private IEnumerator CoReload()
    {

        gunAudioPlayer.PlayOneShot(gunData.reloadClip);

        ammoRemain -= gunData.magCapacity - magAmmo;
        magAmmo = gunData.magCapacity;



        yield return new WaitForSeconds(gunData.reloadTime);


        GunState = Stats.Ready;
        uiManager.SetAmmoText(magAmmo, ammoRemain);

    }
}
