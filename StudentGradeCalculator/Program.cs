namespace lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many students would you like to add: ");
            int numStd = Convert.ToInt32(Console.ReadLine());

            int[] stdId = new int[numStd];
            string[] stdName = new string[numStd];
            double[] finalMarks = new double[numStd];

            string[] javaCourseContent = { "Quizzes", "Lab Exercises", "Lab Test 1", "Lab Test 2", "Assignment 1", "Assignment 2", "Midterm", "Final" };
            float[] weight = { 0.08f, 0.07f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f, 0.25f };

            double[,] stdMarks = new double[numStd, javaCourseContent.Length];

            // collecting students info
            for (int i = 0; i < numStd; i++)
            {
                Console.WriteLine($"Enter Student # {i + 1} ID : ");
                stdId[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Enter Student # {i + 1} Name : ");
                stdName[i] = Console.ReadLine();

                // collecting detailed marks for each java content
                for (int j = 0; j < javaCourseContent.Length; j++)
                {
                    Console.WriteLine($"Enter {javaCourseContent[j]} Mark for {stdName[i]} : ");
                    stdMarks[i, j] = Convert.ToInt32(Console.ReadLine());
                }

            }
            // Calculating Final Mark: sum('content' * 'content'Weight)
            //e.g. RojanFinalMark = stdMark[i, j] * weight[j]

            // picks each student's information
            for (int i = 0; i < stdMarks.GetLength(0); i++)
            {
                Console.WriteLine($"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nStudent ID: {stdId[i]}\nName: {stdName[i]}");
                double finalMark = 0;

                // picks each student's detailed marks
                for (int j = 0; j < stdMarks.GetLength(1); j++)
                {
                    finalMark += stdMarks[i, j] * weight[j];
                    Console.WriteLine($"\t{javaCourseContent[j]} = {stdMarks[i, j]}");
                }
                Console.WriteLine($"\n\tYour Final Mark is : {finalMark:F2}");
                finalMarks[i] = finalMark;
            }

            // the avg of the class, highest and lowest marks of the class
            double add = 0;
            double highestMark = 0;
            double lowestMark = 100;
            int highestMarkLocation = 0;
            int lowestMarkLocation = 0;

            for (int i = 0; i < finalMarks.Length; i++)
            {

                if (finalMarks[i] > highestMark)
                {
                    highestMark = finalMarks[i];
                    highestMarkLocation = i;
                }

                if (finalMarks[i] < lowestMark)
                {
                    lowestMark = finalMarks[i];
                    lowestMarkLocation = i;
                }

                add += finalMarks[i];
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine($"\nThe Class Average is {add / finalMarks.Length:F2}");
            Console.WriteLine($"\tThe Highest Mark is {stdName[highestMarkLocation]} with {highestMark}");
            Console.WriteLine($"\tThe Lowest Mark is {stdName[lowestMarkLocation]} with {lowestMark}");

        }
    }
}
