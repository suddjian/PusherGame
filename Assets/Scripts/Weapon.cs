using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

	public Rigidbody2D projectile;
    public float projectileForce = 200;

	public bool fullAuto = false;
	public float autoRateOfFire = 5; // rounds per second when auto-firing
	public int autoFireBurstLimit = -1; // number of rounds to use when auto-firing (burst fire). -1 for full auto, 0 to disable full auto (same as setting fullAuto to false)

	public float manualRateOfFire = -1; // rounds per second allowed from user clicks. -1 for unlimited.

	private bool firing = false;
	private float lastFireTime = 0;
	private int shotsFiredThisClick = 0;

	void Update ()
	{
		// point at mouse
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Utils.LookAt2D(transform, Utils.Vector2Convert(mousePos));

		if (Input.GetMouseButton(0)) {
            if (CanFire()) {
			    Fire();
                lastFireTime = Time.time;
                shotsFiredThisClick ++;
                firing = true;
            }
		} else {
			firing = false;
			shotsFiredThisClick = 0;
		}
	}

	bool CanFire ()
	{
		if (!firing) { // the user just clicked the mouse this frame
			return Time.time >= lastFireTime + 1 / manualRateOfFire; // check if enough time has elapsed before manually trying to fire again
		} else if (fullAuto && Time.time >= lastFireTime + 1 / autoRateOfFire) { // check if enough time has elapsed before firing full auto again
			return autoFireBurstLimit == -1 || shotsFiredThisClick < autoFireBurstLimit; // check if within the burst limit
		}
		return false;
	}

	void Fire ()
	{
        Rigidbody2D bullet = (Rigidbody2D) Instantiate(projectile, transform.position, transform.rotation);
        Vector3 initialV = Vector3.zero;
        if (rigidbody2D != null) {
            initialV = rigidbody2D.velocity;
        }
        //bullet.AddForce(bullet.transform.right * projectileForce); // this causes the bullet to move 10x slower on some systems for unknown reasons
        bullet.rigidbody2D.velocity = bullet.transform.right * projectileForce + initialV;
    }
}
