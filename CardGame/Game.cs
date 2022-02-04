using System.Collections.Generic;
using Terminal.Gui;
using System.Linq;

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
        private int opponentOfPlayer { get { return selectedPlayer == 0 ? 1: 0; } }
        public List<Cards.Card> CardsInStock { get; set; } = new List<Cards.Card>();
        public void StartGame(Player pl1, Player pl2)
        {
            Players.Add(pl1);
            Players.Add(pl2);
            for (int i = 0; i < 4; i++)
            {
                CardsInStock.Add(Cards.CreatedCards.SkeletonCard);
                CardsInStock.Add(Cards.CreatedCards.KnightCard);
                CardsInStock.Add(Cards.CreatedCards.WarriorCard);
                CardsInStock.Add(Cards.CreatedCards.ShieldManCard);
            }
            CardsInStock.Shuffle();

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
            pl1.CardsInHand.Add(Cards.CreatedCards.ReservoirCard);
            pl2.CardsInHand.Add(Cards.CreatedCards.ReservoirCard);
            displayGame(false);
        }
        private void pullACard(Window optionsField, Button takeReservoir, Label takeCardLabel, Button takeRandomCard, Label backCard1, Label backCard2, Label cardsInStockLabel)
        {
            optionsField.Remove(takeReservoir);
            optionsField.Remove(takeCardLabel);
            if (CardsInStock.Count != 0)
            {
                optionsField.Remove(takeRandomCard);
                optionsField.Remove(backCard1);
                optionsField.Remove(cardsInStockLabel);
            }
            optionsField.Remove(backCard2);
        }
        private void chooseCardToPlace()
        {

        }
        private void choosePlaceToPlaceCard()
        {

        }

        private void attack()
        {
            for (int i = 0; i < 4; i++)
            {
                if (Players[selectedPlayer].CardsOnTable[i] != null)
                {
                    if (Players[opponentOfPlayer].CardsOnTable[i] == null)
                    {
                        Players[opponentOfPlayer].DamageRecieved += Players[selectedPlayer].CardsOnTable[i].Atk;
                    }
                    else
                    {
                        Players[opponentOfPlayer].CardsOnTable[i].Hp -= Players[selectedPlayer].CardsOnTable[i].Atk;
                    }
                }
            }
        }
        private void nextTurn()
        {
            attack();
            selectedPlayer = selectedPlayer == 1 ? 0 : 1;
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
                int player = 0;
                if (selectedPlayer == 0)
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
                if (Players[selectedPlayer].CardsOnTable[i] == null)
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

            var takeCardLabel = new Label("Take a new card") { X = 30, Y = 12 };
            optionsField.Add(takeCardLabel);
            var takeReservoir = new Button("Energy Reservoir") { X = 40, Y = 14 };
            var backCard2 = new Label(Cards.Card.GetBack()) { X = 40, Y = 16 };
            optionsField.Add(backCard2);
            Button takeRandomCard = new Button();
            Label backCard1 = new Label();
            Label cardsInStockLabel = new Label();
            if (CardsInStock.Count != 0)
            {
                takeRandomCard = new Button("Random card from the deck") { X = 6, Y = 14 };
                backCard1 = new Label(Cards.Card.GetBack()) { X = 10, Y = 16 };
                optionsField.Add(backCard1);
                optionsField.Add(takeRandomCard);
                cardsInStockLabel = new Label($"Cards left: {CardsInStock.Count}") { X = 10, Y = 36 };

            }
            takeRandomCard.Clicked += () =>
            {
                if (Players[selectedPlayer].LimitOfCards == Players[selectedPlayer].CardsInHand.Count)
                {
                    return;
                }
                Players[selectedPlayer].CardsInHand.Add(CardsInStock[0]);
                yourHand.Add(new Label(CardsInStock[0].GetVisual()) { X = 1 + 21 * (Players[selectedPlayer].CardsInHand.Count - 1), Y = 1 });
                pullACard(optionsField, takeReservoir, takeCardLabel, takeRandomCard, backCard1, backCard2, cardsInStockLabel);
                CardsInStock.RemoveAt(0);
            };
            takeReservoir.Clicked += () =>
            {
                if (Players[selectedPlayer].LimitOfCards == Players[selectedPlayer].CardsInHand.Count)
                {
                    return;
                }
                Players[selectedPlayer].CardsInHand.Add(Cards.CreatedCards.ReservoirCard);
                yourHand.Add(new Label(Cards.CreatedCards.ReservoirCard.GetVisual()) { X = 1 + 21 * (Players[selectedPlayer].CardsInHand.Count - 1), Y = 1 });
                pullACard(optionsField, takeReservoir, takeCardLabel, takeRandomCard, backCard1, backCard2, cardsInStockLabel);
            };
            optionsField.Add(nextTurnBut);
            optionsField.Add(quitAppication);
            optionsField.Add(takeReservoir);

            Button placeCard = new Button("Place a card")
            {
                X = 75,
                Y = 14
            };
            placeCard.Clicked += () =>
            {
                optionsField.Remove(placeCard);
                Label placeCardText = new Label("Choose the card to place.") { X = 65, Y = 14 };
                optionsField.Add(placeCardText);
                List<Button> buttons1 = new List<Button>();
                for (int i = 0; i < Players[selectedPlayer].CardsInHand.Count; i++)
                {
                    buttons1.Add(new Button((i + 1).ToString()) { X = 71, Y = 16 + i*2 });
                    buttons1[i].Clicked += () =>
                    {
                        for (int j = 0; j < Players[selectedPlayer].CardsInHand.Count; j++)
                        {
                            optionsField.Remove(buttons1[j]);
                        }
                        optionsField.Remove(placeCardText);
                        Label placeCardPosText = new Label("Now choose the position.") { X = 65, Y = 14 };
                        optionsField.Add(placeCardPosText);
                        List<Button> buttons2 = new List<Button>();
                        for (int j = 0; j < 4; j++)
                        {
                            buttons2.Add(new Button((j + 1).ToString()) { X = 71, Y = 16 + j * 2 });
                            if (Players[selectedPlayer].CardsOnTable[j] == null)
                            {
                                optionsField.Add(buttons2[j]);
                                buttons2[j].Clicked += () =>
                                {
                                    int temp1 = i;
                                    int temp2 = j;
                                    Players[selectedPlayer].CardsOnTable[j] = Players[selectedPlayer].CardsInHand[i];
                                    Players[selectedPlayer].CardsInHand.RemoveAt(i);
                                    optionsField.Remove(placeCardPosText);
                                    for (int k = 0; k < 4; k++)
                                    {
                                        optionsField.Remove(buttons2[k]);
                                    }
                                };
                            }
                        }
                    };
                    optionsField.Add(buttons1[i]);
                }
            };
            optionsField.Add(placeCard);

        }
    }
}