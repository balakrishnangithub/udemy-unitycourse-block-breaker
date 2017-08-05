using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Paddle : MonoBehaviour
{
    public bool autoPlay = false;
    public Text debugText;
    private float mousePosInUnitX;
    private Ball ball;
    private float pivotToEdge;

    void Start()
    {
        SpriteRenderer spriteRender = this.gameObject.GetComponent<SpriteRenderer>();
        // Units occupied by Paddle = Paddle.width/Paddle.pixelsPerunit
        // Paddle's Center is Pivot
        // Therefore half of the units occupied by Pivot is pivotToEdge difference
        pivotToEdge = spriteRender.sprite.pivot.x / spriteRender.sprite.pixelsPerUnit;
        ball = GameObject.FindObjectOfType<Ball>();
        debugText = GameObject.FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
            MoveWithMouse();
        else
            AutoPlay();
    }

    void MoveWithMouse()
    {
        mousePosInUnitX =
            Input.mousePosition.x / Screen.width // 0 to 1 because width/width = 1
            *
            16; // 0 to 16 because 1*16 = 16
        this.transform.position = new Vector2(Mathf.Clamp(mousePosInUnitX, 0 + pivotToEdge, 16 - pivotToEdge),
            this.transform.position.y);
        this.debugText.text = "M: " + Input.mousePosition.x / Screen.width + ":" +
                              Input.mousePosition.y / Screen.height +
                              " P: " + Mathf.Clamp(mousePosInUnitX, 0 + pivotToEdge, 16 - pivotToEdge) + ":" +
                              this.transform.position.y;
    }

    void AutoPlay()
    {
        this.transform.position = new Vector2(Mathf.Clamp(ball.transform.position.x, 0 + pivotToEdge, 16 - pivotToEdge),
            this.transform.position.y);
    }
}