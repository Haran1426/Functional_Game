using UnityEngine;

public class PlayerMove_SIM : MonoBehaviour
{
    public static PlayerMove_SIM Instance;

    public Animator PlayerMoveAnim_SIM;

    private void Awake()
    {
        Instance = this;
    }

    // 외부에서 호출하는 함수
    public void PlayCorrectAnimation()
    {
        PlayerMoveAnim_SIM.SetTrigger("CorrectAnim");   // Animator에서 만든 Trigger 실행
    }
}
