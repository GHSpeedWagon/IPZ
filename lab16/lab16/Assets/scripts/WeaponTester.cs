using UnityEngine;

public interface IWeapon {
    void Attack();
}

public class BasicWeapon : IWeapon {
    public void Attack() {
        Debug.Log("Атака звичайною зброєю!");
    }
}

public class FireDecorator : IWeapon {
    private IWeapon weapon;

    public FireDecorator(IWeapon weapon) {
        this.weapon = weapon;
    }

    public void Attack() {
        weapon.Attack();
        Debug.Log("...додано шкоду від вогню!");
    }
}

public class IceDecorator : IWeapon {
    private IWeapon weapon;

    public IceDecorator(IWeapon weapon) {
        this.weapon = weapon;
    }

    public void Attack() {
        weapon.Attack();
        Debug.Log("...додано ефект заморозки!");
    }
}

public class WeaponTester : MonoBehaviour {
    void Start() {
        IWeapon basicWeapon = new BasicWeapon();
        IWeapon fireWeapon = new FireDecorator(basicWeapon);
        IWeapon iceFireWeapon = new IceDecorator(fireWeapon);

        iceFireWeapon.Attack();
    }
}