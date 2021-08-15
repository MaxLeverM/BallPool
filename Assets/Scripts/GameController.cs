using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Rigidbody CueBall;
    public Cue Cue;
    private Vector3 _hitDirection;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            var pos = Camera.main.ScreenToWorldPoint(touch.position);
            pos.z = CueBall.position.z;
            var direction = pos - CueBall.position;
        }*/
       if(Input.GetMouseButton(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.y = CueBall.position.y;
            _hitDirection = (pos - CueBall.position).normalized;
            Cue.transform.LookAt(pos,Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CueHit(_hitDirection, 1f);
        }
    }

    public void CueHit(Vector3 direction, float force, Vector3 torque = default)
    {
        CueBall.AddForce(direction * force,ForceMode.Impulse);
        if (torque != default)
        {
            CueBall.AddTorque(torque);
        }
    }
}
