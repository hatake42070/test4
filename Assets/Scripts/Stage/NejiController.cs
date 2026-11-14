using System;
using UnityEngine;

public class NejiController : MonoBehaviour
{
    public event Action TriggerNeji;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            TriggerNeji?.Invoke();
            Destroy(gameObject); // ©g‚ğ”j‰ó
        }
    }
}
