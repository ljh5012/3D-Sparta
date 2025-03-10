using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform pointA; // 시작 지점
    public Transform pointB; // 끝 지점
    public float speed; // 이동 속도
    private Vector3 targetPosition; // 목표 위치

    private void Start()
    {
        targetPosition = pointB.position; // 처음에는 B 지점으로 이동
    }

    private void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // 현재 위치에서 목표 위치로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 목표 지점에 도달하면 반대편으로 전환
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f) 
        {
            
            targetPosition = (targetPosition == pointA.position) ? pointB.position : pointA.position;
            

           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 발판 위에 올라가면 부모 관계 설정 (플레이어도 함께 이동)
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 플레이어가 발판에서 내려가면 부모 관계 해제
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
