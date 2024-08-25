using UnityEngine;
using UnityEngine.UI;
using Main.SO.Items;
using Main.Systems;

namespace Main.UI
{
    public class CollectItemPopUP : MonoBehaviour
    {
        [Header("Pop Up Settings")]
        [SerializeField] private GameObject _popUpPrefab;
        [SerializeField] private Transform _popUpParent;
        [SerializeField] private float _displayDuration = 2f;

        private void OnEnable()
        {
            InventorySystem.OnAdded += ShowPopUp;
        }

        private void OnDisable()
        {
            InventorySystem.OnAdded -= ShowPopUp;
        }

        private void ShowPopUp(InventoryItemSO item)
        {
            if (item == null || _popUpPrefab == null || _popUpParent == null)
            {
                Debug.LogWarning("CollectItemPopUP: Missing prefab or parent.");
                return;
            }

            GameObject newPopUp = Instantiate(_popUpPrefab, _popUpParent);

            if (newPopUp.TryGetComponent(out Image popUpImage) && item != null)
            {
                popUpImage.sprite = item.ItemImage;
            }
            else
            {
                Debug.LogWarning("CollectItemPopUP: Image component is missing in the prefab or item is null.");
            }

            Destroy(newPopUp, _displayDuration);
        }
    }
}
