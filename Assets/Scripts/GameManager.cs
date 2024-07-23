using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int NumberOfPlayers = 2;
    private Deck deck;
    private List<Player> players;
    private List<Card> communityCards;

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        deck = new Deck();
        players = new List<Player>();
        communityCards = new List<Card>();

        for (int i = 0; i < NumberOfPlayers; i++)
        {
            players.Add(new Player($"Player {i + 1}"));
        }

        DealInitialCards();
    }

    void DealInitialCards()
    {
        // Deal two cards to each player
        for (int i = 0; i < 2; i++)
        {
            foreach (Player player in players)
            {
                player.ReceiveCard(deck.DrawCard());
            }
        }

        // Deal five community cards
        for (int i = 0; i < 5; i++)
        {
            communityCards.Add(deck.DrawCard());
        }

        // For debugging: print all cards
        Debug.Log("Community Cards: " + string.Join(", ", communityCards));
        foreach (Player player in players)
        {
            Debug.Log($"{player.Name}'s hand: {string.Join(", ", player.Hand)}");
        }

        EvaluateHands();
    }

    void EvaluateHands()
    {
        foreach (var player in players)
        {
            PokerHand hand = HandEvaluator.EvaluateHand(player.Hand, communityCards);
            Debug.Log($"{player.Name} has: {hand}");
        }
    }
}

public class Player
{
    public string Name { get; private set; }
    public List<Card> Hand { get; private set; }

    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
    }

    public void ReceiveCard(Card card)
    {
        Hand.Add(card);
    }
}
