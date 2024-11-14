using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace pet_hotel.Models
{
    public enum PetBreedType : byte
    {
        Bulldog
    }
    public enum PetColorType : byte
    {

         black 
    }
    public class Pet {

        public int id {get; set;}
         public string name {get; set;}
         [ForeignKey("petOwnerid")]
          public int petOwnerid  {get; set;}
          [JsonConverter(typeof(JsonStringEnumConverter))] 
         public int checkedInAt {get; set;}

         public string PetBreedType {get; set;}

         public string PetColorType {get; set;}


    }
}
