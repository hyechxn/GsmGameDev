using System.Collections.Generic;
using UnityEngine;
public interface IPowerReceiver
{
    public List<GameObject> PowerUpBullets { get; }
    public void PowerChange(IPowerProvider powerUpProvider);
}
