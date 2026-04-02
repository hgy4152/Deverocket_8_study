using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // 문자열에 한해서 최적화를 잘 해줌
    // input manager 에서 쓰는 문자열 변수로 사용. 오타 방지
    public static readonly string MoveAxis = "Vertical"; 
    public static readonly string RotateAxis = "Horizontal"; 
    public static readonly string FireButton = "Fire1"; 
    public static readonly string ReloadButton = "Reload"; 
    

    public float Move {  get; private set; }
    public float Rotate {  get; private set; }
    public bool Fire {  get; private set; }
    public bool Reload { get; private set; }


    private void Update()
    {
        Move = Input.GetAxis(MoveAxis);
        Rotate = Input.GetAxis(RotateAxis);
        Fire = Input.GetButton(FireButton);
        Reload = Input.GetButton(ReloadButton);

    }
}
