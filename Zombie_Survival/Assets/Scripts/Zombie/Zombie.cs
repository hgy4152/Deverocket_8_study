using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : LivingEntity
{
    public enum Status
    {
        Idle,
        Trace,
        Attack,
        Die,
    }

    // switch 문을 활용한 판단
    // 상태패턴 느낌
    private Status currentStatus;

    public Status CurrentStatus
    {
        get { return currentStatus; }
        set
        {
            var prevStatus = currentStatus;
            currentStatus = value;

            switch(currentStatus)
            {
                case Status.Idle:
                    zombieAnimator.SetBool("HasTarget", false);
                    agent.isStopped = true;
                    break;
                
                case Status.Trace:
                    zombieAnimator.SetBool("HasTarget", true);
                    agent.isStopped = false;
                    break;
                
                case Status.Attack:
                    zombieAnimator.SetBool("HasTarget", false);
                    agent.isStopped = true;
                    agent.velocity = Vector3.zero;
                    break;
                
                case Status.Die:
                    zombieAnimator.SetTrigger("Die");
                    agent.isStopped = true;
                    zombieCollider.enabled = false;
                    zombieAudio.PlayOneShot(deathClip);
                    hitBox.Collisders.Clear();
                    hitBox.gameObject.SetActive(false);
                    break;
                

            }
        }
    }

    public Transform target;

    public LayerMask targetLayer;
    public HitBox hitBox;
    public AudioClip hitClip;
    public AudioClip deathClip;
    public ParticleSystem bloodEffect;
    public Collider zombieCollider;

    public Renderer zombieRenderer;

    private NavMeshAgent agent;
    private Animator zombieAnimator;
    private AudioSource zombieAudio;

    public float traceDistance = 10f;
    private float attackDistance = 1f;

    private float attackTime = 1f;
    private float lastAttack = 0f;

    private float damage = 10f;

    public void Setup(ZombieData data)
    {
        gameObject.SetActive(false);

        startingHealth = data.maxHP;
        damage = data.damage;

        agent.speed = data.speed;

        zombieRenderer.material.color = data.skinCol;

        gameObject.SetActive(true);


    }
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
        zombieAnimator = GetComponent<Animator>();
        zombieAudio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

        switch (currentStatus)
        {
            case Status.Idle:
                UpdateIdle();
                break;

            case Status.Trace:
                UpdateTrace();
                break;

            case Status.Attack:
                UpdateAttack();
                break;

            case Status.Die:
                UpdateDie();
                break;

        }
    }

    #region 상태패턴
    private void UpdateIdle()
    {

        if(target != null && Vector3.Distance(target.position, transform.position) < traceDistance)
        {
            CurrentStatus = Status.Trace;
        }

        target = FindTarget(traceDistance);

    }

    private void UpdateTrace()
    {

        if (target == null || Vector3.Distance(target.position, transform.position) > traceDistance)
        {
            target = null; // 중복 검사 방지
            CurrentStatus = Status.Idle;
            return;
        }

        // 게임적으로 생각했을 땐 시간을 두고 위치 추적하게 하는게 맞음
        agent.SetDestination(target.position);

        var lookAt = target.position;
        lookAt.y = transform.position.y;

        transform.LookAt(lookAt);
        /*
        if (target != null && Vector3.Distance(target.position, transform.position) < attackDistance)
        {
            CurrentStatus = Status.Attack;
            return;
        }
        */

        if(target != null)
        {
            if(hitBox.Collisders.Find( x => x.transform == target) != null)
            {
                CurrentStatus = Status.Attack;
                return;

            }

        }

    }

    private void UpdateAttack()
    {
        if (target == null)
        {
            CurrentStatus = Status.Trace;
            return;
        }

        if (hitBox.Collisders.Find(x => x.transform == target) == null)
        {
            CurrentStatus = Status.Trace;
            return;
        }

        if (Time.time > lastAttack + attackTime)
        {
            lastAttack = Time.time;
            
            var livingEntity = target.GetComponent<LivingEntity>();

            if (livingEntity != null)
            {
                if(!livingEntity.IsDead)
                    livingEntity.OnDamage(10f, transform.position, -transform.forward);
            }

        }

    }

    private void UpdateDie()
    {

    }

    #endregion
    private Transform FindTarget(float radius)
    {
        // 구형 범위 안의 설정된 레이어 소속의 콜라이더들만 받음
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, targetLayer);

        if (colliders.Length == 0)
        {
            return null;
        }

        // 받은 애들 중에 젤 가까운 놈 (원랜 orderby 안씀. 너무 업뎃 잦은 곳에서 쓰면 성능저하)
        var target = colliders.OrderBy(x => Vector3.Distance(x.transform.position, transform.position)).First();


        return target.transform;
    }


    protected override void OnEnable()
    {
        base.OnEnable();

        agent.enabled = true;
        agent.isStopped = false;
        agent.ResetPath();

        // 재생성 시 메쉬 위가 아니라 좌표가 틀어진채로 생성될 가능성이 있음. 특히 y 좌표
        // 반경 내 넣은 포지션과 가장 가까운 점
        if(NavMesh.SamplePosition(transform.position,out NavMeshHit hit, 10f, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);

        }


        hitBox.gameObject.SetActive(true);
        zombieCollider.enabled = true;
        CurrentStatus = Status.Idle;
    }

 

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if(!IsDead)
        {
            zombieAudio.PlayOneShot(hitClip);
            base.OnDamage(damage, hitPoint, hitNormal);
            Debug.Log($"Hit {Health}");

            bloodEffect.transform.position = hitPoint;
            bloodEffect.transform.forward= hitNormal;
            bloodEffect.Play();

        }



    }

    public override void Die()
    {
        base.Die();
        CurrentStatus = Status.Die;
    }


}
