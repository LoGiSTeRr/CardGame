using System.Collections.Generic;
using Terminal.Gui;

namespace CardGame
{
    public class Game
    {
        public Game()
        {
            Application.Top.Add(mainScreen);
        }
        private Window mainScreen = new Window()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };
        public List<IPlayable> Players { get; set; } = new List<IPlayable>();
        private int currentTurn = 0; // player[0] - you, player[1] - opponent
        public List<Cards.Card> CardsInStock { get; set; } = new List<Cards.Card>();

        public void NextTurn()
        {
            currentTurn = currentTurn == 1 ? 0 : 1;
        }
        public void DisplayGame(bool botPlay)
        {
            bool cardIsTaken = false;
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
                yourHand.Add(new Label(Players[currentTurn].CardsInHand[i].GetVisual()) { X = 1 + 21*i, Y = 1});
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
                    gameField.Add(new Label(Cards.Card.GetBack()) { X = 1 + 21 * i, Y = 1 });
                }
                else
                {
                    gameField.Add(new Label(Players[player].CardsOnTable[i].GetVisual()) { X = 1 + 21 * i, Y = 1 });
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (Players[currentTurn].CardsOnTable[i] == null)
                {
                    gameField.Add(new Label(Cards.Card.GetBack()) { X = 1 + 21 * i, Y = 19 });
                }
                else
                {
                    gameField.Add(new Label(Players[currentTurn].CardsOnTable[i].GetVisual()) { X = 1 + 21 * i, Y = 19 });
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
                DisplayGame(botPlay);
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

            var takeCardLabel = new Label("Take a new card") { X = 30, Y = 12 };
            optionsField.Add(takeCardLabel);
            var takeReservoir = new Button("Energy Reservoir") { X = 40, Y = 14 };
            var backCard2 = new Label(Cards.Card.GetBack()) { X = 40, Y = 16 };
            optionsField.Add(backCard2);
            Button takeRandomCard = new Button();
            Label backCard1 = new Label();
            if (CardsInStock.Count != 0)
            {
                 takeRandomCard = new Button("Random card from the deck") { X = 6, Y = 14 };
                 backCard1 = new Label(Cards.Card.GetBack()) { X = 10, Y = 16 };
                 optionsField.Add(backCard1);
                 optionsField.Add(takeRandomCard);
            }
            takeRandomCard.Clicked += () =>
            {
                Players[currentTurn].CardsInHand.Add(CardsInStock[0]);
                yourHand.Add(new Label(CardsInStock[0].GetVisual()) { X = 1 + 21 * (Players[currentTurn].CardsInHand.Count - 1), Y = 1 });

                optionsField.Remove(takeReservoir);
                optionsField.Remove(takeCardLabel);
                if (CardsInStock.Count != 0)
                {
                    optionsField.Remove(takeRandomCard);
                    optionsField.Remove(backCard1);
                }
                optionsField.Remove(backCard2);
                cardIsTaken = true;
                CardsInStock.RemoveAt(0);
            };
            takeReservoir.Clicked += () =>
            {
                Players[currentTurn].CardsInHand.Add(Cards.CreatedCards.ReservoirCard);
                yourHand.Add(new Label(Cards.CreatedCards.ReservoirCard.GetVisual()) { X = 1 + 21 * (Players[currentTurn].CardsInHand.Count - 1), Y = 1 });

                optionsField.Remove(takeReservoir);
                optionsField.Remove(takeCardLabel);
                if (CardsInStock.Count != 0)
                {
                    optionsField.Remove(takeRandomCard);
                    optionsField.Remove(backCard1);
                }
                optionsField.Remove(backCard2);
                cardIsTaken = true;
            };
            optionsField.Add(nextTurnBut);
            optionsField.Add(quitAppication);
            optionsField.Add(takeReservoir);
        }
    }
}