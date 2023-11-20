using System.Linq;

namespace AS.Books
{
    public class Table : ITable
    {
        public ITableLeg[] Legs { get; }


        public Table(params ITableLeg[] legs) {
            Legs = legs;
        }
    }



    public class TableLeg : ITableLeg
    {
        public float Height { get; }


        public TableLeg(float height) {
            Height = height;
        }
    }



    public class CompositeTableLeg : ITableLeg
    {
        public ITableLeg[] Legs { get; }

        public float Height => Legs.Sum(v => v.Height);


        public CompositeTableLeg(params ITableLeg[] legs) {
            Legs = legs;
        }
    }
}