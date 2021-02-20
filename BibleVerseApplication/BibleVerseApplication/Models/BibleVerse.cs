/**
 *        file: Models/BibleVerseController.cs
 * description: controller for our applicaiton
 *      author: Richard Williamson
 *       notes: none
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Models
{
    public class BibleVerse
    {
        [Required]
        public string Testament { get; set; }

        [Required]
        public string Book { get; set; }

        [Required]
        public string Chapter { get; set; }

        [Required]
        public string Verse { get; set; }

        [Required]
        public string Text { get; set; }

        public enum Testaments
        {
            New,
            Old,
        }

    }
}