using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGun : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _weapon;
    private AIManager _player;
    private Vector3 _holsterLocation;
    private Vector3 _holsterRotation;

    void storePositions()
    {
        Vector3 initialLocation = _weapon.transform.localPosition;
        Vector3 initialRotation = _weapon.transform.localEulerAngles;
        _holsterLocation = initialLocation;
        _holsterRotation = initialRotation;
    }

    void Start()
    {
        _weapon = gameObject;
        storePositions();
        _player = GetComponentInParent<AIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.isMoving)
        {
            _weapon.transform.localPosition = new Vector3(1.7581f, 1.4732f, 1.1357f);
            _weapon.transform.localEulerAngles = new Vector3(2.147f, 15.318f, 2.474f);
        }
        else
        {
            _weapon.transform.localPosition = _holsterLocation;
            _weapon.transform.localEulerAngles = _holsterRotation;
        }
    }
}