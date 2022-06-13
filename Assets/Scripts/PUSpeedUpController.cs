using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float magnitude = 2f;

    private float timer;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other == ball)
        {
            ball.GetComponent<GerakanBola>().ActivationPUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer > manager.DeleteInterval)
        {
            Debug.Log("OK");
            manager.RemovePowerUp(gameObject);
        }
    }


}
