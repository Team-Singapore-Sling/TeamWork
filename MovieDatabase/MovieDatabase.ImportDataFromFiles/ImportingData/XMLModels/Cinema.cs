﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace MovieDatabase.ImportDataFromFiles.ImportingData.XMLModels
{
    [XmlRoot("cinema")]
    public class Cinema
    {
        [XmlElement("movie")]
        public List<Movie> Movies { get; set; }
    }
}
