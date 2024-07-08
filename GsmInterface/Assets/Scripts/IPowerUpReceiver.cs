using System.Collections.Generic;
using UnityEngine;
public interface IPowerUpReceiver
{
    public List<GameObject> PowerUpBullets { get; }
    public void PowerChange(IPowerUpProvider powerUpProvider);
}
