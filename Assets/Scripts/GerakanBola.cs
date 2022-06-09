using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakanBola : MonoBehaviour
{
    public Vector2 speed;
    public Vector3 resetPosition;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rig.velocity.x.ToString());
    }

    public void ResetBall(){
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        //Merubah arah bola dan mengembalikan Bola ke kecepatan normal layaknya awal permainan
        if (rig.velocity.x < 0){
            rig.velocity = new Vector2(speed.x * -1, speed.y);
        }else if (rig.velocity.x > 0){
            rig.velocity = new Vector2(speed.x * 1, speed.y);
        }
        
    }
}
