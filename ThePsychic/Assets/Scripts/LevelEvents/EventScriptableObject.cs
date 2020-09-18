using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event")]
public class EventScriptableObject : ScriptableObject
{
    public float speed;
    public Vector3 minPos, maxPos;
    public Sprite eventSprite;
    public AudioClip eventSound;
}
