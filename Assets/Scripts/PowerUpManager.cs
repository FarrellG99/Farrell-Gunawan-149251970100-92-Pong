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

    public GameObject ball;
    public float ballMagnitude;
    float BallSpeedDuration;
    public bool activationBallSpeed;

    public GameObject padKiri;
    public GameObject padKanan;

    float durationScaleUpPadLeft;
    float durationSpeedUpPadLeft;
    float durationScaleUpPadRight;
    float durationSpeedUpPadRight;

    public bool activationScaleUpPadLeft = false;
    public bool activationSpeedUpPadLeft = false;
    public bool activationScaleUpPadRight = false;
    public bool activationSpeedUpPadRight = false;

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

        //Durasi Buff BallSpeedUp
        if (activationBallSpeed == true)
        {
            if (BallSpeedDuration >= 5)
            {
                ball.GetComponent<GerakanBola>().DeactivationPUSpeedUp(ballMagnitude);
                activationBallSpeed = false;
                BallSpeedDuration -= 5;
            }
            BallSpeedDuration += Time.deltaTime;
        }

        //Durasi Buff ScalePadKiri
        if (activationScaleUpPadLeft == true)
        {
            if (durationScaleUpPadLeft >= 5)
            {
                padKiri.GetComponent<PaddleController>().ScaleDown(padKiri);
                activationScaleUpPadLeft = false;
                durationScaleUpPadLeft -= 5;
            }
            durationScaleUpPadLeft += Time.deltaTime;
        }
        //Durasi Buff SpeedUp PadKiri
        if (activationSpeedUpPadLeft == true)
        {
            if (durationSpeedUpPadLeft >= 5)
            {
                padKiri.GetComponent<PaddleController>().ResetSpeedPad();
                activationSpeedUpPadLeft = false;
                durationSpeedUpPadLeft -= 5;
            }
            durationSpeedUpPadLeft += Time.deltaTime;
        }
        //Durasi Buff ScalePadKanan
        if (activationScaleUpPadRight == true)
        {
            if (durationScaleUpPadRight >= 5)
            {
                padKanan.GetComponent<PaddleController>().ScaleDown(padKanan);
                activationScaleUpPadRight = false;
                durationScaleUpPadRight -= 5;
            }
            durationScaleUpPadRight += Time.deltaTime;
        }
        //Durasi Buff SpeedUp PadKanan
        if (activationSpeedUpPadRight == true)
        {
            if (durationSpeedUpPadRight >= 5)
            {
                padKanan.GetComponent<PaddleController>().ResetSpeedPad();
                activationSpeedUpPadRight = false;
                durationSpeedUpPadRight -= 5;
            }
            durationSpeedUpPadRight += Time.deltaTime;
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
