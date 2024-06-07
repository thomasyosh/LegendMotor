﻿using System.Xml.Linq;

namespace LegendMotor.Api.Dtos
{
    public class BinLocationSpareDto
    {
                public string SpareId { get; set; }
                public string Name { get; set; }
                public string Description { get; set; }
                public string Category { get; set; }
                public int Weight { get; set; }
                public int Stock { get; set; }
                public int ROL { get; set; }

                public int DL { get; set; }
                public int Price {  get; set; }



    }
}
