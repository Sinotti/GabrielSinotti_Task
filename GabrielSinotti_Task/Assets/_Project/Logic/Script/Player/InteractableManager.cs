using Main.Interface;
using Main.SO.Input;
using UnityEngine;
using System.Collections.Generic;

public class InteractableManager : MonoBehaviour
{
    [Header("Interaction Parameters")]
    [Space(6)]
    [SerializeField] private int _interactableLayer;

    [Header("References")]
    [Space(6)]
    [SerializeField] private InputReaderGameplay _inputReader;

    private bool _interactInput;
    private int _currentInteractableIndex = 0;

    [SerializeField] private List<IInteractable> _currentCollidingObjects = new List<IInteractable>();

    private void Awake()
    {
        _inputReader.InteractEvent += OnInteract;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _interactableLayer)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                if (!_currentCollidingObjects.Contains(interactable)) // Avoid duplicates
                {
                    _currentCollidingObjects.Add(interactable);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _interactableLayer)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                _currentCollidingObjects.Remove(interactable);

                //Adjust the current index if necessary
                if (_currentInteractableIndex >= _currentCollidingObjects.Count)
                {
                    _currentInteractableIndex = Mathf.Max(0, _currentInteractableIndex - 1);
                }
            }
        }
    }

    #region Input Assigments

    private void OnInteract()
    {
        if (_currentCollidingObjects.Count == 0)
        {
            Debug.Log("No interactables available.");
            return;
        }

        if (_currentInteractableIndex < _currentCollidingObjects.Count)
        {
            var interactable = _currentCollidingObjects[_currentInteractableIndex];
            interactable.Interact();

            _currentInteractableIndex++;

            if (_currentInteractableIndex >= _currentCollidingObjects.Count)
            {
                _currentInteractableIndex = 0;
            }
        }
    }

    #endregion
}
