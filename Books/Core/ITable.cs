namespace AS.Books
{
    public interface ITable
    {
        public ITableLeg[] Legs { get; }
    }



    public interface ITableLeg
    {
        public float Height { get; }
    }
}