
namespace Main.Interface
{
    public interface IInteractable
    {
        public bool CanInteract { get; set; }
        public void Interact();
    }
}
