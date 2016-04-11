using System;
using UnityEngine;

abstract public class Interactable : MonoBehaviour
{
    abstract public void Respond(PlayerManager m);
}
