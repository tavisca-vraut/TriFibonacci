using System.Collections.Generic;
using System.Linq;

namespace TryFibonacci
{
    public class TrippleSumFibonacci
    {
        static List<dynamic> MissingElementAtOneOfFirstThreeIndices = new List<dynamic>()
        {
            new { sum = 3, operand1 = 2, operand2 = 1},
            new { sum = 3, operand1 = 2, operand2 = 0},
            new { sum = 3, operand1 = 1, operand2 = 0}
        };

        public static bool IsFibonacci(int[] sequence)
        {
            for (int i = 0; i < sequence.Length - 3; i++)
            {
                var expectedThirdValue = sequence[i] + sequence[i + 1] + sequence[i + 2];
                var actualThirdValue = sequence[i + 3];

                if (expectedThirdValue != actualThirdValue)
                    return false;
            }
            return true;
        }

        public static int FindMissingElement(int[] sequence)
        {
            int indexOfMissingElement = GetIndexOfMissingElement(sequence);

            if (indexOfMissingElement > 2)
                return sequence[indexOfMissingElement - 1] + sequence[indexOfMissingElement - 2] + sequence[indexOfMissingElement - 3];

            var equation = MissingElementAtOneOfFirstThreeIndices[indexOfMissingElement];

            // We know a[3] = a[0] + a[1] + a[2]
            // So,     a[0] = a[3] - a[2] - a[1]
            // and,    a[1] = a[3] - a[2] - a[0]
            // and,    a[2] = a[3] - a[1] - a[0]
            // 'MissingElementAtOneOfFirstThreeIndices' has values of (subscripts on the RHS) at index = (subscript on LHS)
            return sequence[equation.sum] - sequence[equation.operand1] - sequence[equation.operand2];
        }

        public static int FillAndCheckForTriFibonacci(int[] sequence)
        {
            int possibleFillForMissingValue = FindMissingElement(sequence);

            if (possibleFillForMissingValue <= 0)
                return -1;

            FillSequence(ref sequence, possibleFillForMissingValue);

            return IsFibonacci(sequence) == true ? possibleFillForMissingValue : -1;
        }

        private static void FillSequence(ref int[] sequence, int possibleFillForMissingValue)
        {
            var index = GetIndexOfMissingElement(sequence);
            sequence[index] = possibleFillForMissingValue;
        }

        private static int GetIndexOfMissingElement(int[] sequence)
        {
            return sequence.ToList().IndexOf(-1);
        }
    }
}
