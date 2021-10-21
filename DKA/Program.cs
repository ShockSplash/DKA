using System;
using System.Threading.Tasks;
using DKA.CustomExceptions;
using DKA.Enums;

namespace DKA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alphabet:0, 1\n Input the word!");
            string word = Console.ReadLine();

            CheckAlphabet(word);

            string outputWord = "";

            int taskC = 0;
            
            States currentState = States.S1;

            Console.Write("S1");

            for (int i = 0; i < word.Length; i++)
            {
                if (currentState == States.S1)
                {
                    if (word[i] == '1')
                    {
                        Console.Write("--->S4(Y3)");
                        currentState = States.S4;
                        outputWord += Outputs.Y3;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        Console.Write("--->S2(Y2)");
                        currentState = States.S2;
                        outputWord += Outputs.Y2;
                        taskC++;
                        continue;
                    }
                }

                if (currentState == States.S2)
                {
                    if (word[i] == '1')
                    {
                        Console.Write("--->S1(Y2)");
                        currentState = States.S1;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        Console.Write("--->S3(Y3)");
                        currentState = States.S3;
                        outputWord += Outputs.Y3;
                        continue;
                    }
                }

                if (currentState == States.S3)
                {
                    if (word[i] == '1')
                    {
                        Console.Write("--->S5(Y3)");
                        currentState = States.S5;
                        outputWord += Outputs.Y3;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        Console.Write("--->S2(Y2)");
                        currentState = States.S2;
                        outputWord += Outputs.Y2;
                        continue;
                    }
                }

                if (currentState == States.S4)
                {
                    if (word[i] == '1')
                    {
                        Console.Write("--->S3(Y2)");
                        currentState = States.S3;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        Console.Write("--->S5(Y3)");
                        currentState = States.S5;
                        outputWord += Outputs.Y3;
                        continue;
                    }
                }

                if (currentState == States.S5)
                {
                    if (word[i] == '1')
                    {
                        Console.Write("--->S4(Y2)");
                        currentState = States.S4;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        Console.Write("--->S6(Y3)");
                        currentState = States.S6;
                        outputWord += Outputs.Y3;
                        continue;
                    }
                }

                if (currentState == States.S6)
                {
                    if (word[i] == '1')
                    {
                        Console.Write("--->S5(Y2)");
                        currentState = States.S5;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        Console.Write("--->S7(Y3)");
                        currentState = States.S7;
                        outputWord += Outputs.Y3;
                        continue;
                    }
                }

                if (currentState == States.S7)
                {
                    if (word[i] == '1')
                    {
                        Console.Write("--->S6(Y2)");
                        currentState = States.S6;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        Console.Write("--->S7(Y2)");
                        currentState = States.S7;
                        outputWord += Outputs.Y2;
                    }
                }
            }

            Console.WriteLine();

            Console.WriteLine($"State machine in state {currentState} and output: {outputWord}");

            Console.WriteLine("----------------------------------------------------------------------------------------");

            Console.WriteLine($"Task A: count of Y2: {TaskA(outputWord)}");

            Console.WriteLine($"Task B: count of y1y2y2: {TaskB(outputWord)}");

            Console.WriteLine($"Task C: count of State s1 and output S2: {taskC}");

            Console.WriteLine($"Task D: in 10,20 or 30 tact can occur Y2: {TaskD(outputWord)}");

            Console.WriteLine($"Task E: max length of Y2: {TaskE(outputWord)}");

            int resultF = TaskF(word);

            if (resultF == -1)
            {
                Console.WriteLine("Task F:State machine did not stay in S2 and did not output Y3 together.");
            }
            else
            {
                Console.WriteLine($"Task F: tact when state machine in State S2 and output Y3: {resultF}");
            }

            Console.WriteLine($"Task G: visited all states and have Y2 and Y3: {TaskG(word)}");

            LastTask(outputWord);

            var bo = 1;
            var res = Dima(out bo);
            Console.WriteLine(bo);
        }

        private static void CheckAlphabet(string word)
        {
            foreach (var symbol in word)
            {
                if (symbol != '0' && symbol != '1')
                {
                    throw new AlphabetException("Invalid alphabet!");
                }
            }
        }

        private static int TaskA(string outputWord)
        {
            int count = 0;

            for (int i = 0; i < outputWord.Length - 1; i++)
            {
                if (outputWord[i] == 'Y' && outputWord[i + 1] == '2')
                {
                    count++;
                }
            }

            return count;
        }

        //count oof y1y2y2
        private static int TaskB(string outputWord)
        {
            int count = 0;

            for (int i = 0; i < outputWord.Length-5; i++)
            {
                if (outputWord[i] == 'Y' && outputWord[i + 1] == '2' && outputWord[i + 2] == 'Y' &&
                    outputWord[i + 3] == '3' && outputWord[i + 4] == 'Y' && outputWord[i + 5] == '3')
                    count++;
            }

            return count;
        }

        private static bool TaskD(string outputWord)
        {
            if (outputWord.Length >= 20)
            {
                if (outputWord[18] == 'Y' && outputWord[19] == '2')
                    return true;

                if (outputWord.Length >= 40)
                {
                    if (outputWord[38] == 'Y' && outputWord[39] == '2')
                        return true;

                    if (outputWord.Length >= 60)
                    {
                        if (outputWord[58] == 'Y' && outputWord[59] == '2')
                            return true;
                    }
                }
            }

            return false;
        }

        private static int TaskE(string outputWord)
        {
            int cuurentLenght = 0;
            int maxLenght = 0;

            for (int i = 0; i < outputWord.Length-1; i+=2)
            {
                if (outputWord[i] == 'Y' && outputWord[i + 1] == '2')
                {
                    cuurentLenght++;
                    if (cuurentLenght > maxLenght)
                        maxLenght = cuurentLenght;
                }
                else
                {
                    cuurentLenght = 0;
                }
            }

            return maxLenght;
        }

        private static int TaskF(string word)
        {
            string outputWord = "";

            int counter = 0;
            
            States currentState = States.S1;
            
            for (int i = 0; i < word.Length; i++)
            {
                if (currentState == States.S1)
                {
                    if (word[i] == '1')
                    {
                        currentState = States.S4;
                        outputWord += Outputs.Y3;
                        counter++;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S2;
                        outputWord += Outputs.Y2;
                        counter++;
                        continue;
                    }
                }

                if (currentState == States.S2)
                {
                    if (word[i] == '1')
                    {
                        currentState = States.S1;
                        outputWord += Outputs.Y2;
                        counter++;
                        continue;
                    }

                    if (word[i] == '0')
                    { 
                        currentState = States.S3;
                        outputWord += Outputs.Y3;
                        counter++;
                        break;
                    }
                }

                if (currentState == States.S3)
                {
                    if (word[i] == '1')
                    {
                        currentState = States.S5;
                        outputWord += Outputs.Y3;
                        counter++;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S2;
                        outputWord += Outputs.Y2;
                        counter++;
                        continue;
                    }
                }

                if (currentState == States.S4)
                {
                    if (word[i] == '1')
                    {
                        currentState = States.S3;
                        outputWord += Outputs.Y2;
                        counter++;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S5;
                        outputWord += Outputs.Y3;
                        counter++;
                        continue;
                    }
                }

                if (currentState == States.S5)
                {
                    if (word[i] == '1')
                    {
                        currentState = States.S4;
                        outputWord += Outputs.Y2;
                        counter++;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S6;
                        outputWord += Outputs.Y3;
                        counter++;
                        continue;
                    }
                }

                if (currentState == States.S6)
                {
                    if (word[i] == '1')
                    {
                        currentState = States.S5;
                        outputWord += Outputs.Y2;
                        counter++;
                        continue;
                    }

                    if (word[i] == '0')
                    { 
                        currentState = States.S7;
                        outputWord += Outputs.Y3;
                        counter++;
                        continue;
                    }
                }

                if (currentState == States.S7)
                {
                    if (word[i] == '1')
                    {
                        currentState = States.S6;
                        outputWord += Outputs.Y2;
                        counter++;
                        continue;
                    }

                    if (word[i] == '0')
                    { 
                        currentState = States.S7;
                        outputWord += Outputs.Y2;
                        counter++;
                    }
                }
            }

            if (counter == 0)
                return -1;

            return counter;
        }

        private static bool TaskG(string word)
        {
            string outputWord = "";

            bool[] states = new bool[7];

            States currentState = States.S1;

            for (int i = 0; i < word.Length; i++)
            {
                if (currentState == States.S1)
                {
                    states[0] = true;
                    if (word[i] == '1')
                    {
                        currentState = States.S4;
                        outputWord += Outputs.Y3;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S2;
                        outputWord += Outputs.Y2;
                        continue;
                    }
                }

                if (currentState == States.S2)
                {
                    states[1] = true;
                    if (word[i] == '1')
                    {
                        currentState = States.S1;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S3;
                        outputWord += Outputs.Y3;
                        continue;
                    }
                }

                if (currentState == States.S3)
                {
                    states[2] = true;
                    if (word[i] == '1')
                    {
                        currentState = States.S5;
                        outputWord += Outputs.Y3;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S2;
                        outputWord += Outputs.Y2;
                        continue;
                    }
                }

                if (currentState == States.S4)
                {
                    states[3] = true;
                    if (word[i] == '1')
                    {
                        currentState = States.S3;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S5;
                        outputWord += Outputs.Y3;
                        continue;
                    }
                }

                if (currentState == States.S5)
                {
                    states[4] = true;
                    if (word[i] == '1')
                    {
                        currentState = States.S4;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S6;
                        outputWord += Outputs.Y3;
                        continue;
                    }
                }

                if (currentState == States.S6)
                {
                    states[5] = true;
                    if (word[i] == '1')
                    {
                        currentState = States.S5;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S7;
                        outputWord += Outputs.Y3;
                        continue;
                    }
                }

                if (currentState == States.S7)
                {
                    states[6] = true;
                    if (word[i] == '1')
                    {
                        currentState = States.S6;
                        outputWord += Outputs.Y2;
                        continue;
                    }

                    if (word[i] == '0')
                    {
                        currentState = States.S7;
                        outputWord += Outputs.Y2;
                    }
                }
            }
            
            foreach (var boolState in states)
            {
                if (!boolState)
                    return false;
            }

            if (outputWord.Contains("Y2") && outputWord.Contains("Y3"))
            {
                return true;
            }

            return false;
        }

        private static void LastTask(string outputWord)
        {
            int countY2 = 0;
            int countY3 = 0;

            for (int i = 0; i < outputWord.Length - 1; i+=2)
            {
                if (outputWord[i] == 'Y' && outputWord[i + 1] == '2')
                    countY2++;
                if (outputWord[i] == 'Y' && outputWord[i + 1] == '3')
                    countY3++;
            }

            Console.WriteLine($"Task H: In output: count of Y2: {countY2}, count of Y3: {countY3}");
        }

        private static int Dima(out int a)
        {
             a = 15;
             return 2;
        }
    }
}
