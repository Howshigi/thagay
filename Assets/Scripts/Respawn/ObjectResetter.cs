using UnityEngine;
using System.Collections.Generic;

public class ObjectResetter : MonoBehaviour
{
    // Singleton Pattern สำหรับให้สคริปต์อื่นเรียกใช้ได้ง่าย
    public static ObjectResetter Instance { get; private set; }

    // โครงสร้างข้อมูลสำหรับเก็บค่าเริ่มต้นของวัตถุ
    private struct InitialState
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 linearVelocity;
        public Vector3 angularVelocity;
    }

    // List สำหรับเก็บข้อมูลวัตถุทั้งหมด
    private List<InitialState> objectStates = new List<InitialState>();
    private List<Rigidbody> resettableRigidbodies = new List<Rigidbody>();

    private void Awake()
    {
        // ตั้งค่า Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        // เริ่มเกมมา ให้จดจำค่าเริ่มต้นของวัตถุทั้งหมดที่มี Tag "ResettableObject"
        FindAllResettableObjects();
    }

    private void FindAllResettableObjects()
    {
        // หาวัตถุทั้งหมดที่มี Tag "ResettableObject" และมี Rigidbody
        Rigidbody[] rbs = FindObjectsByType<Rigidbody>(FindObjectsSortMode.None);
        foreach (Rigidbody rb in rbs)
        {
            if (rb.CompareTag("ResettableObject"))
            {
                // บันทึก Rigidbody
                resettableRigidbodies.Add(rb);

                // บันทึกค่าเริ่มต้น
                InitialState state = new InitialState
                {
                    position = rb.transform.position,
                    rotation = rb.transform.rotation,
                    linearVelocity = rb.linearVelocity,
                    angularVelocity = rb.angularVelocity
                };
                objectStates.Add(state);
            }
        }
        Debug.Log("Found " + resettableRigidbodies.Count + " resettable objects.");
    }

    // ฟังก์ชันสำหรับรีเซ็ตวัตถุทั้งหมดกลับค่าเริ่มต้น
    public void ResetAllObjects()
    {
        for (int i = 0; i < resettableRigidbodies.Count; i++)
        {
            Rigidbody rb = resettableRigidbodies[i];
            InitialState state = objectStates[i];

            // รีเซ็ตตำแหน่งและมุม
            rb.transform.position = state.position;
            rb.transform.rotation = state.rotation;

            // รีเซ็ตความเร็ว
            rb.linearVelocity = state.linearVelocity;
            rb.angularVelocity = state.angularVelocity;
        }
        Debug.Log("All objects reset to initial state!");
    }
}