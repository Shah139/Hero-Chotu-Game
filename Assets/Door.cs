using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] 
    // Start is called before the first frame update
    private string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag(TagManager.MAIN_MENU_CHARACTER_TAG) )
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
        } 
    }

}
