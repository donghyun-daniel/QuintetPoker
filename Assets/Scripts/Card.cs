using System;
using UnityEngine;

public enum Color
{
    RED,
    BLUE,
    GREEN,
    YELLOW,
    BLACK
}

[System.Serializable]
public class Card
{
    public Color Color { get; private set; }
    public int Value { get; private set; }

    public Card(Color color, int value)
    {
        if (value < 1 || value > 9)
            throw new ArgumentException("Card value must be between 1 and 9.");

        Color = color;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value} of {Color}";
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
        cards = new Card[45]; // 5 colors * 9 cards each
        int index = 0;
        foreach (Color color in Enum.GetValues(typeof(Color)))
        {
            for (int value = 1; value <= 9; value++)
            {
                cards[index] = new Card(color, value);
                index++;
            }
        }
    }

    public void Shuffle()
    {
        System.Random rng = new System.Random();
        int n = cards.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
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
