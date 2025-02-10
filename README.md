Here's the documentation in the format you've requested:

---

# 🎮 HyperCube

![Prototype-Game](https://user-images.githubusercontent.com/62818241/201542421-96d1c820-da7d-44c8-a804-8d7ef72e37a7.png)

## 📌 Introduction
**HyperCube** is a simple 2D game where players control a character to move across platforms, avoid obstacles, and survive as long as possible. The game features smooth background scrolling, platform spawning, player movement, sound effects, and a scoring system. The game ends if the player falls off the platform or collides with spikes.

🔗 Video Trailer

https://youtube.com/shorts/oep3hfKN5co?si=aR5vu0bQQQnX5iCu

## 🔥 Features
- 🎯 **Level Progression**: Player progresses by surviving longer and avoiding obstacles.
- 🚪 **Scene Management**: Smooth transitions between scenes such as "GameOver" and "MainMenu."
- 🕹️ **Player Controls**: Player moves using a joystick.
- ⚔️ **Obstacle Collision**: Colliding with spikes or falling off the platform triggers a game restart.
- 🎵 **Sound Effects**: Audio feedback for interactions such as landing, death, and ice breaking.
- 📊 **Score Tracking**: Displays score based on platform count.
- ⏳ **Game Over Handling**: Restarts the game when falling off the platform or colliding with spikes.

---

## 🏗️ How It Works

The game consists of various platforms that spawn at random intervals, with the player avoiding obstacles and surviving as long as possible. The player's progress is tracked through a score system.

### 📌 **Background Scrolling**

The background scrolls vertically to simulate the progression of the game.

```csharp
using System.Collections;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scroll_Speed = 0.3f;
    private MeshRenderer mesh_Renderer;

    void Awake() {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    void Update() {
        Scroll();    
    }

    void Scroll() {
        Vector2 Offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        Offset.y += Time.deltaTime * scroll_Speed;
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex",Offset);
    }
}
```

---

### 📌 **Player Movement**

The player's movement is controlled using a joystick, and the game checks if the player falls below a certain height to trigger a restart.

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float movespeed = 2f;
    public Joystick joystick;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Move();        
    }

    void Move()
    {
        if(joystick.Horizontal > 0f)
        {
             myBody.velocity = new Vector2(movespeed, myBody.velocity.y);
        }

        if(joystick.Horizontal < 0f)
        {
            myBody.velocity = new Vector2(-movespeed, myBody.velocity.y);
        }
    }

    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x ,myBody.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("TopSpike"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
```

---

### 📌 **Collision Detection**

If the player collides with obstacles (like spikes), the game triggers a restart.

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter2D(Collision2D collisioninfo)
    {
        if (collisioninfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            SceneManager.LoadScene("GameOver");
        }
    }
}
```

---

### 📌 **Platform Spawning**

Platforms are spawned at random intervals, and there are different types of platforms (moving, breakable, and spike platforms) that affect the gameplay.

```csharp
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platform_Spawn_Timer = 1f;
    private float current_Platform_Spawn_Timer;

    void Start() {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms() {
        current_Platform_Spawn_Timer += Time.deltaTime;

        if(current_Platform_Spawn_Timer >= platform_Spawn_Timer) {
            // Spawning logic for different platform types
            // E.g., moving platforms, spike platforms, breakable platforms
            current_Platform_Spawn_Timer = 0f;
        }
    }
}
```

---

### 📌 **Score System**

The score is based on how many platforms the player survives. It updates every frame.

```csharp
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    private int platform = 0;
    [SerializeField] private Text Score;
    
    void Start()
    {
        StartCoroutine (CountScore());
    }

    IEnumerator CountScore()
    { 
        yield return new WaitForSeconds(0.5f);
        platform++;
        Score.text = "Score: " + platform;
        StartCoroutine (CountScore()); 
    }
}
```

---

### 📌 **Game Manager**

The game manager handles the game flow, including restarting the game after a death and transitioning to the "Game Over" scene.

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("RestartAfterTime", 1f);
    }

    void RestartAfterTime()
    {
        SceneManager.LoadScene("GameOver");
    }
}
```

---

## 🎯 Conclusion

**HyperCube** provides a simple yet engaging 2D platforming experience with smooth mechanics such as platform spawning, player movement, obstacle collision, and scoring. It serves as a solid foundation for more complex games that can be built upon with additional features and levels. 🚀🔥
