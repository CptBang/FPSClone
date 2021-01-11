using UnityEngine;


public class Target : MonoBehaviour, Damageable, Grabbable
{
    public float health = 50f;

    //You can't set properties with the Unity Editor
    //Instead you need to make a placeholder which the property modifies:
    [SerializeField] private bool _isGrabbable = true;
    public bool isGrabbable { get { return _isGrabbable; } set { _isGrabbable = value; } }

    public void TakeDamage(float dmg) {
       health -= dmg;
       if (health <= 0f) {
           Die();
       }
    }

   void Die() {
       Destroy(gameObject);
   }
}
