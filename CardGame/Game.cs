using System.Collections.Generic;
using Terminal.Gui;

namespace CardGame
{
    public class Game
    {
        private Window mainScreen = new Window()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };
        public List<IPlayable> Players { get; set; } = new List<IPlayable>();
        private int currentTurn = 0; // player[0] - you, player[1] - opponent
        private List<Cards.Card> cardsInStock { get; set; } = new List<Cards.Card>();

        public void NextTurn()
        {
            currentTurn = currentTurn == 1 ? 0 : 1;
        }
        public void DisplayGame(bool botPlay)
        {
            Application.Top.Add(mainScreen);
            //      ⚖
            //   x0    x0
            var yourHand = new Window()
            {
                X = Pos.Center(),
                Y = Pos.Center() + 15,
                Width = 21 * Players[currentTurn].LimitOfCards + 6, // 6 is offset
                Height = 19
            };
            mainScreen.Add(yourHand);
            var gameField = new Window()
            {
                X = Pos.Center() + 0, // 0 for make first coordinate at senter. Otherwise it will be situated directly on center
                Y = 0,
                Width = 21 * 4 + 4, // 4 is amount of cards on a field
                Height = 19 * 2 + 2
            };
            mainScreen.Add(gameField);
            for (int i = 0; i < Players[currentTurn].CardsInHand.Count; i++)
            {
                yourHand.Add(new Label(Players[currentTurn].CardsInHand[i].GetVisual(false)) { X = 1 + 21*i, Y = 1});
            }
            for (int i = 0; i < 4; i++)
            {
                int player = 0;
                if (currentTurn == 0)
                {
                    player = 1;
                }
                if (Players[player].CardsOnTable[i] == null)
                {
                    gameField.Add(new Label(new Cards.Card().GetVisual(true)) { X = 1 + 21 * i, Y = 1 });
                }
                else
                {
                    gameField.Add(new Label(Players[player].CardsOnTable[i].GetVisual(false)) { X = 1 + 21 * i, Y = 1 });
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (Players[currentTurn].CardsOnTable[i] == null)
                {
                    gameField.Add(new Label(new Cards.Card().GetVisual(true)) { X = 1 + 21 * i, Y = 19 });
                }
                else
                {
                    gameField.Add(new Label(Players[currentTurn].CardsOnTable[i].GetVisual(false)) { X = 1 + 21 * i, Y = 19 });
                }
            }
            var optionsField = new Window()
            {
                X = 0,
                Y = 0,
                Width = 100,
                Height = 40
            };
            mainScreen.Add(optionsField);
            optionsField.Add(new Label($"{Players[currentTurn].Name}'s turn.") { X = 40, Y = 2});
            optionsField.Add(new Label($"Make the difference of damage equal to 5") { X = 51, Y = 4});
            if (currentTurn == 0)
            {
                optionsField.Add(new Label($"your damage: {Players[0].AmountOfPoints}x") { X = 51, Y = 6 });
                optionsField.Add(new Label($"opponent damage: {Players[1].AmountOfPoints}x") { X = 51, Y = 7 });
            }
            else
            {
                optionsField.Add(new Label($"your damage: {Players[1].AmountOfPoints}x") { X = 51, Y = 6 });
                optionsField.Add(new Label($"opponent damage: {Players[0].AmountOfPoints}x") { X = 51, Y = 7 });
            }
            var nextTurnBut = new Button("Next turn")
            {
                X = 10,
                Y = 6
            };
            nextTurnBut.Clicked += () =>
            {
                NextTurn();
                DisplayGame(false);
            };
            var quitAppication = new Button("Quit application")
            {
                X = 10,
                Y = 8
            };
            quitAppication.Clicked += () =>
            {
                Application.RequestStop();
            };
            optionsField.Add(nextTurnBut);
            optionsField.Add(quitAppication);
        }
    }
}