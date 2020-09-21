using System.Collections;
using UnityEngine;

public class RandomEvent : MonoBehaviour
{
    [SerializeField] private PredictedEvent[] _eventArray = new PredictedEvent[6];
    [SerializeField] private SpriteRenderer _predictionSpriteRenderer;
    [SerializeField] private float _spriteSwitchTime;

    private PredictedEvent[] _selectedEventArray = new PredictedEvent[3];

    private Sprite[] _selectedSpriteArray = new Sprite[3];

    public bool _isReady;

    public bool IsReady()
    {
        return _isReady;
    }

    private void Start()
    {
        StartCoroutine(SelectedSpriteSwitch());
    }

    //private void SelectEvent()
    //{
    //    int j = 0;

    //    for (int i = 0; i<=2; i++)
    //    {
    //        int x = Random.Range(0, _eventArray.Length);

    //        if (_eventArray[x] != null)
    //        {
    //            _selectedEventArray[j] = _eventArray[x];

    //            j++;
    //            _eventArray[x] = null;
    //        }

    //        else
    //        {
    //            i--;
    //        }
    //    }
    //}

    //private void SetSelectedEvent()
    //{
    //     for (int z = 0; z <= _selectedEventArray.Length - 1; z++)
    //     {
    //         _selectedSpriteArray[z] = _selectedEventArray[z].VoyanteSprite();
    //     }
    //}

    private void Update()
    {
        if (!_isReady)
        {
            //for (int t = 0; t <= _eventArray.Length - 1; t++)
            //{
            //    _predictionSpriteRenderer.sprite = _eventArray[t].VoyanteSprite();
            //}
            //SelectEvent();
            //SetSelectedEvent();
            //StartCoroutine(SelectedSpriteSwitch());
        }
    }

    IEnumerator SelectedSpriteSwitch()
    {
            foreach (PredictedEvent danger in _eventArray)
            {
                _predictionSpriteRenderer.sprite = danger.VoyanteSprite();

                yield return new WaitForSeconds(_spriteSwitchTime);
            }
        //    _predictionSpriteRenderer.gameObject.SetActive(false);
        //}
    }
}
