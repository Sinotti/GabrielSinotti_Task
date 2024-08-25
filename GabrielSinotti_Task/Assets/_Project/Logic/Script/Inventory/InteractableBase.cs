using Main.Interface;

using UnityEngine;
using UnityEngine.Events;

public class InteractableBase : MonoBehaviour, IInteractable
{
    [Header("Interactable Inheritance")]
    [Space(6)]
    [SerializeField] private UnityEvent _OnInteract;
    public bool CanInteract { get; set; }

    public virtual void Interact()
    {
        _OnInteract?.Invoke();
    }
}
