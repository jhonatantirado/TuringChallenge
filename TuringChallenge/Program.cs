namespace CalPoints
{
    class Solution
    {

        public static int CalPoints(string[] ops)
        {
            var scores = new Stack<int>();
            var total = 0;

            if (ops == null || ops.Length == 0)
            {
                return total;
            }

            foreach (var item in ops)
            {
                switch (item)
                {
                    case "+":
                        var lastScore = scores.Pop();
                        var newScore = lastScore + scores.Peek();
                        scores.Push(lastScore);
                        scores.Push(newScore);
                        break;
                    case "D":
                        scores.Push(scores.Peek() * 2);
                        break;
                    case "C":
                        scores.Pop();
                        break;
                    default:
                        if (int.TryParse(item, out int score))
                        {
                            scores.Push(score);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid input: " + item);
                        }
                        break;
                }
            }

            while (scores.Count > 0)
            {
                total += scores.Pop();
            }

            return total;
        }

        public static char FindAddedCharacter(string s, string t)
        {
            int[] count = new int[26];

            foreach (char c in s)
            {
                count[c - 'a']++;
            }

            foreach (char c in t)
            {
                count[c - 'a']--;
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] == -1)
                {
                    return (char)(i + 'a');
                }
            }

            return '\0'; // Strings are identical.
        }


    }

    class CalPoints
    {
        public static void Main(string[] args)
        {
            //var space = new char[] { ' ' };
            //string[] ops = Console.ReadLine().Split(space);

            string[] ops = { "5", "2", "C", "D", "+"};
            int output = Solution.CalPoints(ops);
            Console.WriteLine(output.ToString());//expected 30

            string[] ops2 = { "5", "-2", "4", "C", "D", "9","+","+" };
            int output2 = Solution.CalPoints(ops2);
            Console.WriteLine(output2.ToString());//expected 27

            string s = "abcd";
            string t = "dbcae";
            var result = Solution.FindAddedCharacter(s, t);

            string s2 = "aaaa";
            string t2 = "aaaaa";
            var result2 = Solution.FindAddedCharacter(s2, t2);

            string s3 = "abdbd";
            string t3 = "bbddad";
            var result3 = Solution.FindAddedCharacter(s3, t3);

            string s4 = "";
            string t4 = "x";
            var result4 = Solution.FindAddedCharacter(s4, t4);

            Console.WriteLine(result.ToString());//expected e
            Console.WriteLine(result2.ToString());//expected a
            Console.WriteLine(result3.ToString());//expected d
            Console.WriteLine(result4.ToString());//expected x
        }
    }

}