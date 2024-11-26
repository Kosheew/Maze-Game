using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private Transform eyesPosition; // Точка початку перевірки
    [SerializeField] private float visionDistance = 10f; // Дальність зору
    [SerializeField] private float fieldOfViewAngle = 120f; // Кут огляду
    [SerializeField] private LayerMask visionMask; // Маска для визначення перешкод
    [SerializeField] private float loseTargetDelay = 2f; // Час до втрати цілі
    [SerializeField] private float checkInterval = 0.2f; // Інтервал перевірки

    private Transform _currentTarget;
    private float _loseTargetTimer;
    private bool _isTargetVisible;

    public Transform CurrentTarget => _isTargetVisible ? _currentTarget : null;

    private void Start()
    {
        StartCoroutine(CheckVisionRoutine());
    }

    public void SetTarget(Transform target)
    {
        _currentTarget = target;
        _isTargetVisible = true;
        _loseTargetTimer = loseTargetDelay; // Скидаємо таймер
    }

    private IEnumerator CheckVisionRoutine()
    {
        while (true)
        {
            if (_currentTarget == null)
            {
                _isTargetVisible = false;
            }
            else if (CanSeeTarget(_currentTarget))
            {
                _isTargetVisible = true;
                _loseTargetTimer = loseTargetDelay; // Скидаємо таймер
            }
            else
            {
                _loseTargetTimer -= checkInterval;
                if (_loseTargetTimer <= 0)
                {
                    _isTargetVisible = false; // Втрата цілі
                    _currentTarget = null;
                }
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }
    
    
    
    public bool CanSeeTarget(Transform target)
    {
        Vector3 directionToTarget = (target.position - eyesPosition.position).normalized;
        float angleToTarget = Vector3.Angle(eyesPosition.forward, directionToTarget);

        if (angleToTarget > fieldOfViewAngle / 2f)
            return false;

        if (Physics.Raycast(eyesPosition.position, directionToTarget, out RaycastHit hit, visionDistance, visionMask))
        {
            return hit.transform == target; // Перевірка, чи це наша ціль
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        if (eyesPosition == null) return;

        // Візуалізація кута зору
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(eyesPosition.position, Quaternion.Euler(0, -fieldOfViewAngle / 2, 0) * eyesPosition.forward * visionDistance);
        Gizmos.DrawRay(eyesPosition.position, Quaternion.Euler(0, fieldOfViewAngle / 2, 0) * eyesPosition.forward * visionDistance);

        // Візуалізація дальності зору
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(eyesPosition.position, visionDistance);
    }
}