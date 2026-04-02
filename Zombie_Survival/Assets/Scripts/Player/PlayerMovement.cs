using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 해쉬함수 내장되어 있음
    // 일반적으로 애니메이터에 변수 넘길 때 이렇게 사용함
    public static readonly int HashMove = Animator.StringToHash("Move");

    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;

    private Animator playerAnimator;
    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        playerAnimator.SetFloat(HashMove, playerInput.Move);    
    }

    private void FixedUpdate()
    {
        float angle = playerInput.Rotate * rotateSpeed * Time.deltaTime;
        // 인스펙터엔 오일러 앵글러로 돼있음. Quaternion 으로 변환해서 사용
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.Euler(0f, angle, 0f)); // update에 해도 잘 작동함. 메소드 내부적으로 물리로직에 맞춰서 해주기 때문

        Vector3 delta = transform.forward * moveSpeed * playerInput.Move * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + delta);
    }
}
