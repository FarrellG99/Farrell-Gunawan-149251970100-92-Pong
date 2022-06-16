using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaddleController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rig;
    public KeyCode upKey;
    public KeyCode downKey;

    

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());

        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("Main Menu");
        }

    }

    private Vector2 GetInput(){
        if(Input.GetKey(upKey)){
            //Gerak Ke Atas
            if (upKey.ToString() == "W"){
                Debug.Log("Kecepatan Paddle Kiri : " + Vector2.up * speed);
            }if(upKey.ToString() == "UpArrow"){
                Debug.Log("Kecepatan Paddle Kanan : " + Vector2.up * speed);
            }
            return Vector2.up * speed;
        }
        else if(Input.GetKey(downKey)){
            //Gerak Ke Bawah
            if (upKey.ToString() == "S"){
                Debug.Log("Kecepatan Paddle Kiri : " + Vector2.up * speed);
            }if (upKey.ToString() == "DownArrow"){
                Debug.Log("Kecepatan Paddle Kanan : " + Vector2.up * speed);
            }
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement){
        rig.velocity = movement;
    }

    public void SpeedUpPad(){
        speed *= 2;
    }

    public void ResetSpeedPad(){
        speed /= 2;
    }

    public void ScaleUp(GameObject paddle){
        paddle.transform.localScale += new Vector3(0, paddle.transform.localScale.y, 0);
    }

    public void ScaleDown(GameObject paddle){
        paddle.transform.localScale -= new Vector3(0, paddle.transform.localScale.y/2, 0);
    }
}
