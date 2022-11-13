using better.Models;
using better.Models.ModelsDTO;
using better.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace better.services.Implementations
{
    public class ModuleService:IModuleService
    {
        private readonly CalculatorContext context;

        public ModuleService(CalculatorContext context)
        {
            this.context = context;
        }
        public OperationSuccesDTO<Module> AddModule(Module module)
        {
            context.Module.Add(module);
            context.SaveChanges(); //nie wiem czy SaveChangesAsy() nie było by lepsze ale co ja tam wiem 
            return new OperationSuccesDTO<Module> { Message = "Sukces" };
        }

        public Module GetModuleByName(string moduleName)
        {
            return context.Module.Where(module => module.Name == moduleName).FirstOrDefault();
        }

        public OperationSuccesDTO<List<Module>> GetModules()
        {
            List<Module> modules =context.Module.ToList();
            return new OperationSuccesDTO<List<Module>>
            {
                Message = "Sukces",
                Result = modules
            };
        }

        public OperationSuccesDTO<Module> DeleteModule(string name)
        {
            var module = context.Module.Where(m => m.Name == name).FirstOrDefault();
            context.Module.Remove(module);
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Sukces" };
        }

        public OperationSuccesDTO<Module> UpdateModule(Module module)
        {
            var mod = context.Module.Where(m => m.Name == module.Name).FirstOrDefault();
            mod.Name = module.Name;
            mod.Price = module.Price;
            mod.Weight = module.Weight;
            mod.AssemblyTime = module.AssemblyTime;
            mod.Code = module.Code;
            mod.Description = module.Description;
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Sukces" };
        }

       
    }
}