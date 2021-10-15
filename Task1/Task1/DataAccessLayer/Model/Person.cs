using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Task1.DBLayer.Model
{


    [Serializable]
    public partial class Person
    {
        public Person()
        {
            
        }
        
        [JsonProperty("id")]
        public int PkPersonId { get; set; }
        [JsonProperty("name")]
        public string PersonName { get; set; }
        [JsonIgnore]
        public int? FkParentPersonId { get; set; }
        [JsonIgnore]
        public  Person FkParentPerson { get; set; }

        [JsonProperty("child")]
        public List<Person> InverseFkParentPerson { get; set; }

        public bool ShouldSerializeInverseFkParentPerson()
        {
            return (InverseFkParentPerson.Count != 0);
        }
    }
}
