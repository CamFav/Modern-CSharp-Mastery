/*
 * ============================================
 * ARRAYS AND LOOPS - STUDENT GRADES REPORT
 * ============================================
 * CONTEXT: Classroom grading system with exams + extra credit.
 * OBJECTIVE: Process student score data, compute averages and letter grades, and print a report.
 * TECHNIQUES: Comparison between Basic C# (Parallel Arrays + Loops) and Modern C# (Objects + LINQ).
 */

namespace StudentGrades
{
    // ================================
    // Student Class
    // ================================
    // Represents a student and their assignment scores.
    // Includes behavior to convert a numeric grade into a letter grade.
    class Student
    {
        public string Name { get; set; } = string.Empty;
        public int[] Scores { get; set; } = Array.Empty<int>();

        // Convert a numeric grade to a letter grade based on a fixed grading scale.
        public string GetLetterGrade(decimal grade)
        {
            // Letter grade thresholds
            if (grade >= 97) return "A+";
            if (grade >= 93) return "A";
            if (grade >= 90) return "A-";
            if (grade >= 87) return "B+";
            if (grade >= 83) return "B";
            if (grade >= 80) return "B-";
            if (grade >= 77) return "C+";
            if (grade >= 73) return "C";
            if (grade >= 70) return "C-";
            if (grade >= 67) return "D+";
            if (grade >= 63) return "D";
            if (grade >= 60) return "D-";
            return "F";
        }
    }

    // ================================
    // Program Entry Point
    // ================================
    class Program
    {
        // Global rule: number of exam assignments (the rest are extra credit)
        private const int ExamAssignments = 5;

        static void Main()
        {
            Console.WriteLine("-- Basic C# --\n");
            RunBasicCSharp();

            Console.WriteLine("\n-- Modern C# --\n");
            RunModernCSharp();

            ExitPrompt();
        }

        // Pause the console so results remain visible.
        private static void ExitPrompt()
        {
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }

        // ================================
        // Basic C# Implementation (Arrays & Loops)
        // ================================
        // Uses parallel arrays and control flow (if/else + foreach) to:
        // - map names to score arrays
        // - split exam vs extra credit using a counter
        // - calculate averages and letter grades
        static void RunBasicCSharp()
        {
            int examAssignments = 5;

            string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

            int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
            int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
            int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
            int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

            int[] studentScores = new int[10];

            string currentStudentLetterGrade = "";

            // Display the header row for scores/grades
            Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\n");

            /*
             * The outer foreach loop is used to:
             * - iterate through student names
             * - assign a student's grades to the studentScores array
             * - sum exam vs extra credit (inner foreach loop)
             * - calculate numeric and letter grade
             * - write the score report information
             */
            foreach (string name in studentNames)
            {
                string currentStudent = name;

                // Map student name -> corresponding score array
                if (currentStudent == "Sophia")
                    studentScores = sophiaScores;
                else if (currentStudent == "Andrew")
                    studentScores = andrewScores;
                else if (currentStudent == "Emma")
                    studentScores = emmaScores;
                else if (currentStudent == "Logan")
                    studentScores = loganScores;

                int sumExamScores = 0;
                int sumExtraCreditScores = 0;
                int gradedAssignments = 0;

                /*
                 * The inner foreach loop sums assignment scores.
                 * Extra credit assignments are worth 10% of an exam score.
                 */
                foreach (int score in studentScores)
                {
                    gradedAssignments++;

                    // First N scores are exams, remaining scores are extra credit
                    if (gradedAssignments <= examAssignments)
                        sumExamScores += score;
                    else
                        sumExtraCreditScores += score;
                }

                // Exam Score (average of exams)
                decimal currentStudentExamScore =
                    (decimal)sumExamScores / examAssignments;

                // Extra credit points (10% of extra credit, spread over exams)
                decimal extraCreditPoints =
                    ((decimal)sumExtraCreditScores * 0.1m) / examAssignments;

                // Overall Grade (exams + 10% of extra credit, averaged across exams)
                decimal currentStudentGrade =
                    ((decimal)sumExamScores + ((decimal)sumExtraCreditScores * 0.1m))
                    / examAssignments;

                // Letter grade (based on overall grade)
                if (currentStudentGrade >= 97)
                    currentStudentLetterGrade = "A+";
                else if (currentStudentGrade >= 93)
                    currentStudentLetterGrade = "A";
                else if (currentStudentGrade >= 90)
                    currentStudentLetterGrade = "A-";
                else if (currentStudentGrade >= 87)
                    currentStudentLetterGrade = "B+";
                else if (currentStudentGrade >= 83)
                    currentStudentLetterGrade = "B";
                else if (currentStudentGrade >= 80)
                    currentStudentLetterGrade = "B-";
                else if (currentStudentGrade >= 77)
                    currentStudentLetterGrade = "C+";
                else if (currentStudentGrade >= 73)
                    currentStudentLetterGrade = "C";
                else if (currentStudentGrade >= 70)
                    currentStudentLetterGrade = "C-";
                else if (currentStudentGrade >= 67)
                    currentStudentLetterGrade = "D+";
                else if (currentStudentGrade >= 63)
                    currentStudentLetterGrade = "D";
                else if (currentStudentGrade >= 60)
                    currentStudentLetterGrade = "D-";
                else
                    currentStudentLetterGrade = "F";

                // Print the report line
                Console.WriteLine(
                    $"{currentStudent}\t\t{currentStudentExamScore:0.#}\t\t{currentStudentGrade:F2}\t{currentStudentLetterGrade}\t{sumExtraCreditScores} ({extraCreditPoints:F2} pts)"
                );
            }
        }

        // Header printer
        private static void PrintHeader()
        {
            Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\n");
        }

        // ================================
        // Modern C# Implementation (LINQ & List<Student>)
        // ================================
        // Uses a List<Student> + LINQ to:
        // - split exam vs extra credit using Take/Skip
        // - compute totals via Sum()
        // - reuse Student behavior for letter grade conversion
        static void RunModernCSharp()
        {
            var students = new List<Student>
            {
                new Student { Name = "Sophia", Scores = new int[] { 90, 86, 87, 98, 100, 94, 90 } },
                new Student { Name = "Andrew", Scores = new int[] { 92, 89, 81, 96, 90, 89 } },
                new Student { Name = "Emma", Scores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 } },
                new Student { Name = "Logan", Scores = new int[] { 90, 95, 87, 88, 96, 96 } },
            };

            // Display the header row for the modern report
            PrintHeader();

            foreach (var student in students)
            {
                // Sum exams and extra credit using sequence operations
                int sumExamScores = student.Scores.Take(ExamAssignments).Sum();
                int sumExtraCreditScores = student.Scores.Skip(ExamAssignments).Sum();

                // Exam Score (average of exams)
                decimal currentStudentExamScore = (decimal)sumExamScores / ExamAssignments;

                // Extra credit points (10% of extra credit, spread over exams)
                decimal extraCreditPoints = sumExtraCreditScores * 0.1m / ExamAssignments;

                // Overall Grade (exams + 10% of extra credit, averaged across exams)
                decimal currentStudentGrade =
                    (sumExamScores + ((decimal)sumExtraCreditScores * 0.1m)) / ExamAssignments;

                // Letter grade via Student behavior
                string letter = student.GetLetterGrade(currentStudentGrade);

                // Print the report line
                Console.WriteLine(
                    $"{student.Name}\t\t{currentStudentExamScore:0.#}\t\t{currentStudentGrade:F2}\t{letter}\t{sumExtraCreditScores} ({extraCreditPoints:F2} pts)"
                );
            }
        }
    }
}