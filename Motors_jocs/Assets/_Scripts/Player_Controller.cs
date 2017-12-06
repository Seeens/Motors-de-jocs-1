using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 8.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;
    [SerializeField] private float jumpSpeed = 12.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float castingTime = 1.0f;

    private CharacterController _controller;
    private Camera _camera;

    /* Prefab for the spell projectile */
    public GameObject spellPrefab;
    private UI_DebugInfo _debugInfo;

    [HideInInspector] public Vector3 _moveDirection = Vector3.zero;
    public Transform spellSpawn_R;
    public Transform spellSpawn_L;

    private bool _isJumping = false;
    private bool _isJumpingRunning = false;
    private bool _isRunning = false;

    private bool _isCasting_R = false;
    private bool _isCasting_L = false;

    private float _castTime_R = 0.0f;
    private float _castTime_L = 0.0f;

    private GameObject _spell_R;
    private GameObject _spell_L;


    private void Start()
    {
        /* Set the intial lockstate and get the reference to the character controller*/
        _controller = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
        _debugInfo = GameObject.FindGameObjectWithTag("UI").GetComponent<UI_DebugInfo>();
        //_handAnimation_R = GameObject.FindGameObjectWithTag("RHand").GetComponent<Animation_Hand>();
        //_handAnimation_L = GameObject.FindGameObjectWithTag("LHand").GetComponent<Animation_Hand>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        /* Reset jumping state */
        _isJumping = false;

        /* Input manager for the controller */
        CheckInputs();

        /* Compute speeds and apply movement to the controller */
        PerformMovement();

        /* Updates cast times */
        UpdateCastingTimes();
    }

    private void CheckInputs()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown("mouse 0"))
        {
            /* Lock cursor */
            Cursor.lockState = CursorLockMode.Locked;

            /* Start casting */
            CheckCastStart_L();
        }
        if (Input.GetKeyUp("mouse 0"))
        {
            /* Stop casting */
            CheckCastStop_L();
        }
        if (Input.GetKeyDown("mouse 1"))
        {
            /* Start casting */
            CheckCastStart_R();
        }
        if (Input.GetKeyUp("mouse 1"))
        {
            /* Stop casting */
            CheckCastStop_R();
        }
        if (Input.GetKeyDown("left shift"))
        {
            _isRunning = true;
        }
        if (Input.GetKeyUp("left shift"))
        {
            _isRunning = false;
        }
        if (Input.GetKeyDown("space"))
        {
            _isJumping = _controller.isGrounded;
        }
    }

    private void PerformMovement()
    {
        /* Get movement vector and tranform from local axis to world axis */
        if (_controller.isGrounded)
        {
            /* Clear air running speed flag*/
            _isJumpingRunning = false;

            /* Get axis values for the movement */
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = transform.TransformDirection(_moveDirection);

            /* Apply speed */
            _moveDirection *= moveSpeed;

            /* Apply sprint multiplier */
            if (_isRunning)
            {
                _moveDirection *= sprintMultiplier;
            }
        }
        else
        {
            /* Get axis values for the movement */
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), _moveDirection.y, Input.GetAxis("Vertical"));
            _moveDirection = transform.TransformDirection(_moveDirection);

            /* Apply speed */
            _moveDirection.x *= moveSpeed;
            _moveDirection.z *= moveSpeed;

            /* Apply sprint multiplier */
            if (_isJumpingRunning)
            {
                _moveDirection.x *= sprintMultiplier;
                _moveDirection.z *= sprintMultiplier;
            }
        }

        /* Check for jumping state */
        if (_isJumping)
        {
            _isJumpingRunning = _isRunning;
            _moveDirection.y = jumpSpeed;
        }

        /* Apply gravity */
        _moveDirection.y -= gravity * Time.deltaTime;

        /* Send speed update to canvas */
        _debugInfo.UpdateSpeed(_moveDirection.magnitude);

        /*Apply movement */
        _controller.Move(_moveDirection * Time.deltaTime);
    }

    private void CastSpell_L()
    {
        /* Unchild the fireball to get a free movement and enable trailing*/
        _spell_L.transform.parent = null;
        var _trails = _spell_L.GetComponent<ParticleSystem>().trails;
        _trails.enabled = true;

        /* Add velocity to the spell*/
        _spell_L.GetComponent<Rigidbody>().velocity = _camera.transform.forward * 50;

        /* Destroy the spell after 2 seconds */
        Destroy(_spell_L, 5.0f);
    }

    private void CastSpell_R()
    {
        /* Unchild the fireball to get a free movement and enable trailing*/
        _spell_R.transform.parent = null;
        var _trails = _spell_R.GetComponent<ParticleSystem>().trails;
        _trails.enabled = true;

        /* Add velocity to the spell*/
        _spell_R.GetComponent<Rigidbody>().velocity = _camera.transform.forward * 50;

        /* Destroy the spell after 2 seconds */
        Destroy(_spell_R, 5.0f);
    }

    private void CheckCastStop_L()
    {
        _isCasting_L = false;
        if (_castTime_L >= castingTime)
        {
            CastSpell_L();
        }
        else
        {
            Destroy(_spell_L);
        }
        _castTime_L = 0.0f;
    }

    private void CheckCastStop_R()
    {
        _isCasting_R = false;
        if (_castTime_R >= castingTime)
        {
            CastSpell_R();
        }
        _castTime_R = 0.0f;
    }

    private void CheckCastStart_L()
    {
        /* Missing the CD contraints */
        _isCasting_L = true;

        /* Create the Spell from the spell prefab*/
        _spell_L = (GameObject)Instantiate(spellPrefab, spellSpawn_L.position, spellSpawn_L.rotation, _camera.transform);

        /* Disable trailing while on hands */
        var _trails = _spell_L.GetComponent<ParticleSystem>().trails;
        _trails.enabled = false;
    }

    private void CheckCastStart_R()
    {
        /* Missing the CD contraints */
        _isCasting_R = true;

        /* Create the Spell from the spell prefab*/
        _spell_R = (GameObject)Instantiate(spellPrefab, spellSpawn_R.position, spellSpawn_R.rotation, _camera.transform);

        /* Disable trailing while on hands */
        var _trails = _spell_R.GetComponent<ParticleSystem>().trails;
        _trails.enabled = false;
    }

    private void UpdateCastingTimes()
    {
        if (_isCasting_L)
        {
            _castTime_L = _castTime_L + Time.deltaTime;
        }
        if (_isCasting_R)
        {
            _castTime_R = _castTime_R + Time.deltaTime;
        }
    }

}
