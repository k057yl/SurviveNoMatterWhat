using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    [Inject] private CharacterControl _characterControl;
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float verticalOffset = 5f;
    private Transform _characterTransform;
    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
        if (_characterControl != null)
        {
            _characterTransform = _characterControl.transform;
        }
        else
        {
            Debug.LogError("CharacterControl is not injected!");
        }
    }

    private void LateUpdate()
    {
        if (_characterTransform != null)
        {
            Vector3 characterPosition = _characterTransform.position;
            
            Vector3 targetPosition = new Vector3(characterPosition.x, characterPosition.y + verticalOffset, transform.position.z);
            
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, followSpeed * Time.deltaTime);
        }
    }
}
