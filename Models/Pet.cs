using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace pet_hotel
{
    public enum PetBreedType : byte
    {
        Bulldog
    }
    public enum PetColorType : byte
    {

         black 
    }
    

        public class Pet
    {

        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("petOwner")]
        public int petOwnerid { get; set; }
        public PetOwner petOwner { get; set; }
        public int checkedInAt { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]

        public PetBreedType BreedType { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType ColorType { get; set; }
    }
    }

