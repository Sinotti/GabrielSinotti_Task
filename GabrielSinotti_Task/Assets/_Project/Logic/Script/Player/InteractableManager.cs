using Main.Interface;
using Main.SO.Input;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    [Header("Interaction Parameters")]
    [Space(6)]
    [SerializeField] private int _interactableLayer;

    [Header("References")]
    [Space(6)]
    [SerializeField] private InputReader _inputReader;

    private bool _interactInput;

    private InteractableBase _currentInteractable;

    private void Awake()
    {
        _inputReader.InteractEvent += OnInteract;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _interactableLayer)
        {
            if(other.TryGetComponent(out IInteractable interactable))
            {
                
            }
        }
    }

    #region Input Assigments

    private void OnInteract()
    {
        Debug.Log("Interact");
    }

    #endregion
}
