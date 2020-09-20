using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] Player _player;

    public string _theEnd;
    public float _waitToLoad;

    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player.IsDead(true);
            StartCoroutine(LevelEnding());
        }
    }



    #region Coroutines

    public IEnumerator LevelEnding()
    {
        UIController.instance.StartFadeToBlack();

        yield return new WaitForSeconds(_waitToLoad);

        SceneManager.LoadScene(_theEnd);
    }

    #endregion
}
