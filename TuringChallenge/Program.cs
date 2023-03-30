namespace CalPoints
{
    class Solution
    {
        public static int CalPoints(string[] ops)
        {
            var scores = new List<string>();
            var total = 0;

            foreach (var item in ops)
            {
                if (item.Equals("+"))
                {

                    var newScore = int.Parse(scores[scores.Count - 1]) + int.Parse(scores[scores.Count - 2]);
                    scores.Add(newScore.ToString());

                }
                else if (item.Equals("D"))
                {

                    var newScore = int.Parse(scores[scores.Count - 1]) * 2;
                    scores.Add(newScore.ToString());

                }
                else if (item.Equals("C"))
                {

                    scores.RemoveAt(scores.Count - 1);

                }
                else if (int.TryParse(item, out _))
                {

                    scores.Add(item);
                }
                else
                {
                    break;
                }

            }

            foreach (var score in scores)
            {
                total += int.Parse(score);
            }

            return total;
        }
    }

    class CalPoints
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();
            var space = new char[] { ' ' };

            string[] ops = Console.ReadLine().Split(space);
            int output = Solution.CalPoints(ops);
            Console.Write(output.ToString());
        }
    }

}