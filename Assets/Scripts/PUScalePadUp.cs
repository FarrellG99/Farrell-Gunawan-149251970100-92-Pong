using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUScalePadUp : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D bola;
    public GerakanBola bolaa;
    
    float timer;

    void OnTriggerEnter2D(Collider2D other) {
        if (other == bola)
        {
            //donleft dan doneright digunakan untuk menghentikan penambahan dan mengembalikan value seperti semula pada paddle guna untuk memberikan gameplay yang lebih playable
            if (bolaa.isLeft && !manager.activationScaleUpPadLeft)
            {
                manager.activationScaleUpPadLeft = true;
                manager.padKiri.GetComponent<PaddleController>().ScaleUp(manager.padKiri);
                manager.RemovePowerUp(gameObject);
            }
            if (!bolaa.isLeft && !manager.activationScaleUpPadRight)
            {
                manager.activationScaleUpPadRight = true;
                manager.padKanan.GetComponent<PaddleController>().ScaleUp(manager.padKanan);
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
