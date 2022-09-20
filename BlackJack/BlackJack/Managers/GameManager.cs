using static BlackJack.BusinessLogic.House;
using static BlackJack.BusinessLogic.Player;
using BlackJack.BusinessLogic;

namespace BlackJack.Managers;

public static class GameManager
{
    private static int _playerGame;
    private static int _houseGame;
    
    private static Dealer _dealer = new Dealer();
    public static void Intro()
    {
        _playerGame = 0;
        _houseGame = 0;
        
        Console.Clear();
        Console.WriteLine("Seja bem-vindo ao novíssimo jogo de Black Jack!");
        Console.WriteLine("Aperte Enter para começar!");
        if (Console.ReadLine() == "")
            DealCards();
    }

    private static void DealCards()
    {
        PlayerCards.Clear();
        HouseCards.Clear();
        
        _playerGame = _dealer.DealCards(PlayerCards);
        _houseGame = _dealer.DealCards(HouseCards);
        GameState();
    }
    
    private static void GameState()
    {
        Round();
        if (Console.ReadLine() == "y")
            BuyCard();
        else if(Console.ReadLine() == "")
            NextRound();
    }

    private static void NextRound()
    {
        AI();
        Round();
        if(Console.ReadLine() == "y")
            BuyCard();
        else FinalScreen();
    }
    
    private static void FinalScreen()
    {
        Console.Clear();
        if(_playerGame > _houseGame && _playerGame <= 21)
            Console.WriteLine("Você ganhou!");
        else if(_playerGame < _houseGame && _houseGame <= 21)
            Console.WriteLine("Você perdeu!");
        else if(_playerGame == _houseGame)
            Console.WriteLine("Vocês empataram!");
        Console.WriteLine("Gostaria de Jogar de novo? Escreva y");
        if(Console.ReadLine() == "y")
            Intro();
    }

    private static void AI()
    {
        if (_houseGame < _playerGame && _playerGame <= 21)
            _houseGame = _dealer.PlusCard(_houseGame);
    }
    
    private static void BuyCard()
    {
        _playerGame = _dealer.PlusCard(_playerGame);
        Round();
        if(Console.ReadLine() == "y")
            BuyCard();
        else NextRound();
    }
    
    private static void Round()
    {
        Console.Clear();
        Console.WriteLine("Aqui está a some das suas cartas: " + _playerGame + "\n");
        Console.WriteLine("Aqui está a soma da mesa: " + _houseGame + "\n");
        Console.WriteLine("Você gostaria de comprar mais uma carta? Escreva y, caso o contrário aperte Enter");
    }
}