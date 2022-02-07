namespace CardGame.Cards
{
    public static class CreatedAbilities
    {
        //Attack Abilities.

        //Attacks player one more time.
        public static void PlayerMurder(Game game, IPlayable playerWhoAttacks, Card cardWhichAttacks)
        {
            playerWhoAttacks.AmountOfPoints += cardWhichAttacks.Atk;
        }
        //Attacks card one more time.
        public static void CardMurder(Game game, IPlayable playerWhoAttacks, Card cardWhichAttacks)
        {
            game.Players[game.OpponentOfPlayer].CardsOnTable[cardWhichAttacks.PosOnTheTable].GetDamage(game, playerWhoAttacks, cardWhichAttacks);
        }

        //Defense Abilities
        
        //Gets less damage in 2 times
        public static void Tank(Game game, IPlayable playerWhoAttacks, Card cardWhichRecieveDamage)
        {
            cardWhichRecieveDamage.Hp += playerWhoAttacks.CardsOnTable[cardWhichRecieveDamage.PosOnTheTable].Atk / 2;
        }
        //Strikes back for 1 damage
        public static void Thorn(Game game, IPlayable playerWhoAttacks, Card cardWhichRecieveDamage)
        {
            playerWhoAttacks.CardsOnTable[cardWhichRecieveDamage.PosOnTheTable].Hp -= 1;
        }

        //Passive Abilities

        //Increase energy by one
        public static void EnergyBuff(Game game, IPlayable player, Card card)
        {
            player.Energy += 1;
        }
    }
}
