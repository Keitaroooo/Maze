using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    public static float speed = 0;
    public float speedincrease;
    public float maxspeed = 0.03f;
    public float jumpspeed;

    private Rigidbody rigid;

    // カメラオブジェクトを格納する変数
    public GameObject mainCamera;
    // カメラの回転速度を格納する変数
    public Vector2 rotationSpeed;
    // マウス移動方向とカメラ回転方向を反転する判定フラグ
    public bool reverse;
    // マウス座標を格納する変数
    private Vector2 lastMousePosition;
    // カメラの角度を格納する変数（初期値に0,0を代入）
    private Vector2 newAngle = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        rigid = GetComponent<Rigidbody>();
    }

    public void ForwardButton()
    {
        speed += speedincrease;
        
        if(speed > maxspeed)
        {
            speed = 0;
        }
    }

    public void StopButton()
    {

        if (rigid.velocity.y == 0 )
        { 
        rigid.AddForce(0, jumpspeed, 0);
        }
        speed = 0;
    }


    /*public void LeftRotateButton()
    {
        transform.Rotate(0, -90, 0);
    }

    public void RightRotateButton()
    {
        transform.Rotate(0, 90, 0);
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        mainCamera.transform.Translate(0, 0, speed);

        // 左クリックした時
        if (Input.GetMouseButtonDown(0))
        {
            // カメラの角度を変数"newAngle"に格納
            newAngle = mainCamera.transform.localEulerAngles;
            // マウス座標を変数"lastMousePosition"に格納
            lastMousePosition = Input.mousePosition;
        }
        // 左ドラッグしている間
        else if (Input.GetMouseButton(0))
        {
            // Y軸の回転：マウスドラッグ方向に視点回転
            // マウスの水平移動値に変数"rotationSpeed"を掛ける
            //（クリック時の座標とマウス座標の現在値の差分値）
            newAngle.y -= (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
            // X軸の回転：マウスドラッグ方向に視点回転
            // マウスの垂直移動値に変数"rotationSpeed"を掛ける
            //（クリック時の座標とマウス座標の現在値の差分値）
            newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x;
            // "newAngle"の角度をカメラ角度に格納
            mainCamera.transform.localEulerAngles = newAngle;
            // マウス座標を変数"lastMousePosition"に格納
            lastMousePosition = Input.mousePosition;
        }
    }
}
