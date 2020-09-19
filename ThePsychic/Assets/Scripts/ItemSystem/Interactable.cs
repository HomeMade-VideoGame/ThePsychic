using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] Player _player;
    [SerializeField] float _interactRadius = 3f;

    [SerializeField] GameObject _notification;
    [SerializeField] bool isWrench, isFlower, isUmbrella;

    #endregion

    #region Private

    private bool _canPickup = false;

    #endregion

    #region Unity Lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canPickup)
        {
            // Remplis l'inventaire en fonction de l'item trouvé
            if (isWrench)
            {
                UIController.instance._wrenchImage.enabled = true;
                _player._hasWrench = true;
                _player._hasAnyItem = true;
            }

            if (isFlower)
            {
                UIController.instance._flowerImage.enabled = true;
                _player._hasFlower = true;
                _player._hasAnyItem = true;
            }

            if (isUmbrella)
            {
                UIController.instance._umbrellaImage.enabled = true;
                _player._hasUmbrella = true;
                _player._hasAnyItem = true;
            }

            Destroy(gameObject);
        }
    }

    #endregion

    #region Private methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _notification.SetActive(true);
            _canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _notification.SetActive(false);
            _canPickup = false;
        }
    }

    #endregion

}
