using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedEvent : MonoBehaviour
{
    public Sprite _voyanteSprite;

    private bool isActive = true;
    private bool isTriggered;


    public Sprite VoyanteSprite()
    {
        return _voyanteSprite;
    }

    public bool IsActive(bool status)
    {
        isActive = status;
        return isActive;
    }

    private void Start()
    {

    }

    //Methode appelée depuis Event Manager
    public void StartEvent()
    {
        isTriggered = true;
    }

    private void Update()
    {
        if (isTriggered)
        {

        }
        else if (!isActive)
        {

        }
    }

  
    //Tue le joueur si le touche
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            Debug.Log("Triggered the event");
        }
    }

    public virtual void Disarm()
    {
        Debug.Log("Event disarmed");
        IsActive(false);
    }

    


}
