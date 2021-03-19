using System;
using System.ComponentModel.DataAnnotations;

namespace week_2.requestModel
{
    public class RequestModel
    {   
        [Required(ErrorMessage="Id Boş Bırakılamaz")]
        public int Id {get;set;}
        [StringLength(140,ErrorMessage="Baslık maksimum 140 karakter olabilir.")]
        public string Subject{get;set;}

        public string TextContext{get;set;}
        public DateTime Date{get;set;}
        
        [Range(1,60 ,ErrorMessage="ReadTime 1-60 dakika arası olabilir")]
        public int readTime {get;set;}


    }
}