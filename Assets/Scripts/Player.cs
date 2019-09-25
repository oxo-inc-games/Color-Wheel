﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float jumpForce = 2.5f;
    public string currentColor;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GameObject smallCircle;
    public GameObject square;
    public GameObject colorChanger;

    private Transform colorChangerTranform;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    private void Start()
    {
        setRandomColor();
        rb.velocity = Vector2.up * jumpForce;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallCircle")
            return;

        if(collision.tag == "ColorChanger")
        {
            setRandomColor(); //TODO: Change to already existed color
            colorChangerTranform = collision.gameObject.GetComponent<Transform>();
            Instantiate(colorChanger, new Vector3(0, colorChangerTranform.position.y + 7f, 0), Quaternion.identity);
            instantiateRandomObject();
            Destroy(collision.gameObject);
            return;
        }

        if(collision.tag != currentColor)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            //instantiate prefab
        }
       
    }

    void instantiateRandomObject()
    {
        int r = Random.Range(0, 2);
        if (r == 0)
            Instantiate(smallCircle, new Vector3(0, colorChangerTranform.position.y + 10.5f, 0), Quaternion.identity);
        else
            Instantiate(square, new Vector3(0, colorChangerTranform.position.y + 10.5f, 0), Quaternion.identity);
    }

    void setRandomColor()
    {
        int index = Random.Range(0, 4);

        switch(index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;

        }
    }
}
