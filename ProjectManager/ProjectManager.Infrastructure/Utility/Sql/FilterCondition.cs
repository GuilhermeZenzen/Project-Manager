namespace ProjectManager.Infrastructure.Utility.Sql
{
    public class FilterCondition
    {
        public string Condition { get; }
        public object[] Inputs { get; }

        public FilterCondition(string condition, params object[] inputs) => (Condition, Inputs) = (condition, inputs);
    }
}
