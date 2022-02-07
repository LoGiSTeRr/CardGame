using Terminal.Gui;
namespace CardGame
{
    public static class Menu
    {
        public static void DisplayMainMenu()
        {
            var mainMenu = new Window()
            {
                X = Pos.Center(),
                Y = Pos.Center(),
                Width = 50,
                Height = 20
            };
            mainMenu.Add(new Label(" █▀▀ ▄▀█ █▀█ █▀▄   █▀▀ ▄▀█ █▀▄▀█ █▀▀\n" +
                                   " █▄▄ █▀█ █▀▄ █▄▀   █▄█ █▀█ █░▀░█ ██▄")
            {
                X = Pos.Center(),
                Y = 1,
            });
            var startGameBut = new Button("Start Game")
            {
                X = Pos.Center(),
                Y = 5,
            };
            startGameBut.Clicked += () =>
            {
                Application.Top.Remove(mainMenu);
                mainMenu.Clear();
                Player pl1 = new Player() { Name = "player1" };
                Player pl2 = new Player() { Name = "player2" };
                Game game = new Game();
                game.StartGame(pl1, pl2);
            };

            var seeTutorialBut = new Button("Tutorial")
            {
                X = Pos.Center(),
                Y = 7,
            };
            seeTutorialBut.Clicked += () =>
            {
                Application.Top.Remove(mainMenu);
                mainMenu.Clear();
                DisplayTutorial();
            };

            var quitGameBut = new Button("Quit")
            {
                X = Pos.Center(),
                Y = 9,
            };
            quitGameBut.Clicked += () =>
            {
                Application.RequestStop();
            };
            mainMenu.Add(startGameBut);
            mainMenu.Add(seeTutorialBut);
            mainMenu.Add(quitGameBut);
            mainMenu.Add(new Label("This game was made by LoGiSTeRr\n" +
                                   "        08.02.2022 ")
            {
                X = Pos.Center(),
                Y = 15,
            });
            Application.Top.Add(mainMenu);
        }
        public static void DisplayTutorial()
        {
            var mainMenu = new Window()
            {
                X = Pos.Center(),
                Y = Pos.Center(),
                Width = 100,
                Height = 50
            };
            var goBack = new Button("Go Back")
            {
                X = Pos.Center(),
                Y = 45,
            };
            goBack.Clicked += () =>
            {
                Application.Top.Remove(mainMenu);
                mainMenu.Clear();
                DisplayMainMenu();
            };
            mainMenu.Add(goBack);
            mainMenu.Add(new Label(Cards.CreatedCards.GetWarriorCard().GetVisual()) { X = 75, Y = 1 });
            mainMenu.Add(new Label(Cards.CreatedCards.GetReservoirCard().GetVisual()) { X = 1, Y = 20 });
            mainMenu.Add(new Label(Cards.CreatedCards.GetBigThornCard().GetVisual()) { X = 25, Y = 20 });
            mainMenu.Add(new Label(Cards.CreatedCards.GetCrazyDudeCard().GetVisual()) { X = 50, Y = 20 });
            mainMenu.Add(new Label(Cards.CreatedCards.GetSkeletonCard().GetVisual()) { X = 75, Y = 20 });

            mainMenu.Add(new Label("How to play:\n" +
                                   "This is 1v1 card game, where the main goal is to hit the opponent as much as possible." +
                                   "Each card has ATK(attack), HP(health points), Energy(cost of placement) and Abilities." +
                                   "Each card, after end of the turn starts attack opponent's field. If there is nobody, card attack" +
                                   "the enemy. But when card is placed, for one turn is sleep, and can't attack. On the next one awakes, and " +
                                   "avaible to attack.\n\nNow About abilities: " +
                                   "Player murder: Attacks player 2 times.\n" +
                                   "Card murder: Attacks card 2 times.\n" +
                                   "Tank: Gets less damage in 2 times.\n" +
                                   "Thorn: Strikes back 1 damage.\n" +
                                   "Energy Buff: At the start of the turn, increase energy by one.\n" +
                                   "How to win:\nMake the difference of damage equal to 5!") { X = 1, Y = 1, Width = 65, Height = 19 });
            Application.Top.Add(mainMenu);
        }
    }
}
