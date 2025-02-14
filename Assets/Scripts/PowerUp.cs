using UnityEngine;
using TMPro;
public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower,
    }

    public TextMeshProUGUI Coin_text;


    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player)) {
            if (Coin_text == null)
            {
                Coin_text = GameObject.Find("TextCoin").GetComponent<TextMeshProUGUI>();
                if (Coin_text == null) {
                    Debug.LogError("bruh");

                }
            }
            //Coin_text.text = "33333";
            Collect(player);
        }
    }

    private void Collect(Player player)
    {
        int Coin_count = 0;
        switch (type)
        {
            case Type.Coin:
                
                GameManager.Instance.AddCoin();
                Coin_count += 1;
                Coin_text.text = $"{Coin_count}";
                break;

            case Type.ExtraLife:
                GameManager.Instance.AddLife();
                break;

            case Type.MagicMushroom:
                player.Grow();
                Coin_count += 1;
                Coin_text.text = $"{Coin_count}";
                break;

            case Type.Starpower:
                player.Starpower();
                break;
        }

        Destroy(gameObject);
    }

}
