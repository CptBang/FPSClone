public interface Damageable
{
    //interfaces can have methods
    void TakeDamage(float dmg);
}

public interface Grabbable
{
    //interfaces can have properties too! (but not fields)
    bool isGrabbable { get; set; }
}
