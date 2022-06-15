using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedPadUp : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D bola;
    [SerializeField] Collider2D padKiri;
    [SerializeField] Collider2D padKanan;
    public GerakanBola bolaa;
    
    float timer;

    void OnTriggerEnter2D(Collider2D other) {
        if (other == bola)
        {
            //donleft dan doneright digunakan untuk menghentikan penambahan dan mengembalikan value seperti semula pada paddle guna untuk memberikan gameplay yang lebih playable
            if (bolaa.isLeft && !manager.doneleftSpeed)
            {
                manager.doneleftSpeed = true;
                padKiri.GetComponent<PaddleController>().SpeedUpPad();
                manager.RemovePowerUp(gameObject);
            }
            else if (bolaa.isLeft && manager.doneleftSpeed)
            {
                manager.doneleftSpeed = false;
                padKiri.GetComponent<PaddleController>().ResetSpeedPad();
                manager.RemovePowerUp(gameObject);
            }
            
            else if (!bolaa.isLeft && !manager.donerightSpeed)
            {
                manager.donerightSpeed = true;
                padKanan.GetComponent<PaddleController>().SpeedUpPad();
                manager.RemovePowerUp(gameObject);
            }
            else if (!bolaa.isLeft && manager.donerightSpeed)
            {
                manager.donerightSpeed = false;
                padKanan.GetComponent<PaddleController>().ResetSpeedPad();
                manager.RemovePowerUp(gameObject);
            }
        }
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
