using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun;

    public Transform gunPivot;
    public Transform leftHandMount;
    public Transform rightHandMount;

    private PlayerInput playerInput;
    private Animator playerAnimator;



    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if ((playerInput.Fire))
        {
            gun.Fire();
        }

        if (playerInput.Reload && gun.GunState != Gun.Stats.Reloading || gun.magAmmo <= 0)
        {
            gun.Reload();
            playerAnimator.SetTrigger(PlayerInput.ReloadButton);
        }
    }

    // ik 설정
    private void OnAnimatorIK(int layerIndex)
    {
        gunPivot.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);




        // 가중치 설정
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

        // 위치 설정
        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandMount.rotation);

        // 가중치 설정
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

        // 위치 설정
        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);

        /*

        if (gun.GunState == Gun.Stats.Reloading)
        {
            var pos = rightHandMount.position;
            pos.x += 0.1f;

            var rot = leftHandMount.rotation * Quaternion.Euler(0f,0f,45f);


            // 위치 설정
            playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, pos);
            playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, rot);

        }
        */
    }
}
