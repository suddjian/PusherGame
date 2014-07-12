using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

	public Rigidbody2D projectile;
    public float projectileForce = 200;

	public bool fullAuto = false;
	public float autoRateOfFire = 5; // rounds per second
	public int autoFireBurstLimit = -1; // number of rounds to use when auto-firing (burst fire). -1 for full auto, 0 to disable full auto (same as setting fullAuto to false)

	public float manualRateOfFire = -1; // rounds per second allowed from user clicks. -1 for unlimited.

	private bool firing = false;
	private long lastFireTime = 0;
	private int shotsFiredThisClick = 0;

	private System.Diagnostics.Stopwatch time;

	void Start ()
	{
		time = System.Diagnostics.Stopwatch.StartNew ();
	}

	void Update ()
	{
		// point at mouse
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Utils.LookAt2D(transform, Utils.Vector2Convert(mousePos));

		if (Input.GetMouseButton(0)) {
            if (canFire()) {
			    Fire();
                lastFireTime = time.ElapsedMilliseconds;
                shotsFiredThisClick ++;
                firing = true;
            }
		} else {
			firing = false;
			shotsFiredThisClick = 0;
		}
	}

	bool canFire ()
	{
		long currentTime = time.ElapsedMilliseconds;
		if (!firing) { // the user just clicked the mouse this frame
			return currentTime >= lastFireTime + 1000 / manualRateOfFire; // check if enough time has elapsed before manually trying to fire again
		} else if (fullAuto && currentTime >= lastFireTime + 1000 / autoRateOfFire) { // check if enough time has elapsed before firing full auto again
			return autoFireBurstLimit == -1 || shotsFiredThisClick < autoFireBurstLimit; // check if within the burst limit
		}
		return false;
	}

	void Fire ()
	{
        Rigidbody2D bullet = (Rigidbody2D) Instantiate(projectile, transform.position, transform.rotation);
        if (rigidbody2D != null) {
            bullet.velocity = rigidbody2D.velocity;
        }
        bullet.AddForce(bullet.transform.right * projectileForce);
    }
}
