﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public int Age { get; set; }

        public string Position { get; set; }
        
        public Guid CompanyId { get; set; }
        
        public Company Company { get; set; }
    }
}
