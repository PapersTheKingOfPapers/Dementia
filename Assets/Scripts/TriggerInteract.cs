using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerInteract : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private AnimControl _control;
    [SerializeField] private GameObject _interacterParent;
    [SerializeField] private GameObject _intParentChild;
    [SerializeField] private bool _secondHitbox;

    private bool animTriggered;
    private Animator _anim;
    private Animator _userAnim;
    private GameObject _interacter;
    private RigidbodyConstraints _previousConstraits;
    private InputController input;
    private bool interact;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        _interacter = _intParentChild;
        _anim = _control._anim;
    }

    // Update is called once per frame
    void Update()
    {
        if(_interacter.GetComponent<Move>() != null)
        {
            input = _interacter.GetComponent<Move>().GetInputController();
            interact |= input.RetrieveInteractInput();
        }
    }
    private void LateUpdate()
    {
        if (_interacter.GetComponent<Move>() != null && _anim.GetBool("animActive") == true)
        {
            _interacter.transform.parent = _interacterParent.transform;
            _interacter.transform.position = Vector3.Lerp(_interacter.transform.position, _interacterParent.transform.position, Time.deltaTime * 5f);  
        }
    }

    void CheckInput(Collider other)
    {
        if(_anim.GetBool("isInteractable") == true)
        {
            if (other.GetComponent<Move>() != null)
            {
                _interacter = other.gameObject;

                if (interact == true)
                {
                    interact = false;
                    RunAnim();
                }
            }
        }
    }
    public void ResetAnim()
    {
        _anim.SetBool("animActive", false);
        _interacter.GetComponent<Rigidbody>().constraints = _previousConstraits;
        _interacter.transform.parent = null;
        _interacter.transform.position = _interacterParent.transform.position;
        _interacter = _intParentChild;
    }
    void RunAnim()
    {
        _anim.SetBool("isInteractable", false);
        _anim.SetBool("_secondHitbox", _secondHitbox);
        _anim.SetBool("animActive", true);
        _previousConstraits = _interacter.GetComponent<Rigidbody>().constraints;
        _interacter.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_anim.GetBool("animActive") == false)
            {
                text.SetActive(true);
                _anim.SetBool("isInteractable", true);
                CheckInput(other);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            if (_anim.GetBool("animActive") == false)
            {
                _anim.SetBool("isInteractable", false);
            }
        }
    }
}
