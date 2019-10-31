namespace P1RhombusOfStars
{
    using System.Text;

    public class RhombusDrawer
    {
        private const char BackgroundCaracter = ' ';
        private const char DrawingCharacter = '*';

        public string Draw(int starsCount)
        {
            var stringBuilder = new StringBuilder();
            this.DrawTopPart(starsCount, stringBuilder);
            this.DrawBottomPart(starsCount, stringBuilder);

            return stringBuilder.ToString().TrimEnd();
        }

        private void DrawTopPart(int starsCount, StringBuilder stringBuilder)
        {
            for (int i = 0; i < starsCount; i++)
            {
                DrawSingleLine(starsCount, i, stringBuilder);
            }
        }

        private void DrawBottomPart(int starsCount, StringBuilder stringBuilder)
        {
            for (int i = starsCount - 2; i >= 0; i--)
            {
                DrawSingleLine(starsCount, i , stringBuilder);
            }
        }

        private void DrawSingleLine(int starsCount, int i, StringBuilder stringBuilder)
        {
            stringBuilder.Append(new string(BackgroundCaracter, starsCount - i - 1));

            for (int j = 0; j < i + 1; j++)
            {
                stringBuilder.Append($"{DrawingCharacter}{BackgroundCaracter}");
            }
            stringBuilder.AppendLine();
        }
    }
}
