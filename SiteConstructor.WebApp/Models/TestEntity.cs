using Microsoft.AspNetCore.Mvc;
using SiteConstructor.Framework.Models;
using SiteConstructor.GenericControllers;
using SiteConstructor.GenericControllers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SiteConstructor.WebApp.Models
{
    [Bind("Id", "Name", "Age")]
    public class TestEntity : IEntityWithId<int>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }
    }

    [GeneratedController(Controller = typeof(GenericApiController<>), Name = "Test2")]
    public class TestEntity2 : IEntityWithId<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //[GeneratedController(Controller = typeof(G2Controller<>))]
    //public class TestEntity3 : IEntityWithId<int>
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
