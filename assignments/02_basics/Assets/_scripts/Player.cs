using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float speed = 10f;
    public int score = 0;
    public GameObject keyPrefeb;
    private GameObject keyObj;
    public GameObject LooseText;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Vector3 keyPos = new Vector3(Random.Range(0f, 18f), 1.5f, -6f);
        keyObj = Instantiate(keyPrefeb, keyPos, Quaternion.identity);
        keyObj.SetActive(false);

        LooseText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * speed * Time.deltaTime);

        //rotate while move
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0.0f, 45f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0.0f, -45f, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0.0f, 0f, 0.0f);
        }

        if(score == 3)
        {
            keyObj.SetActive(true);
        }
     

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gem"))
        {
            Destroy(other.gameObject);
            score += 1;
            Debug.Log("score = " + score);


        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            LooseText.SetActive(true);

        }

        if (other.CompareTag("key"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("Scene02");

        }
    }

    


}