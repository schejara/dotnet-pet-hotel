using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace pet_hotel
{
    public enum PetBreedType : byte
    {
        Bulldog,
        Shepherd,
        Poodle,
        Beagle,
        Terrier,
        Boxer,
        Labrador,
        Retriever
    }
    public enum PetColorType : byte
    {

        White,
        Black,
        Golden,
        Tricolor,
        Spotted
    }


    public class Pet
    {

        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("petOwner")]
        public int petOwnerid { get; set; }
        public PetOwner petOwner { get; set; }
        public int? checkedInAt { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]

        public PetBreedType breed { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color { get; set; }
    }
}

