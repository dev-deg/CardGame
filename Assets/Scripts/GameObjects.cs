using System;
using System.Collections.Generic;


public static class GameData
{
    public static Player player;
    public static Player opponent;
    public static List<Card> playerCards = new List<Card>();
    public static List<Card> opponentCards = new List<Card>();
}

[Serializable]
public class Card
{
    public string _cardName;
    public int _sp;
    public int _hp;
    public Card(string name, int sp, int hp)
    {
        this._cardName = name;
        this._sp = sp;
        this._hp = hp;
    }
}

[Serializable]
public class Player
{
    public string _PlayerName;
    public bool _isOpponent;
    public int _sp;
    public int _hp;
    Player(string name, bool isOpponent, int sp, int hp)
    {
        this._PlayerName = name;
        this._isOpponent = isOpponent;
        this._sp = sp;
        this._hp = hp;
    }
    
}
