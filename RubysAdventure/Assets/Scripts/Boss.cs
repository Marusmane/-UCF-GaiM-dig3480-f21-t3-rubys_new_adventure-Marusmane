using System;
using UnityEngine;
using TMPro;


public class Boss : MonoBehaviour
{

	public float speed;
	public TextMeshProUGUI countText;
	public float timeToChange;
	public bool horizontal;

	public GameObject smokeParticleEffect;
	public ParticleSystem fixedParticleEffect;

	public AudioClip hitSound;
	public AudioClip fixedSound;

	Rigidbody2D rigidbody2d;

	//private int count;

	float remainingTimeToChange;
	Vector2 direction = Vector2.right;
	bool repaired = false;


	Animator animator;


	AudioSource audioSource;

	void Start()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		remainingTimeToChange = timeToChange;

		direction = horizontal ? Vector2.right : Vector2.down;

		animator = GetComponent<Animator>();

		audioSource = GetComponent<AudioSource>();

		//count = 0;
		//SetCountText();
	}

	//void SetCountText()
	//{
		//countText.text = "Fixed Robots: " + count.ToString();
	//}
	void Update()
	{
		if (repaired)
			return;

		remainingTimeToChange -= Time.deltaTime;

		if (remainingTimeToChange <= 0)
		{
			remainingTimeToChange += timeToChange;
			direction *= -1;
		}

		animator.SetFloat("ForwardX", direction.x);
		animator.SetFloat("ForwardY", direction.y);
	}

	void FixedUpdate()
	{
		rigidbody2d.MovePosition(rigidbody2d.position + direction * speed * Time.deltaTime);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (repaired)
			return;

		RubyController controller = other.collider.GetComponent<RubyController>();

		if (controller != null)
			controller.ChangeHealth(-2);
	}

	public void Fix()
	{
		animator.SetTrigger("Fixed");
		repaired = true;

		smokeParticleEffect.SetActive(false);


		Instantiate(fixedParticleEffect, transform.position + Vector3.up * 0.5f, Quaternion.identity);

		//count = count + 1;

		//SetCountText();

		rigidbody2d.simulated = false;

		audioSource.Stop();
		audioSource.PlayOneShot(hitSound);
		audioSource.PlayOneShot(fixedSound);
	}
}
