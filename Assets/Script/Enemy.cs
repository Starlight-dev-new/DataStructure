using UnityEngine;

public class Enemy : Identity
{
    [SerializeField]  Transform Feet;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (CheckForTurn())
        {
            // หันหลังกลับ
            transform.Rotate(0f, 180f, 0f);
        }
        transform.Translate( speed * Time.deltaTime, 0f, 0f);
    }
    private bool CheckForTurn()
    {
        // ตำแหน่งเริ่มต้นของ Raycast (อยู่ที่จุดเช็คขอบ)
        Vector2 startPosition = Feet.position;
        // 1. Raycast สำหรับเช็คขอบ (ยิงลงจากจุด GroundCheckPoint)
        // ถ้า Raycast นี้ "ไม่โดน" (collider == null) แปลว่าไม่มีพื้นอยู่ใต้จุดนั้น = กำลังจะตก
        RaycastHit2D groundHit = Physics2D.Raycast(startPosition, Vector2.down, 0.3f,  LayerMask.GetMask("Ground"));
        Debug.DrawRay(groundHit.point, Vector2.down, Color.red);
        // ถ้าไม่มีพื้น
        if (groundHit.collider == null)
        {
            return true; // ต้องหันหลังกลับ!
        }

        return false;
    }
}
