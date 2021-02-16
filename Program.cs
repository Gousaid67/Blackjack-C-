using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        List<Player> Playerlist = new List<Player>();
        Dealer dealer = new Dealer();
        Deck deck;
        
        public Game()
        {
            deck = new Deck();
        }
        class Player
        {
            List<Card> CardList = new List<Card>();
            Card LastDrawn;
            int lowvalue, highvalue, bestvalue;

            public void Draw(Deck deck)
            {
                Card selcard = deck.Draw();
                LastDrawn = selcard;
                CardList.Add(selcard);
            }
            

        }
        class Dealer : Player
        {

        }
        public class Card
        {
            CardType Value;
            SuitType suittype;
            public int BlackJackValue; // Find out what this is.

            public Card(CardType invalue, SuitType cardtype, int Blackjackval)
            {
                suittype = cardtype;
                Value = invalue;
                BlackJackValue = Math.Clamp(Blackjackval, 1, 10);
            }
        }
        public class Deck
        {
            Random rand = new Random();
           List<Card> CardList = new List<Card>(52); //used for shuffling and resetting the Deck.
           public Queue<Card> CardDeck = new Queue<Card>();

            public Deck()
            {
                for(int x = 0; x < 4; x++)
                {
                    SuitType currtype = (SuitType)x;
                    for (int y = 1; y <= 13; y++)
                    {
                        CardList.Add(new Card((CardType) y,currtype, y));
                    }
                }
                
                
            }
            public Card Draw()
            {
                return CardDeck.Dequeue();
            }
            public Queue<Card> Shuffle(Queue<Card> deck)
            {
                int decklength = deck.Count;
                int[] randused = new int[decklength];
                
                Card[] ShuffleList = deck.ToArray();
                deck.Clear();
                for(int x = 0; x < ShuffleList.Length; x++)
                {
                
                    int nextrand = rand.Next(0, ShuffleList.Length);
                    if(Array.Find(randused, x => x == nextrand) == nextrand)
                    {
                        x--;
                        continue;
                    }
                    deck.Enqueue(ShuffleList[nextrand]);
                }
                return deck; 
                

            }
            public Queue<Card> ResetAndShuffle(List<Card> list)
            {
                Queue<Card> NewDeck = new Queue<Card>();
                int decklength = list.Count;
                int[] randused = new int[decklength];
                for (int x = 0; x < decklength; x++)
                {

                    int nextrand = rand.Next(0, decklength);
                    if (Array.Find(randused, x => x == nextrand) == nextrand)
                    {
                        x--;
                        continue;
                    }
                    NewDeck.Enqueue(list[nextrand]);
                
                }
                return NewDeck; 
            }
        }
        public enum SuitType
        {
            Spades,
            Diamond,
            Club,
            Heart,
        }
        public enum GameState
        {
            Win,
            Lost,
            Playing,
            Tie,
            BlackJack,
        }
        public enum CardType : int
        {
            Ace = 1,
            Jack = 11,
            Queen = 12,
            King = 13,
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(); 
            Console.WriteLine("Ah Shit Here We Go Again");
            
        }
    }
}
