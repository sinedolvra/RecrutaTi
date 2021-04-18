using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecrutaTi.Domain.Entities;
using RecrutaTi.Domain.Entities.ValueObjects;
using RecrutaTi.Domain.Enums;
using RecrutaTi.Repository;

namespace RecrutaTi.Application.Controllers
{
    [ApiController]
    [Route("/api/v1/companies")]
    public class CompanyController : Controller
    {
        public readonly CompanyRepository _repository;
        public CompanyController(CompanyRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet()]
        public IActionResult Index()
        {
            try
            {
                var company = BuildCompany();
                _repository.Save(company);
                return Ok(company);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
            
        }

        private Company BuildCompany()
        {
            var socialNetworkAddress = new SocialNetWorkAddress()
            {
                SocialNetWork = SocialNetWork.Instagram,
                Uri = new Uri("https://instagram.com/denisolvra")
            };
            var address = new Address()
            {
                State = "RJ",
                Cep = "22230060",
                City = "Rio de Janeiro",
                Complement = "apto 200",
                Number = "88",
                Street = "Marques de Leitão"
            };
            
            var company = new Company()
            {
                Name = "Sined Developers",
                Description = "Empresa do Vale do Silício",
                Address = address,
                SocialNetWorks = new List<SocialNetWorkAddress>(){socialNetworkAddress}
            };
            return company;
        }
    }
}