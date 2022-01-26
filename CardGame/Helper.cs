namespace CardGame
{
    public static class Helper
    {
        public static bool IsNameValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new System.ArgumentException("Invalid name");
            }
            return true;
        }
    }
}
