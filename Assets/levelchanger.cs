using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelchanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            SceneManager.LoadScene("SampleScene");
        }
    }
}
