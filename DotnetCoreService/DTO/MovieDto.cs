﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotnetCoreService.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }
        public int NumberInStock { get; set; }

        public GenreDto GenreDto { get; set; }
    }
}
