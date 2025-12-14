using UnityEngine;
using UnityEngine.UI;

public class ArrowUI_NA : MonoBehaviour
{
    public RawImage leftArrow;
    public RawImage rightArrow;

    public Texture leftNormal;
    public Texture leftPressed;
    public Texture rightNormal;
    public Texture rightPressed;

    void Start()
    {
        leftArrow.texture = leftNormal;
        rightArrow.texture = rightNormal;
    }

    void Update()
    {
        // A 키
        if (Input.GetKeyDown(KeyCode.A))
            leftArrow.texture = leftPressed;

        if (Input.GetKeyUp(KeyCode.A))
            leftArrow.texture = leftNormal;

        // D 키
        if (Input.GetKeyDown(KeyCode.D))
            rightArrow.texture = rightPressed;

        if (Input.GetKeyUp(KeyCode.D))
            rightArrow.texture = rightNormal;
    }
}
