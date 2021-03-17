namespace Exam.Q2.Report
{
    public interface IFormatterFactory
    {
        IFormatter GetFormatter<TFormatter>() where TFormatter : IFormatter;
    }
}