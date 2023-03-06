using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float dashTime = 0.1f;
    [SerializeField] private float edgePos = 0.125f;
    [SerializeField] private Vector3 playerStart;
    [SerializeField] private Vector3 playerEnd;
    public LogicScript logic;

    private bool _isLeftLane = true;
    private bool _isDashing = false;
    public bool isPlayerAlive = true;
    private float _currentDashTime = 0f;

    private PhotonView view;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetMouseButtonDown(0) && isPlayerAlive)
            {
                if (_isDashing == false)
                {
                    var laneEdge = -edgePos;

                    if (_isLeftLane)
                    {
                        laneEdge = edgePos;
                    }

                    _isDashing = true;
                    _currentDashTime = 0f;
                    playerStart = transform.position;
                    playerEnd = new Vector3(laneEdge, playerStart.y, playerStart.z);
                }
            }

            if (_isDashing)
            {
                // incrementing time
                _currentDashTime += Time.deltaTime;

                var tValue = Mathf.Clamp01(_currentDashTime / dashTime);
                transform.position = Vector3.Lerp(playerStart, playerEnd, tValue);


                if (_currentDashTime >= dashTime)
                {
                    // dash finished
                    _isDashing = false;
                    _isLeftLane = !_isLeftLane;
                    transform.position = playerEnd;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            logic.GameOver();
            isPlayerAlive = false;
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }
    }
}