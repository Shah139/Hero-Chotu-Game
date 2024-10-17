using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusButton : MonoBehaviour
{
    public float speed = 5f;
    public bool IsMoving = false;
    public void OnButtonClick(){
        IsMoving = true;
        Debug.Log("BUttonclicking");
    }

    // Update is called once per frame
    void Update()
    {
        if(IsMoving) transform.Translate(Vector3.forward * speed * Time.deltaTime);
        


        
    }
}
