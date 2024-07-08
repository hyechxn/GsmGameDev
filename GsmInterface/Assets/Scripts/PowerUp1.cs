using UnityEngine;
public class PowerUp1 : MonoBehaviour, IPowerProvider
{
    [SerializeField] private int powerAmount;

    public int PowerAmount => powerAmount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IPowerReceiver>(out IPowerReceiver powerReceiver))
        {
            powerReceiver.PowerChange(this);
        }
    }
}
