using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace BreederBot.Models
{
    [XmlRoot(ElementName = "DinoBaseStat")]
    public class DinoBaseStat
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Health")]
        public string Health { get; set; }
        [XmlElement(ElementName = "Stamina")]
        public string Stamina { get; set; }
        [XmlElement(ElementName = "Oxygen")]
        public string Oxygen { get; set; }
        [XmlElement(ElementName = "Food")]
        public string Food { get; set; }
        [XmlElement(ElementName = "Weight")]
        public string Weight { get; set; }
        [XmlElement(ElementName = "MeleeDMG")]
        public string MeleeDMG { get; set; }
        [XmlElement(ElementName = "MovementSpeed")]
        public string MovementSpeed { get; set; }
        [XmlElement(ElementName = "HealthINC")]
        public string HealthINC { get; set; }
        [XmlElement(ElementName = "StaminaINC")]
        public string StaminaINC { get; set; }
        [XmlElement(ElementName = "OxygenINC")]
        public string OxygenINC { get; set; }
        [XmlElement(ElementName = "FoodINC")]
        public string FoodINC { get; set; }
        [XmlElement(ElementName = "WeightINC")]
        public string WeightINC { get; set; }
        [XmlElement(ElementName = "MeleeDMGINC")]
        public string MeleeDMGINC { get; set; }
        [XmlElement(ElementName = "MovementSpeedINC")]
        public string MovementSpeedINC { get; set; }
    }

    [XmlRoot(ElementName = "DinoBaseStats")]
    public class DinoBaseStats
    {
        [XmlElement(ElementName = "DinoBaseStat")]
        public DinoBaseStat Dino { get; set; }
    }


}
