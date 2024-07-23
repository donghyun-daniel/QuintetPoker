using System.Collections.Generic;
using System.Linq;

public class HandEvaluator
{
    public static PokerHand EvaluateHand(List<Card> hand, List<Card> communityCards)
    {
        var allCards = hand.Concat(communityCards).ToList();
        
        if (HasStraightFlush(allCards)) return PokerHand.StraightFlush;
        if (HasFourOfAKind(allCards)) return PokerHand.FourOfAKind;
        if (HasFullHouse(allCards)) return PokerHand.FullHouse;
        if (HasFlush(allCards)) return PokerHand.Flush;
        if (HasStraight(allCards)) return PokerHand.Straight;
        if (HasThreeOfAKind(allCards)) return PokerHand.ThreeOfAKind;
        if (HasTwoPair(allCards)) return PokerHand.TwoPair;
        if (HasOnePair(allCards)) return PokerHand.OnePair;
        
        return PokerHand.HighCard;
    }

    private static bool HasStraightFlush(List<Card> cards)
    {
        return cards.GroupBy(c => c.Color)
                    .Any(g => HasStraight(g.ToList()) && g.Count() >= 5);
    }

    private static bool HasFourOfAKind(List<Card> cards)
    {
        return cards.GroupBy(c => c.Value).Any(g => g.Count() >= 4);
    }

    private static bool HasFullHouse(List<Card> cards)
    {
        var groups = cards.GroupBy(c => c.Value).Select(g => g.Count()).OrderByDescending(c => c).ToList();
        return groups.Count >= 2 && groups[0] >= 3 && groups[1] >= 2;
    }

    private static bool HasFlush(List<Card> cards)
    {
        return cards.GroupBy(c => c.Color).Any(g => g.Count() >= 5);
    }

    private static bool HasStraight(List<Card> cards)
    {
        var orderedValues = cards.Select(c => c.Value).Distinct().OrderBy(v => v).ToList();
        for (int i = 0; i <= orderedValues.Count - 5; i++)
        {
            if (orderedValues[i + 4] - orderedValues[i] == 4)
            {
                return true;
            }
        }
        return false;
    }

    private static bool HasThreeOfAKind(List<Card> cards)
    {
        return cards.GroupBy(c => c.Value).Any(g => g.Count() >= 3);
    }

    private static bool HasTwoPair(List<Card> cards)
    {
        return cards.GroupBy(c => c.Value).Count(g => g.Count() >= 2) >= 2;
    }

    private static bool HasOnePair(List<Card> cards)
    {
        return cards.GroupBy(c => c.Value).Any(g => g.Count() >= 2);
    }
}

public enum PokerHand
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush
}
