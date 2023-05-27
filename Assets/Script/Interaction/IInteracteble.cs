using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteracteble
{
   public string InteractionPrompt { get; }

    public void Interact(Interactor interactor);
}
