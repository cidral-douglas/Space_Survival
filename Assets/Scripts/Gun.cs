using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] Transform shotPoint;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] GameObject emissionEffect;

    private float shotTime;
    

    void Update()
    {
        float angle = getMouseAngleDirection();
        rotateGunByAngle(angle);

        shoot();
    }

    private float getMouseAngleDirection()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //This calculates the arc Tangent angle between the direction point and the (x0, y0).
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    private void rotateGunByAngle(float angle)
    {
        //-15 degress was used to calibrate the gun shooting point.
        //This was needed due to the diferent locations between the shooting point and the sprite pivot point.
        Quaternion rotation = Quaternion.AngleAxis(angle - 15, Vector3.forward);
        transform.rotation = rotation;
    }

    private void shoot() {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                Instantiate(shot, shotPoint.position, transform.rotation);
                Instantiate(emissionEffect, shotPoint.position, transform.rotation);
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }

}
