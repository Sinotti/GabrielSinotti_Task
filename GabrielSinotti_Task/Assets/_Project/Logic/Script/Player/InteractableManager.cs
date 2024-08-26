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

    [SerializeField] private List<IInteractable> _currentCollidingObjects = new List<IInteractable>();

    private void Awake()
    {
        _inputReader.InteractEvent += OnInteract;
    }

    private void OnDisable()
    {
        _inputReader.InteractEvent -= OnInteract;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _interactableLayer)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                if (!_currentCollidingObjects.Contains(interactable))
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
            }
        }
    }

    private void OnInteract()
    {
        if (_currentCollidingObjects.Count > 0)
        {
            var interactable = _currentCollidingObjects[0];
            interactable.Interact();

            _currentCollidingObjects.Remove(interactable);
        }
    }
}
