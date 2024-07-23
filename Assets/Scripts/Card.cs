using System;
using UnityEngine;
using System.Security.Cryptography;

public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades,
    Stars // The fifth suit
}

[System.Serializable]
public class Card
{
    public Suit Suit { get; private set; }
    public int Value { get; private set; }

    public Card(Suit suit, int value)
    {
        if (value < 2 || value > 10)
            throw new ArgumentException("Card value must be between 2 and 10.");

        Suit = suit;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}

[System.Serializable]
public class Deck
{
    private Card[] cards;
    private int currentIndex;

    public Deck()
    {
        InitializeDeck();
        Shuffle();
    }

    private void InitializeDeck()
    {
        cards = new Card[45]; // 5 suits * 9 cards each
        int index = 0;
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            for (int value = 2; value <= 10; value++)
            {
                cards[index] = new Card(suit, value);
                index++;
            }
        }
    }

    public void Shuffle()
    {
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            int n = cards.Length;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do rng.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
        }
        currentIndex = 0;
    }

    public Card DrawCard()
    {
        if (currentIndex >= cards.Length)
            throw new InvalidOperationException("No more cards in the deck.");

        return cards[currentIndex++];
    }
}
