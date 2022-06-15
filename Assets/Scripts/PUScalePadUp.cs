using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUScalePadUp : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D bola;
    [SerializeField] GameObject padKiri;
    [SerializeField] GameObject padKanan;
    public GerakanBola bolaa;
    
    float timer;

    void OnTriggerEnter2D(Collider2D other) {
        if (other == bola)
        {
            Debug.Log("d : " + manager.doneleftScale);
            //donleft dan doneright digunakan untuk menghentikan penambahan dan mengembalikan value seperti semula pada paddle guna untuk memberikan gameplay yang lebih playable
            if (bolaa.isLeft && !manager.doneleftScale)
            {
                manager.doneleftScale = true;
                padKiri.transform.localScale += new Vector3(0, padKiri.transform.localScale.y, 0);
                manager.RemovePowerUp(gameObject);
            }
            else if (bolaa.isLeft && manager.doneleftScale)
            {
                manager.doneleftScale = false;
                Debug.Log("b : " + manager.doneleftScale);
                padKiri.transform.localScale -= new Vector3 (0,padKiri.transform.localScale.y/2,0);
                manager.RemovePowerUp(gameObject);
            }
            
            else if (!bolaa.isLeft && !manager.donerightScale)
            {
                manager.donerightScale = true;
                padKanan.transform.localScale += new Vector3 (0,padKanan.transform.localScale.y,0);
                manager.RemovePowerUp(gameObject);
            }
            else if (!bolaa.isLeft && manager.donerightScale)
            {
                manager.donerightScale = false;
                padKanan.transform.localScale -= new Vector3 (0,padKanan.transform.localScale.y/2,0);
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
