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
            if (bolaa.isLeft && !manager.activationSpeedUpPadLeft)
            {
                manager.activationSpeedUpPadLeft = true;
                manager.padKiri.GetComponent<PaddleController>().SpeedUpPad();
                manager.RemovePowerUp(gameObject);
            }
            if (!bolaa.isLeft && !manager.activationSpeedUpPadRight)
            {
                manager.activationSpeedUpPadRight = true;
                manager.padKanan.GetComponent<PaddleController>().SpeedUpPad();
                manager.RemovePowerUp(gameObject);
            }
        }
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= manager.DeleteInterval)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
