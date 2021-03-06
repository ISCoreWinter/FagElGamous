using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public class PhotoUpload
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload")]
        public IFormFile FormFile { get; set; }

        public int? BurialId { get; set; }
        public string Description { get; set; }
    }
}
