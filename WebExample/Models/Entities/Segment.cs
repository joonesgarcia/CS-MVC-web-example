﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WebExample.Models
{
    public class Segment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalSpend { get; set; }

        public ICollection<SpendsRecord> Spends { get; set; } = new List<SpendsRecord>();

        public Segment()
        {
        }
        public Segment(int id, string name, double initialSpend)
        {
            Id = id;
            Name = name;
            TotalSpend = initialSpend;
        }
        public double TotalSpendsDated(DateTime initial, DateTime final)
        {
            return Spends.Where(s => 
                        Name == s.Segment.Name 
                        && s.Date >= initial 
                        && s.Date <= final).Sum(s => s.Amount);
        }
        public double TotalSpendsUpdate() => TotalSpend = Spends.Where(s => Id == s.SegmentId).Sum(s => s.Amount);
    }
}
