// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;

public class LadderController : MonoBehaviour
{
    CharacterController _characterController;
    PlayerMove _move;

    [SerializeField] float _climbSpeed = 2.0f;

    bool _isClimbing = false;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _move = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        float ladderInputVert = Input.GetAxis("Vertical");
      

        Vector3 moveDir = new Vector3(0, ladderInputVert, 0).normalized;

        if (_isClimbing)
            _characterController.Move(moveDir * _climbSpeed * Time.deltaTime);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isClimbing = true;
            _move._canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isClimbing = false;
            _move._canMove = true;
        }
    }
}
