using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace lab17_18
{
    public abstract class Section
    {
        public string AgeRating { get; set; }
        public Section(string ageRating) => AgeRating = ageRating;
        public abstract int GetAge();

    }
    public class E: Section
    {
        public E() : base("Для всех") { }
        public override int GetAge() => 7;
    }

    public class T : Section
    {
        public T() : base("Для подростков") { }
        public override int GetAge() => 16;
    }

    public class  А: Section
    {
        public А() : base("Для взрослых") { }
        public override int GetAge() => 18;
    }
    public abstract class SectionDecorator : Section
    {
        protected readonly Section section;
        protected SectionDecorator(string n, Section section) : base(n) => this.section = section;
    }
    public class Teen : SectionDecorator
    {
        public Teen(Section section) : base(section.AgeRating, section) { }
        public override int GetAge() =>  17;

    }
    public class Adult : SectionDecorator
    {
        public Adult(Section section) : base(section.AgeRating, section) { }
        public override int GetAge() => 50;
    }

}
