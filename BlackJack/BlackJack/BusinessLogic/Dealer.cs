namespace BlackJack.BusinessLogic;

public class Dealer
{
    public int DealCards(List<int> playerCards)
    {
        var rand = new Random();
        int playerGame = 0;
        
        while (playerCards.Count != 2)
            playerCards.Add(rand.Next(1, 13));
        
        foreach (var card in playerCards)
            playerGame += card;
        return playerGame;
    }

    public int PlusCard(int game)
    {
        Random random = new Random();
        game += random.Next(1, 13);
        return game;
    }
}