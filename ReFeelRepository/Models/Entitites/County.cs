﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ReFeelRepository.Models.Entitites
{
    public partial class County
    {
        public County()
        {
            City = new HashSet<City>();
        }

        public int CountyId { get; set; }
        public string Name { get; set; }
        public int? ZipCodeId { get; set; }

        public virtual ZipCode ZipCode { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}