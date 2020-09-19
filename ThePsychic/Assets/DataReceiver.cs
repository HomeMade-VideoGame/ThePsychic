using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReceiver : MonoBehaviour
{
    [SerializeField] BoutonData _boutonDataReceiver;

    public UtilisationItem _utilisationItem;

    public void UseWrenchReceiver()
    {
        _boutonDataReceiver.value.UseWrench();
    }

    public void UseFlowerReceiver()
    {
        _boutonDataReceiver.value.UseFlower();
    }

    public void UseUmbrellaReceiver()
    {
        _boutonDataReceiver.value.UseUmbrella();
    }
}
