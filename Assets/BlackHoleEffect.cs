using UnityEngine;
 
public class BlackHoleEffects : MonoBehaviour
{
    public float gravity = -10f;
    public float destroyRadius = 1.0f;
    public float visualEffectRadius = 5.0f;
    public float transformRadius = 2.0f; // Distance at which objects start to transform into a ring
    public Material lightBendingMaterial;
    private Material originalMaterial;
    public float distortionIntensity = 5.0f;
 
    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            Vector3 direction = other.transform.position - transform.position;
            float distance = direction.magnitude;
 
            // Gravitational pull
            other.attachedRigidbody.AddForce(direction.normalized * gravity * other.attachedRigidbody.mass);
 
            // Visual effects logic
            ApplyVisualEffects(other, distance);
 
            // Transformation to ring logic
            TransformToRing(other, distance);
 
            // Destroy logic
            DestroyObject(other, distance);
        }
    }
 
    private void ApplyVisualEffects(Collider other, float distance)
    {
        Renderer rend = other.GetComponent<Renderer>();
        if (rend && distance < visualEffectRadius && distance >= destroyRadius)
        {
            if (originalMaterial == null)
            {
                originalMaterial = rend.material;
            }
            rend.material = lightBendingMaterial;
            rend.material.SetVector("_BlackHolePosition", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0));
            rend.material.SetFloat("_DistortionRadius", visualEffectRadius);
            rend.material.SetFloat("_DistortionIntensity", distortionIntensity);
        }
    }
 
    private void TransformToRing(Collider other, float distance)
    {
        if (distance < transformRadius && distance >= destroyRadius)
        {
            // Scale object to form a ring
            float scaleRatio = (transformRadius - distance) / transformRadius; // Smaller as it gets closer
            Vector3 newScale = new Vector3(other.transform.localScale.x, other.transform.localScale.y * scaleRatio, other.transform.localScale.z * scaleRatio);
            other.transform.localScale = newScale;
        }
    }
 
    private void DestroyObject(Collider other, float distance)
    {
        if (distance < destroyRadius)
        {
            Renderer rend = other.GetComponent<Renderer>();
            if (rend && originalMaterial != null)
            {
                rend.material = originalMaterial; // Restore original material before destruction
            }
            Destroy(other.gameObject); // Destroys the object
        }
    }
 
    void OnTriggerExit(Collider other)
    {
        // Reset material when exiting the trigger area
        Renderer rend = other.GetComponent<Renderer>();
        if (rend && originalMaterial != null)
        {
            rend.material = originalMaterial;
            originalMaterial = null; // Clear stored original material
        }
    }
}
 