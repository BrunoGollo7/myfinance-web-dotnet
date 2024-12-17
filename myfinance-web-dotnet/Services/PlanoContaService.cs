using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;

namespace myfinance_web_dotnet.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private MyFinanceDbContext _myFinanceDbContext;
        public PlanoContaService(MyFinanceDbContext myFinanceDbContext)
        {
            _myFinanceDbContext = myFinanceDbContext;
        }
        public void Excluir(int id)
        {
            var dbSet = _myFinanceDbContext.PlanoConta;
            var item = RetornarRegistro(id);
            dbSet.Attach(item);
            dbSet.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public List<PlanoConta> ListarRegistros()
        {
            var lista = _myFinanceDbContext.PlanoConta.ToList();
            return lista;
        }

        public PlanoConta RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First();
            return item;
        }

        public void Salvar(PlanoConta item)
        {
            var dbSet = _myFinanceDbContext.PlanoConta;
            if(item.Id == null)
            {
                dbSet.Add(item);
            }else
            {
                dbSet.Attach(item);
                _myFinanceDbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();

            
            
        }
    }
}