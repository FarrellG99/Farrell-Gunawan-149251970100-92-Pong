using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rig;
    public KeyCode upKey;
    public KeyCode downKey;
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
            Application.Quit();
        }
    }

    private Vector2 GetInput(){
        if(Input.GetKey(upKey)){
            //Gerak Ke Atas
            return Vector2.up * speed;
        }
        else if(Input.GetKey(downKey)){
            //Gerak Ke Bawah
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement){
        rig.velocity = movement;
    }
}