using System;
namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                // switch statment with when...
                switch (Average)
                {
                    // we dont need break statment when we return
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }

            }
        }
        public double Sum;
        public int Count;
        public Statistics()
        {
            Count = 0;
            Sum = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void Add(double number)
        {
            // we now have a sum and a count to calculate the average
            Sum += number;
            Count += 1;

            // to compare grade in the index and result.High
            //and store the highest grade
            High = Math.Max(number, High);
            //to compare and store the min value i minGrade
            Low = Math.Min(number, Low);
        }

    }
}