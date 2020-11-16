using Core.Domain.Common;
using System.Collections.Generic;

namespace Core.Domain.Entities
{
    public class Station : Auditable<int>
    {
        public string Name { get; set; }
        public int FromPrevious { get; set; }
        public int ToNext { get; set; }

        public static IEnumerable<Station> MRT_Line1()
        {

            return new List<Station>
            {
                new Station { Name = "Baclaran", ID = 1, FromPrevious = 0, ToNext = 1},
                new Station { Name = "EDSA", ID = 2, FromPrevious  = 1, ToNext = 1},
                new Station { Name = "Libertad", ID = 3, FromPrevious = 1, ToNext = 0},
                new Station { Name = "Gil Puyat", ID = 4, FromPrevious = 0, ToNext = 1},
                new Station { Name = "V. Cruz", ID = 5, FromPrevious =  1, ToNext = 1},
                new Station { Name = "Quirino", ID = 6, FromPrevious = 1, ToNext = 1},
                new Station { Name = "P. Gil", ID = 7, FromPrevious = 1, ToNext = 1},
                new Station { Name = "United Nations", ID = 8, FromPrevious = 1, ToNext = 1},
                new Station { Name = "C. Terminal", ID = 9, FromPrevious = 1, ToNext = 1},
                new Station { Name = "Carriedo", ID = 10, FromPrevious = 1, ToNext = 0},
                new Station { Name = "D. Jose", ID = 11, FromPrevious = 0, ToNext = 1},
                new Station { Name = "Bambang", ID = 12, FromPrevious = 1, ToNext = 1},
                new Station { Name = "Tayuman", ID = 13, FromPrevious = 1, ToNext = 0},
                new Station { Name = "Blumentritt", ID = 14, FromPrevious = 0, ToNext = 1},
                new Station { Name = "A. Santos", ID = 15, FromPrevious = 1, ToNext = 1},
                new Station { Name = "R. Papa", ID = 16, FromPrevious = 1, ToNext = 1},
                new Station { Name = "5th Ave.", ID = 17, FromPrevious = 1, ToNext = 1},
                new Station { Name = "Monumento", ID = 18, FromPrevious = 1, ToNext = 2},
                new Station { Name = "Balintawak", ID = 19, FromPrevious = 2, ToNext = 2},
                new Station { Name = "Roosevelt", ID = 20, FromPrevious = 2, ToNext = 0},
            };
        }


    }
}
