using UnityEngine;

public class PlatformGame : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;

    [SerializeField] private int _rotateMultiply;
    [SerializeField] private int _returnMultiply;
    [SerializeField] private float _lerpFactor;
    [SerializeField] private Transform _player;

    void Update()
    {
        InclineTerrain();
        FlattenTerrain();
    }

    private void InclineTerrain() //rotate via input
    {
        _horizontalInput = Input.GetAxis("Horizontal"); 
        _verticalInput = Input.GetAxis("Vertical");
        
        transform.RotateAround(_player.localPosition, Vector3.forward, -_rotateMultiply * _horizontalInput * Time.deltaTime);        
        transform.RotateAround(_player.localPosition, Vector3.left, -_rotateMultiply * _verticalInput * Time.deltaTime );
    }

    private void FlattenTerrain() //rotate back if no input
    {
        if (_verticalInput == 0 && transform.rotation.x != 0)
        {
            float changeAngleX = Mathf.LerpAngle(transform.rotation.x, 0, _lerpFactor);
            transform.RotateAround(_player.localPosition, Vector3.left, changeAngleX * _returnMultiply * Time.deltaTime);
        }

        if (_horizontalInput == 0 && transform.rotation.z != 0)
        {
            float changeAngleZ = Mathf.LerpAngle(transform.rotation.z, 0, _lerpFactor);
            transform.RotateAround(_player.localPosition, Vector3.forward, -changeAngleZ * _returnMultiply * Time.deltaTime);
        }
    }
}