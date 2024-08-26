using Main.Gameplay.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Systems
{
    public class ResetScaleTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                StatusManager.Instance.ResetScale();
            }
        }
    }
}
