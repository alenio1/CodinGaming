using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
 class Deck
{
    char[] Tab = { '2', '3', '4', '5','6' ,'7','8','9','1','J','Q','K','A' };
    public List<string> Hand = new List<string>();
    public static bool game = true;
    public static bool gameTurn = true;
    public static int turn = 0;
    public void LoadCard(string card)
    {
        Hand.Add(card);
    }
    
    public static void normalTurn(Deck myDeck, Deck enemyDeck)
    {
        if(Array.IndexOf(myDeck.Tab, myDeck.Hand[0].First()) > Array.IndexOf(enemyDeck.Tab, enemyDeck.Hand[0].First()))
        {
            string x = myDeck.Hand[0];
            myDeck.Hand.RemoveAt(0);
            myDeck.Hand.Add(x);
            myDeck.Hand.Add(enemyDeck.Hand[0]);
            enemyDeck.Hand.RemoveAt(0);
        }
        else
        {
            string x = enemyDeck.Hand[0];
            enemyDeck.Hand.RemoveAt(0);
            enemyDeck.Hand.Add(myDeck.Hand[0]);
            enemyDeck.Hand.Add(x);
            myDeck.Hand.RemoveAt(0);
            

        }
    }
   
    public static void War(Deck myDeck, Deck enemyDeck, int turn)
    {
        int x = 0;
        bool warStatus = true;
        while(warStatus == true)
        {
            x += 4;
            if (myDeck.Hand.Count < x+1 || enemyDeck.Hand.Count < x+1)
            {
                Console.WriteLine("PAT");
                Solution.GameOver();
                warStatus = false;
                break;
            }
            else if (myDeck.Hand[x].First() != enemyDeck.Hand[x].First())
            {
                if (Array.IndexOf(myDeck.Tab, myDeck.Hand[x].First()) > Array.IndexOf(enemyDeck.Tab, enemyDeck.Hand[x].First()))
                {
                    for (int i = 0; i < x+1; i++)
                    {
                        string t = myDeck.Hand[0];
                        myDeck.Hand.RemoveAt(0);
                        myDeck.Hand.Add(t);
                    }
                    for (int i = 0; i < x+1; i++)
                    {
                        string y = enemyDeck.Hand[0];
                        enemyDeck.Hand.RemoveAt(0);
                        myDeck.Hand.Add(y);
                    }
                    
                    warStatus = false;
                    break;
                }
                else
                {
                    for (int i = 0; i < x + 1; i++)
                    {
                        string t = myDeck.Hand[0];
                        myDeck.Hand.RemoveAt(0);
                        enemyDeck.Hand.Add(t);
                    }
                    for (int i = 0; i < x + 1; i++)
                    {
                        string y = enemyDeck.Hand[0];
                        enemyDeck.Hand.RemoveAt(0);
                        enemyDeck.Hand.Add(y);
                    }
                    
                    warStatus = false;
                    break;
                }
            }
            
        }

    }
}
class Solution
{
    public static void Turn(Deck myDeck, Deck enemyDeck)
    {
        Deck.gameTurn = true;
        while (Deck.gameTurn == true)
        {
            //Checking if both player have cards in their hand
            if (myDeck.Hand.Count != 0 && enemyDeck.Hand.Count == 0)
            {
                Console.WriteLine("1 " + Deck.turn);
                GameOver();
                break;
            }
            else if (myDeck.Hand.Count == 0 && enemyDeck.Hand.Count != 0)
            {
                Console.WriteLine("2 " + Deck.turn);
                GameOver();
                break;
            }
            //Checking is it normal turn or war
            if (myDeck.Hand[0].First() != enemyDeck.Hand[0].First())
            {
                Deck.turn++;
                Deck.normalTurn(myDeck, enemyDeck);
                EndTurn();
            }
            else
            {
                Deck.turn++;
                Deck.War(myDeck, enemyDeck, Deck.turn);
                EndTurn();


            }
            if (myDeck.Hand.Count != 0 && enemyDeck.Hand.Count == 0)
            {
                Console.WriteLine("1 " + Deck.turn);
                GameOver();
                break;
            }
            else if (myDeck.Hand.Count == 0 && enemyDeck.Hand.Count != 0)
            {
                Console.WriteLine("2 " + Deck.turn);
                GameOver();
                break;
            }

        }
    }
    
    public static void GameOver()
    {
        Deck.game = false;
    }
    public static void EndTurn()
    {
        Deck.gameTurn = false;
    }
    static void Main(string[] args)
    {
        
        Deck myDeck = new Deck();
        Deck enemyDeck = new Deck();
        
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        for (int i = 0; i < n; i++)
        {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            myDeck.LoadCard(cardp1);
        }
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            enemyDeck.LoadCard(cardp2);
        }
        
        while (Deck.game == true)
        {
            Turn(myDeck, enemyDeck);
            
        }
    }
}
//(Array.IndexOf(myDeck.Tab, myDeck.Hand[x].First()) < Array.IndexOf(enemyDeck.Tab, enemyDeck.Hand[x].First()))
//(myDeck.Hand[0].First() == enemyDeck.Hand[0].First())