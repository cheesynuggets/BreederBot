using BreederBot.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreederBot.Models;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace BreederBot
{
    public class BaseStatCalculator
    {
        List<DinoBaseStat> BaseStats;
        XmlSerializer _xmlSerializer;
        private readonly string _dir;
        string DemoBaseStat =
@"<DinoBaseStats>
    <DinoBaseStat>
        <Name>Niggersaurs</Name>
        <Health>100</Health>
        <Stamina>100</Stamina>
        <Oxygen>100</Oxygen>
        <Food>100</Food>
        <Weight>100</Weight>
        <MeleeDMG>100</MeleeDMG>
        <MovementSpeed>100</MovementSpeed>
        <HealthINC>100</HealthINC>
        <StaminaINC>100</StaminaINC>
        <OxygenINC>100</OxygenINC>
        <FoodINC>100</FoodINC>
        <WeightINC>100</WeightINC>
        <MeleeDMGINC>100</MeleeDMGINC>
        <MovementSpeedINC>100</MovementSpeedINC>
    </DinoBaseStat>
</DinoBaseStats>";

        public BaseStatCalculator()
        {
            BaseStats = new List<DinoBaseStat>();
            _xmlSerializer = new XmlSerializer(typeof(DinoBaseStat));
            _dir = Directory.GetCurrentDirectory();
            loadBaseStats();
        }


        void loadBaseStats()
        {
            if(!Directory.Exists(_dir + "/config"))
            {
                Directory.CreateDirectory(_dir + "/config");
            }

            if(!File.Exists(_dir + "/config/basestats.xml"))
            {
                File.Create(_dir + "/config/basestats.xml");
                File.WriteAllText(_dir + "/config/basestats.xml", DemoBaseStat);
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(_dir + "/config/basestats.xml");
            XmlElement root = xmlDocument.DocumentElement;

            XmlNodeList nodes = root.SelectNodes("DinoBaseStat");

            foreach (var node in nodes)
            {
                using (TextReader reader = new StringReader((node as XmlNode).OuterXml))
                {
                    DinoBaseStat obj = (DinoBaseStat)_xmlSerializer.Deserialize(reader);

                    BaseStats.Add(obj);
                    Console.WriteLine(BaseStats.Count);
                }    
            }
        }
    }
}
