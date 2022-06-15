using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakanBola : MonoBehaviour
{
    public Vector2 speed;
    public Vector3 resetPosition;

    public Vector2 startSpeed;

    private Rigidbody2D rig;

    public bool isLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        startSpeed.x = speed.x;
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "PadKiri")
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }
    }

    public void ResetBall(){
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        //Merubah arah bola dan mengembalikan Bola ke kecepatan normal layaknya awal permainan
        if (rig.velocity.x < 0){
            speed = startSpeed;
            rig.velocity = new Vector2(speed.x * -1, speed.y);
        }else if (rig.velocity.x > 0){
            speed = startSpeed;
            rig.velocity = new Vector2(speed.x * 1, speed.y);
        }
    }

    public void ActivationPUSpeedUp(float magnitude){
        rig.velocity *= magnitude;
    }
}
