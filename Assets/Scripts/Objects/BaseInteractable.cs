using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{
    public abstract void OnInteract(Character character);
    public virtual void OnEscape(Character character) {}
}