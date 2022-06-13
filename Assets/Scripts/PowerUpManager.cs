using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount = 3;
    public int spamInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public List<GameObject> powerUpTemplateList;
    private List<GameObject> powerUpList;

    private float timer;

    //DeleteInterval berfungsi untuk mengatur berapa lama waktu dari PowerUp, apabila sudah mencapai waktu maka PowerUp akan dihapus;
    [SerializeField] public float DeleteInterval;
    
    void Start() {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer > spamInterval)
        {
            GenerateRandomPowerUp();
            timer -= spamInterval;
        }
    }

    public void GenerateRandomPowerUp(){
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position){
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }
        if (position.x < powerUpAreaMin.x || 
            position.x > powerUpAreaMax.x || 
            position.y < powerUpAreaMin.y || 
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp){
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp(){
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
