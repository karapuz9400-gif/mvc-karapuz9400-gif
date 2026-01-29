using System.Text;

namespace bit285_assignment1_naps.Models
{
    public class PasswordSuggestion
    {
        private readonly Random _rnd = new Random();

        public string GeneratePassword(User user)
        {
            if (user == null) return string.Empty;

            // Normalize inputs
            var last = (user.LastName ?? string.Empty).Replace(" ", "").Trim();
            var color = (user.FavoriteColor ?? string.Empty).Replace(" ", "").Trim().ToLower();
            var year = (user.BirthYear ?? string.Empty).Replace(" ", "").Trim();

            // Use pieces but guard lengths
            var lastPart = last.Length == 0 ? "user" : (last.Length > 6 ? last.Substring(0, 6) : last);
            var colorPart = color.Length == 0 ? "clr" : (color.Length > 4 ? color.Substring(0, 4) : color);
            var yearPart = year.Length >= 2 ? year.Substring(year.Length - 2) : (year.Length == 1 ? "0" + year : "YY");

            var sb = new StringBuilder();

            // Start with year + color + last
            sb.Append(yearPart);
            sb.Append("-");
            sb.Append(colorPart);
            sb.Append("-");
            sb.Append(lastPart);

            // Ensure at least one numeric and some randomness
            var num = _rnd.Next(10, 999);
            sb.Append("-");
            sb.Append(num.ToString());

            // If length is too short, append random chars
            while (sb.Length < 9)
            {
                var c = (char)('a' + _rnd.Next(0, 26));
                sb.Append(c);
            }

            // Final password
            var pwd = sb.ToString();

            // Ensure contains at least one digit (it does via num), and replace spaces
            return pwd.Replace(" ", "-");
        }
    }
}
