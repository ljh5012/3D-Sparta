using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform pointA; // ���� ����
    public Transform pointB; // �� ����
    public float speed; // �̵� �ӵ�
    private Vector3 targetPosition; // ��ǥ ��ġ

    private void Start()
    {
        targetPosition = pointB.position; // ó������ B �������� �̵�
    }

    private void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // ���� ��ġ���� ��ǥ ��ġ�� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // ��ǥ ������ �����ϸ� �ݴ������� ��ȯ
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f) 
        {
            
            targetPosition = (targetPosition == pointA.position) ? pointB.position : pointA.position;
            

           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾ ���� ���� �ö󰡸� �θ� ���� ���� (�÷��̾ �Բ� �̵�)
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // �÷��̾ ���ǿ��� �������� �θ� ���� ����
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
