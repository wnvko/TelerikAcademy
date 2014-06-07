using System;

public class SimpleMathExam : Exam
{
    public const int MaxProblemCountPerExam = 10;
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            problemsSolved = 0;
        }
        if (problemsSolved > MaxProblemCountPerExam)
        {
            problemsSolved = MaxProblemCountPerExam;
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: some problems solved.");
        }
        else
        {
            return new ExamResult(6, 2, 6, "Excelent result: most problems solved.");
        }
    }
}