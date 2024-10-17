using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class BusScript : MonoBehaviour
{
    public GameObject button;
    private bool playerDetected;
    public float speed = 2f;
    public bool IsMoving = false;

    public GameObject car1, car2, car3, car4, car5, car6;

    private bool canMoveDelayedCars = false; // To track when delayed cars should move

    //Detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we triggered the player, enable playerDetected and show the button
        if (collision.tag == "Player")
        {
            playerDetected = true;
            Debug.Log("Player detected");
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If we lost trigger with the player, disable playerDetected and hide the button
        if (collision.tag == "Player")
        {
            playerDetected = false;
            Debug.Log("Player left");
            button.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        IsMoving = true;
        Debug.Log("clicked");
        StartCoroutine(DelayedStart()); // Start the delay for car4, car5, car6
    }

    void Start()
    {
        button.SetActive(false);
    }

    void Update()
    {
        if (IsMoving)
        {
            // Move car1, car2, car3 immediately
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            car1.transform.Translate(Vector3.right * speed * Time.deltaTime);
            car2.transform.Translate(Vector3.right * speed * Time.deltaTime);
            car3.transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Move car4, car5, car6 after the delay
            if (canMoveDelayedCars)
            {
                car4.transform.Translate(Vector3.down * speed * Time.deltaTime);
                car5.transform.Translate(Vector3.down * speed * Time.deltaTime);
                car6.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }

    // Coroutine for delaying car4, car5, and car6 movement
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        canMoveDelayedCars = true; // Allow car4, car5, and car6 to move
    }
}
