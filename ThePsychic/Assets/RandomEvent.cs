using System.Collections;
using UnityEngine;

public class RandomEvent : MonoBehaviour
{
    [SerializeField] private PredictedEvent[] _eventArray = new PredictedEvent[6];
    [SerializeField] private SpriteRenderer _predictionSpriteRenderer;
    [SerializeField] private float _spriteSwitchTime;

    private PredictedEvent[] _selectedEventArray = new PredictedEvent[3];

    private Sprite[] _selectedSpriteArray = new Sprite[3];


    private void SelectEvent()
    {
        int j = 0;

        for (int i = 0; i<=2; i++)
        {
            int x = Random.Range(0, _eventArray.Length);
            _selectedEventArray[j] = _eventArray[x];
            j++;
            Debug.Log(j + "j event chargé");
        }
    }

    private void SetSelectedEvent()
    {
         for (int z = 0; z <= _selectedEventArray.Length - 1; z++)
         {
             _selectedSpriteArray[z] = _selectedEventArray[z].VoyanteSprite();
         }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SelectEvent();
            SetSelectedEvent();
        }
    }

    IEnumerator SelectedSpriteSwitch()
    {
        foreach(Sprite danger in _selectedSpriteArray)
        {
            yield return new WaitForSeconds(_spriteSwitchTime);

            _predictionSpriteRenderer.sprite = danger;
        }
    }

    private void SpawnEvent()
    {

    }
}
