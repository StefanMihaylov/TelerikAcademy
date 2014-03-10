﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town name cannot be null");
                }
                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendFormat("; Town={0}", this.Town);
            return result.ToString();
        }
    }
}
