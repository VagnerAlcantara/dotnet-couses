using BookStore.Validator;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookStore.ViewModels
{
    public class EditorBookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome inválido")]
        [Display(Name = "Nome do livro")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "ISBN inválido")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Data de lançamento inválida")]
        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria")]
        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }
        public SelectList CategoriaOptions { get; set; }

        [CheckAgeValidator]
        [DataType(DataType.Date)]
        public DateTime Age { get; set; }
    }
}