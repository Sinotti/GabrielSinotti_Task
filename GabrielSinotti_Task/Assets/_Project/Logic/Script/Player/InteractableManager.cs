using Main.Interface;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] private int _interactableLayer;
    private InteractableBase _currentInteractable;
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _interactableLayer)
        {
            if(other.TryGetComponent(out IInteractable interactable))
            {
                interactable.CanInteract = true;
            }
        }
    }
}
