using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBox : MonoBehaviour
{
    [SerializeField] Animator _anim;

    public void AnimateDefuser()
    {
        _anim.SetBool("isOff", true);
    }

}
