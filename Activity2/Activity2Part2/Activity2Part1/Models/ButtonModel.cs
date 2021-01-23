using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity2Part1.Models
{
    public class ButtonModel
    {
        public ButtonModel(bool State) {
            this.State = State;
        }
        
        public bool State { get; set; }

    }
}