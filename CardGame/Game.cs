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
        private int selectedPlayer = 0; // player[0] - you, player[1] - opponent
        private float energy = 0;
        private int opponentOfPlayer { get { return selectedPlayer == 0 ? 1: 0; } }
        public List<Cards.Card> CardsInStock { get; set; } = new List<Cards.Card>();
        public void StartGame(Player pl1, Player pl2)
        {
            energy = 1;
            pl1.Energy = energy;
            pl2.Energy = energy;
            Players.Add(pl1);
            Players.Add(pl2);
            for (int i = 0; i < 4; i++)
            {
                CardsInStock.Add(Cards.CreatedCards.GetSkeletonCard());
                CardsInStock.Add(Cards.CreatedCards.GetKnightCard());
                CardsInStock.Add(Cards.CreatedCards.GetWarriorCard());
                CardsInStock.Add(Cards.CreatedCards.GetShieldManCard());
            }
            //CardsInStock.Shuffle();

            for (int i = 0; i < 3; i++)
            {
                pl1.CardsInHand.Add(CardsInStock[0]);
                CardsInStock.RemoveAt(0);
            }
            for (int i = 0; i < 3; i++)
            {
                pl2.CardsInHand.Add(CardsInStock[0]);
                CardsInStock.RemoveAt(0);
            }
            pl1.CardsInHand.Add(Cards.CreatedCards.GetReservoirCard());
            pl2.CardsInHand.Add(Cards.CreatedCards.GetReservoirCard());
            displayGame(false);
        }
        private void pullACard(Window optionsField, Button takeReservoir, Label takeCardLabel, Button takeRandomCard, Label backCard1, Label backCard2, Label cardsInStockLabel, Label cardsLeft)
        {
            optionsField.Remove(takeReservoir);
            optionsField.Remove(takeCardLabel);
            if (CardsInStock.Count != 0)
            {
                optionsField.Remove(takeRandomCard);
                optionsField.Remove(backCard1);
                optionsField.Remove(cardsInStockLabel);
                optionsField.Remove(cardsLeft);
            }
            optionsField.Remove(backCard2);
            Players[selectedPlayer].CardWasTaken = true;
        }
        private void attack()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!Players[selectedPlayer].CardsOnTable[i].Equals(Cards.CreatedCards.GetNullCard()))
                {
                    if (Players[opponentOfPlayer].CardsOnTable[i].Equals(Cards.CreatedCards.GetNullCard()))
                    {
                        Players[selectedPlayer].AmountOfPoints += Players[selectedPlayer].CardsOnTable[i].Atk;
                    }
                    else
                    {
                        Players[opponentOfPlayer].CardsOnTable[i].Hp -= Players[selectedPlayer].CardsOnTable[i].Atk;
                        if (Players[opponentOfPlayer].CardsOnTable[i].Hp == 0)
                        {
                            Players[opponentOfPlayer].CardsOnTable[i] = Cards.CreatedCards.GetNullCard();
                        }
                    }
                }
            }
        }
        private void nextTurn()
        {
            attack();
            if (Players[selectedPlayer].AmountOfPoints - Players[opponentOfPlayer].AmountOfPoints >= 5)
            {
                MessageBox.Query(" ", $"{Players[selectedPlayer].Name} won!!\n" +
                                      $"your damage: {Players[selectedPlayer].AmountOfPoints}x\n" +
                                      $"opponent damage: {Players[opponentOfPlayer].AmountOfPoints}x", "Ok");
                Application.RequestStop();
                return;
            }
            energy += 0.5f;
            selectedPlayer = selectedPlayer == 1 ? 0 : 1;
            Players[selectedPlayer].CardWasTaken = false;
            Players[selectedPlayer].Energy = energy;
            mainScreen.Clear();
            Window temp = new Window(" ") { X = 0, Y = 0, Width = Dim.Fill(), Height = Dim.Fill() };
            mainScreen.Add(temp);
            MessageBox.Query(" ", "Change the player", "Ok");
            mainScreen.Remove(temp);
        }
        public void displayGame(bool botPlay)
        {
            var yourHand = new Window()
            {
                X = Pos.Center(),
                Y = Pos.Center() + 15,
                Width = 21 * Players[selectedPlayer].LimitOfCards + 6, // 6 is offset
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
            for (int i = 0; i < Players[selectedPlayer].CardsInHand.Count; i++)
            {
                yourHand.Add(new Label(Players[selectedPlayer].CardsInHand[i].GetVisual()) { X = 1 + 21 * i, Y = 1 });
            }
            for (int i = 0; i < 4; i++)
            {
                if (Players[opponentOfPlayer].CardsOnTable[i].Equals(Cards.CreatedCards.GetNullCard()))
                {
                    gameField.Add(new Label(Cards.Card.GetBack()) { X = 1 + 21 * i, Y = 1 });
                }
                else
                {
                    gameField.Add(new Label(Players[opponentOfPlayer].CardsOnTable[i].GetVisual()) { X = 1 + 21 * i, Y = 1 });
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (Players[selectedPlayer].CardsOnTable[i].Equals(Cards.CreatedCards.GetNullCard()))
                {
                    gameField.Add(new Label(Cards.Card.GetBack()) { X = 1 + 21 * i, Y = 19 });
                }
                else
                {
                    gameField.Add(new Label(Players[selectedPlayer].CardsOnTable[i].GetVisual()) { X = 1 + 21 * i, Y = 19 });
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
            optionsField.Add(new Label($"{Players[selectedPlayer].Name}'s turn.") { X = 40, Y = 2 });
            optionsField.Add(new Label($"Make the difference of damage equal to 5") { X = 51, Y = 4 });
            optionsField.Add(new Label($"your damage: {Players[selectedPlayer].AmountOfPoints}x") { X = 51, Y = 6 });
            optionsField.Add(new Label($"opponent damage: {Players[opponentOfPlayer].AmountOfPoints}x") { X = 51, Y = 7 });
            var nextTurnBut = new Button("Next turn")
            {
                X = 10,
                Y = 6
            };
            nextTurnBut.Clicked += () =>
            {
                nextTurn();
                displayGame(botPlay);
            };
            var quitAppication = new Button("Quit application")
            {
                X = 10,
                Y = 2
            };
            quitAppication.Clicked += () =>
            {
                Application.RequestStop();
            };
            if (!Players[selectedPlayer].CardWasTaken)
            {
                var takeCardLabel = new Label("Take a new card") { X = 30, Y = 12 };
                optionsField.Add(takeCardLabel);
                var takeReservoir = new Button("Energy Reservoir") { X = 40, Y = 14 };
                var backCard2 = new Label(Cards.Card.GetBack()) { X = 40, Y = 16 };
                optionsField.Add(backCard2);
                Button takeRandomCard = new Button();
                Label backCard1 = new Label();
                Label cardsInStockLabel = new Label();
                Label cardsLeft = new Label();
                if (CardsInStock.Count != 0)
                {
                    takeRandomCard = new Button("Random card from the deck") { X = 6, Y = 14 };
                    backCard1 = new Label(Cards.Card.GetBack()) { X = 10, Y = 16 };
                    cardsLeft = new Label($"Cards left: {CardsInStock.Count}") { X = 10, Y = 32 };
                    
                    optionsField.Add(backCard1);
                    optionsField.Add(takeRandomCard);
                    optionsField.Add(cardsLeft);

                }
                optionsField.Add(takeReservoir);

                takeRandomCard.Clicked += () =>
                {
                    if (Players[selectedPlayer].LimitOfCards == Players[selectedPlayer].CardsInHand.Count)
                    {
                        return;
                    }
                    Players[selectedPlayer].CardsInHand.Add(CardsInStock[0]);
                    yourHand.Add(new Label(CardsInStock[0].GetVisual()) { X = 1 + 21 * (Players[selectedPlayer].CardsInHand.Count - 1), Y = 1 });
                    pullACard(optionsField, takeReservoir, takeCardLabel, takeRandomCard, backCard1, backCard2, cardsInStockLabel, cardsLeft);
                    CardsInStock.RemoveAt(0);
                };
                takeReservoir.Clicked += () =>
                {
                    if (Players[selectedPlayer].LimitOfCards == Players[selectedPlayer].CardsInHand.Count)
                    {
                        return;
                    }
                    Players[selectedPlayer].CardsInHand.Add(Cards.CreatedCards.GetReservoirCard());
                    yourHand.Add(new Label(Cards.CreatedCards.GetReservoirCard().GetVisual()) { X = 1 + 21 * (Players[selectedPlayer].CardsInHand.Count - 1), Y = 1 });
                    pullACard(optionsField, takeReservoir, takeCardLabel, takeRandomCard, backCard1, backCard2, cardsInStockLabel, cardsLeft);
                };
            }
            optionsField.Add(nextTurnBut);
            optionsField.Add(quitAppication);
            Button placeCard = new Button("Place a card")
            {
                X = 75,
                Y = 14
            };
            Label yourEnergy = new Label($"Your energy: {(int)Players[selectedPlayer].Energy}")
            {
                X = 75,
                Y = 12
            };
            placeCard.Clicked += () =>
            {
                optionsField.Remove(placeCard);
                List<NStack.ustring> list = new List<NStack.ustring>();
                list.Add("Cancel");
                for (int i = 0; i < Players[selectedPlayer].CardsInHand.Count; i++)
                {
                    list.Add((i + 1).ToString());
                }
                int choose1 = MessageBox.Query("Choose.", "Choose card number", list.ToArray());
                if (choose1 == 0)
                {
                    optionsField.Add(placeCard);
                    return;
                }
                choose1--;
                if (Players[selectedPlayer].CardsInHand[choose1].Energy > Players[selectedPlayer].Energy)
                {
                    MessageBox.ErrorQuery("Error", "Not enough energy to place this card!", "Ok");
                    optionsField.Add(placeCard);
                    return;
                }
                list.Clear();
                for (int i = 0; i < 4; i++)
                {
                    if (Players[selectedPlayer].CardsOnTable[i].Equals(Cards.CreatedCards.GetNullCard()))
                    {
                        list.Add((i + 1).ToString());
                    }
                    else
                    {
                        list.Add("-");
                    }
                }
                int choose2 = MessageBox.Query("Choose.", "Now choose card placement", list.ToArray());
                if (Players[selectedPlayer].CardsOnTable[choose2].Equals(Cards.CreatedCards.GetNullCard()))
                {
                    Players[selectedPlayer].CardsOnTable[choose2] = Players[selectedPlayer].CardsInHand[choose1];
                    Players[selectedPlayer].Energy -= Players[selectedPlayer].CardsInHand[choose1].Energy;
                    Players[selectedPlayer].CardsInHand.RemoveAt(choose1);
                    displayGame(botPlay);
                }
                else
                {
                    MessageBox.ErrorQuery("error", "You can't place a card above another.", "Ok");
                }
                optionsField.Add(placeCard);
            };
            optionsField.Add(placeCard);
            optionsField.Add(yourEnergy);

        }
    }
}