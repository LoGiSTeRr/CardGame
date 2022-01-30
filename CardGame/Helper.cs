namespace CardGame
{
    public static class Helper
    {
        public static bool IsNameValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 17)
            {
                throw new System.ArgumentException("Invalid name");
            }
            return true;
        }
    }
}
