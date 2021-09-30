using UnityEngine;

public class ShootManager : MonoBehaviour
{
    private static readonly int IsShoot = Animator.StringToHash("shoot");
    private const string CanShoot = "CanShoot";

    [SerializeField] private Camera _camera;

    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _prefabBullet;

    private bool _canShoot;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (_canShoot == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = _camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        Instantiate(_prefabBullet, new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Quaternion.identity);
                    }

                    _animator.SetTrigger(IsShoot);

                }
            }
        }
     
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(CanShoot))
        {
            _canShoot = true;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(CanShoot))
        {
            _canShoot = false;
        }
    }

}
