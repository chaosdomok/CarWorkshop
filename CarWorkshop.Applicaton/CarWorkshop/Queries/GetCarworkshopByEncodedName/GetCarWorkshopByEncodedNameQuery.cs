﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Applicaton.CarWorkshop.Queries.GetCarworkshopByEncodedName
{
    public class GetCarWorkshopByEncodedNameQuery : IRequest<CarWorkshopDto>
    {
        public string EncodedName { get; set; }

        public GetCarWorkshopByEncodedNameQuery(string encodedName) 
        {
            EncodedName = encodedName;
        }
    }
}
