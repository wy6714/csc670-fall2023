using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BroomController : MonoBehaviour
{
    public float speed = 2f;
    public float rotateAmount = 120f;
    private float rotateValue;
    public GameManager gm;

    public float energy = 20;
    public Slider enerygySlider;

    public float energyDecreseTime = 1.0f;

    public GameObject fuelMeterObj;

    public int energyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        fuelMeterObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.onBroom)
        {
            //move forward
            transform.position += transform.forward * speed * Time.deltaTime;

            //rotate
            float hInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");
            rotateValue += hInput * rotateAmount * Time.deltaTime;

            //Mathf.Sign decides go up or down based on value of vInput's negative or positive
            //up and down 0-20 degree
            float pitch = Mathf.Lerp(0, 20, Mathf.Abs(vInput)) * -Mathf.Sign(vInput);

            //roll
            float roll = Mathf.Lerp(0, 30, Mathf.Abs(hInput)) * Mathf.Sign(hInput);
            if (energy <= 0)
            {
                pitch = 30;
                roll = 0;
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
            transform.localRotation = Quaternion.Euler(Vector3.up * rotateValue
                + Vector3.right * pitch
                + Vector3.forward * roll);
            
            //decrease energy
            EnergyDecreaseOvertime();

            //show broom energy
            fuelMeterObj.SetActive(true);
        }

        if (energy > 100)
        {
            energy = 100;
        }

        
        updateEnergySlider();

        if (energyCount == 7)
        {
            SceneManager.LoadScene("win");
        }
    }

    private void EnergyDecreaseOvertime()
    {
        energyDecreseTime -= Time.deltaTime;
        if (energyDecreseTime <= 0)
        {
            energy -= 1;
            energyDecreseTime = 1.0f;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("energy"))
        {
            Destroy(other.gameObject);
            energy += 5;
            energy += 1;
        }
    }

    public void updateEnergySlider()
    {
        Debug.Log(energy);
        enerygySlider.value = energy;
    }
    
        
    
}
