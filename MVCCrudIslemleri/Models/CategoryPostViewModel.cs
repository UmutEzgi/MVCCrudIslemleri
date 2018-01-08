using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrudIslemleri.Models
{
    public class CategoryPostViewModel
    {
        [Required(ErrorMessage ="Kategori alanı boş geçilemez")]
        [StringLength(50,ErrorMessage ="50 karakter olabilir" )]
        public string Name { get; set; }

    }
}